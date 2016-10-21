using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppChecklist : WSAction
    {
        /// <summary>
        /// Gets or sets the record type keys.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false, Order = 1)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the display for record type
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false, Order = 2)]
        public string Display { get; set; }

        /// <summary>
        /// Gets or sets the checklist Subject.
        /// </summary>
        [DataMember(Name = "subject", EmitDefaultValue = false)]
        public string Subject { get; set; }

        [DataMember(Name = "checklistGroups", EmitDefaultValue = false)]
        public List<WSInspectorAppChecklistGroup> ChecklistGroups { get; set; }

        /// <summary>
        /// The item is coresponse for id field in AMO
        /// </summary>
        [DataMember(Name = "label", EmitDefaultValue = false)]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the total score string.
        /// </summary>
        /// <value>
        /// The total score string.
        /// </value>
        [DataMember(Name = "totalScore", EmitDefaultValue = false)]
        public string TotalScore { get; set; }

        /// <summary>
        /// Checklist Items
        /// The item only use to translate between client and server
        /// </summary>
        [DataMember(Name = "checklistItems", EmitDefaultValue = false)]
        public List<WSInspectorAppChecklistItem> ChecklistItems { get; set; }

        public static ChecklistModel ToEntityModel(WSInspectorAppChecklist model)
        {
            ChecklistModel result = null;

            if (model != null)
            {
                result = new ChecklistModel()
                {
                    Action = model.Action,
                    ChecklistGroups = WSInspectorAppChecklistGroup.ToEntityModels(model.ChecklistGroups),
                    ChecklistItems = WSInspectorAppChecklistItem.ToEntityModels(model.ChecklistItems),
                    Identifier = model.Id,
                    Label = model.Label,
                    Subject = model.Subject,
                    TotalScore = model.TotalScore
                };
            }

            return result;
        }

        public static List<ChecklistModel> ToEntityModels(List<WSInspectorAppChecklist> models)
        {
            List<ChecklistModel> result = null;

            if (models != null && models.Count > 0)
            {
                result = new List<ChecklistModel>();
                foreach (var m in models)
                {
                    var entityModel = ToEntityModel(m);
                    result.Add(entityModel);
                }
            }

            return result;
        }

        public static WSInspectorAppChecklist FromEntityModel(ChecklistModel model)
        {
            WSInspectorAppChecklist result = null;

            if (model != null)
            {
                result = new WSInspectorAppChecklist()
                {
                    Action = model.Action,
                    ChecklistGroups = WSInspectorAppChecklistGroup.FromEntityModels(model.ChecklistGroups),
                    ChecklistItems = WSInspectorAppChecklistItem.FromEntityModels(model.ChecklistItems),
                    Id = model.Identifier,
                    Label = model.Label,
                    Subject = model.Subject,
                    TotalScore = model.TotalScore
                };
            }

            return result;
        }

        public static List<WSInspectorAppChecklist> FromEntityModels(List<ChecklistModel> models)
        {
            List<WSInspectorAppChecklist> result = null;

            if (models != null && models.Count > 0)
            {
                result = new List<WSInspectorAppChecklist>();
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
