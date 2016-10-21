using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Accela.Apps.Shared.Exceptions
{
    public class TokenException : MobileException
    {
        // 401
        // Token is not existed or invalid token
        public TokenException() 
        {
            base.HttpStatus = HttpStatusCode.Unauthorized;
            base.ErrorCode = ErrorCodes.token_expired_401;
        }

        public TokenException(string message) : base(message)
        {
            base.HttpStatus = HttpStatusCode.Unauthorized;
            base.ErrorCode = ErrorCodes.token_expired_401;
        }

        public TokenException(string message,string detail)
            : base(message,detail)
        {
            base.HttpStatus = HttpStatusCode.Unauthorized;
            base.ErrorCode = ErrorCodes.token_expired_401;
        }

        public TokenException(string message, string detail, string errorCode)
            : base(message, detail, errorCode)
        {
            base.HttpStatus = HttpStatusCode.Unauthorized;
        }

        public TokenException(string message, Exception innerException)
            : base(message, innerException)
        {
            base.HttpStatus = HttpStatusCode.Unauthorized;
            base.ErrorCode = ErrorCodes.token_expired_401;
        }

        public TokenException(string message, Exception innerException, string errorCode)
            : base(message, innerException, errorCode)
        {
            base.HttpStatus = HttpStatusCode.Unauthorized;
        }
    }
}
