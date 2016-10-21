using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Core.Logging
{
    public class LogEntity : ILogEntity
    {
        
        public string TraceId
        {
            get;
            set;
        }

        public string Host
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public string Detail
        {
            get;
            set;
        }

        public int Order
        {
            get;
            set;
        }

        public string MethodName
        {
            get;
            set;
        }

        /// <summary>
        /// milsecond
        /// </summary>
        public int MethodExecuteTime
        {
            get;
            set;
        }

        public int MethodInSize
        {
            get;
            set;
        }

        public int MethodOutSize
        {
            get;
            set;
        }

        public string Agency
        {
            get;
            set;
        }

        /// <summary>
        /// AppId or appName
        /// </summary>
        public string AppId
        {
            get;
            set;
        }


        public string EnvName
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public string ClientIP
        {
            get;
            set;
        }

        public string RequestFrom
        {
            get;
            set;
        }

        public string RequestTo
        {
            get;
            set;
        }

        public string DetailBlobUri
        {
            get;
            set;
        }

        public DateTime DateCreated
        {
            get;
            set;
        }
    }
    
}

