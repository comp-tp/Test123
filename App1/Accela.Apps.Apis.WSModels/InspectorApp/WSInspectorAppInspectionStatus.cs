using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppInspectionStatus : WSIdentifierBase
    {
        /// <summary>
        /// Gets or sets the inspection statustype.
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        public static InspectionStatusModel ToEntityModel(WSInspectorAppInspectionStatus model)
        {
            InspectionStatusModel result = null;

            if (model != null)
            {
                result = new InspectionStatusModel()
                {
                    Identifier = model.Id,
                    Display = model.Display,
                    Type = model.Type
                };
            }

            return result;
        }

        public static List<InspectionStatusModel> ToEntityModels(List<WSInspectorAppInspectionStatus> models)
        {
            List<InspectionStatusModel> result = null;

            if (models != null && models.Count > 0)
            {
                result = new List<InspectionStatusModel>();
                foreach (var m in models)
                {
                    var entityModel = ToEntityModel(m);
                    result.Add(entityModel);
                }
            }

            return result;
        }

        public static WSInspectorAppInspectionStatus FromEntityModel(InspectionStatusModel model)
        {
            WSInspectorAppInspectionStatus result = null;

            if (model != null)
            {
                result = new WSInspectorAppInspectionStatus()
                {
                    Id = model.Identifier,
                    Display = model.Display,
                    Type = model.Type
                };
            }

            return result;
        }

        public static List<WSInspectorAppInspectionStatus> FromEntityModels(List<InspectionStatusModel> models)
        {
            List<WSInspectorAppInspectionStatus> result = null;

            if (models != null && models.Count > 0)
            {
                result = new List<WSInspectorAppInspectionStatus>();
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
