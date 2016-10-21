using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract(Name = "scheduleChecklist")]
    public class WSScheduleChecklist : WSChecklist
    {
        /// <summary>
        /// Checklist Items
        /// The item only use to translate between client and server
        /// </summary>
        [DataMember(Name = "checklistItems", EmitDefaultValue = false)]
        public List<WSScheduleChecklistItem> ChecklistItems { get; set; }

        /// <summary>
        /// Toes the entity models.
        /// </summary>
        /// <param name="wsModels">The web service models.</param>
        /// <returns>the entity models.</returns>
        public static List<ChecklistModel> ToEntityModels(List<WSScheduleChecklist> wsModels)
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
        public new static List<WSScheduleChecklist> FromEntityModels(List<ChecklistModel> entityModels)
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
        public static ChecklistModel ToEntityModel(WSScheduleChecklist wsModel)
        {
            if (wsModel == null)
            {
                return null;
            }

            var result = WSChecklist.ToEntityModel(wsModel);
            result.ChecklistItems = WSScheduleChecklistItem.ToEntityModels(wsModel.ChecklistItems);

            return result;
        }

        /// <summary>
        /// Froms the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>the entity model.</returns>
        public new static WSScheduleChecklist FromEntityModel(ChecklistModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = WSChecklist.FromEntityModel(entityModel) as WSScheduleChecklist;
            result.ChecklistItems = WSScheduleChecklistItem.FromEntityModels(entityModel.ChecklistItems);

            return result;
        }
    }
}
