using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;


namespace Accela.Apps.Apis.WSModels.Assessments
{
    [DataContract(Name = "wsCreateAssetCARequest")]
    public class WSCreateAssetCARequest : WSRequestBase
    {
        [DataMember(Name = "assetCA")]
        public WSCreateAssetCA AssetCA { get; set; }

        public static CreateAssetCARequest ToEntityModel(WSCreateAssetCARequest wsCreateAssetCARequest)
        {
            CreateAssetCARequest createAssetCARequest = null;
            if (wsCreateAssetCARequest != null)
            {
                createAssetCARequest = new CreateAssetCARequest();
                createAssetCARequest = WSCreateAssetCA.ToEntityModel(wsCreateAssetCARequest.AssetCA);
            }
            return createAssetCARequest;
        }
    }
}
