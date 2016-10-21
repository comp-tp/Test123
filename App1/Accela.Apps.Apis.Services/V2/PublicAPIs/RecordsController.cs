using System;
using System.Collections.Generic;
using System.Web.Http;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Requests.AddressRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.AttachmentRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.CitizenCommentRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.CostRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.ParcelRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.ReferenceRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.SummaryRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AddressResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.AttachmentResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.CitizenCommentResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.CommonResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.CostResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.ParcelResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.SummaryResponses;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Apis.WSModels.Addresses;
using Accela.Apps.Apis.WSModels.ASIs;
using Accela.Apps.Apis.WSModels.Comments;
using Accela.Apps.Apis.WSModels.Documents;
using Accela.Apps.Apis.WSModels.Owners;
using Accela.Apps.Apis.WSModels.Parcels;
using Accela.Apps.Apis.WSModels.Parts;
using Accela.Apps.Apis.WSModels.RecordAssets;
using Accela.Apps.Apis.WSModels.RecordComments;
using Accela.Apps.Apis.WSModels.RecordConditions;
using Accela.Apps.Apis.WSModels.RecordContacts;
using Accela.Apps.Apis.WSModels.RecordCosts;
using Accela.Apps.Apis.WSModels.RecordInspections;
using Accela.Apps.Apis.WSModels.RecordLocation;
using Accela.Apps.Apis.WSModels.Records;
using Accela.Apps.Apis.WSModels.RecordSummary;
using Accela.Apps.Apis.WSModels.RelatedRecords;
using Accela.Apps.Apis.WSModels.V1.WorkOrderTasks;
using Accela.Apps.Apis.WSModels.Workflow;
using Accela.Apps.Shared;

