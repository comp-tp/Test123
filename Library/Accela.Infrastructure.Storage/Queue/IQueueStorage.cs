using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Queue
{
    /// <summary>
    /// This interface represents a queue storage interface.
    /// </summary>
    public interface IQueueStorage<T> where T : class
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
        /// <param name="message">A Accela.Infrastructure.Queue.QueueMessage object.</param>
        /// <param name="timeToLive">A System.TimeSpan specifying the maximum time to allow the message to be in the queue, or null.</param>
        /// <returns>A System.Threading.Tasks.Task object that represents the asynchronous operation.</returns>
        Task CreateNewMessageAsync(string queueName, QueueMessage<T> message);

        /// <summary>
        /// Initiates an asynchronous operation to batch add messages to the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <param name="messages">List of Accela.Infrastructure.Queue.QueueMessage object.</param>
        /// <returns>A System.Threading.Tasks.Task object that represents the asynchronous operation.</returns>
        Task CreateNewMessagesAsync(string queueName, IEnumerable<QueueMessage<T>> messages);

        /// <summary>
        /// Initiates an asynchronous operation to get a single message and removing it from the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <returns>A System.Threading.Tasks.Task<TResult> object of type Accela.Infrastructure.Queue.QueueMessage that represents the asynchronous operation.</returns>
        Task<QueueMessage<T>> GetMessageAsync(string queueName);

        /// <summary>
        /// Initiates an asynchronous operation to get the specified number of messages and removing them from the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <param name="messageCount">The number of messages to retrieve.</param>
        /// <returns>A System.Threading.Tasks.Task<TResult> object that is an enumerable collection
        ///  of type Accela.Infrastructure.Queue.QueueMessage that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<QueueMessage<T>>> GetMessagesAsync(string queueName, int messageCount);

        /// <summary>
        /// Initiates an asynchronous operation to clear all messages from the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <returns>A System.Threading.Tasks.Task object that represents the asynchronous operation.</returns>
        Task ClearAsync(string queueName);

        /// <summary>
        /// Initiates an asynchronous operation to get a single message from the queue without removing it.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <returns>A System.Threading.Tasks.Task<TResult> object of type Accela.Infrastructure.Queue.QueueMessage that represents the asynchronous operation.</returns>
        Task<QueueMessage<T>> PeekMessageAsync(string queueName);
    
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
        Task<IEnumerable<QueueMessage<T>>> PeekMessagesAsync(string queueName, int messageCount);
    }
}
