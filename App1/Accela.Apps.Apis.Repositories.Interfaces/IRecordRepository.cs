using Accela.Apps.Apis.Models.DTOs.Requests.AddressRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.SummaryRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AddressResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.SummaryResponses;
using Accela.Apps.Shared.Contexts;

namespace Accela.Apps.Apis.Repositories.Interfaces
{
    public interface IRecordRepository
    {

        /// <summary>
        /// Current Agency Context
        /// </summary>
        IAgencyAppContext CurrentContext { get; } 

        /// <summary>
        /// Query records according request's criteria
        /// </summary>
        /// <param name="request">Records Request Object, include criteria and related system parameter</param>
        /// <returns>return matched record list</returns>
        RecordsResponse GetRecords(RecordsRequest request);

        /// <summary>
        /// Create Record 
        /// </summary>
        /// <param name="request">request include record that need created</param>
        /// <returns>return created record and related information</returns>
        CreateRecordResponse CreateRecord(CreateRecordRequest request);

        /// <summary>
        /// Update Record
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateRecordResponse UpdateRecord(UpdateRecordRequest request);

        /// <summary>
        /// Get Record Summary Information
        /// </summary>
        /// <param name="request">the request include record id that need search by</param>
        /// <returns>record record's summary information</returns>
        RecordSummaryResponse GetRecordSummary(RecordSummaryRequest request);

        WorkflowTasksResponse GetWorkflowTasks(WorkflowTasksRequest request);

        UpdateWorkflowTaskResponse UpdateWorkflowTask(UpdateWorkflowTaskRequest request);

        //RecordLocationResponse GetRecordLocation(RecordLocationRequest request);

        /// <summary>
        /// Get Record Contacts by record id
        /// </summary>
        /// <param name="request">wrap record id's object</param>
        /// <returns>return record contacts object</returns>
        RecordContactsResponse GetRecordContacts(RecordContactsRequest request);

        /// <summary>
        /// Get Record Addresses By record id
        /// </summary>
        /// <param name="request">wrap record id's object</param>
        /// <returns>return record addresses object</returns>
        AddressesResponse GetAddresses(AddressesRequest request);

        /// <summary>
        /// Counts the daily records.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the daily records count.</returns>
        DailyRecordsCountResponse CountDailyRecords(DailyRecordsCountRequest request);
    }
}
