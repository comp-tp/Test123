#region Header

/**
 * <pre>
 *
 *  Accela Mobile
 *  File: AMException.cs
 *
 *  Accela, Inc.
 *  Copyright (C): 2011
 *
 *  Description:
 *
 *  Notes:
 * $Id: AMException.cs 142354 2011-11-04 02:19:45Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 *  2011-11-04       Jackie Yu       Init.
 * </pre>
 */

#endregion Header

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Runtime.Serialization;

namespace Accela.Apps.Shared.Exceptions
{

    public class MobileException : Exception
    {
        private string _detail;
        private string _errorCode;
        private HttpStatusCode _status = HttpStatusCode.InternalServerError;
        public MobileException()
        { }

        public MobileException(string message)
            : base(message)
        {
        }
        public MobileException(string message, HttpStatusCode statusCode)
            : base(message)
        {            
            _status = statusCode;
        }

        public MobileException(string message, string detail)
            : base(message)
        {
            _detail = detail;
        }

        public MobileException(string message, string detail, string errorCode)
            : base(message)
        {
            _detail = detail;
            _errorCode = errorCode;
        }

        public MobileException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public MobileException(string message, Exception innerException, string errorCode)
            : base(message, innerException)
        {
            _errorCode = errorCode;
        }

        public MobileException(string message, string detail, string errorCode, HttpStatusCode statusCode)
            : base(message==null?"":message)
        {
            _detail = detail;
            _errorCode = errorCode;
            _status = statusCode;
        }

        public string Detail
        {
            get { return _detail; }
            protected set { _detail = value; }
        }

        public string ErrorCode
        {
            get { return _errorCode; }
            protected set { _errorCode = value; }
        }

        public HttpStatusCode HttpStatus
        {
            get { return _status; }
            protected set { _status = value; }
        }
    }
}
