using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract(Name = "scheduleChecklistItem")]
    public class WSScheduleChecklistItem : WSChecklistItem
    {
        /// <summary>
        /// Gets or sets the Additional Visible
        /// </summary>
        [DataMember(Name = "additionalVisible")]
        public bool AdditionalVisible { get; set; }

        /// <summary>
        /// Gets or sets the additionoal information.
        /// </summary>
        /// <value>
        /// The additional info.
        /// </value>
        //[DataMember(Name = "asis")]
        //public List<WSASI> ASIs { get; set; }

        /// <summary>
        /// Gets or sets the additionoal information.
        /// </summary>
        /// <value>
        /// The additional info.
        /// </value>
        //[DataMember(Name = "asits")]
        //public List<WSASIT> ASITs { get; set; }

        /// <summary>
        /// Toes the entity models.
        /// </summary>
        /// <param name="wsModels">The web service models.</param>
        /// <returns>the entity models.</returns>
        public static List<ChecklistItemModel> ToEntityModels(List<WSScheduleChecklistItem> wsModels)
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
        public new static List<WSScheduleChecklistItem> FromEntityModels(List<ChecklistItemModel> entityModels)
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
        public static ChecklistItemModel ToEntityModel(WSScheduleChecklistItem wsModel)
        {
            if (wsModel == null)
            {
                return null;
            }

            var result = WSChecklistItem.ToEntityModel(wsModel);
            result.AdditionalVisible = wsModel.AdditionalVisible;

            return result;
        }

        /// <summary>
        /// Froms the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>the entity model.</returns>
        public new static WSScheduleChecklistItem FromEntityModel(ChecklistItemModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = WSChecklistItem.FromEntityModel(entityModel) as WSScheduleChecklistItem;
            result.AdditionalVisible = entityModel.AdditionalVisible;

            return result;
        }
    }
}
