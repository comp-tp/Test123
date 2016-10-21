using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract(Name = "checklistItemStatusGroup")]
    public class WSChecklistItemStatusGroup : WSDataModel
    {
        /// <summary>
        /// Gets or sets the checklist item status group id.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the checklist item status group id display.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        /// <summary>
        /// Gets or sets the check list item statuses.
        /// </summary>
        [DataMember(Name = "checklistItemStatuses", EmitDefaultValue = false)]
        public List<WSChecklistItemStatus> ChecklistItemStatuses { get; set; }

        /// <summary>
        /// Toes the entity models.
        /// </summary>
        /// <param name="wsModels">The web service models.</param>
        /// <returns>the entity models.</returns>
        public static List<ChecklistItemStatusGroup> ToEntityModels(List<WSChecklistItemStatusGroup> wsModels)
        {
            if (wsModels == null)
            {
                return null;
            }

            var result = wsModels.Select(m => ToEntityModel(m)).ToList();
            return result;
        }

        /// <summary>
        /// Froms the entity models.
        /// </summary>
        /// <param name="entityModels">The entity models.</param>
        /// <returns>the entity models.</returns>
        public static List<WSChecklistItemStatusGroup> FromEntityModels(List<ChecklistItemStatusGroup> entityModels)
        {
            if (entityModels == null)
            {
                return null;
            }

            var result = entityModels.Select(m => FromEntityModel(m)).ToList();
            return result;
        }

        /// <summary>
        /// Toes the entity model.
        /// </summary>
        /// <param name="wsModel">The web service model.</param>
        /// <returns>The entity model.</returns>
        public static ChecklistItemStatusGroup ToEntityModel(WSChecklistItemStatusGroup wsModel)
        {
            if (wsModel == null)
            {
                return null;
            }

            var result = new ChecklistItemStatusGroup()
            {
                ChecklistItemStatuses = WSChecklistItemStatus.ToEntityModels(wsModel.ChecklistItemStatuses),
                Display = wsModel.Display,
                Identifier = wsModel.Id
            };

            return result;
        }

        /// <summary>
        /// Froms the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>the entity model.</returns>
        public static WSChecklistItemStatusGroup FromEntityModel(ChecklistItemStatusGroup entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSChecklistItemStatusGroup()
            {
                ChecklistItemStatuses = WSChecklistItemStatus.FromEntityModels(entityModel.ChecklistItemStatuses),
                Display = entityModel.Display,
                Id = entityModel.Identifier
            };

            return result;
        }
    }
}
