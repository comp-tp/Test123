using Accela.Infrastructure.Queue;
using Accela.Infrastructure.Storage.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.SQLServer.Queue
{
    public class SQLServerQueueStorage<T> : IQueueStorage<T> where T : class
    {
        private const int MAX_MESSAGE_COUNT_LIMITATION = 1000;
        private ISQLServerQueueStorageRepository _queueRepository;
        private IRetryPolicyConfiguration _retryPolicyConfiguration;

        public SQLServerQueueStorage(ISQLServerQueueStorageRepository queueRepository, IRetryPolicyConfiguration retryPolicyConfiguration)
        {
            if (queueRepository == null)
            {
                throw new ArgumentNullException("queueRepository");
            }

            _queueRepository = queueRepository;
            _retryPolicyConfiguration = retryPolicyConfiguration;

            if (this._retryPolicyConfiguration != null)
            {
                SQLServerStorageDbConfiguration.DeltaBackoff = this._retryPolicyConfiguration.DeltaBackoff;
                SQLServerStorageDbConfiguration.MaxAttempts = this._retryPolicyConfiguration.MaxAttempts;
                SQLServerStorageDbConfiguration.RetryMethod = this._retryPolicyConfiguration.RetryMethod;
                SQLServerStorageDbConfiguration.RetrySpans = this._retryPolicyConfiguration.RetrySpans;
            }
        }

        /// <summary>
        /// Initiates an asynchronous operation to create the queue if it does not already exist.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <returns>  A System.Threading.Tasks.Task<TResult> object of type bool that represents the asynchronous operation.</returns>
        public async Task<bool> CreateIfNotExistsAsync(string queueName)
        {
            QueueValidation.CheckQueueName(queueName);

            return await _queueRepository.CreateIfNotExistsAsync(queueName);
        }

        /// <summary>
        /// Initiates an asynchronous operation to delete the queue if it already exists.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <returns>A System.Threading.Tasks.Task<TResult> object of type bool that represents the asynchronous operation.</returns>
        public async Task<bool> DeleteIfExistsAsync(string queueName)
        {
            QueueValidation.CheckQueueName(queueName);

            return await _queueRepository.DeleteIfExistsAsync(queueName);
        }

        /// <summary>
        /// Initiates an asynchronous operation to check the existence of the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <returns>A System.Threading.Tasks.Task<TResult> object of type bool that represents the asynchronous operation.</returns>
        public async Task<bool> ExistsAsync(string queueName)
        {
            QueueValidation.CheckQueueName(queueName);

            return await _queueRepository.ExistsAsync(queueName);
        }

        /// <summary>
        /// Initiates an asynchronous operation to add a message to the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <param name="message">A Accela.Infrastructure.Queue.QueueMessage object.</param>
        /// <param name="timeToLive">A System.TimeSpan specifying the maximum time to allow the message to be in the queue, or null.</param>
        /// <returns>A System.Threading.Tasks.Task object that represents the asynchronous operation.</returns>
        public async Task CreateNewMessageAsync(string queueName, QueueMessage<T> message)
        {
            QueueValidation.CheckQueueName(queueName);

            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            if (!message.ExpirationTime.HasValue)
            {
                throw new ArgumentNullException("message.ExpirationTime");
            }

            var queueEntity = new SQLServerQueueEntity
            {
                InsertionTime = new DateTimeOffset(DateTime.UtcNow),
                ExpirationTime = message.ExpirationTime.Value,
                Content = message.AsString
            };
            await _queueRepository.InsertQueueEntityAsync(queueName, queueEntity);
        }

        /// <summary>
        /// Initiates an asynchronous operation to batch add messages to the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <param name="messages">List of Accela.Infrastructure.Queue.QueueMessage object.</param>
        /// <returns>A System.Threading.Tasks.Task object that represents the asynchronous operation.</returns>
        public async Task CreateNewMessagesAsync(string queueName, IEnumerable<QueueMessage<T>> messages)
        {
            QueueValidation.CheckQueueName(queueName);

            if (messages == null)
            {
                throw new ArgumentNullException("message");
            }

            if (!messages.Any())
            {
                return;
            }

            List<SQLServerQueueEntity> queueEntities = new List<SQLServerQueueEntity>();

            foreach (var message in messages)
            {
                if (!message.ExpirationTime.HasValue)
                {
                    throw new ArgumentNullException("message.ExpirationTime");
                }

                queueEntities.Add(new SQLServerQueueEntity
                {
                    InsertionTime = new DateTimeOffset(DateTime.UtcNow),
                    ExpirationTime = message.ExpirationTime.Value,
                    Content = message.AsString
                });
            }

            await _queueRepository.InsertQueueEntitiesAsync(queueName, queueEntities);
        }

        /// <summary>
        /// Initiates an asynchronous operation to get a single message and removing it from the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <returns>A System.Threading.Tasks.Task<TResult> object of type Accela.Infrastructure.Queue.QueueMessage that represents the asynchronous operation.</returns>
        public async Task<QueueMessage<T>> GetMessageAsync(string queueName)
        {
            return await GetMessage(queueName, true);
        }

        /// <summary>
        /// Initiates an asynchronous operation to get the specified number of messages and removing them from the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <param name="messageCount">The number of messages to retrieve.</param>
        /// <returns>A System.Threading.Tasks.Task<TResult> object that is an enumerable collection
        ///  of type Accela.Infrastructure.Queue.QueueMessage that represents the asynchronous operation.
        /// </returns>
        public async Task<IEnumerable<QueueMessage<T>>> GetMessagesAsync(string queueName, int messageCount)
        {
            return await GetMessages(queueName, messageCount, true);
        }

        /// <summary>
        /// Initiates an asynchronous operation to clear all messages from the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <returns>A System.Threading.Tasks.Task object that represents the asynchronous operation.</returns>
        public async Task ClearAsync(string queueName)
        {
            QueueValidation.CheckQueueName(queueName);

            await _queueRepository.ClearAsync(queueName);
        }

        /// <summary>
        /// Initiates an asynchronous operation to get a single message from the queue without removing it.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <returns>A System.Threading.Tasks.Task<TResult> object of type Accela.Infrastructure.Queue.QueueMessage that represents the asynchronous operation.</returns>
        public async Task<QueueMessage<T>> PeekMessageAsync(string queueName)
        {
            return await GetMessage(queueName, false);
        }

        //
        // Summary:
        //     Initiates an asynchronous operation to peek messages from the queue without removing them.
        //
        // Parameters:
        //   messageCount:
        //     The number of messages to peek.
        //
        // Returns:
        //     A System.Threading.Tasks.Task<TResult> object that is an enumerable collection
        //     of type Accela.Infrastructure.Queue.QueueMessage that represents
        //     the asynchronous operation.
        /// <summary>
        /// Initiates an asynchronous operation to peek messages from the queue without removing them.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <param name="messageCount">The number of messages to peek.</param>
        /// <returns>A System.Threading.Tasks.Task<TResult> object that is an enumerable collection
        ///     of type Accela.Infrastructure.Queue.QueueMessage that represents the asynchronous operation.
        /// </returns>
        public async Task<IEnumerable<QueueMessage<T>>> PeekMessagesAsync(string queueName, int messageCount)
        {
            return await GetMessages(queueName, messageCount, false);
        }

        private async Task<QueueMessage<T>> GetMessage(string queueName, bool deleteQueueEntity)
        {
            QueueValidation.CheckQueueName(queueName);

            var queueEntity = await _queueRepository.GetQueueEntityAsync(queueName, deleteQueueEntity);

            if (queueEntity == null)
            {
                return null;
            }

            return new QueueMessage<T>(queueEntity.Content)
            {
                Id = queueEntity.Id.ToString(),
                InsertionTime = queueEntity.InsertionTime,
                ExpirationTime = queueEntity.ExpirationTime
            };
        }

        private async Task<IEnumerable<QueueMessage<T>>> GetMessages(string queueName, int messageCount, bool deleteQueueEntities)
        {
            QueueValidation.CheckQueueName(queueName);

            if (messageCount <= 0 || messageCount > MAX_MESSAGE_COUNT_LIMITATION)
            {
                throw new ArgumentOutOfRangeException("messageCount", "The message count must be between 1 to 1000");
            }

            var queueEntities = await _queueRepository.GetQueueEntitiesAsync(queueName, messageCount, deleteQueueEntities);

            var result = new List<QueueMessage<T>>();

            if (queueEntities == null)
            {
                foreach (var queueEntity in queueEntities)
                {
                    result.Add(new QueueMessage<T>(queueEntity.Content)
                    {
                        Id = queueEntity.Id.ToString(),
                        InsertionTime = queueEntity.InsertionTime,
                        ExpirationTime = queueEntity.ExpirationTime
                    });
                }
            }

            return result;
        }
    }
}
