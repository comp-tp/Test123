using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppChecklistItemStatus : WSIdentifierBase
    {
        /// <summary>
        /// Gets or sets the inspection statustype.
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the default score string.
        /// </summary>
        /// <value>
        /// The default score string.
        /// </value>
        [DataMember(Name = "defaultScore")]
        public string DefaultScore { get; set; }

        public static ChecklistItemStatus ToEntityModel(WSInspectorAppChecklistItemStatus model)
        {
            ChecklistItemStatus result = null;

            if (model != null)
            {
                result = new ChecklistItemStatus()
                {
                    Identifier = model.Id,
                    Display = model.Display,
                    DefaultScore = model.DefaultScore,
                    Type = model.Type
                };
            }

            return result;
        }

        public static List<ChecklistItemStatus> ToEntityModels(List<WSInspectorAppChecklistItemStatus> models)
        {
            List<ChecklistItemStatus> result = null;

            if (models != null && models.Count > 0)
            {
                result = new List<ChecklistItemStatus>();
                foreach (var m in models)
                {
                    var entityModel = ToEntityModel(m);
                    result.Add(entityModel);
                }
            }

            return result;
        }

        public static WSInspectorAppChecklistItemStatus FromEntityModel(ChecklistItemStatus model)
        {
            WSInspectorAppChecklistItemStatus result = null;

            if (model != null)
            {
                result = new WSInspectorAppChecklistItemStatus()
                {
                    Id = model.Identifier,
                    Display = model.Display,
                    DefaultScore = model.DefaultScore,
                    Type = model.Type
                };
            }

            return result;
        }

        public static List<WSInspectorAppChecklistItemStatus> FromEntityModels(List<ChecklistItemStatus> models)
        {
            List<WSInspectorAppChecklistItemStatus> result = null;

            if (models != null && models.Count > 0)
            {
                result = new List<WSInspectorAppChecklistItemStatus>();
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
