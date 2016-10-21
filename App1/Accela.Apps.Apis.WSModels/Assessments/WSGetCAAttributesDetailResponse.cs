using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.WSModels.ASIs;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;
using Accela.Apps.Apis.WSModels.Assets;

namespace Accela.Apps.Apis.WSModels.Assessments
{
    [DataContract(Name = "wsGetCAAttributesDetails")]
    public class WSGetCAAttributesDetailResponse : WSPagedResponse
    {
        [DataMember(Name = "attributes")]
        public List<WSAdditionalDetail> Attributes { get; set; }

        public static WSGetCAAttributesDetailResponse FromWSASI(WSGetAssetCAResponse wsGetAssetCAResponse)
        {
            var wsGetCAAttributesDetailResponse = new WSGetCAAttributesDetailResponse();
            if (wsGetAssetCAResponse != null && wsGetAssetCAResponse.AssetCA.Attributes != null)
            {
                wsGetCAAttributesDetailResponse.Attributes = WSAdditionalDetail.FromWSASIs(wsGetAssetCAResponse.AssetCA.Attributes);
            } 

            return wsGetCAAttributesDetailResponse;
        }

        public static WSGetCAAttributesDetailResponse FromWSASI(WSAssetCA wsAssetCA)
        {
            var wsGetCAAttributesDetailResponse = new WSGetCAAttributesDetailResponse();
            if (wsAssetCA != null && wsAssetCA.Attributes != null)
            {
                wsGetCAAttributesDetailResponse.Attributes = WSAdditionalDetail.FromWSASIs(wsAssetCA.Attributes);
            }

            return wsGetCAAttributesDetailResponse;
        }
    }
}
