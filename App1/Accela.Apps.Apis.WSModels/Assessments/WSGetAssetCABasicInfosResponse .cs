using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;
using Accela.Apps.Apis.WSModels.Assets;
using System.Collections.Generic;

namespace Accela.Apps.Apis.WSModels.Assessments
{
    [DataContract(Name = "wsGetAssetCABasicInfosResponse")]
    public class WSGetAssetCABasicInfosResponse : WSPagedResponse
    {
        [DataMember(Name = "assetCAs", EmitDefaultValue = false)]
        public List<WSAssetCABasicInfo> AssetCAs { get; set; }

        public static WSGetAssetCABasicInfosResponse FromWSGetAssetCAsResponse(WSGetAssetCAsResponse wsGetAssetCAsResponse)
        {
            var wsGetAssetCABasicInfosResponse = new WSGetAssetCABasicInfosResponse();
            wsGetAssetCABasicInfosResponse.PageInfo = wsGetAssetCAsResponse.PageInfo;

            if (wsGetAssetCAsResponse != null && wsGetAssetCAsResponse.AssetCAs != null)
            {
                wsGetAssetCABasicInfosResponse.AssetCAs = WSAssetCABasicInfo.FromWSAssetCAs(wsGetAssetCAsResponse.AssetCAs);
            }
            return wsGetAssetCABasicInfosResponse;
        }
    }
}