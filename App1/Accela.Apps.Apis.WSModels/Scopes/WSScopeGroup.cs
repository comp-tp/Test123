using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Accela.Apps.Apis.Models.DomainModels.Scope;

namespace Accela.Apps.Apis.WSModels.Scopes
{
    [Serializable]
    [DataContract(Name = "scopeGroup")]
    public class WSScopeGroup
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public Guid Id { get; set; }

        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        [DataMember(Name = "createdBy", EmitDefaultValue = false)]
        public string CreatedBy { get; set; }

        [DataMember(Name = "createdDate", EmitDefaultValue = false)]
        public DateTime? CreatedDate { get; set; }

        [DataMember(Name = "lastUpdatedBy", EmitDefaultValue = false)]
        public string LastUpdatedBy { get; set; }

        [DataMember(Name = "lastUpdatedDate", EmitDefaultValue = false)]
        public DateTime? LastUpdatedDate { get; set; }

        public static WSScopeGroup FromBusinessEntity(ScopeGroupModel model)
        {
            WSScopeGroup result = null;

            if (model != null)
            {
                result = new WSScopeGroup()
                {
                    CreatedBy = model.CreatedBy,
                    CreatedDate = model.CreatedDate,
                    Description = model.Description,
                    Id = model.Id,
                    LastUpdatedBy = model.LastUpdatedBy,
                    LastUpdatedDate = model.LastUpdatedDate,
                    Name = model.Name
                };
            }

            return result;
        }

        public static List<WSScopeGroup> FromBusinessEntities(List<ScopeGroupModel> models)
        {
            List<WSScopeGroup> result = null;

            if (models != null)
            {
                result = new List<WSScopeGroup>();
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
