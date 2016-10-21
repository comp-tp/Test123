using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Queue
{
    public abstract class QueueProcessorBase<T> : IQueueProcessor<T> where T : class
    {
        private readonly IQueueStorage<T> _queueStorage;
        private readonly ConcurrentQueue<T> _concurrentQueue;
        //private readonly ManualResetEvent _manualResetEvent;
        private static volatile CancellationTokenSource _cts;
        private static volatile object _activateLock = 0;
        private bool _shuttingDown;

        public abstract string QueueName { get; set; }
        public abstract void HandleError(string message);

        public QueueProcessorBase(IQueueStorage<T> queueStorage)
        {
            if (queueStorage == null)
            {
                throw new ArgumentNullException("queueStorage");
            }

            _queueStorage = queueStorage;
            _concurrentQueue = new ConcurrentQueue<T>();
        }


        /// <summary>
        /// Activates the options that have been configured on this Appender. This appender supports reconfiguration while active.
        /// </summary>
        public virtual void Start()
        {
            lock (_activateLock)
            {
                _cts = new CancellationTokenSource();
                _shuttingDown = false;
                StartAddQueueTask();
            }
        }


        public virtual void Cancel()
        {
            if(_cts != null)
                _cts.Cancel();
        }


        public virtual void Enqueue(T[] queueItems)
        {
            if (queueItems == null)
            {
                return;
            }

            foreach (var queueItem in queueItems)
            {
                if(queueItem == null)
                {
                    continue;
                }

                _concurrentQueue.Enqueue(queueItem);
            }
        }

        public virtual void Enqueue(T queueItem)
        {
            if(queueItem == null)
            {
                return;
            }

            _concurrentQueue.Enqueue(queueItem);
        }

        private void StartAddQueueTask()
        {
            if (!_shuttingDown)
            {
                Task appendTask = new Task(AddToQueueStorage, _cts.Token, TaskCreationOptions.LongRunning);
                appendTask.LogErrors(LogError).ContinueWith(x => AddToQueueStorage()).LogErrors(LogError);
                appendTask.Start();
            }
        }

        public virtual void AddToQueueStorage()
        {
            var currentInterval = 0;
            var maxInterval = 10;
            T queueItem = default(T);
            while (!_cts.IsCancellationRequested)
            {
                while (_concurrentQueue.TryDequeue(out queueItem))
                {
                    currentInterval = 0;
                    try
                    {
                        AddToQueueStorage(queueItem);
                    }
                    catch
                    {
                        // write log to event
                    }
                }
                if (currentInterval < maxInterval)
                {
                    currentInterval++;
                }
                Thread.Sleep(currentInterval * 100);
            }
            _shuttingDown = true;
            //manualResetEvent.Set();
        }

        private void  AddToQueueStorage(T item)
        {
            QueueMessage<T> message = new QueueMessage<T>(item);
            _queueStorage.CreateNewMessage(this.QueueName, message);
        }

        public virtual void LogError(string logMessage, Exception exception)
        {
            HandleError(String.Format("Message: {0}, Exception : {1}",logMessage,exception == null ? null : exception.ToString()));
        }
    }
}
