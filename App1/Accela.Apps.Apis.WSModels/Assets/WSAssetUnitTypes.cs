using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;

namespace Accela.Apps.Apis.WSModels.Assets
{
    /// <summary>
    /// AssetUnitTypes info class.
    /// </summary>
    [DataContract(Name="assetUnitType")]
    public class WSAssetUnitTypes : WSDataModel
    {
        /// <summary>
        /// Gets or Sets the wskey Key.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id {get; set;}

        /// <summary>
        /// Gets or Sets the wsidentifDisplay Key.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string IdentifDisplay {get; set;}

        /// <summary>
        /// Gets or Sets the wsenumeType Key.
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type {get; set;}

        /// <summary>
        /// Gets or Sets the wsdescription Key.
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description {get; set;}

        /// <summary>
        /// Toes the entity models.
        /// </summary>
        /// <param name="wsModels">The WSAssetUnitTypes models.</param>
        /// <returns>AssetUnitTypesModel models.</returns>
        public static AssetUnitTypesModel[] ToEntityModels(WSAssetUnitTypes[] wsModels)
        {
            if (wsModels == null)
            {
                return null;
            }

            var result = wsModels.Select(m => ToEntityModel(m)).ToArray();
            return result;
        }

        /// <summary>
        /// Froms the entity models.
        /// </summary>
        /// <param name="entityModels">The entity models.</param>
        /// <returns>the entity models.</returns>
        public static WSAssetUnitTypes[] FromEntityModels(AssetUnitTypesModel[] entityModels)
        {
            if (entityModels == null)
            {
                return null;
            }

            var result = entityModels.Select(m => FromEntityModel(m)).ToArray();
            return result;
        }


        /// <summary>
        /// Toes the entity model.
        /// </summary>
        /// <param name="wsModel">WSAssetUnitTypes.</param>
        /// <returns>ConditioAssetUnitTypesModelnModel.</returns>
        public static AssetUnitTypesModel ToEntityModel(WSAssetUnitTypes wsModel)
        {
            if (wsModel == null)
            {
                return null;
            }

            var result = new AssetUnitTypesModel()
            {
                Id = wsModel.Id,
                IdentifierDisplay = wsModel.IdentifDisplay,
                Type = wsModel.Type,
                Description = wsModel.Description,
            };

            return result;
        }

        /// <summary>
        /// Froms the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>the entity model.</returns>
        public static WSAssetUnitTypes FromEntityModel(AssetUnitTypesModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSAssetUnitTypes()
            {
               Id = entityModel.Id,
               IdentifDisplay = entityModel.IdentifierDisplay,
               Type = entityModel.Type,
               Description = entityModel.Description,
            };

            return result;
        }
    }
}
