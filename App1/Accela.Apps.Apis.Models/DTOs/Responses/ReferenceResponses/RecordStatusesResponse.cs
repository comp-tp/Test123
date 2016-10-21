using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses
{
    [DataContract(Name = "getRecordStatusesResponse")]
    public class RecordStatusesResponse : ResponseBase
    {
        [DataMember(Name = "recordStatuses", EmitDefaultValue = false)]
        public List<RecordStatusModel> RecordStatuses { get; set; }
    }
}
