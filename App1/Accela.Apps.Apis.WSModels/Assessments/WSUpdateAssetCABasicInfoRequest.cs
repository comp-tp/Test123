using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.WSModels.Assessments;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;
using Accela.Apps.Apis.WSModels.Assets;
using Accela.Apps.Apis.WSModels.ASIs;

namespace Accela.Apps.Apis.WSModels.Models.Assessments
{
    [DataContract(Name = "wsUpdateAssetCABasicInfoRequest")]
    public class WSUpdateAssetCABasicInfoRequest
    {
        [DataMember(Name = "assetCA")]
        public WSUpdateAssetCABasicInfo AssetCA { get; set; }

        public static UpdateAssetCARequest ToEntityModel(WSUpdateAssetCABasicInfoRequest wsUpdateAssetCABasicInfoRequest, List<WSASI> attributes = null, List<WSASIT> observations = null)
        {
            UpdateAssetCARequest updateAssetCARequest = null;
            if (wsUpdateAssetCABasicInfoRequest != null)
            {
                updateAssetCARequest = new UpdateAssetCARequest();
                updateAssetCARequest = WSUpdateAssetCA.ToEntityModel(wsUpdateAssetCABasicInfoRequest.AssetCA, attributes, observations);
            }
            return updateAssetCARequest;
        }        
    }
}
