using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;
using Accela.Apps.Apis.Models.DTOs;

namespace Accela.Apps.Apis.Repositories.Interfaces
{
    public interface IChecklistRepository : IRepository
    {
        /// <summary>
        /// Get all check list.
        /// </summary>        
        /// <returns>Check list models.</returns>
        List<ChecklistModel> GetChecklists(int offset = 0, int limit = 0);

        /// <summary>
        /// Get all check list group.
        /// </summary>
        /// <param name="offset">Offset.</param>
        /// <param name="limit">Limit</param>
        /// <param name="pagination">Pagination</param>
        /// <returns>Check list group.</returns>
        List<ChecklistGroupModel> GetChecklistGroups(int offset, int limit, out Pagination pagination);

        /// <summary>
        /// Get checklist items by specific checklist ID.
        /// </summary>
        /// <param name="checklistID">Checklist ID.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="pagination">Pagination.</param>
        /// <returns>ChecklistItemModel list.</returns>
        List<ChecklistItemModel> GetChecklistItems(string checklistID, int offset, int limit, out Pagination pagination);

        /// <summary>
        /// Get checklists.
        /// </summary>
        /// <param name="groupID">Group ID.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="pagination">Pagination.</param>
        /// <returns>Checklist models.</returns>
        List<ChecklistModel> GetChecklists(string groupID, int offset, int limit, out Pagination pagination);

        ContextParameter Context { get; set; }
    }
}
