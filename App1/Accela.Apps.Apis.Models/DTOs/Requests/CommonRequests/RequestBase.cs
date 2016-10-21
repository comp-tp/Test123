using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests
{
    [DataContract]
    public class RequestBase
    {
        public RequestBase()
        {
        }

        public int Offset { get; set; }

        public int Limit { get; set; }
    }
}
