using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.SQLServer.Queue
{
    public interface ISQLServerQueueStorageRepository
    {
        /// <summary>
        /// Initiates an asynchronous operation to create the queue if it does not already exist.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <returns>  A System.Threading.Tasks.Task<TResult> object of type bool that represents the asynchronous operation.</returns>
        Task<bool> CreateIfNotExistsAsync(string queueName);

        /// <summary>
        /// Initiates an asynchronous operation to delete the queue if it already exists.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <returns>A System.Threading.Tasks.Task<TResult> object of type bool that represents the asynchronous operation.</returns>
        Task<bool> DeleteIfExistsAsync(string queueName);

        /// <summary>
        /// Initiates an asynchronous operation to check the existence of the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <returns>A System.Threading.Tasks.Task<TResult> object of type bool that represents the asynchronous operation.</returns>
        Task<bool> ExistsAsync(string queueName);

        /// <summary>
        /// Initiates an asynchronous operation to add a message to the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <param name="queueEntity">A SQLServerQueueEntity object.</param>
        /// <returns>A System.Threading.Tasks.Task object that represents the asynchronous operation.</returns>
        Task InsertQueueEntityAsync(string queueName, SQLServerQueueEntity queueEntity);

        /// <summary>
        /// Initiates an asynchronous operation to add messages to the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <param name="queueEntities">A SQLServerQueueEntity list.</param>
        /// <returns>A System.Threading.Tasks.Task object that represents the asynchronous operation.</returns>
        Task InsertQueueEntitiesAsync(string queueName, IEnumerable<SQLServerQueueEntity> queueEntities);

        /// <summary>
        /// Initiates an asynchronous operation to get a single message and removing it from the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <param name="deleteQueueEntity">true - will delete queue entity, false - will not delete queue entity.</param>
        /// <returns>A System.Threading.Tasks.Task<TResult> object of type Accela.Infrastructure.Queue.QueueMessage that represents the asynchronous operation.</returns>
        Task<SQLServerQueueEntity> GetQueueEntityAsync(string queueName, bool deleteQueueEntity);

        /// <summary>
        /// Initiates an asynchronous operation to get the specified number of messages and removing them from the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <param name="messageCount">The number of messages to retrieve.</param>
        /// <param name="deleteQueueEntity">true - will delete queue entity, false - will not delete queue entity.</param>
        /// <returns>A System.Threading.Tasks.Task<TResult> object that is an enumerable collection
        ///  of type Accela.Infrastructure.Queue.QueueMessage that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<SQLServerQueueEntity>> GetQueueEntitiesAsync(string queueName, int messageCount, bool deleteQueueEntity);

        /// <summary>
        /// Initiates an asynchronous operation to clear all messages from the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <returns>A System.Threading.Tasks.Task object that represents the asynchronous operation.</returns>
        Task ClearAsync(string queueName);
    }
}
