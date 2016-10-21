using Accela.Apps.Apis.Models.DTOs.Requests.ChecklistRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ChecklistResponses;

namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    /// <summary>
    /// ChecklistBusinessEntity interfaces.
    /// </summary>
    public interface IChecklistBusinessEntity : IBusinessEntity
    {
        /// <summary>
        /// Get checklist's groups.
        /// </summary>
        /// <param name="getChecklistGroupRequest">GetChecklistGroupRequest.</param>
        /// <returns>GetChecklistGroupResponse.</returns>
        GetChecklistGroupResponse GetChecklistGroups(GetChecklistGroupRequest getChecklistGroupRequest);

        /// <summary>
        /// Get checklist's groups.
        /// </summary>
        /// <returns></returns>
        GetChecklistGroupResponse GetChecklistGroups();

        /// <summary>
        /// Get checklist items.
        /// </summary>
        /// <param name="getChecklistItemRequest">GetChecklistItemRequest.</param>
        /// <returns>GetChecklistItemResponse.</returns>
        GetChecklistItemResponse GetChecklistItems(GetChecklistItemRequest getChecklistItemRequest);

        /// <summary>
        /// Get checklists.
        /// </summary>
        /// <param name="getChecklistRequest">GetChecklistRequest.</param>
        /// <returns>GetChecklistResponse.</returns>
        GetChecklistResponse GetChecklists(GetChecklistRequest getChecklistRequest);
    }
}
