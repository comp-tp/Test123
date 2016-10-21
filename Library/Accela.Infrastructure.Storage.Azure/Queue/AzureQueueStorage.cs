using Accela.Infrastructure.Queue;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Azure.Queue
{
    public class AzureQueueStorage<T> : IQueueStorage<T> where T : class
    {
        private CloudQueueClient _queueClient = null;
        private QueueRequestOptions _requestOptions = null;
        private const int MAX_MESSAGE_COUNT_LIMITATION = 1000;
        private const int AZURE_MESSAGE_COUNT_LIMITATION = 32;
        private static TimeSpan VISIBILITY_TIMEOUT = new TimeSpan(0, 30, 0);

        public AzureQueueStorage(IConnectionStringSetting connectionStringSetting, IRetryPolicyConfiguration retryPolicyConfiguration)
        {
            if (connectionStringSetting == null)
            {
                throw new ArgumentNullException("connectionStringSetting");
            }

            var connectionString = connectionStringSetting.Get();
            if (String.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException("Invalid connection string.");
            }
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);

            // Creates the queue service client.
            _queueClient = storageAccount.CreateCloudQueueClient();

            QueueRequestOptions requestOptions = null;
            // Retry Policy
            if (retryPolicyConfiguration != null && retryPolicyConfiguration.RetryMethod != RetryMethod.None)
            {
                Microsoft.WindowsAzure.Storage.RetryPolicies.IRetryPolicy azureRetryPolicy = null;
                // convert to azure IRetryPolicy
                if (retryPolicyConfiguration.RetryMethod == RetryMethod.Linear)
                {
                    azureRetryPolicy = new Microsoft.WindowsAzure.Storage.RetryPolicies.LinearRetry(retryPolicyConfiguration.DeltaBackoff, retryPolicyConfiguration.MaxAttempts);
                }
                else if (retryPolicyConfiguration.RetryMethod == RetryMethod.Exponential)
                {
                    azureRetryPolicy = new Microsoft.WindowsAzure.Storage.RetryPolicies.ExponentialRetry(retryPolicyConfiguration.DeltaBackoff, retryPolicyConfiguration.MaxAttempts);
                }
                else if(retryPolicyConfiguration.RetryMethod == RetryMethod.Discrete)
                {
                    throw new NotSupportedException("Doesn't support Discrete retry method in Azure implementation.");
                }

                if (azureRetryPolicy != null)
                {
                    requestOptions = new QueueRequestOptions()
                    {
                        RetryPolicy = azureRetryPolicy,
                    };
                    _requestOptions = requestOptions;
                }
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

            CloudQueue queue = _queueClient.GetQueueReference(queueName);

            return await queue.CreateIfNotExistsAsync(_requestOptions, null);
        }

        /// <summary>
        /// Initiates an asynchronous operation to delete the queue if it already exists.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <returns>A System.Threading.Tasks.Task<TResult> object of type bool that represents the asynchronous operation.
        /// true if the queue did not already exist and was created; otherwise false.
        /// </returns>
        public async Task<bool> DeleteIfExistsAsync(string queueName)
        {
            QueueValidation.CheckQueueName(queueName);

            CloudQueue queue = _queueClient.GetQueueReference(queueName);

            return await queue.DeleteIfExistsAsync(_requestOptions, null);
        }

        /// <summary>
        /// Initiates an asynchronous operation to check the existence of the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <returns>A System.Threading.Tasks.Task<TResult> object of type bool that represents the asynchronous operation.</returns>
        public async Task<bool> ExistsAsync(string queueName)
        {
            QueueValidation.CheckQueueName(queueName);

            CloudQueue queue = _queueClient.GetQueueReference(queueName);

            return await queue.ExistsAsync(_requestOptions, null);
        }

        /// <summary>
        /// Initiates an asynchronous operation to add a message to the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <param name="message">A Accela.Infrastructure.Queue.QueueMessage object.</param>
        /// <returns>A System.Threading.Tasks.Task object that represents the asynchronous operation.</returns>
        public async Task CreateNewMessageAsync(string queueName, QueueMessage<T> message)
        {
            QueueValidation.CheckQueueName(queueName);

            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            CloudQueue queue = _queueClient.GetQueueReference(queueName);

            await queue.CreateIfNotExistsAsync(_requestOptions, null);

            //Convert QueueMessage to Azure CloudQueueMessage
            CloudQueueMessage cloudQueueMessage = null;
            
            if(message.QueueMessageType == QueueMessageType.RawString)
            {
                cloudQueueMessage = new CloudQueueMessage(message.AsString);
            }
            else
            {
                cloudQueueMessage = new CloudQueueMessage(message.AsBytes);
            }

            TimeSpan? timeToLive = null;

            if(message.ExpirationTime.HasValue)
            {
                DateTimeOffset timeToLiveDTO = message.ExpirationTime.Value;

                timeToLive = timeToLiveDTO - new DateTimeOffset(DateTime.UtcNow);

                if(timeToLive <= TimeSpan.Zero)
                {
                    timeToLive = null;
                }
            }

            await queue.AddMessageAsync(cloudQueueMessage, timeToLive, null, null, null);
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
                throw new ArgumentNullException("messages");
            }

            if(!messages.Any())
            {
                return;
            }

            CloudQueue queue = _queueClient.GetQueueReference(queueName);

            await queue.CreateIfNotExistsAsync(_requestOptions, null);

            foreach (var message in messages)
            {
                //Convert QueueMessage to Azure CloudQueueMessage
                CloudQueueMessage cloudQueueMessage = null;

                if (message.QueueMessageType == QueueMessageType.RawString)
                {
                    cloudQueueMessage = new CloudQueueMessage(message.AsString);
                }
                else
                {
                    cloudQueueMessage = new CloudQueueMessage(message.AsBytes);
                }

                TimeSpan? timeToLive = null;

                if (message.ExpirationTime.HasValue)
                {
                    DateTimeOffset timeToLiveDTO = message.ExpirationTime.Value;

                    timeToLive = timeToLiveDTO - new DateTimeOffset(DateTime.UtcNow);

                    if (timeToLive <= TimeSpan.Zero)
                    {
                        timeToLive = null;
                    }
                }

                await queue.AddMessageAsync(cloudQueueMessage, timeToLive, null, null, null);
            }
        }

        /// <summary>
        /// Initiates an asynchronous operation to get a single message and removing it from the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <returns>A System.Threading.Tasks.Task<TResult> object of type Accela.Infrastructure.Queue.QueueMessage that represents the asynchronous operation.</returns>
        public async Task<QueueMessage<T>> GetMessageAsync(string queueName)
        {
            QueueValidation.CheckQueueName(queueName);

            CloudQueue queue = _queueClient.GetQueueReference(queueName);

            await queue.CreateIfNotExistsAsync(_requestOptions, null);
            var cloudQueueMessage = await queue.GetMessageAsync(VISIBILITY_TIMEOUT, _requestOptions, null);
            await queue.DeleteMessageAsync(cloudQueueMessage);
            // convert Azure queue message to Accela QueueMessage
            QueueMessage<T> result = new QueueMessage<T>(cloudQueueMessage.AsBytes);
            result.ExpirationTime = cloudQueueMessage.ExpirationTime;
            result.InsertionTime = cloudQueueMessage.InsertionTime;
            result.Id = cloudQueueMessage.Id;

            return result;
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
            QueueValidation.CheckQueueName(queueName);

            if (messageCount <= 0 || messageCount > MAX_MESSAGE_COUNT_LIMITATION)
            {
                throw new ArgumentOutOfRangeException("messageCount","The message count must be between 1 to 1000");
            }

            CloudQueue queue = _queueClient.GetQueueReference(queueName);

            await queue.CreateIfNotExistsAsync(_requestOptions, null);

            var result = new List<QueueMessage<T>>();


            int times = Convert.ToInt32(Math.Ceiling((double)messageCount / AZURE_MESSAGE_COUNT_LIMITATION));

            for (int i = 0; i < times; i++)
            {
                int messageCountPerGet = AZURE_MESSAGE_COUNT_LIMITATION;

                if(i == times - 1)
                {
                    messageCountPerGet = messageCount - (AZURE_MESSAGE_COUNT_LIMITATION * i);
                }

                var cloudQueueMessage = await queue.GetMessagesAsync(messageCountPerGet, VISIBILITY_TIMEOUT, _requestOptions, null);

                if(cloudQueueMessage.Count() == 0)
                {
                    break;
                }

                foreach (var cqm in cloudQueueMessage)
                {
                    // convert Azure queue message to Accela QueueMessage
                    QueueMessage<T> qm = new QueueMessage<T>(cqm.AsBytes);
                    qm.ExpirationTime = cqm.ExpirationTime;
                    qm.InsertionTime = cqm.InsertionTime;
                    qm.Id = cqm.Id;
                    result.Add(qm);
                    await queue.DeleteMessageAsync(cqm);
                }
            }

            return result;
        }


        /// <summary>
        /// Initiates an asynchronous operation to clear all messages from the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <returns>A System.Threading.Tasks.Task object that represents the asynchronous operation.</returns>
        public async Task ClearAsync(string queueName)
        {
            QueueValidation.CheckQueueName(queueName);

            CloudQueue queue = _queueClient.GetQueueReference(queueName);

            await queue.ClearAsync(_requestOptions, null);
        }

        /// <summary>
        /// Initiates an asynchronous operation to get a single message from the queue without removing it.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <returns>A System.Threading.Tasks.Task<TResult> object of type Accela.Infrastructure.Queue.QueueMessage that represents the asynchronous operation.</returns>
        public async Task<QueueMessage<T>> PeekMessageAsync(string queueName)
        {
            QueueValidation.CheckQueueName(queueName);

            CloudQueue queue = _queueClient.GetQueueReference(queueName);
            await queue.CreateIfNotExistsAsync(_requestOptions, null);

            var cloudQueueMessage = await queue.PeekMessageAsync(_requestOptions, null);
            QueueMessage<T> result = null;
            // convert Azure queue message to Accela QueueMessage
            if (cloudQueueMessage != null)
            {
                result = new QueueMessage<T>(cloudQueueMessage.AsBytes);
                result.ExpirationTime = cloudQueueMessage.ExpirationTime;
                result.InsertionTime = cloudQueueMessage.InsertionTime;
                result.Id = cloudQueueMessage.Id;
            }

            return result;
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
            QueueValidation.CheckQueueName(queueName);

            if (messageCount <= 0)
            {
                throw new ArgumentOutOfRangeException("messageCount");
            }

            CloudQueue queue = _queueClient.GetQueueReference(queueName);

            await queue.CreateIfNotExistsAsync(_requestOptions, null);
            var cloudQueueMessage = await queue.PeekMessagesAsync(messageCount, _requestOptions, null);

            var result = new List<QueueMessage<T>>();

            foreach (var cqm in cloudQueueMessage)
            {
                // convert Azure queue message to Accela QueueMessage
                QueueMessage<T> qm = new QueueMessage<T>(cqm.AsBytes);
                qm.ExpirationTime = cqm.ExpirationTime;
                qm.InsertionTime = cqm.InsertionTime;
                qm.Id = cqm.Id;
                result.Add(qm);
            }

            return result;
        }
    }
}
