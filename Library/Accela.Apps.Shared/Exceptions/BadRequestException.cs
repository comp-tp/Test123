using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Accela.Apps.Shared.Exceptions
{
    public class BadRequestException : MobileException
    {
        //400
        public BadRequestException()
        { 
            base.HttpStatus = HttpStatusCode.BadRequest;
            base.ErrorCode = ErrorCodes.bad_request_400;
        }

        public BadRequestException(string message) : base(message)
        {
            base.HttpStatus = HttpStatusCode.BadRequest;
            base.ErrorCode = ErrorCodes.bad_request_400;
        }

        public BadRequestException(string message,string detail)
            : base(message,detail)
        {
            base.HttpStatus = HttpStatusCode.BadRequest;
            base.ErrorCode = ErrorCodes.bad_request_400;
        }

        public BadRequestException(string message, string detail, string errorCode)
            : base(message, detail, errorCode)
        {
            base.HttpStatus = HttpStatusCode.BadRequest;
        }

        public BadRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
            base.HttpStatus = HttpStatusCode.BadRequest;
            base.ErrorCode = ErrorCodes.bad_request_400;
        }

        public BadRequestException(string message, Exception innerException, string errorCode)
            : base(message, innerException, errorCode)
        {
            base.HttpStatus = HttpStatusCode.BadRequest;
        }
    }
}
