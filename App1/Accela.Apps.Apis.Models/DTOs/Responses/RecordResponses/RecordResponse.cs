using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses
{
    [DataContract(Name = "GetRecordResponse")]
    public class RecordResponse : ResponseBase
    {
        [DataMember(Name = "record", EmitDefaultValue = false)]
        public RecordModel Record { get; set; }
    }
}
