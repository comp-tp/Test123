using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;

namespace Accela.Apps.Apis.WSModels.Records
{
    [DataContract]
    public class WSRecordResponse : WSPagedResponse
    {
        [DataMember(Name = "record", EmitDefaultValue = false)]
        public WSRecord WSRecord { get; set; }

        public static WSRecordResponse FromEntityModel(RecordResponse recordResponse)
        {
            return new WSRecordResponse()
            {
                WSRecord = WSRecord.FromEntityModel(recordResponse.Record),
            };
        }
    }
}
