
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.InspectionRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;

namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    /// <summary>
    /// Job list business entity interface.
    /// </summary>
    public interface IJobBusinessEntity : IBusinessEntity
    {
        /// <summary>
        /// Gets user's Inspections Job List.
        /// </summary>
        /// <param name="cloudUser">CloudUser</param>
        /// <param name="pageIndex">Page start index. Used for paging.</param>
        /// <param name="pageSize">Number of items to return in paged collection.</param>
        /// <returns></returns>
        JoblistResponse GetJobList(JoblistRequest request);

        /// <summary>
        /// Clear specified user's cache so that client is able to get latest data from next access.
        /// </summary>
        /// <param name="refreshRequest">Refresh request model.</param>
        void RefreshData(RefreshRequest refreshRequest);

        /// <summary>
        /// Updates the inspection.
        /// </summary>
        /// <param name="inspectionRequest">InspectionRequest parameter.</param>
        /// <returns>Inspection response.</returns>
        InspectionResponse UpdateJob(InspectionRequest inspectionRequest);

        /// <summary>
        /// Gets the inspetion comments.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="inspectionId">The inspection id.</param>
        /// <returns>the inspetion comments.</returns>
        InspectionCommentResponse GetInspetionComments(InspectionCommentRequest request);

        /// <summary>
        /// Gets the checklists.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="inspectionId">The inspection id.</param>
        /// <param name="pageIndex">The page index.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>the checklists.</returns>
        InspectionChecklistResponse GetChecklists(InspectionChecklistRequest request);

        /// <summary>
        /// Gets the checklist items.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="inspectionId">The inspection id.</param>
        /// <param name="checklistId">The checklist id.</param>
        /// <param name="pageIndex">The page index.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>the checklist items.</returns>
        InspectionChecklistItemResponse GetChecklistItems(InspectionChecklistItemRequest request);
    }
}
