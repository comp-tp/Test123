using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;

namespace Accela.Apps.Apis.WSModels.Assets
{
    [DataContract(Name = "getWSAssetStatusesResponse")]
    public class WSAssetStatusesResponse : WSResponseBase
    {
        [DataMember(Name = "assetStatuses", EmitDefaultValue = false)]
        public List<WSAssetStatus> AssetStatuses { get; set; }

        public static WSAssetStatusesResponse FromEntityModel(AssetStatusesResponse response)
        {
            return new WSAssetStatusesResponse()
            {
                AssetStatuses = response.Statuses == null ? null : WSAssetStatus.FromEntityModels(response.Statuses.ToArray()).ToList()
            };
        }
    }
}
