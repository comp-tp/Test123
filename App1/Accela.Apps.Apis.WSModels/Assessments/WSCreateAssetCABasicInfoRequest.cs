using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;


namespace Accela.Apps.Apis.WSModels.Assessments
{
    [DataContract(Name = "wsCreateAssetCABasicInfoRequest")]
    public class WSCreateAssetCABasicInfoRequest : WSRequestBase
    {
        [DataMember(Name = "assetCA")]
        public WSCreateAssetCABasicInfo AssetCA { get; set; }

        public static CreateAssetCARequest ToEntityModel(WSCreateAssetCABasicInfoRequest wsCreateAssetCABasicInfoRequest)
        {
            CreateAssetCARequest createAssetCARequest = null;
            if (wsCreateAssetCABasicInfoRequest != null)
            {
                createAssetCARequest = new CreateAssetCARequest();
                createAssetCARequest = WSCreateAssetCABasicInfo.ToEntityModel(wsCreateAssetCABasicInfoRequest.AssetCA);
            }
            return createAssetCARequest;
        }
    }
}
