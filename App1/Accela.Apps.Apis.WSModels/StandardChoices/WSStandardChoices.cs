using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;
using Accela.Apps.Apis.Models.DomainModels.StandardChoicesModels;

namespace Accela.Apps.Apis.WSModels.StandardChoices
{
    /// <summary>
    /// AssetUnitTypes info class.
    /// </summary>
    [DataContract(Name = "standardChoices")]
    public class WSStandardChoices
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
        /// <param name="wsStandardChoices">The WSAssetUnitTypes models.</param>
        /// <returns>AssetUnitTypesModel models.</returns>
        public static StandardChoicesModel[] ToEntityModels(WSStandardChoices[] wsStandardChoices)
        {
            if (wsStandardChoices == null)
            {
                return null;
            }

            var result = wsStandardChoices.Select(m => ToEntityModel(m)).ToArray();
            return result;
        }

        /// <summary>
        /// Froms the entity models.
        /// </summary>
        /// <param name="entityModels">The entity models.</param>
        /// <returns>the entity models.</returns>
        public static WSStandardChoices[] FromEntityModels(StandardChoicesModel[] entityModels)
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
        /// <param name="wsStandardChoice">WSAssetUnitTypes.</param>
        /// <returns>ConditioAssetUnitTypesModelnModel.</returns>
        public static StandardChoicesModel ToEntityModel(WSStandardChoices wsStandardChoice)
        {
            if (wsStandardChoice == null)
            {
                return null;
            }

            var result = new StandardChoicesModel()
            {
                Id = wsStandardChoice.Id,
                IdentifierDisplay = wsStandardChoice.IdentifDisplay,
                Type = wsStandardChoice.Type,
                Description = wsStandardChoice.Description,
            };

            return result;
        }

        /// <summary>
        /// Froms the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>the entity model.</returns>
        public static WSStandardChoices FromEntityModel(StandardChoicesModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSStandardChoices()
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
