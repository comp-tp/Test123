
using Accela.Apps.Apis.Models.DTOs.Requests.InspectionRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;

namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    public interface IInspectionBusinessEntity : IBusinessEntity
    {
        /// <summary>
        /// Get Inspection by criteria
        /// </summary>
        /// <param name="request">search inspection criteria</param>
        /// <returns>return inspections that match criteria</returns>
        InspectionsResponse GetInspections(InspectionsRequest request);

        /// <summary>
        /// Get Inspection By Id
        /// </summary>
        /// <param name="request">the request include inspection Id</param>
        /// <returns>return the inspection</returns>
        InspectionResponse GetInspection(InspectionRequest request);

        /// <summary>
        /// Update inspection. each record will be mark as action.
        /// the method difference updatejob. the updatejob serve with inspectorappservice.
        /// </summary>
        /// <param name="request">request that need updated inspection</param>
        /// <returns>return the keys after updated</returns>
        UpdateInspectionResponse UpdateInspection(UpdateInspectionRequest request);

        /// <summary>
        /// Reassign the Inseection.
        /// if record's key or display is null, then it need create record first
        /// </summary>
        /// <param name="request">inspection that need reassgin</param>
        /// <returns>return reassigned inspection</returns>
        ReassignInspectionResponse ReassignInspection(ReassignInspectionRequest request);

        /// <summary>
        /// Create Inspection
        /// if record's key or display is null, then it need create record first
        /// </summary>
        /// <param name="request">inspection that need create</param>
        /// <returns>return created inspection</returns>
        CreateInspectionResponse CreateInspection(CreateInspectionRequest request);

        /// <summary>
        /// Get Inspection Histories. in returned data model, it don't need checklist and 
        /// </summary>
        /// <param name="request">the condition for histories</param>
        /// <returns>all matched inspection histories</returns>
        InspectionsResponse GetInspectionHistories(InspectionsRequest request);
         
        /// <summary>
        /// Get RescheduleInspection
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        RescheduleInspectionResponse RescheduleInspection(RescheduleInspectionRequest request);

        CancelInspectionResponse CancelInspection(CancelInspectionRequest request);

        AvailableInspectionDatesResponse GetAvailableInspectionDates(AvailableInspectionDatesRequest request);
    }
}
