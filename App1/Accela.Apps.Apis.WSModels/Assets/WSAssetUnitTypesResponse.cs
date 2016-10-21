using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;

namespace Accela.Apps.Apis.WSModels.Assets
{
    [DataContract(Name = "getWSAssetUnitTypesResponse")]
    public class WSAssetUnitTypesResponse : WSResponseBase
    {
        [DataMember(Name="assetUnitTypes",EmitDefaultValue=false)]
        public List<WSAssetUnitTypes> AssetUnitTypes { get; set; }

        public static WSAssetUnitTypesResponse FromEntityModel(AssetUnitTypesResponse response)
        {
            return new WSAssetUnitTypesResponse()
            {
                AssetUnitTypes = response.AssetUnitTypes == null ? null : WSAssetUnitTypes.FromEntityModels(response.AssetUnitTypes.ToArray()).ToList()
            };
        }
    }
}
