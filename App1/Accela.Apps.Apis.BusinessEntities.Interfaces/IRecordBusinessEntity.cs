using Accela.Apps.Apis.Models.DTOs.Requests.AddressRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.CostRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.ParcelRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.ReferenceRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.SummaryRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AddressResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.CommonResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.CostResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.ParcelResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.SummaryResponses;
using Accela.Apps.Shared.Contexts;

namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    public interface IRecordBusinessEntity : IBusinessEntity
    {
        /// <summary>
        /// Query records according request's criteria
        /// </summary>
        /// <param name="request">Records Request Object, include criteria and related system parameter</param>
        /// <returns>return matched record list</returns>
        //RecordsResponse GetRecords(RecordsRequest request);
        RecordsResponse GetRecords(RecordsRequest request, IAgencyAppContext context);

        /// <summary>
        /// get record by id
        /// </summary>
        /// <param name="request">the request include record id and  related system parameter</param>
        /// <returns>return matched record object</returns>
        RecordResponse GetRecord(RecordRequest request);

        /// <summary>
        /// Get record by id.
        /// </summary>
        /// <param name="recordId">Record Id.</param>
        /// <returns>Record.</returns>
        RecordsResponse GetRecordById(string recordId);

        /// <summary>
        /// Create record according passed record
        /// </summary>
        /// <param name="request">the record comming from client</param>
        /// <param name="needMakeUpCoordinates">indicates if need make up coordinates, true: needed, false: not needed</param>
        /// <returns>
        /// return created record
        /// </returns>
        CreateRecordResponse CreateRecord(CreateRecordRequest request, IAgencyAppContext context, bool needMakeUpCoordinates = true);

        /// <summary>
        /// UpdateRecord
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateRecordResponse UpdateRecord(UpdateRecordRequest request);

        /// <summary>
        /// Get Condition summary of record
        /// </summary>
        /// <param name="request">the record id</param>
        /// <returns>return summary information</returns>
        ConditionSummaryResponse GetConditionSummary(ConditionSummaryRequest request);

        /// <summary>
        /// Get inspection summary of record
        /// </summary>
        /// <param name="request">the record id</param>
        /// <returns>return summary information</returns>
        InspectionSummaryResponse GetInspectionSummary(InspectionSummaryRequest request);

        /// <summary>
        /// Get workflow summary of record
        /// </summary>
        /// <param name="request">the record id</param>
        /// <returns>return summary information</returns>
        WorkflowSummaryResponse GetWorkflowSummary(WorkflowSummaryRequest request);

        /// <summary>
        /// Get fee summary of record
        /// </summary>
        /// <param name="request">the record id</param>
        /// <returns>return summary information</returns>
        FeeSummaryResponse GetFeeSummary(FeeSummaryRequest request);

        /// <summary>
        /// Get contact summary of record
        /// </summary>
        /// <param name="request">the record id</param>
        /// <returns>return summary information</returns>
        ContactSummaryResponse GetContactSummary(ContactSummaryRequest request);

        /// <summary>
        /// Gets the project informations.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the project informations.</returns>
        ProjectInformationResponse GetProjectInformations(ProjectInformationRequest request);

        /// <summary>
        /// Get Record's contact
        /// </summary>
        /// <param name="request">the record id in request</param>
        /// <returns>return the contact that below to record</returns>
        ContactsResponse GetRecordContacts(ContactsRequest request);

        /// <summary>
        /// Gets the record owners.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the record owners.</returns>
        RecordOwnersResponse GetRecordOwners(RecordOwnersRequest request);

        /// <summary>
        /// Gets the record contact.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the record contact.</returns>
        RecordContactsResponse GetRecordContacts(RecordContactsRequest request);

        /// <summary>
        /// Get Record's condition
        /// </summary>
        /// <param name="request">the record id in request</param>
        /// <returns>return the condition that below to record</returns>
        ConditionsResponse GetRecordConditions(ConditionsRequest request);

        /// <summary>
        /// Gets the record inspections.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the record inspections.</returns>
        RecordInspectionsResponse GetRecordInspections(RecordInspectionsRequest request);

        /// <summary>     
        /// Returns a collection of the corresponding addresses of the given record.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AddressesResponse GetAddresses(AddressesRequest request);

        /// <summary>
        /// Get Record's parcels
        /// </summary>
        /// <param name="request">the record id in request</param>
        /// <returns>return the parcel that below to record</returns>
        ParcelsResponse GetRecordParcels(ParcelsRequest request); 

        /// <summary>
        /// Get Record's costs.
        /// </summary>
        /// <param name="request">CostsRequest.</param>
        /// <returns>CostsResponse.</returns>
        CostsResponse GetRecordCosts(CostsRequest request);

        /// <summary>
        /// Get record's additionals 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AdditionalResponse GetRecordAdditionals(AdditionalRequest request);

        AdditionalResponse GetAllRecordAdditionals(AdditionalRequest request);

        /// <summary>
        /// Get record's additional tables 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AdditionalTableResponse GetRecordAdditionalTables(AdditionalTableRequest request);

        AdditionalTableResponse GetAllRecordAdditionalTables(AdditionalTableRequest request);

        /// <summary>
        /// Get Record's parts
        /// </summary>
        /// <param name="request">the record id in request</param>
        /// <returns>return the part that below to record</returns>
        PartsResponse GetRecordParts(PartsRequest request);

        /// <summary>
        /// Returns a list of related records of the specific record.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        RelatedRecordsResponse GetRelatedRecords(RelatedRecordsRequest request);

       /// <summary>
       /// Get record's assets.
       /// </summary>
        /// <param name="recordAssetsRequest">RecordAssetsRequest.</param>
        /// <returns>RecordAssetsResponse.</returns>
        RecordAssetsResponse GetRecordAssets(RecordAssetsRequest recordAssetsRequest);

        /// <summary>
        /// Gets the record comment.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the record comment.</returns>
        RecordCommentsResponse  GetRecordComments(RecordCommentsRequest request);

        WorkflowTasksResponse GetWorkflowTasks(WorkflowTasksRequest request);

        UpdateWorkflowTaskResponse UpdateWorkflowTask(UpdateWorkflowTaskRequest request);

        RecordLocationResponse GetRecordLocation(RecordLocationRequest request);

        /// <summary>
        /// Get work order tasks by record id
        /// </summary>
        /// <param name="request">the paramenter include record id</param>
        /// <returns>return the record's work order tasks</returns>
        WorkOrderTasksResponse GetWorkOrderTasks(WorkOrderTasksRequest request);

        /// <summary>
        /// Counts the daily records.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the daily records count.</returns>
        DailyRecordsCountResponse CountDailyRecords(DailyRecordsCountRequest request);

        RecordsGeoResponse GetRecordsViaCivicId(RecordsGeoRequest request);

        DrillDownValuesResponse GetASIDrillDownValues(DrillDownValuesRequest request);

        DrillDownValuesResponse GetASIDrillDownValuesForParent(DrillDownValuesRequest request);

        DrillDownValuesResponse GetASITDrillDownValues(DrillDownValuesRequest request);

        DrillDownValuesResponse GetASITDrillDownValuesForParent(DrillDownValuesRequest request);

        RecordsLocationResponse GetRecordsLocation(RecordLocationRequest request);
    }
}
