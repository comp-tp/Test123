using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.WSModels.Assets;
using Accela.Apps.Apis.Models.DTOs.Responses.AssessmentResponses;


namespace Accela.Apps.Apis.WSModels.Assessments
{
    [DataContract(Name = "wsUpdateAssetCAResponse")]
    public class WSUpdateAssetCAResponse : WSResponseBase
    {
        [DataMember(Name = "assetCA", EmitDefaultValue = false)]
        public WSAssetCA AssetCA { get; set; }

        public static WSUpdateAssetCAResponse FromEntityModel(UpdateAssetCAResponse updateAssetCAResponse)
        {
            var wsUpdateAssetCAResponse = new WSUpdateAssetCAResponse();           

            if (updateAssetCAResponse != null)
            {
                wsUpdateAssetCAResponse.AssetCA = WSAssetCA.FromEntityModel(updateAssetCAResponse.AssetCAModel);
            }

            return wsUpdateAssetCAResponse;
        }
    }
}
