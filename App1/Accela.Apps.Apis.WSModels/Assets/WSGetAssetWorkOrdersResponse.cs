using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;
using Accela.Apps.Apis.WSModels.Records;

namespace Accela.Apps.Apis.WSModels.Assets
{
    [DataContract]
    public class WSGetAssetWorkOrdersResponse : WSResponseBase
    {
        [DataMember(Name = "records", EmitDefaultValue = false, Order = 3)]
        public List<WSRecordWithAddress> Records { get; set; }

        public static WSGetAssetWorkOrdersResponse FromEntityModel(RecordsResponse entityResponse)
        {
            WSGetAssetWorkOrdersResponse results = new WSGetAssetWorkOrdersResponse();

            if (entityResponse != null)
            {
                if (entityResponse.Records != null
                    && entityResponse.Records.Count > 0)
                {
                    results.Records = new List<WSRecordWithAddress>();
                    entityResponse.Records.ForEach(r => results.Records.Add(WSRecordWithAddress.FromEntityModel(r)));
                }
            }

            return results;
        }
    }
}
