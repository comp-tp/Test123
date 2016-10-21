using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.WSModels.Modules
{
    [DataContract(Name = "module")]
    public class WSModule
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id;

        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display;

        public static List<string> GetKeysFromEntityModels(List<ModuleModel> entityModels)
        {
            if (entityModels == null)
            {
                return null;
            }

            var result = entityModels.Select(m => m.Key).ToList();
            return result;
        }

        public static List<WSModule> FromEntityModels(List<ModuleModel> entityModels)
        {
            if (entityModels == null)
            {
                return null;
            }

            var result = entityModels.Select(m => FromEntityModel(m)).ToList();
            return result;
        }

        /// <summary>
        /// Froms the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>the entity model.</returns>
        public static WSModule FromEntityModel(ModuleModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSModule()
            {
                Id = entityModel.Key,

                //TODO: there is a bug in GovXml2, with no module value returned, so set the Display to the value of Key property temporarily.
                Display = entityModel.Key
            };

            return result;
        }
    }
}
