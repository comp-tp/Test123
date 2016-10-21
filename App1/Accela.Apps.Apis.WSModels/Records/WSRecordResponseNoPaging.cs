using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;

namespace Accela.Apps.Apis.WSModels.Records
{
    [DataContract(Name = "GetRecordResponse")]
    public class WSRecordResponseNoPaging : WSResponseBase
    {
        [DataMember(Name = "record", EmitDefaultValue = false)]
        public WSRecord Record { get; set; }

        public static WSRecordResponseNoPaging FromEntityModel(RecordResponse recordResponse)
        {
            return new WSRecordResponseNoPaging()
            {
                Record = WSRecord.FromEntityModel(recordResponse.Record)
            };
        }
    }
}
