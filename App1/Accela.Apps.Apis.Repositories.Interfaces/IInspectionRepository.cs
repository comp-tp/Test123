using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;
using Accela.Apps.Apis.Models.DTOs.Requests.InspectionRequests;

//using Accela.Azure.Infrastructure.Authentication;

namespace Accela.Apps.Apis.Repositories.Interfaces
{
    public interface IInspectionRepository : IRepository
    {
        /// <summary>
        /// Clear specified user's cache so that client is able to get latest data from next access.
        /// </summary>
        /// <param name="refreshRequest">Refresh request model.</param>
        void RefreshData(RefreshRequest refreshRequest);

        /// <summary>
        /// Updates the inspection.
        /// it is difference Update Inspection is the job may have part of data.
        /// system will get inspection first then put client data into inspection
        /// </summary>
        /// <param name="inspectionRequest">InspectionRequest parameter.</param>
        /// <returns>Inspection response.</returns>
        InspectionResponse UpdateJob(InspectionRequest inspectionRequest);

        /// <summary>
        /// Gets list of Inspections
        /// </summary>
        /// <param name="cloudUser">Cloud User</param>
        /// <param name="pageIndex">Page start Index</param>
        /// <param name="pageSize">Number of items to return in paged collection</param>
        /// <returns></returns>
        JoblistResponse GetJobs(JoblistRequest request);

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

        /// <summary>
        /// Get Inspection By Criteria
        /// </summary>
        /// <param name="request">Inspection Criteria</param>
        /// <param name="conversionElement">need parse to local data model, if the parameter is null, then parse all element in inspection</param>
        /// <returns>return matched Insepction</returns>
        InspectionsResponse GetInspections(InspectionsRequest request, List<string> conversionElement);

        /// <summary>
        /// Update inspection. each record will be mark as action.
        /// the method difference updatejob. the updatejob serve with inspectorappservice.
        /// </summary>
        /// <param name="request">request that need updated inspection</param>
        /// <returns>return the keys after updated</returns>
        UpdateInspectionResponse UpdateInspection(UpdateInspectionRequest request);

        /// <summary>
        /// Create Inspection
        /// if record's key or display is null, then it need create record first
        /// </summary>
        /// <param name="request">inspection that need create</param>
        /// <returns>return created inspection</returns>
        CreateInspectionResponse CreateInspection(CreateInspectionRequest request);

        /// <summary>
        /// Reschedule Inspection
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        RescheduleInspectionResponse RescheduleInspection(RescheduleInspectionRequest request);

        /// <summary>
        /// reassign the inspection
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ReassignInspectionResponse ReassignInspection(ReassignInspectionRequest request);

        CancelInspectionResponse CancelInspection(CancelInspectionRequest request);

        AvailableInspectionDatesResponse GetAvailableInspectionDates(AvailableInspectionDatesRequest request);
    }
}
