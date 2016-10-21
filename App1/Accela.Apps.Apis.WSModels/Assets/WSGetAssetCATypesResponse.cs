using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.WSModels.Assets;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;

namespace Accela.Apps.Apis.WSModels.Assets
{
    [DataContract(Name = "getWSGetAssetCATypesResponse")]
    public class WSGetAssetCATypesResponse : WSResponseBase
    {
        [DataMember(Name = "assetCATypes", EmitDefaultValue = false)]
        public List<WSAssetCAType> AssetCATypes { get; set; }

        public static WSGetAssetCATypesResponse FromEntityModel(AssetCATypesResponse response)
        {

            return new WSGetAssetCATypesResponse()
            {
                AssetCATypes = GetAssetCATypesModel(response)
            };

        }

        public static List<WSAssetCAType> GetAssetCATypesModel(AssetCATypesResponse response)
        {
            if (response == null || response.AssetCATypes == null || response.AssetCATypes.Count == 0) return null;
            List<WSAssetCAType> assetCATypeModels = new List<WSAssetCAType>();

            foreach (AssetCATypeModel assetCATypeModel in response.AssetCATypes)
            {
                WSAssetCAType assetCAType = new WSAssetCAType()
                {
                    Id = assetCATypeModel.Identifier,
                    Display = assetCATypeModel.Display
                };
                assetCATypeModels.Add(assetCAType);
            }

            return assetCATypeModels;
        }
    }
}
