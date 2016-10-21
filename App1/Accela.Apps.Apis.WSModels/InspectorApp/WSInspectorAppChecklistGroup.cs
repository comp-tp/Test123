using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppChecklistGroup : WSIdentifierBase
    {
        public static ChecklistGroupModel ToEntityModel(WSInspectorAppChecklistGroup model)
        {
            ChecklistGroupModel result = null;

            if (model != null)
            {
                result = new ChecklistGroupModel()
                {
                    Identifier = model.Id,
                    Display = model.Display
                };
            }

            return result;
        }

        public static List<ChecklistGroupModel> ToEntityModels(List<WSInspectorAppChecklistGroup> models)
        {
            List<ChecklistGroupModel> result = null;

            if (models != null && models.Count > 0)
            {
                result = new List<ChecklistGroupModel>();
                foreach (var m in models)
                {
                    var entityModel = ToEntityModel(m);
                    result.Add(entityModel);
                }
            }

            return result;
        }

        public static WSInspectorAppChecklistGroup FromEntityModel(ChecklistGroupModel model)
        {
            WSInspectorAppChecklistGroup result = null;

            if (model != null)
            {
                result = new WSInspectorAppChecklistGroup()
                {
                    Id = model.Identifier,
                    Display = model.Display
                };
            }

            return result;
        }

        public static List<WSInspectorAppChecklistGroup> FromEntityModels(List<ChecklistGroupModel> models)
        {
            List<WSInspectorAppChecklistGroup> result = null;

            if (models != null && models.Count > 0)
            {
                result = new List<WSInspectorAppChecklistGroup>();
                foreach (var m in models)
                {
                    var entityModel = FromEntityModel(m);
                    result.Add(entityModel);
                }
            }

            return result;
        }
    }
}
