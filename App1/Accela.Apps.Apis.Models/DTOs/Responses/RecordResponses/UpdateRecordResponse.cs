using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses
{
    [DataContract(Name = "UpdateRecordResponse")]
    public class UpdateRecordResponse : ResponseBase
    {
        [DataMember(Name="record")]
        public RecordModel Record { get; set; }
    }
}
