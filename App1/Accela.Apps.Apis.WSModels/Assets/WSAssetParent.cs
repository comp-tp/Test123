using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;
using Accela.Apps.Apis.Models.DomainModels;

namespace Accela.Apps.Apis.WSModels.Assets
{
    [DataContract(Name="assetParent")]
    public class WSAssetParent: WSDataModel
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the display.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        
        public static WSAssetParent FromEntityModel(AssetParentModel assetParentModel)
        {
            if (assetParentModel != null)
            {
                return new WSAssetParent()
                {
                    Id = assetParentModel.Id,
                    Display = assetParentModel.Display
                };
            }
            return null;
        }

        public static WSAssetParent[] FromEntityModels(AssetParentModel[] entityModels)
        {
            if (entityModels == null)
            {
                return null;
            }

            var result = entityModels.Select(m => FromEntityModel(m)).ToArray();
            return result;
        }

        public static AssetParentModel ToEntityModel(WSAssetParent wsAssetParent)
        {
            AssetParentModel result = new AssetParentModel();

            if (wsAssetParent != null)
            {
                result.Id = wsAssetParent.Id;
                result.Display = wsAssetParent.Display;
            }

            return result;
        }
    }
}
