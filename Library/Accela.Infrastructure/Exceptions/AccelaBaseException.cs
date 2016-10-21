using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Exceptions
{
    /// <summary>
    /// Implements Exception handling, like log the exception and return human readable error messages.
    /// </summary>
    public class AccelaBaseException : Exception, ISerializable
    {
        private readonly string details;
        private readonly string errorCode;
       
        public AccelaBaseException()
        {

        }

        public AccelaBaseException(string message)
            : base(message)
        {
        }

        public AccelaBaseException(string message, string details)
            : base(message)
        {
            this.details = details;
        }

        public AccelaBaseException(string message, string details, string errorCode)
            : base(message)
        {
            this.details = details;
            this.errorCode = errorCode;
        }

        public AccelaBaseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public AccelaBaseException(string message, Exception innerException, string errorCode)
            : base(message, innerException)
        {
            this.errorCode = errorCode;
        }

        /// <summary>
        /// TODO: why combine message & details together? If it's together, exception should set it to message directly w/o using details.
        /// </summary>
        public override string Message
        {
            get
            {
                return base.Message + details;
            }
        }

        public string Details
        {
            get
            {
                return details;
            }
        }

        public string ErrorCode
        {
            get
            {
                return errorCode;
            }
        }

        // This constructor is needed for serialization.
        protected AccelaBaseException(SerializationInfo info, StreamingContext context)
        {
            // Add implementation.
        }
    }
}
