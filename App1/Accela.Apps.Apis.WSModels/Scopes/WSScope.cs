using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.Scope;

namespace Accela.Apps.Apis.WSModels.Scopes
{
    [Serializable]
    [DataContract(Name = "scope")]
    public class WSScope
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "scopeGroups", EmitDefaultValue = false)]
        public List<WSScopeGroup> ScopeGroups { get; set; }

        public static WSScope FromBusinessEntity(ScopeModel model)
        {
            WSScope result = null;

            if (model != null)
            {
                result = new WSScope()
                {
                    Name = model.Name,
                    ScopeGroups = WSScopeGroup.FromBusinessEntities(model.ScopeGroups)
                };
            }

            return result;
        }

        public static List<WSScope> FromBusinessEntities(List<ScopeModel> models)
        {
            List<WSScope> result = null;

            if (models != null)
            {
                result = new List<WSScope>();
                models.ForEach(p =>
                {
                    var tempModel = FromBusinessEntity(p);
                    result.Add(tempModel);
                });
            }

            return result;
        }
    }
}
