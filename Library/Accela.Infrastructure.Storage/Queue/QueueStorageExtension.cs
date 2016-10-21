using Accela.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Queue
{
    public static class QueueStorageExtension
    {
        /// <summary>
        /// create the queue if it does not already exist.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <returns> </returns>
        public static bool CreateIfNotExists<T>(this IQueueStorage<T> queueStorage, string queueName) where T : class
        {
            var t = Task.Run(async () =>
            {
                return await queueStorage.CreateIfNotExistsAsync(queueName);
            });

            try
            {
                t.Wait();
            }
            catch (AggregateException ae)
            {
                if (ae.InnerException != null)
                {
                    throw ae.InnerException;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            if (t.Status == TaskStatus.RanToCompletion)
            {
                return t.Result;
            }
            else
            {
                string taskException = t.Exception != null ? t.Exception.ToString() : null;
                throw new AccelaBaseException("Failed to access to QueueStorage.", "Task is not RanToCompletion while calling CreateIfNotExistsAsync()." + taskException);
            }
        }

        /// <summary>
        /// delete the queue if it already exists.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        public static bool DeleteIfExists<T>(this IQueueStorage<T> queueStorage, string queueName) where T : class
        {
            var t = Task.Run(async () =>
            {
                return await queueStorage.DeleteIfExistsAsync(queueName);
            });

            try
            {
                t.Wait();
            }
            catch (AggregateException ae)
            {
                if (ae.InnerException != null)
                {
                    throw ae.InnerException;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            if (t.Status == TaskStatus.RanToCompletion)
            {
                return t.Result;
            }
            else
            {
                string taskException = t.Exception != null ? t.Exception.ToString() : null;
                throw new AccelaBaseException("Failed to access to QueueStorage.", "Task is not RanToCompletion while calling DeleteIfExistsAsync()." + taskException);
            }
        }

        /// <summary>
        /// check the existence of the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        public static bool Exists<T>(this IQueueStorage<T> queueStorage, string queueName) where T : class
        {
            var t = Task.Run(async () =>
            {
                return await queueStorage.ExistsAsync(queueName);
            });

            try
            {
                t.Wait();
            }
            catch (AggregateException ae)
            {
                if (ae.InnerException != null)
                {
                    throw ae.InnerException;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            if (t.Status == TaskStatus.RanToCompletion)
            {
                return t.Result;
            }
            else
            {
                string taskException = t.Exception != null ? t.Exception.ToString() : null;
                throw new AccelaBaseException("Failed to access to QueueStorage.", "Task is not RanToCompletion while calling ExistsAsync()." + taskException);
            }
        }

        /// <summary>
        /// add a message to the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <param name="message">A Accela.Infrastructure.Queue.QueueMessage object.</param>
        public static void CreateNewMessage<T>(this IQueueStorage<T> queueStorage, string queueName, QueueMessage<T> message) where T : class
        {
            var t = Task.Run(async () =>
            {
                await queueStorage.CreateNewMessageAsync(queueName, message);
            });

            try
            {
                t.Wait();
            }
            catch (AggregateException ae)
            {
                if (ae.InnerException != null)
                {
                    throw ae.InnerException;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            if (t.Status == TaskStatus.RanToCompletion)
            {
                return;
            }
            else
            {
                string taskException = t.Exception != null ? t.Exception.ToString() : null;
                throw new AccelaBaseException("Failed to access to QueueStorage.", "Task is not RanToCompletion while calling CreateNewMessageAsync()." + taskException);
            }
        }

        /// <summary>
        /// batch add a message to the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <param name="messages">A list of Accela.Infrastructure.Queue.QueueMessage object.</param>
        public static void CreateNewMessages<T>(this IQueueStorage<T> queueStorage, string queueName, IEnumerable<QueueMessage<T>> messages) where T : class
        {
            var t = Task.Run(async () =>
            {
                await queueStorage.CreateNewMessagesAsync(queueName, messages);
            });

            try
            {
                t.Wait();
            }
            catch (AggregateException ae)
            {
                if (ae.InnerException != null)
                {
                    throw ae.InnerException;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            if (t.Status == TaskStatus.RanToCompletion)
            {
                return;
            }
            else
            {
                string taskException = t.Exception != null ? t.Exception.ToString() : null;
                throw new AccelaBaseException("Failed to access to QueueStorage.", "Task is not RanToCompletion while calling CreateNewMessagesAsync()." + taskException);
            }
        }

        /// <summary>
        /// get a single message and removing it from the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <returns>object of type Accela.Infrastructure.Queue.QueueMessage.</returns>
        public static QueueMessage<T> GetMessage<T>(this IQueueStorage<T> queueStorage, string queueName) where T : class
        {
            var t = Task.Run(async () =>
            {
                return await queueStorage.GetMessageAsync(queueName);
            });

            try
            {
                t.Wait();
            }
            catch (AggregateException ae)
            {
                if (ae.InnerException != null)
                {
                    throw ae.InnerException;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            if (t.Status == TaskStatus.RanToCompletion)
            {
                return t.Result;
            }
            else
            {
                string taskException = t.Exception != null ? t.Exception.ToString() : null;
                throw new AccelaBaseException("Failed to access to QueueStorage.", "Task is not RanToCompletion while calling GetMessageAsync()." + taskException);
            }
        }

        /// <summary>
        /// get the specified number of messages and removing them from the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <param name="messageCount">The number of messages to retrieve.</param>
        /// <returns>an enumerable collection of QueueMessage
        /// </returns>
        public static IEnumerable<QueueMessage<T>> GetMessages<T>(this IQueueStorage<T> queueStorage, string queueName, int messageCount) where T : class
        {
            var t = Task.Run(async () =>
            {
                return await queueStorage.GetMessagesAsync(queueName, messageCount);
            });

            try
            {
                t.Wait();
            }
            catch (AggregateException ae)
            {
                if (ae.InnerException != null)
                {
                    throw ae.InnerException;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            if (t.Status == TaskStatus.RanToCompletion)
            {
                return t.Result;
            }
            else
            {
                string taskException = t.Exception != null ? t.Exception.ToString() : null;
                throw new AccelaBaseException("Failed to access to QueueStorage.", "Task is not RanToCompletion while calling GetMessagesAsync()." + taskException);
            }
        }


        /// <summary>
        /// clear all messages from the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        public static void Clear<T>(this IQueueStorage<T> queueStorage, string queueName) where T : class
        {
            var t = Task.Run(async () =>
            {
                await queueStorage.ClearAsync(queueName);
            });

            try
            {
                t.Wait();
            }
            catch (AggregateException ae)
            {
                if (ae.InnerException != null)
                {
                    throw ae.InnerException;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            if (t.Status == TaskStatus.RanToCompletion)
            {
                return;
            }
            else
            {
                string taskException = t.Exception != null ? t.Exception.ToString() : null;
                throw new AccelaBaseException("Failed to access to QueueStorage.", "Task is not RanToCompletion while calling ClearAsync()." + taskException);
            }
        }

        /// <summary>
        /// get a single message from the queue without removing it.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <returns>object of type Accela.Infrastructure.Queue.QueueMessage.</returns>
        public static QueueMessage<T> PeekMessage<T>(this IQueueStorage<T> queueStorage, string queueName) where T : class
        {
            var t = Task.Run(async () =>
            {
                return await queueStorage.PeekMessageAsync(queueName);
            });

            try
            {
                t.Wait();
            }
            catch (AggregateException ae)
            {
                if (ae.InnerException != null)
                {
                    throw ae.InnerException;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            if (t.Status == TaskStatus.RanToCompletion)
            {
                return t.Result;
            }
            else
            {
                string taskException = t.Exception != null ? t.Exception.ToString() : null;
                throw new AccelaBaseException("Failed to access to QueueStorage.", "Task is not RanToCompletion while calling PeekMessageAsync()." + taskException);
            }
        }

        //
        // Summary:
        //     peek messages from the queue without removing them.
        //
        // Parameters:
        //   messageCount:
        //     The number of messages to peek.
        //
        // Returns:
        //     an enumerable collection of type Accela.Infrastructure.Queue.QueueMessage
        /// <summary>
        /// peek messages from the queue without removing them.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <param name="messageCount">The number of messages to peek.</param>
        /// <returns>an enumerable collection
        ///     of type Accela.Infrastructure.Queue.QueueMessage.
        /// </returns>
        public static IEnumerable<QueueMessage<T>> PeekMessages<T>(this IQueueStorage<T> queueStorage, string queueName, int messageCount) where T : class
        {
            var t = Task.Run(async () =>
            {
                return await queueStorage.PeekMessagesAsync(queueName, messageCount);
            });

            try
            {
                t.Wait();
            }
            catch (AggregateException ae)
            {
                if (ae.InnerException != null)
                {
                    throw ae.InnerException;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            if (t.Status == TaskStatus.RanToCompletion)
            {
                return t.Result;
            }
            else
            {
                string taskException = t.Exception != null ? t.Exception.ToString() : null;
                throw new AccelaBaseException("Failed to access to QueueStorage.", "Task is not RanToCompletion while calling PeekMessagesAsync()." + taskException);
            }
        }
    }
}
