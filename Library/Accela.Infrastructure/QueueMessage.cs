using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Queue
{
    /// <summary>
    /// Represents a message in Queue.
    /// </summary>
    public class QueueMessage 
    {
        /// <summary>
        /// Initializes a new instance of the QueueMessage class with the given byte array.
        /// </summary>
        /// <param name="content">The content of the message as a byte array.</param>
        public QueueMessage(byte[] content)
        {

        }

        /// <summary>
        /// Initializes a new instance of the QueueMessage class with the given string.
        /// </summary>
        /// <param name="content">The content of the message as a string of text.</param>
        public QueueMessage(string content)
        {

        }

        /// <summary>
        /// Gets the content of the message as a byte array.
        /// </summary>
        public byte[] AsBytes 
        { 
            get
            {
                return null; 
            }
        }

        /// <summary>
        /// Gets the content of the message, as a string.
        /// </summary>
        public string AsString
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the time that the message expires.
        /// </summary>
        public DateTimeOffset? ExpirationTime { get; internal set; }

        /// <summary>
        /// Gets the message ID.
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        ///  Gets the time that the message was added to the queue.
        /// </summary>
        public DateTimeOffset? InsertionTime { get; internal set; }
    }
}
