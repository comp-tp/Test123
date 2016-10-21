using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppChecklistItemStatusGroup : WSIdentifierBase
    {
        /// <summary>
        /// Gets or sets the check list item statuses.
        /// </summary>
        [DataMember(Name = "checklistItemStatuses", EmitDefaultValue = false)]
        public List<WSInspectorAppChecklistItemStatus> ChecklistItemStatuses { get; set; }

        public static ChecklistItemStatusGroup ToEntityModel(WSInspectorAppChecklistItemStatusGroup model)
        {
            ChecklistItemStatusGroup result = null;

            if (model != null)
            {
                result = new ChecklistItemStatusGroup()
                {
                    Identifier = model.Id,
                    Display = model.Display,
                    ChecklistItemStatuses = WSInspectorAppChecklistItemStatus.ToEntityModels(model.ChecklistItemStatuses)
                };
            }

            return result;
        }

        public static List<ChecklistItemStatusGroup> ToEntityModels(List<WSInspectorAppChecklistItemStatusGroup> models)
        {
            List<ChecklistItemStatusGroup> result = null;

            if (models != null && models.Count > 0)
            {
                result = new List<ChecklistItemStatusGroup>();
                foreach (var m in models)
                {
                    var entityModel = ToEntityModel(m);
                    result.Add(entityModel);
                }
            }

            return result;
        }

        public static WSInspectorAppChecklistItemStatusGroup FromEntityModel(ChecklistItemStatusGroup model)
        {
            WSInspectorAppChecklistItemStatusGroup result = null;

            if (model != null)
            {
                result = new WSInspectorAppChecklistItemStatusGroup()
                {
                    Id = model.Identifier,
                    Display = model.Display,
                    ChecklistItemStatuses = WSInspectorAppChecklistItemStatus.FromEntityModels(model.ChecklistItemStatuses)
                };
            }

            return result;
        }

        public static List<WSInspectorAppChecklistItemStatusGroup> FromEntityModels(List<ChecklistItemStatusGroup> models)
        {
            List<WSInspectorAppChecklistItemStatusGroup> result = null;

            if (models != null && models.Count > 0)
            {
                result = new List<WSInspectorAppChecklistItemStatusGroup>();
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
