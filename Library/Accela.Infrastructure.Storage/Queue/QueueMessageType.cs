using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Queue
{
    /// <summary>
    /// Enum for Queue message type.
    /// </summary>
    public enum QueueMessageType
    {
        /// <summary>
        /// Indicates the message object stores the raw text string.
        /// </summary>
        RawString,

        /// <summary>
        /// Indicates the message object stores the raw binary data.
        /// </summary>
        RawBytes,

        RawObject
    }
}
