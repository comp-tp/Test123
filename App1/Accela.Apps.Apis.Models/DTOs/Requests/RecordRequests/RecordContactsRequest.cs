using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests
{
    [DataContract(Name = "getRecordContactsRequest")]
    public class RecordContactsRequest : PageListRequest
    {
        public string RecordId { get; set; }
    }
}