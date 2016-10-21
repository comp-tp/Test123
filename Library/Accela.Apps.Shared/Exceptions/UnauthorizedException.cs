using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Accela.Apps.Shared.Exceptions
{
    public class UnauthorizedException : MobileException
    {
        // 401
        // client uses an not existing or invalid token, or not pass any credential
        public UnauthorizedException() 
        {
            base.HttpStatus = HttpStatusCode.Unauthorized;
            base.ErrorCode = ErrorCodes.unauthorized_401;
        }

        public UnauthorizedException(string message) : base(message)
        {
            base.HttpStatus = HttpStatusCode.Unauthorized;
            base.ErrorCode = ErrorCodes.unauthorized_401;
        }

        public UnauthorizedException(string message,string detail)
            : base(message,detail)
        {
            base.HttpStatus = HttpStatusCode.Unauthorized;
            base.ErrorCode = ErrorCodes.unauthorized_401;
        }

        public UnauthorizedException(string message, string detail, string errorCode)
            : base(message, detail, errorCode)
        {
            base.HttpStatus = HttpStatusCode.Unauthorized;
        }

        public UnauthorizedException(string message, Exception innerException)
            : base(message, innerException)
        {
            base.HttpStatus = HttpStatusCode.Unauthorized;
            base.ErrorCode = ErrorCodes.unauthorized_401;
        }

        public UnauthorizedException(string message, Exception innerException, string errorCode)
            : base(message, innerException, errorCode)
        {
            base.HttpStatus = HttpStatusCode.Unauthorized;
        }
    }
}
