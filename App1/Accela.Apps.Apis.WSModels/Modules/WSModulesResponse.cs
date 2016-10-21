using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;

namespace Accela.Apps.Apis.WSModels.Modules
{
    [DataContract(Name = "getModulesResponse")]
    public class WSModulesResponse : WSResponseBase
    {
        [DataMember(Name = "modules", EmitDefaultValue = false)]
        public List<WSModule> Modules { get; set; }

        /// <summary>
        /// Converts from the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>Web service owners response</returns>
        public static WSModulesResponse FromEntityModel(ModulesResponse entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSModulesResponse()
            {
                Modules = entityModel.Modules == null ? null : WSModule.FromEntityModels(entityModel.Modules)
            };

            return result;
        }
    }
}
