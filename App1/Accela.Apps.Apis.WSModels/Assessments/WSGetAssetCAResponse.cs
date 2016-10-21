using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;
using Accela.Apps.Apis.WSModels.Assets;

namespace Accela.Apps.Apis.WSModels.Assessments
{
    [DataContract(Name = "wsGetAssetCAResponse")]
    public class WSGetAssetCAResponse : WSResponseBase
    {
        [DataMember(Name = "assetCA", EmitDefaultValue = false)]
        public WSAssetCA AssetCA { get; set; }

        public static WSGetAssetCAResponse FromEntityModel(GetAssetCAsResponse getAssetCAsResponse)
        {
            var wsGetAssetCAResponse = new WSGetAssetCAResponse
            {

            };

            if (getAssetCAsResponse != null && getAssetCAsResponse.AssetCAModels != null && getAssetCAsResponse.AssetCAModels.Count == 1)
            {
                wsGetAssetCAResponse.AssetCA = WSAssetCA.FromEntityModel(getAssetCAsResponse.AssetCAModels.First());
            }

            return wsGetAssetCAResponse;
        }
    }
}
