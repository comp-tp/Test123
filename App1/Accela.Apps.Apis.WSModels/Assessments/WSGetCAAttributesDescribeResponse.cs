using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.WSModels.ASIs;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;
using Accela.Apps.Apis.WSModels.Assets;

namespace Accela.Apps.Apis.WSModels.Assessments
{
    [DataContract(Name = "wsGetCAAttributes")]
    public class WSGetCAAttributesDescribeResponse : WSResponseBase
    {
        [DataMember(Name = "attributes")]
        public List<WSAdditional> Attributes { get; set; }

        public static WSGetCAAttributesDescribeResponse FromWSASI(WSGetAssetCAResponse wsGetAssetCAResponse)
        {
            var wsGetCAAttributesResponse = new WSGetCAAttributesDescribeResponse();
            if (wsGetAssetCAResponse != null && wsGetAssetCAResponse.AssetCA != null && wsGetAssetCAResponse.AssetCA.Attributes != null)
            {
                wsGetCAAttributesResponse.Attributes = WSAdditional.FromWSASIs(wsGetAssetCAResponse.AssetCA.Attributes);                
            }

            return wsGetCAAttributesResponse;
        }
    }
}
