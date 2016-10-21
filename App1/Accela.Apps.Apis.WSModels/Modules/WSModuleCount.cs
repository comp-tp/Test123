using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.WSModels.Modules
{
    [DataContract(Name = "moduleCount")]
    public class WSModuleCount
    {
        [DataMember(Name = "moduleName", EmitDefaultValue = false)]
        public string ModuleName;

        [DataMember(Name = "count")]
        public int Count;

        public static List<WSModuleCount> FromEntityModels(List<ModuleModel> models)
        {
            List<WSModuleCount> result = null;

            if (models != null)
            {
                result = models.Select(p => FromEntityModel(p)).ToList();
            }

            return result;
        }

        public static WSModuleCount FromEntityModel(ModuleModel model)
        {
            WSModuleCount result = null;

            if (model != null)
            {
                result = new WSModuleCount()
                {
                    ModuleName = model.Key
                };

                int tempCount = 0;

                if (!String.IsNullOrWhiteSpace(model.Value) && int.TryParse(model.Value, out tempCount))
                {
                    result.Count = tempCount;
                }
            }

            return result;
        }
    }
}
