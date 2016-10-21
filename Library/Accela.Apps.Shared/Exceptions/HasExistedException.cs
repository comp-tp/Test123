using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Accela.Apps.Shared.Exceptions
{
    public class HasExistedException : MobileException
    {
        //400
        public HasExistedException() 
        {
            base.HttpStatus = HttpStatusCode.BadRequest;
            base.ErrorCode = ErrorCodes.record_has_existed_400;
        }

        public HasExistedException(string message) : base(message)
        {
            base.HttpStatus = HttpStatusCode.BadRequest;
            base.ErrorCode = ErrorCodes.record_has_existed_400;
        }

        public HasExistedException(string message,string detail)
            : base(message,detail)
        {
            base.HttpStatus = HttpStatusCode.BadRequest;
            base.ErrorCode = ErrorCodes.record_has_existed_400;
        }

        public HasExistedException(string message, string detail, string errorCode)
            : base(message, detail, errorCode)
        {
            base.HttpStatus = HttpStatusCode.BadRequest;
        }

        public HasExistedException(string message, Exception innerException)
            : base(message, innerException)
        {
            base.HttpStatus = HttpStatusCode.BadRequest;
            base.ErrorCode = ErrorCodes.record_has_existed_400;
        }

        public HasExistedException(string message, Exception innerException, string errorCode)
            : base(message, innerException, errorCode)
        {
            base.HttpStatus = HttpStatusCode.BadRequest;
        }
    }
}
