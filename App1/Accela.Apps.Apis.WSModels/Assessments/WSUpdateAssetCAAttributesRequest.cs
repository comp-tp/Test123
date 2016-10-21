using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;
using Accela.Apps.Apis.WSModels.ASIs;


namespace Accela.Apps.Apis.WSModels.Assessments
{
    [DataContract(Name = "wsUpdateAssetCAAttributesRequest")]
    public class WSUpdateAssetCAAttributesRequest : WSRequestBase
    {
        [DataMember(Name = "subGroup")]
        public WSASISubGroup SubGroup { get; set; }

        public static UpdateAssetCARequest ToEntityModel(WSUpdateAssetCA wsUpdateAssetCA)
        {
            UpdateAssetCARequest updateAssetCARequest = null;
            if (wsUpdateAssetCA != null)
            {
                updateAssetCARequest = new UpdateAssetCARequest();
                updateAssetCARequest = WSUpdateAssetCA.ToEntityModel(wsUpdateAssetCA);
            }
            return updateAssetCARequest;
        }

    }
}
