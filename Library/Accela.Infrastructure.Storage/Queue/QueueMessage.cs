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
    public class QueueMessage<T> where T : class
    {
        //the original message string
        private string _rawString;

        //the original binary data
        private byte[] _rawBytes;

        //the original T object
        private T _rawT;

        private QueueMessageType _queueMessageType = QueueMessageType.RawString;

        /// <summary>
        /// Initializes a new instance of the QueueMessage class with the given byte array.
        /// </summary>
        /// <param name="content">The content of the message as a byte array.</param>
        public QueueMessage(byte[] content)
        {
            if(content == null)
            {
                throw new ArgumentNullException("content");
            }

            this._rawBytes = content;
            _queueMessageType = QueueMessageType.RawBytes;
        }

        /// <summary>
        /// Initializes a new instance of the QueueMessage class with the given string.
        /// </summary>
        /// <param name="content">The content of the message as a string of text.</param>
        public QueueMessage(string content)
        {
            if (String.IsNullOrEmpty(content))
            {
                throw new ArgumentNullException("content");
            }

            this._rawString = content;
            _queueMessageType = QueueMessageType.RawString;
        }

        /// <summary>
        /// Initializes a new instance of the QueueMessage class with the given byte array.
        /// </summary>
        /// <param name="content">The content of the message as a byte array.</param>
        public QueueMessage(T content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            this._rawT = content;
            _queueMessageType = QueueMessageType.RawObject;
        }

        /// <summary>
        /// Gets the content of the message as a byte array.
        /// </summary>
        public byte[] AsBytes 
        { 
            get
            {
                if(_rawBytes != null)
                {
                    return _rawBytes;
                }
                else if (_rawString != null)
                {
                    return Encoding.UTF8.GetBytes(this._rawString);
                }
                else if(_rawT != null)
                {
                    return ObjectConverter.ObjectToByteArray(_rawT);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the content of the message, as a string.
        /// </summary>
        public string AsString
        {
            get
            {
                if (_rawString != null)
                {
                    return _rawString;
                }
                else if (_rawBytes != null)
                {
                    return Encoding.UTF8.GetString(this._rawBytes);
                }
                else if (_rawT != null)
                {
                    return Encoding.UTF8.GetString(ObjectConverter.ObjectToByteArray(_rawT));
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the content of the message, as a string.
        /// </summary>
        public T AsT
        {
            get
            {
                if (_rawT != null)
                {
                    return _rawT;
                }
                else if (_rawString != null)
                {
                    var resultBytes = Encoding.UTF8.GetBytes(_rawString);
                    var resultT = ObjectConverter.ByteArrayToObject(resultBytes);
                    return resultT as T;
                }
                else if (_rawBytes != null)
                {
                    var resultT = ObjectConverter.ByteArrayToObject(_rawBytes);
                    return resultT as T;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        ///  Gets the queue message type.
        /// </summary>
        public QueueMessageType QueueMessageType
        {
            get
            {
                return _queueMessageType;
            }
        }

        /// <summary>
        /// Gets the time that the message expires.
        /// </summary>
        public DateTimeOffset? ExpirationTime { get; set; }

        /// <summary>
        /// Gets the message ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///  Gets the time that the message was added to the queue.
        /// </summary>
        public DateTimeOffset? InsertionTime { get; set; }
    }
}