using System.Web.Http;
using Accela.Apps.Apis.WSModels.Location;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Apis.Services.Handlers.Models;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v3/records")]
    [APIControllerInfoAttribute(Name = "Records", Group = "Entities", Order = 14, Description = "The APIs are exposed to record apps.")]
    public class RecordsController : ControllerBase
    {
        private const string RECORD = "CAP";

        //private static Dictionary<string, object> MakeConstructorParameters()
        //{
        //    Dictionary<string, object> tmpParams = new Dictionary<string, object>();

        //    tmpParams.Add("appId", Context.App);
        //    tmpParams.Add("agencyName", Context.Agency);
        //    tmpParams.Add("serviceProvCode", Context.ServProvCode);
        //    tmpParams.Add("agencyUserId", Context.CurrentUser.Id.ToString());
        //    tmpParams.Add("agencyUsername", Context.LoginName);
        //    tmpParams.Add("token", Context.SocialToken);
        //    tmpParams.Add("environmentName", Context.EnvName);
        //    tmpParams.Add("language", Context.Language);

        //    return tmpParams;
        //}

        //private IRecordBusinessEntity _recordBusinessEntity = null;
        private readonly IRecordBusinessEntity recordBusinessEntity;
        //{
        //    get
        //    {
        //        if (_recordBusinessEntity == null)
        //        {
        //            Dictionary<string, object> ctorParams = MakeConstructorParameters();
        //            _recordBusinessEntity = IocContainer.Resolve<IRecordBusinessEntity>(ctorParams);
        //        }

        //        return _recordBusinessEntity;
        //    }
        //}


        private readonly IGlobalEntityBusinessEntity globalEntityBusinessEntity;
        //{
        //    get
        //    {
        //        return IocContainer.Resolve<IGlobalEntityBusinessEntity>();
        //    }
        //}

       

        private readonly IAgencyAppContext agencyContext;
        public RecordsController(IRecordBusinessEntity recordBusinessEntity, IGlobalEntityBusinessEntity globalEntityBusinessEntity, IAgencyAppContext agencyContext)
        {
            this.recordBusinessEntity = recordBusinessEntity;
            this.globalEntityBusinessEntity = globalEntityBusinessEntity;
            this.agencyContext = agencyContext;
        }

        [Route("")]
        [APIActionInfoAttribute(Name = "Simple Search Records", Order = 7, Scope = "get_records", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves records matching the query parameters.")]
        public WSRecordsResponse GetRecords(string lang = null, string expand = null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST, string recordTypeIds = null, string recordStatusIds = null, string scheduledDateRange = null, string openedDateRange = null, string aliases = null, string staffIds = null, string module = null)
        {

            RecordsRequest request = new RecordsRequest();
            SetPageRangeToRequest(request, offset, limit);

            request.Criteria = new RecordCriteria();
            request.Criteria.ReturnElements = GetReturnElements(expand);
            request.Criteria.Module = module;
            request.Criteria.RecordTypeIds = SpliteIdsToList(recordTypeIds);
            request.Criteria.RecordStatusIds = SpliteIdsToList(recordStatusIds);
            request.Criteria.StaffIds = SpliteIdsToList(staffIds);
            request.Method = RecordsRequest.Methods.GetRecords.ToString();

            string[] schRange = SpliteDateRange(scheduledDateRange);
            request.Criteria.RecordScheduledDateFrom = schRange[0];
            request.Criteria.RecordScheduledDateTo = schRange[1];

            string[] openRange = SpliteDateRange(openedDateRange);
            request.Criteria.OpenedDateFrom = openRange[0];
            request.Criteria.OpenedDateTo = openRange[1];

            request.Criteria.Displays = SpliteIdsToList(aliases);

            var recordsResponse = ExcuteV1_2<RecordsResponse, RecordsRequest>(
                                    (o) =>
                                    {
                                        return this.recordBusinessEntity.GetRecords(o, agencyContext);
                                    },
                                    request);

            return WSRecordsResponse.FromEntityModel(recordsResponse);
        }

        

        [Route("{ids}")]
        [APIActionInfoAttribute(Name = "Get Records By Ids", Order = 9, Scope = "get_record", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves records by record IDs and other parameters (optional).")]
        public WSRecordsResponseNoPaging GetRecordsByIds(string ids, string expand = null, string lang = null)
        {
            var originalId = ParseUID(ids, agencyContext);

            RecordsRequest request = new RecordsRequest();
            request.Criteria = new RecordCriteria();
            request.Criteria.ReturnElements = GetReturnElements(expand);
            //request.Criteria.RecordIds = SpliteIdsToList(ids);
            request.Criteria.RecordIds = SpliteIdsToList(originalId);

            request.Method = RecordsRequest.Methods.GetRecordsByIds.ToString();

            var RecordsResponse = ExcuteV1_2<RecordsResponse, RecordsRequest>(
                                    (o) =>
                                    {
                                        //return _recordBusinessEntity.GetRecords(o);
                                        return this.recordBusinessEntity.GetRecords(o, agencyContext);
                                    },
                                    request);

            return WSRecordsResponseNoPaging.FromEntityModel(RecordsResponse);

        }

        [Route("{id}/owners")]
        [APIActionInfoAttribute(Name = "Get Record's Owners", Order = 20, Scope = "get_record_owners", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves owners for the record by record ID and other parameters (optional).")]
        public WSRecordOwnersResponse GetOwners(string id, string lang = null)
        {
            var originalId = ParseUID(id, agencyContext);
            var request = new RecordOwnersRequest();
            request.RecordId = originalId;

            var tempResult = ExcuteV1_2<RecordOwnersResponse, RecordOwnersRequest>(
                (o) =>
                {
                    return this.recordBusinessEntity.GetRecordOwners(o);
                },
                request);
            var result = WSRecordOwnersResponse.FromEntityModel(tempResult);
            return result;

        }

        [Route("{id}/contacts")]
        [APIActionInfoAttribute(Name = "Get Record's Contacts", Order = 16, Scope = "get_record_contacts", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves contacts for the given record.")]
        public WSRecordContactsResponse GetContacts(string id, string lang = null)
        {
            var originalId = ParseUID(id, agencyContext);
            
            var request = new RecordContactsRequest();
            request.RecordId = originalId;

            var tempResult = ExcuteV1_2<RecordContactsResponse, RecordContactsRequest>(
                (o) =>
                {
                    return this.recordBusinessEntity.GetRecordContacts(o);
                },
                request);

            var result = WSRecordContactsResponse.FromEntityModel(tempResult);
            return result;

        }

        [HttpPut]
        [Route("{id}")]
        [APIActionInfoAttribute(Name = "Update Record", Order = 32, Scope = "update_record", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Updates the records and the subobjects. You can do three kinds of operations on the subobjects, namely, CREATE, UPDATE, and DELETE. If you want to add a parcel to a record, set the entityState of the subobject to Added; if you want to update an existing parcel, set the entityState of the subobject to Updated; if you want to delete a parcel, set the entityState of the subobject to Deleted.")]
        public WSUpdateRecordResponse UpdateRecord([FromBody]WSUpdateRecordRequest request, string id = null, string lang = null)
        {
            var originalId = ParseUID(id, agencyContext);
            var updateRecordRequest = WSUpdateRecordRequest.ToEntityModel(request);
            updateRecordRequest.Record.Identifier = originalId;

            var updateRecordResponse = ExcuteV1_2<UpdateRecordResponse, UpdateRecordRequest>(
                (o) =>
                {
                    return this.recordBusinessEntity.UpdateRecord(o);
                }, updateRecordRequest);

            return WSUpdateRecordResponse.FromEntityModel(updateRecordResponse);

        }

        [HttpPost]
        [Route("")]
        [APIActionInfoAttribute(Name = "Create Record", Order = 29, Scope = "create_record", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Creates a record with addresses, comments, contacts, GIS objects, parcels, additional information, and additional information tables. You can get the additional information and additional information tables by using the URI /system/record/type/{id}/asi and /system/record/type/{id}/asit. Note: Set the entityState property of the subobjects to Added when creating a record.")]
        public WSCreateRecordResponse CreateRecord([FromBody]WSCreateRecordRequest request, string lang = null)
        {
            var createRecordRequest = new CreateRecordRequest();
            createRecordRequest.Record = new RecordModel();
            
            // special temp bug fix for code enforcement app -- 14ACC-01454: create case fail if client passes incomplete gisobject
            // solution remove gisObject if gis data is incomplete and it is accela App.
            string appName = agencyContext.AppName == null ? String.Empty : agencyContext.AppName.ToLower();

            if (appName.Contains("accela") && request != null && request.WSCreateRecord != null 
                && request.WSCreateRecord.GISObjects != null 
                && request.WSCreateRecord.GISObjects.Count > 0)
            {
                 var newGisObjects = new List<WSGISObject>();

                // only add valid gis object
                foreach(var gis in request.WSCreateRecord.GISObjects)
                {
                    if(gis != null 
                        && !String.IsNullOrWhiteSpace(gis.MapService)
                        && !String.IsNullOrWhiteSpace(gis.LayerId)
                        && !String.IsNullOrWhiteSpace(gis.FeatureId)
                        && !String.IsNullOrWhiteSpace(gis.EntityState)                      
                        )
                    {
                        newGisObjects.Add(gis);
                    }
                }

                request.WSCreateRecord.GISObjects = newGisObjects;
            }

            WSCreateRecordRequest.ToEntityModel(createRecordRequest, request);

            var createRecordResponse = ExcuteV1_2<CreateRecordResponse, CreateRecordRequest>(
                                        (o) =>
                                        {
                                            return this.recordBusinessEntity.CreateRecord(o, agencyContext);
                                        }, createRecordRequest);

            return WSCreateRecordResponse.FromEntityModel(createRecordResponse);

        }

        [Route("{id}/addresses")]
        [APIActionInfoAttribute(Name = "Get Record's Addresses", Order = 12, Scope = "get_record_addresses", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves addresses for the record.")]
        public WSAddressesResponse GetAddresses(string id, string lang = null)
        {

            var originalId = ParseUID(id, agencyContext);
            AddressesRequest request = new AddressesRequest();
            request.RecordId = originalId;

            var entityResult = ExcuteV1_2<AddressesResponse, AddressesRequest>(
                                (o) =>
                                {
                                    return this.recordBusinessEntity.GetAddresses(o);
                                },
                                request);

            return WSAddressesResponse.FromEntityModel(entityResult);

        }

        [Route("{id}/asis")]
        [APIActionInfoAttribute(Name = "Get Record's ASI", Order=10, Scope = "get_record_asis", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves additional information about the record.")]
        public WSASIResponse GetRecordAdditionals(string id, string lang = null)
        {
            var originalId = ParseUID(id, agencyContext);
            var request = new AdditionalRequest();
            request.RelatedId = originalId;

            AdditionalResponse response = ExcuteV1_2<AdditionalResponse, AdditionalRequest>(
                (o) =>
                {
                    return this.recordBusinessEntity.GetRecordAdditionals(o);
                },
                request);

            return WSASIResponse.FromEntityModel(response);


        }

        [Route("{id}/asits")]
        [APIActionInfoAttribute(Name = "Get Record's ASIT", Order = 11, Scope = "get_record_asits", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves additional information tables for the record.")]
        public WSASITResponse GetRecordASIT(string id, string lang = null)
        {
            var originalId = ParseUID(id, agencyContext);
            var request = new AdditionalTableRequest();
            request.RelatedId = originalId;

            AdditionalTableResponse response = ExcuteV1_2<AdditionalTableResponse, AdditionalTableRequest>(
                (o) =>
                {
                    return this.recordBusinessEntity.GetRecordAdditionalTables(o);
                },
                request);

            return WSASITResponse.FromEntityModel(response);

        }

        [Route("{id}/parcels")]
        [APIActionInfoAttribute(Name = "Get Record's Parcels", Order = 21, Scope = "get_record_parcels", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves parcels for the record by record ID and other parameters (optional).")]
        public WSParcelsResponse GetParcels(string id, string lang = null)
        {
            var originalId = ParseUID(id, agencyContext);
            ParcelsRequest request = new ParcelsRequest();
            request.Criteria = new ParcelCriteria();
            request.Criteria.RecordId = originalId;

            var response = ExcuteV1_2<ParcelsResponse, ParcelsRequest>(
                (o) =>
                {
                    return this.recordBusinessEntity.GetRecordParcels(o);
                },
                request);

            return WSParcelsResponse.FromEntityModel(response);

        }

        [Route("{id}/costs")]
        [APIActionInfoAttribute(Name = "Get Record's Costs", Order = 24, Scope = "get_record_costs", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves the cost for the record by record ID and other parameters (optional).")]
        public WSCostsResponse GetCosts(string id, string lang = null)
        {
            var originalId = ParseUID(id, agencyContext);
            var request = new CostsRequest();
            request.RecordId = originalId;

            var response = ExcuteV1_2<CostsResponse, CostsRequest>(
                (o) =>
                {
                    return this.recordBusinessEntity.GetRecordCosts(o);
                },
                request);

            return WSCostsResponse.FromEntityModel(response);

        }

        [Route("{id}/documents")]
        [APIActionInfoAttribute(Name = "Get Record's Documents", Order = 17, Scope = "get_record_documents", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves a document list without content for the given record. Use the URI /document/{id} to download the content. For example, /records/10CAP-00000-00012/documents/?token=1232.")]
        public WSDocumentsResponse GetAttachments(string id, string lang = null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            var originalId = ParseUID(id, agencyContext);
            AttachmentsRequest request = new AttachmentsRequest()
            {
                EntityId = originalId,
                EntityType = RECORD,
            };

            SetPageRangeToRequest(request, offset, limit);

            var entityResult = ExcuteV1_2<AttachmentsResponse, AttachmentsRequest>(
                                (o) =>
                                {
                                    return AttachmentBussinessEntity.GetAttachments(o);
                                },
                                request);

            return WSDocumentsResponse.FromEntityModel(entityResult);

        }

        /*
         * Implementation Notes:
         
         A parameter of Stream type works as a place holder will cause a problem after upgrading to ASP.NET Web API.
         Here is the error message:
         No MediaTypeFormatter is available to read an object of type 'Stream' from content with media type 'multipart/form-data'.
         
         To solve this kind of problem, we simply remove this parameter.
         Everything works fine after removing it.
        */
        [Route("{id}/documents")]
        [APIActionInfoAttribute(Name = "Upload Documents", Order = 31, Scope = "create_record_document", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Create record's document. The API use \"multipart/form-data\" to upload file, the \"fileInfo\" include file name, description etc. the schema as {\"attachment\":{\"fileName\":\"file name\",\"fileType\":\"image\",\"fileSize\":200,\"description\":\"desc\"}}")]
        public WSDocumentCreationResponse UploadAttachment(string id, string lang = null)
        {
            var originalId = ParseUID(id, agencyContext);
            var entityResult = UploadFile(originalId, RECORD, lang);
            return WSDocumentCreationResponse.FromEntityModel(entityResult);
        }

        [Route("{id}/parts")]
        [APIActionInfoAttribute(Name = "Get Record's Parts", Order = 23, Scope = "get_record_parts", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves parts for the record by record ID and other parameters (optional).")]
        public WSPartsResponse GetParts(string id, string lang = null)
        {
            var originalId = ParseUID(id, agencyContext);
            PartsRequest request = new PartsRequest();
            request.RecordId = originalId;

            var response = ExcuteV1_2<PartsResponse, PartsRequest>(
                (o) =>
                {
                    return this.recordBusinessEntity.GetRecordParts(o);
                },
                request);

            return WSPartsResponse.FromEntityModel(response);

        }

        [Route("{id}/related")]
        [APIActionInfoAttribute(Name = "Get Related Records", Order = 26, Scope = "get_related_records", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves related records by record ID and other parameters (optional).")]
        public WSRelatedRecordsResponse GetRelatedRecords(string id, string lang = null)
        {
            var originalId = ParseUID(id, agencyContext);
            RelatedRecordsRequest request = new RelatedRecordsRequest();

            request.RecordId = originalId;

            var entityResult = ExcuteV1_2<RelatedRecordsResponse, RelatedRecordsRequest>(
                                            (o) =>
                                            {
                                                return this.recordBusinessEntity.GetRelatedRecords(o);
                                            },
                                            request);

            return WSRelatedRecordsResponse.FromEntityModel(entityResult);

        }

        [Route("{id}/conditions")]
        [APIActionInfoAttribute(Name = "Get Record's Conditions", Order = 15, Scope = "get_record_conditions", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves conditions for the record by record ID and other parameters (optional).")]
        public WSRecordConditionsResponse GetConditions(string id, string lang = null, string priority = null)
        {
            var originalId = ParseUID(id, agencyContext);
            var request = new ConditionsRequest();
            request.RecordId = originalId;
            request.Filter = priority;

            var tempResult = ExcuteV1_2<ConditionsResponse, ConditionsRequest>(
                (o) =>
                {
                    return this.recordBusinessEntity.GetRecordConditions(o);
                },
                request);

            var result = WSRecordConditionsResponse.FromEntityModel(tempResult);
            return result;

        }

        [Route("{id}/inspections")]
        [APIActionInfoAttribute(Name = "Get Record's Inspections", Order = 18, Scope = "get_record_inspections", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves inspections for the record by record ID and other parameters (optional).")]
        public WSRecordInspectionsResponse GetInspections(string id, bool openInspectionsOnly = false, string scheduledDateRange = null, string lang = null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            var originalId = ParseUID(id, agencyContext);
            var request = new RecordInspectionsRequest();
            SetPageRangeToRequest(request, offset, limit);
            request.RecordId = originalId;

            string[] scheduledDateRangeArray = SpliteDateRange(scheduledDateRange);
            request.InspectionScheduledDateFrom = scheduledDateRangeArray[0];
            request.InspectionScheduledDateTo = scheduledDateRangeArray[1];
            request.OpenInspectionsOnly = openInspectionsOnly;

            var tempResult = ExcuteV1_2<RecordInspectionsResponse, RecordInspectionsRequest>(
                (o) =>
                {
                    return this.recordBusinessEntity.GetRecordInspections(o);
                },
                request);

            var result = WSRecordInspectionsResponse.FromEntityModel(tempResult);
            return result;

        }

        [Route("{id}/assets")]
        [APIActionInfoAttribute(Name = "Get Record's Assets", Order = 13 , Scope = "get_record_assets", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves assets for the record.")]
        public WSRecordAssetsResponse GetAssets(string id, string lang = null)
        {
            var originalId = ParseUID(id, agencyContext);
            var request = new RecordAssetsRequest();
            request.RecordId = originalId;

            var recordAssetsResponse = ExcuteV1_2<RecordAssetsResponse, RecordAssetsRequest>(
                (o) =>
                {
                    return this.recordBusinessEntity.GetRecordAssets(o);
                },
                request);

            var wsRecordAssetsResponse = WSRecordAssetsResponse.FromEntityModel(recordAssetsResponse);
            return wsRecordAssetsResponse;

        }

        [Route("{id}/comments")]
        [APIActionInfoAttribute(Name = "Get Record's comments", Order = 14, Scope = "get_record_comments", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves comments for the record.")]
        public WSRecordCommentsResponse GetComments(string id, string lang = null)
        {
            var originalId = ParseUID(id, agencyContext);
            var request = new RecordCommentsRequest();
            request.RecordId = originalId;

            var tempResult = ExcuteV1_2<RecordCommentsResponse, RecordCommentsRequest>(
                (o) =>
                {
                    return this.recordBusinessEntity.GetRecordComments(o);
                },
                request);

            var result = WSRecordCommentsResponse.FromEntityModel(tempResult);
            string GetTmpClientResponseJson = JsonConverter.ToJson(result);
            return result;

        }

        [Route("{id}/workflowtasks")]
        [APIActionInfoAttribute(Name = "Get Record's Workflow Tasks", Order = 22, Scope = "get_record_workflow_tasks", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves workflow tasks for the record by record ID and other parameters (optional).")]
        public WSWorkflowTasksResponse GetWorkflowTasks(string id, string lang = null)
        {
            var originalId = ParseUID(id, agencyContext);
            var request = new WorkflowTasksRequest();

            request.RecordId = originalId;

            var entityResponse = ExcuteV1_2<WorkflowTasksResponse, WorkflowTasksRequest>(
                                    (o) =>
                                    {
                                        return this.recordBusinessEntity.GetWorkflowTasks(o);
                                    },
                                    request);

            return WSWorkflowTasksResponse.FromEntityModel(entityResponse);

        }

        [HttpPut]
        [Route("{id}/workflowtask")]
        [APIActionInfoAttribute(Name = "Update Workflow Task", Order = 33, Scope = "update_record_workflow_task", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Updates the workflow task by the specific parameters. You should include processCode, status and statusDate in the JSON representation when updating a workflow task; otherwise, the update will fail.")]
        public WSUpdateWorkflowTaskResponse UpdateWorkflowTask(string id, [FromBody]WSUpdateWorkflowTaskRequest updateWorkflowTaskRequest, string lang = null)
        {
            var originalId = ParseUID(id, agencyContext);
            var request = WSUpdateWorkflowTaskRequest.ToEntityModel(updateWorkflowTaskRequest);
            request.RecordId = originalId;

            var entityResponse = ExcuteV1_2<UpdateWorkflowTaskResponse, UpdateWorkflowTaskRequest>(
                                    (o) =>
                                    {
                                        //return _recordBusinessEntity.UpdateWorkflowTask(o);
                                        return this.recordBusinessEntity.UpdateWorkflowTask(o);
                                    },
                                    request);

            return WSUpdateWorkflowTaskResponse.FromEntityModel(entityResponse);

        }

        [Route("{id}/location")]
        [APIActionInfoAttribute(Name = "Get Record's Plottable Location", Order = 19, Scope = "get_record_location", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves location for the record by record ID and other parameters (optional).")]
        public WSLocationResponse GetRecordLocation(string id, string lang = null)
        {
            var originalId = ParseUID(id, agencyContext);
            var request = new RecordLocationRequest();
            request.Criteria = new RecordCriteria();
            request.Criteria.RecordIds = new List<string>() { originalId };

            var entityResponse = ExcuteV1_2<RecordLocationResponse, RecordLocationRequest>(
                                    (o) =>
                                    {
                                        return recordBusinessEntity.GetRecordLocation(o);
                                    },
                                    request);

            return WSLocationResponse.FromEntityModel(entityResponse);

        }

        [Route("{id}/workordertasks")]
        [APIActionInfoAttribute(Name = "Get Record's Workorder Tasks", Order = 25, Scope = "get_record_workorder_tasks", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves workorder tasks for the record by record ID and other parameters (optional).")]
        public WSWorkOrderTasksResponse GetWorkorderTasks(string id, string lang = null)
        {
            var originalId = ParseUID(id, agencyContext);
            var request = new WorkOrderTasksRequest();
            request.RecordId = originalId;
            var entityResponse = ExcuteV1_2<WorkOrderTasksResponse, WorkOrderTasksRequest>(
                                    (o) =>
                                    {
                                        return recordBusinessEntity.GetWorkOrderTasks(o);
                                    },
                                    request);

            return WSWorkOrderTasksResponse.FromEntityModel(entityResponse);

        }

        [Route("{id}/conditionsummary")]
        [APIActionInfoAttribute(Name = "Get Record's Condition Summary", Scope = "get_record_condition_summary", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves condition summary for the record by record ID and other parameters (optional).")]
        public WSConditionSummaryResponse GetConditionSummary(string id, string lang = null)
        {
            var originalId = ParseUID(id, agencyContext);
            var request = new ConditionSummaryRequest();
            request.RecordId = originalId;

            var tempResponse = ExcuteV1_2<ConditionSummaryResponse, ConditionSummaryRequest>(
                (o) =>
                {
                    return recordBusinessEntity.GetConditionSummary(o);
                },
                request);

            var result = WSConditionSummaryResponse.FromEntityModel(tempResponse);

            return result;
        }

        [Route("{id}/inspectionsummary")]
        [APIActionInfoAttribute(Name = "Get Record's Inspection Summary", Scope = "get_record_inspection_summary", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves inspection summary for the record by record ID and other parameters (optional).")]
        public WSInspectionSummaryResponse GetInspectionSummary(string id, string lang = null)
        {
            var originalId = ParseUID(id, agencyContext);
            var request = new InspectionSummaryRequest();
            request.RecordId = originalId;

            var tempResponse = ExcuteV1_2<InspectionSummaryResponse, InspectionSummaryRequest>(
                (o) =>
                {
                    return recordBusinessEntity.GetInspectionSummary(o);
                },
                request);

            var result = WSInspectionSummaryResponse.FromEntityModel(tempResponse);

            return result;
        }

        [Route("{id}/workflowsummary")]
        [APIActionInfoAttribute(Name = "Get Record's Workflow Summary", Scope = "get_record_workflow_summary", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves workflow summary for the record by record ID and other parameters (optional).")]
        public WSWorkflowSummaryResponse GetWorkflowSummary(string id, string lang = null)
        {
            var originalId = ParseUID(id, agencyContext);
            var request = new WorkflowSummaryRequest();
            request.RecordId = originalId;

            var tempResponse = ExcuteV1_2<WorkflowSummaryResponse, WorkflowSummaryRequest>(
                (o) =>
                {
                    return recordBusinessEntity.GetWorkflowSummary(o);
                },
                request);

            var result = WSWorkflowSummaryResponse.FromEntityModel(tempResponse);

            return result;
        }

        [Route("{id}/feesummary")]
        [APIActionInfoAttribute(Name = "Get Record's Fee Summary", Scope = "get_record_fee_summary", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves fee summary of the record by record ID and other parameters (optional).")]
        public WSFeeSummaryResponse GetFeeSummary(string id, string lang = null)
        {
            var originalId = ParseUID(id, agencyContext);
            var request = new FeeSummaryRequest();
            request.RecordId = originalId;

            var tempResponse = ExcuteV1_2<FeeSummaryResponse, FeeSummaryRequest>(
                (o) =>
                {
                    return recordBusinessEntity.GetFeeSummary(o);
                },
                request);

            var result = WSFeeSummaryResponse.FromEntityModel(tempResponse);

            return result;
        }

        [Route("{id}/contactsummary")]
        [APIActionInfoAttribute(Name = "Get Record's Contact Summary", Scope = "get_record_contact_summary", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves contact summary of the record by record ID and other parameters (optional).")]
        public WSContactSummaryResponse GetContactSummary(string id, string lang = null)
        {
            var originalId = ParseUID(id, agencyContext);
            var request = new ContactSummaryRequest();
            request.RecordId = originalId;

            var tempResponse = ExcuteV1_2<ContactSummaryResponse, ContactSummaryRequest>(
                (o) =>
                {
                    return recordBusinessEntity.GetContactSummary(o);
                },
                request);

            var result = WSContactSummaryResponse.FromEntityModel(tempResponse);

            return result;
        }

        [Route("{id}/projectinformations")]
        [APIActionInfoAttribute(Name = "Get Record's Project Informations", Scope = "get_record_project_informations", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves project information about the record by record ID and other parameters (optional).")]
        public WSProjectInformationResponse GetProjectInformations(string id, string lang = null)
        {
            var originalId = ParseUID(id, agencyContext);
            var request = new ProjectInformationRequest();
            request.RecordId = originalId;

            var tempResponse = ExcuteV1_2<ProjectInformationResponse, ProjectInformationRequest>(
                (o) =>
                {
                    return recordBusinessEntity.GetProjectInformations(o);
                },
                request);

            var result = WSProjectInformationResponse.FromEntityModel(tempResponse);

            return result;
        }

        
        

        [Route("{id}/asis/drilldowns/{drilldownid}")]
        [APIActionInfoAttribute(Name = "Get Record ASI Drilldown", Order = 10, Scope = "get_record_asi_drilldown", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get the record's project informations by record id and some specified parameters.")]
        public WSDrillDownValuesResponse GetRecordASIDrillDownValues(string id, string drilldownid, string parentvalueid = null)
        {
            DrillDownValuesRequest request = new DrillDownValuesRequest();

            request.RecordId = id;
            request.DrillDownId = drilldownid;
            request.ParentValueId = parentvalueid;

            DrillDownValuesResponse response = this.ExcuteV1_2<DrillDownValuesResponse, DrillDownValuesRequest>(
            (o) =>
            {
                if (string.IsNullOrEmpty(parentvalueid))
                {
                    return recordBusinessEntity.GetASIDrillDownValues(o);
                }
                else
                {
                    return recordBusinessEntity.GetASIDrillDownValuesForParent(o);
                }
            },
            request);

            return WSDrillDownValuesResponse.FromEntityModel(response);
        }        

        [Route("{id}/asits/drilldowns/{drilldownid}")]
        [APIActionInfoAttribute(Name = "Get Drilldowns", Order = 10, Scope = "get_record_asit_drilldown", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get the record''s project informations by record id and some specified parameters.")]
        public WSDrillDownValuesResponse GetASITDrillDownValues(string id, string drilldownid, string parentvalueid = null)
        {
            var request = new DrillDownValuesRequest();

            request.RecordId = id;
            request.DrillDownId = drilldownid;
            request.ParentValueId = parentvalueid;

            DrillDownValuesResponse response = this.ExcuteV1_2<DrillDownValuesResponse, DrillDownValuesRequest>(
            (o) =>
            {
                if (string.IsNullOrEmpty(parentvalueid))
                {
                    return recordBusinessEntity.GetASITDrillDownValues(o);
                }
                else
                {
                    return recordBusinessEntity.GetASITDrillDownValuesForParent(o);
                }
            },
            request);
            return WSDrillDownValuesResponse.FromEntityModel(response);
        }        
    }
}
