using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;

namespace Accela.Apps.Apis.WSModels.Assets
{
    [DataContract(Name="assetStatus")]
    public class WSAssetStatus : WSDataModel
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

        /// <summary>
        /// Convert biz entity to response entity.
        /// </summary>
        /// <param name="recordStatus">Record status model.</param>
        /// <returns>Web service record status model.</returns>
        public static WSAssetStatus FromEntityModel(AssetStatusModel assetStatus)
        {
            if (assetStatus != null)
            {
                return new WSAssetStatus()
                {
                    Id = assetStatus.Id,
                    Display = assetStatus.Display
                };
            }
            return null;
        }

        /// <summary>
        /// From the entity models.
        /// </summary>
        /// <param name="entityModels">The entity models.</param>
        /// <returns>the entity models.</returns>
        public static WSAssetStatus[] FromEntityModels(AssetStatusModel[] entityModels)
        {
            if (entityModels == null)
            {
                return null;
            }

            var result = entityModels.Select(m => FromEntityModel(m)).ToArray();
            return result;
        }

        public static AssetStatusModel ToEntityModel(WSAssetStatus wsAssetStatus)
        {
            AssetStatusModel result = new AssetStatusModel();

            if (wsAssetStatus != null)
            {
                result.Id = wsAssetStatus.Id;
                result.Display = wsAssetStatus.Display;
            }

            return result;
        }
    }
}
