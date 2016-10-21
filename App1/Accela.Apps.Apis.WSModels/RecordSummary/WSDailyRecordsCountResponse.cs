using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;

namespace Accela.Apps.Apis.WSModels.RecordSummary
{
    [DataContract(Name = "dailyRecordsCountResponse")]
    public class WSDailyRecordsCountResponse : WSResponseBase
    {
        [DataMember(Name = "dailyRecords", EmitDefaultValue = false)]
        public List<WSDailyRecord> DailyRecords { get; set; }

        public static WSDailyRecordsCountResponse FromEntityModel(DailyRecordsCountResponse response)
        {
            WSDailyRecordsCountResponse result = null;

            if (response != null)
            {
                result = new WSDailyRecordsCountResponse()
                {
                    DailyRecords = WSDailyRecord.FromEntityModels(response.DailyRecords)
                };
            }

            return result;
        }
    }
}
