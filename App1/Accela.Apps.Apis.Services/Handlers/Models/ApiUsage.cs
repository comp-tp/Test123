using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.Apis.Services.Handlers.Models
{
    [Serializable]
    public class ApiUsage
    {
        public string ResourceName
        {
            get;
            set;
        }

        public string HttpVerb
        {
            get;
            set;
        }

        public string Agency
        {
            get;
            set;
        }

        public string UserId
        {
            get;
            set;
        }

        public string AppId
        {
            get;
            set;
        }

        public string AppVersion
        {
            get;
            set;
        }

        public string Environment
        {
            get;
            set;
        }

        public string ClientOS
        {
            get;
            set;
        }

        public string ClientOSVersion
        {
            get;
            set;
        }

        public string ClientDevice
        {
            get;
            set;
        }

        public string ClientIP
        {
            get;
            set;
        }

        public DateTime CreatedDate
        {
            get;
            set;
        }
    }
}