using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.Shared.Exceptions
{
    public class DuplicateObjectException : MobileException
    {
        //400
        public DuplicateObjectException() 
        {
            HttpStatus = System.Net.HttpStatusCode.BadRequest;
        }

        public DuplicateObjectException(string message) : base(message)
        {
            HttpStatus = System.Net.HttpStatusCode.BadRequest;
        }

        public DuplicateObjectException(string message,string detail)
            : base(message,detail)
        {
            HttpStatus = System.Net.HttpStatusCode.BadRequest;
        }

        public DuplicateObjectException(string message, string detail, string errorCode)
            : base(message, detail, errorCode)
        {
            HttpStatus = System.Net.HttpStatusCode.BadRequest;
        }

        public DuplicateObjectException(string message, Exception innerException)
            : base(message, innerException)
        {
            HttpStatus = System.Net.HttpStatusCode.BadRequest;
        }

        public DuplicateObjectException(string message, Exception innerException, string errorCode)
            : base(message, innerException, errorCode)
        {
            HttpStatus = System.Net.HttpStatusCode.BadRequest;
        }
    }
}
