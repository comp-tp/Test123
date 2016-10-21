using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses
{
    [DataContract(Name = "GetRecordResponse")]
    public class RecordsResponse : PagedResponse
    {
        [DataMember(Name = "records", EmitDefaultValue = false)]
        public List<RecordModel> Records { get; set; }
    }
}
