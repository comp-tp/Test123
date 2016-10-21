using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;

namespace Accela.Apps.Apis.WSModels.Assets
{
    [DataContract(Name = "getAssetCAsResponse")]
    public class WSGetAssetCAsResponse : WSPagedResponse
    {
        [DataMember(Name = "assetCAs", EmitDefaultValue = false)]
        public List<WSAssetCA> AssetCAs { get; set; }

        public static WSGetAssetCAsResponse FromEntityModel(GetAssetCAsResponse getAssetCAsResponse)
        {
            var wsGetAssetCAsResponse = new WSGetAssetCAsResponse
            {
                PageInfo = WSPagination.FromEntityModel(getAssetCAsResponse.PageInfo)
            };

            if (getAssetCAsResponse != null && getAssetCAsResponse.AssetCAModels != null)
            {
                wsGetAssetCAsResponse.AssetCAs = WSAssetCA.FromEntityModels(getAssetCAsResponse.AssetCAModels);
            }

            return wsGetAssetCAsResponse;
        }
    }
}
