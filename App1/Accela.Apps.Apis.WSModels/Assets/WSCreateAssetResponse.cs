using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;

namespace Accela.Apps.Apis.WSModels.Assets
{
    [DataContract(Name = "CreateAssetResponse")]
    public class WSCreateAssetResponse : WSResponseBase
    {
        [DataMember(Name = "asset")]
        public WSAsset Asset { get; set; }

        public static WSCreateAssetResponse FromEntityModel(CreateAssetResponse entityResponse)
        {
            WSCreateAssetResponse response = new WSCreateAssetResponse();

            if (entityResponse != null)
            {
                response.Asset = WSAsset.FromEntityModel(entityResponse.Asset);
            }

            return response;
        }
    }
}
