using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;
using Accela.Apps.Apis.WSModels.Assets;

namespace Accela.Apps.Apis.WSModels.Assessments
{
    [DataContract(Name = "wsGetAssetCABasicInfoResponse")]
    public class WSGetAssetCABasicInfoResponse : WSResponseBase
    {
        [DataMember(Name = "assetCA", EmitDefaultValue = false)]
        public WSAssetCABasicInfo assetCABasicInfo { get; set; }

        public static WSGetAssetCABasicInfoResponse FromWSGetAssetCAResponse(WSGetAssetCAResponse wsGetAssetCAResponse)
        {
            var wsGetAssetCABasicInfoResponse = new WSGetAssetCABasicInfoResponse();
            if (wsGetAssetCAResponse != null && wsGetAssetCAResponse.AssetCA != null)
            {
                wsGetAssetCABasicInfoResponse.assetCABasicInfo = WSAssetCABasicInfo.FromWSAssetCA(wsGetAssetCAResponse.AssetCA);
            }
            return wsGetAssetCABasicInfoResponse;
        }

        public static WSGetAssetCABasicInfoResponse FromWSUpdateAssetCAResponse(WSUpdateAssetCAResponse wsUpdateAssetCAResponse)
        {
            var wsGetAssetCABasicInfoResponse = new WSGetAssetCABasicInfoResponse();
            if (wsUpdateAssetCAResponse != null && wsUpdateAssetCAResponse.AssetCA != null)
            {
                wsGetAssetCABasicInfoResponse.assetCABasicInfo = WSAssetCABasicInfo.FromWSAssetCA(wsUpdateAssetCAResponse.AssetCA);
            }
            return wsGetAssetCABasicInfoResponse;
        }
    }
}