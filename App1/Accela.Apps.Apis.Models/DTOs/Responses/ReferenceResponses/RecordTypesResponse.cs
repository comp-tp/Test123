using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses
{
    [DataContract(Name = "getRecordTypesResponse")]
    public class RecordTypesResponse : PagedResponse
    {
        [DataMember(Name = "recordTypes", EmitDefaultValue = false)]
        public List<RecordTypeModel> RecordTypes { get; set; }
    }
}
