using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Accela.Apps.Apis.Models.DomainModels.AsyncRequestModels
{
    [Serializable]
    public class AsyncHttpResponseMessage
    {
        private IDictionary<string, string> _responseHeaders = null;
        public IDictionary<string, string> Headers
        {
            get
            {
                if (_responseHeaders == null)
                {
                    _responseHeaders = new Dictionary<string, string>();
                }
                return _responseHeaders;
            }
            set
            {
                _responseHeaders = value;
            }
        }

        public Stream Content
        {
            get;
            set;
        }
        public string ReasonPhrase
        {
            get;
            set;
        }

        public HttpStatusCode StatusCode
        {
            get;
            set;
        }

        public string ContentType_MediaType
        {
            get;
            set;
        }
    }
}
