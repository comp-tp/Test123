using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;

namespace Accela.Apps.Apis.WSModels.RelatedRecords
{
    //public class WSRelatedRecordsResponse : ClientResponseBase
    [DataContract(Name = "GetRelatedRecordsResponse")]
    //public class WSRelatedRecordsResponse : WSRecordsResponse  
    public class WSRelatedRecordsResponse : WSResponseBase
    {
        [DataMember(Name = "records", EmitDefaultValue = false)]
        public List<WSRelatedRecord> Records { get; set; }

        public static WSRelatedRecordsResponse FromEntityModel(RelatedRecordsResponse entityResponse)
        {
            WSRelatedRecordsResponse response = new WSRelatedRecordsResponse
            {
            };

            response.Records = new List<WSRelatedRecord>();

            if (entityResponse.Records != null && entityResponse.Records.Count != 0)
            {
                entityResponse.Records.ForEach(model => response.Records.Add(WSRelatedRecord.FromEntityModel(model)));
            }

            return response;
        }
    }
}
