using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.WSModels.Assessments;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;
using Accela.Apps.Apis.WSModels.Assets;

namespace Accela.Apps.Apis.WSModels.Models.Assessments
{
    [DataContract(Name = "wsUpdateAssetCARequest")]
    public class WSUpdateAssetCARequest
    {
        [DataMember(Name = "assetCA")]
        public WSUpdateAssetCA AssetCA { get; set; }

        public static UpdateAssetCARequest ToEntityModel(WSUpdateAssetCARequest wsUpdateAssetCARequest)
        {
            UpdateAssetCARequest updateAssetCARequest = null;
            if (wsUpdateAssetCARequest != null)
            {
                updateAssetCARequest = new UpdateAssetCARequest();
                updateAssetCARequest = WSUpdateAssetCA.ToEntityModel(wsUpdateAssetCARequest.AssetCA);
            }
            return updateAssetCARequest;
        }

        public static WSUpdateAssetCARequest FromWSAssetCA(WSAssetCA wsAssetCA)
        {
            WSUpdateAssetCARequest wsUpdateAssetCARequest = null;
            if (wsAssetCA != null)
            {
                wsUpdateAssetCARequest = new WSUpdateAssetCARequest();
                wsUpdateAssetCARequest.AssetCA = WSUpdateAssetCA.FromEntityModel(wsAssetCA);
            }
            return wsUpdateAssetCARequest;
        }
    }
}
