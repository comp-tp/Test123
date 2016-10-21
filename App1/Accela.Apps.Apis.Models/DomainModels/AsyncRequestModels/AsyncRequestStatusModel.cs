using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Accela.Apps.Apis.Models.DomainModels.AsyncRequestModels
{
    public class AsyncRequestStatusModel
    {
        public string RequestID { get; set; }
        public string Status { get; set; }
        public string HttpMethod { get; set; }
        public string RequestUrl { get; set; }
        public AsyncHttpRequestMessage RequestData { get; set; }
        public AsyncHttpResponseMessage ResponseData { get; set; }
        public DateTime ExpirationDate { get; set; }
    }

    public enum AsyncProcessState
    {
        Created,
        Running,
        Completed
    }

}
