using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppDescription : WSIdentifierBase
    {
        public static DescriptionModel ToEntityModel(WSInspectorAppDescription model)
        {
            DescriptionModel result = null;

            if (model != null)
            {
                result = new DescriptionModel()
                {
                    ID = model.Id,
                    Display = model.Display
                };
            }

            return result;
        }

        public static List<DescriptionModel> ToEntityModels(List<WSInspectorAppDescription> models)
        {
            List<DescriptionModel> result = null;

            if (models != null && models.Count > 0)
            {
                result = new List<DescriptionModel>();
                foreach (var m in models)
                {
                    var entityModel = ToEntityModel(m);
                    result.Add(entityModel);
                }
            }

            return result;
        }

        public static WSInspectorAppDescription FromEntityModel(DescriptionModel model)
        {
            WSInspectorAppDescription result = null;

            if (model != null)
            {
                result = new WSInspectorAppDescription()
                {
                    Id = model.ID,
                    Display = model.Display
                };
            }

            return result;
        }

        public static List<WSInspectorAppDescription> FromEntityModels(List<DescriptionModel> models)
        {
            List<WSInspectorAppDescription> result = null;

            if (models != null && models.Count > 0)
            {
                result = new List<WSInspectorAppDescription>();
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
