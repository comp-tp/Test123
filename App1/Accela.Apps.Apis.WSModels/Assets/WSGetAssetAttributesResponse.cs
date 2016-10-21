using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.WSModels.ASIs;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;

namespace Accela.Apps.Apis.WSModels.Assets
{
    [DataContract(Name = "wsGetAssetAttributesResponse")]
    public class WSGetAssetAttributesResponse : WSResponseBase
    {
        [DataMember(Name = "attributes", EmitDefaultValue = false)]
        public List<WSASI> Attributes { get; set; }

        public static WSGetAssetAttributesResponse FromEntityModel(AssetResponse getAssetResponse)
        {
            var wsGetAssetAttributesResponse = new WSGetAssetAttributesResponse();
            
            if (getAssetResponse != null && getAssetResponse.Asset != null)
            {
                wsGetAssetAttributesResponse.Attributes = WSASIResponse.GetASIModel(getAssetResponse.Asset.AdditionalInformation);
            }

            return wsGetAssetAttributesResponse;
        }
    }
}
