using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppInspector : WSIdentifierBase
    {
        /// <summary>
        /// Gets or sets the display.
        /// </summary>
        /// <value>
        /// The display.
        /// </value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name
        {
            get;
            set;
        }

        public static InspectorModel ToEntityModel(WSInspectorAppInspector model)
        {
            InspectorModel result = null;

            if (model != null)
            {
                result = new InspectorModel()
                {
                    Identifier = model.Id,
                    Name = model.Name
                };
            }

            return result;
        }

        public static List<InspectorModel> ToEntityModels(List<WSInspectorAppInspector> models)
        {
            List<InspectorModel> result = null;

            if (models != null && models.Count > 0)
            {
                result = new List<InspectorModel>();
                foreach (var m in models)
                {
                    var entityModel = ToEntityModel(m);
                    result.Add(entityModel);
                }
            }

            return result;
        }

        public static WSInspectorAppInspector FromEntityModel(InspectorModel model)
        {
            WSInspectorAppInspector result = null;

            if (model != null)
            {
                result = new WSInspectorAppInspector()
                {
                    Id = model.Identifier,
                    Name = model.Name
                };
            }

            return result;
        }

        public static List<WSInspectorAppInspector> FromEntityModels(List<InspectorModel> models)
        {
            List<WSInspectorAppInspector> result = null;

            if (models != null && models.Count > 0)
            {
                result = new List<WSInspectorAppInspector>();
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
