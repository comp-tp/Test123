using System;

namespace Accela.Core.Analytics
{
    public class StatsData
    {
        //public Guid Id {get; set;}
        
        public string Agency
        {
            get;
            set;
        }

        public string App
        {
            get;
            set;
        }

        public string Environment
        {
            get;
            set;
        }
        
        public string User
        {
            get;
            set;
        }

        public string Resource
        {
            get;
            set;
        }

        public DateTime RequestTime
        {
            get;
            set;
        }

        public string RequestUri
        {
            get;
            set;
        }

        public string RequestQuery
        {
            get;
            set;
        }

        public string RequestMethod
        {
            get;
            set;
        }

        public string RequestUserAgent
        {
            get;
            set;
        }

        public string ClientIP
        {
            get;
            set;
        }

        public int ResponseTime // in ms
        {
            get;
            set;
        }

        public int ResponseSize // in bytes
        {
            get;
            set;
        }

        public int ResponseStatus
        {
            get;
            set;
        }

        public int BackendResponseTime // Ex. AA response time
        {
            get;
            set;
        }

    }
}
