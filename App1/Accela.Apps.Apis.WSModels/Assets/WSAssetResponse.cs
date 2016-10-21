using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;

namespace Accela.Apps.Apis.WSModels.Assets
{
    [DataContract]
    public class WSAssetResponse : WSResponseBase
    {
        [DataMember(Name = "asset")]
        public WSAsset Asset { get; set; }

        public static WSAssetResponse FromEntityModel(AssetResponse assetResponse)
        {
            return new WSAssetResponse()
            {
                Asset = WSAsset.FromEntityModel(assetResponse.Asset)
            };
        }
    }
}
