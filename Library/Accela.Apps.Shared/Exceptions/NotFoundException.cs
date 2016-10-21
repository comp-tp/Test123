using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Accela.Apps.Shared.Exceptions
{
    public class NotFoundException : MobileException
    {
        //404
        public NotFoundException() 
        {
            base.HttpStatus = HttpStatusCode.NotFound;
            base.ErrorCode = ErrorCodes.not_found_404;
        }

        public NotFoundException(string message) : base(message)
        {
            base.HttpStatus = HttpStatusCode.NotFound;
            base.ErrorCode = ErrorCodes.not_found_404;
        }

        public NotFoundException(string message,string detail)
            : base(message,detail)
        {
            base.HttpStatus = HttpStatusCode.NotFound;
            base.ErrorCode = ErrorCodes.not_found_404;
        }

        public NotFoundException(string message, string detail, string errorCode)
            : base(message, detail, errorCode)
        {
            base.HttpStatus = HttpStatusCode.NotFound;
        }

        public NotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
            base.HttpStatus = HttpStatusCode.NotFound;
            base.ErrorCode = ErrorCodes.not_found_404;
        }

        public NotFoundException(string message, Exception innerException, string errorCode)
            : base(message, innerException, errorCode)
        {
            base.HttpStatus = HttpStatusCode.NotFound;
        }
    }
}
