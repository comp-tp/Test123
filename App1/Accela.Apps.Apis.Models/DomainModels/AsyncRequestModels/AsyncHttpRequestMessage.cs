using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Accela.Apps.Apis.Models.DomainModels.AsyncRequestModels
{
    [Serializable]
    public class AsyncHttpRequestMessage
    {
        public string Url
        {
            get;
            set;
        }

        public string HttpMethod
        {
            get;
            set;
        }

        private IDictionary<string, object> _properties = new Dictionary<string, object>();
        public IDictionary<string, object> Properties
        {
            get
            {
                return _properties;
            }
            set
            {
                _properties = value;
            }
        }

        private IDictionary<string, string> _requestHeaders = new Dictionary<string, string>();
        public IDictionary<string, string> Headers
        {
            get
            {
                return _requestHeaders;
            }
            set
            {
                _requestHeaders = value;
            }
        }

        public Stream Content
        {
            get;
            set;
        }

        public string ContentType_MediaType
        {
            get;
            set;
        }

        public Dictionary<string,string> ContentType_Parameters
        {
            get;
            set;
        }

        public string ContentType_CharSet
        {
            get;
            set;
        }
    }
}
