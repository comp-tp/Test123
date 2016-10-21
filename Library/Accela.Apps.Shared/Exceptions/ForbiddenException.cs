using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Accela.Apps.Shared.Exceptions
{
    public class ForbiddenException : MobileException
    {
        // 403 - expired token or no permission to access this resource
        public ForbiddenException() 
        {
            base.HttpStatus = HttpStatusCode.Forbidden;
            base.ErrorCode = ErrorCodes.forbidden_403;
        }

        public ForbiddenException(string message) : base(message)
        {
            base.HttpStatus = HttpStatusCode.Forbidden;
            base.ErrorCode = ErrorCodes.forbidden_403;
        }

        public ForbiddenException(string message,string detail)
            : base(message,detail)
        {
            base.HttpStatus = HttpStatusCode.Forbidden;
            base.ErrorCode = ErrorCodes.forbidden_403;
        }

        public ForbiddenException(string message, string detail, string errorCode)
            : base(message, detail, errorCode)
        {
            base.HttpStatus = HttpStatusCode.Forbidden;
        }

        public ForbiddenException(string message, Exception innerException)
            : base(message, innerException)
        {
            base.HttpStatus = HttpStatusCode.Forbidden;
            base.ErrorCode = ErrorCodes.forbidden_403;
        }

        public ForbiddenException(string message, Exception innerException, string errorCode)
            : base(message, innerException, errorCode)
        {
            base.HttpStatus = HttpStatusCode.Forbidden;
        }
    }
}
