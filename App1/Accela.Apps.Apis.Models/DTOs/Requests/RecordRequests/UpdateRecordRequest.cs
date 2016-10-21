using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests
{
    [DataContract(Name = "UpdateRecordRequest")]
    public class UpdateRecordRequest: RequestBase
    {
        [DataMember(Name = "record", EmitDefaultValue = false)]
        public RecordModel Record { get; set; }
    }
}
