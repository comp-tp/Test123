using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses
{
    [DataContract(Name = "dailyRecordsCountResponse")]
    public class DailyRecordsCountResponse : ResponseBase
    {
        [DataMember(Name = "DailyRecords", EmitDefaultValue = false)]
        public List<DailyRecordModel> DailyRecords { get; set; }
    }
}
