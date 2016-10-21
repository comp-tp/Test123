using System;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Models.DomainModels.SummaryModels;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Requests.AddressRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.SummaryRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.SummaryResponses;
using Accela.Apps.Apis.Repositories.GovXmlHelpers;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared.Exceptions;
using Accela.Automation.GovXmlClient.Model;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Contexts;


namespace Accela.Apps.Apis.Repositories.Agency
{
    public class RecordRepository : RepositoryBase, IRecordRepository
    {
        private RecordHelper _recordHelper;
        //private IAgencyAppContext _agencyContext;

        private RecordHelper RecordHelper
        {
            get
            {
                if (_recordHelper == null)
                {
                    var bizServerVersion = this.Environment.BizServerVersion;
                    _recordHelper = new RecordHelper(bizServerVersion, ShouldAutoCorrectCoordinate);
                }

                return _recordHelper;
            }
        }

        //public RecordRepository(string appId, string agencyName, string serviceProvCode, string agencyUserId, string agencyUsername, string token, string environmentName, string language)
        //    : base(appId, agencyName, serviceProvCode, agencyUserId, agencyUsername, token, environmentName, language)
        //{
        //}

        public RecordRepository(IAgencyAppContext contextEntity)
            : base(contextEntity)
        {
            //this._agencyContext = contextEntity;
        }

        public RecordsResponse GetRecords(RecordsRequest request)
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.getCAPs = new GetCAPs();
            govXmlIn.getCAPs.system = CommonHelper.GetSystem(request, this.CurrentContext);

            RecordHelper.ToGovXmlFromCriteria(govXmlIn.getCAPs, request.Criteria, request.Elements);

            GovXML response = CommonHelper.Post(govXmlIn,
                govXmlIn.getCAPs.system,
                (o) => o.getCAPsResponse == null ? null : o.getCAPsResponse.system);

            RecordsResponse results = RecordHelper.GetClientRecords(response.getCAPsResponse, request.IgnoreCoordinatesSearch);
            return results;
        }

        public CreateRecordResponse CreateRecord(CreateRecordRequest request)
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.initiateCAP = RecordHelper.ToXMLCreateRecord(request.Record);
            govXmlIn.initiateCAP.system = CommonHelper.GetSystem(request,this.CurrentContext, isCreateRecord:true);

            GovXML response = CommonHelper.Post(govXmlIn,
                                                govXmlIn.initiateCAP.system,
                                                (o) => o.initiateCAPResponse == null ? null : o.initiateCAPResponse.system);

            CreateRecordResponse results = RecordHelper.ToClientRecordResponse(response);

            return results;
        }

        public UpdateRecordResponse UpdateRecord(UpdateRecordRequest request)
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.UpdateCAP = RecordHelper.ToXmlUpdateRecord(request.Record);
            govXmlIn.UpdateCAP.system = CommonHelper.GetSystem(request, this.CurrentContext);

            GovXML response = CommonHelper.Post(govXmlIn,
                                                govXmlIn.UpdateCAP.system,
                                                (o) => o.UpdateCAPResponse == null ? null : o.UpdateCAPResponse.system);

            UpdateRecordResponse result = RecordHelper.ToUpdateRecordResponse(response);

            if (result.Record == null)
            {
                result.Record = request.Record;
            }

            return result;
        }

        public RecordSummaryResponse GetRecordSummary(RecordSummaryRequest request)
        {
            RecordSummaryResponse result = new RecordSummaryResponse();

            RecordSummaryModel cacheData = RecordCache.Instance.GetRecordSummaryFromCache(request.RecordId, this.CurrentContext);

            if (cacheData != null)
            {
                result.ConditionSummary = cacheData.ConditionSummary;
                result.FeeSummary = cacheData.FeeSummary;
                result.WorkflowSummary = cacheData.WorkflowSummary;
                result.InspectionSummary = cacheData.InspectionSummary;
                result.ContactSummaries = cacheData.ContactSummaries;
                result.ProjectInformations = cacheData.ProjectInformations;
            }
            else
            {
                GovXML govXmlIn = new GovXML();
                govXmlIn.getCAPDetail = new GetCAPDetail();
                govXmlIn.getCAPDetail.system = CommonHelper.GetSystem(request, this.CurrentContext);
                govXmlIn.getCAPDetail.CAPId = new CAPId();
                govXmlIn.getCAPDetail.CAPId.val = request.RecordId;

                GovXML response = CommonHelper.Post(govXmlIn,
                    govXmlIn.getCAPDetail.system,
                    (o) => o.getCAPDetailResponse == null ? null : o.getCAPDetailResponse.system);


                if (response != null && response.getCAPDetailResponse != null)
                {
                    if (response.getCAPDetailResponse.system != null)
                    {
                        result.Events = CommonHelper.GetClientEventMessage(response.getCAPDetailResponse.system.eventMessages);
                    }

                    if (response.getCAPDetailResponse.CapDetail != null)
                    {
                        result.ConditionSummary = RecordSummaryHelper.ToConditionSummary(response.getCAPDetailResponse.CapDetail.CapConditions);
                        result.FeeSummary = RecordSummaryHelper.ToFeeSummary(response.getCAPDetailResponse.CapDetail.CapFees);
                        result.WorkflowSummary = RecordSummaryHelper.ToWorkflowSummary(response.getCAPDetailResponse.CapDetail.CapWorkflows);
                        result.InspectionSummary = RecordSummaryHelper.ToInspectionSummarySummary(response.getCAPDetailResponse.CapDetail.CapInspections);
                        result.ContactSummaries = RecordSummaryHelper.ToContactSummaries(response.getCAPDetailResponse.CapDetail.CapContacts);
                        result.ProjectInformations = RecordSummaryHelper.ToProjectInformations(response.getCAPDetailResponse.CapDetail.CapProjectInformations);
                        RecordSummaryModel tocached = new RecordSummaryModel();
                        tocached.ConditionSummary = result.ConditionSummary;
                        tocached.FeeSummary = result.FeeSummary;
                        tocached.WorkflowSummary = result.WorkflowSummary;
                        tocached.InspectionSummary = result.InspectionSummary;
                        tocached.ContactSummaries = result.ContactSummaries;
                        tocached.ProjectInformations = result.ProjectInformations;
                        RecordCache.Instance.CacheRecordSummary(tocached, request.RecordId, this.CurrentContext);
                    }
                }
            }

            return result;
        }

        public WorkflowTasksResponse GetWorkflowTasks(WorkflowTasksRequest request)
        {
            //GovXML govXmlIn = WorkflowHelper.ToXMLGetWorkflowModel(request);

            GovXML govXmlIn = new GovXML();
            govXmlIn.getWorkflow = new GetWorkflow();
            govXmlIn.getWorkflow.system = CommonHelper.GetSystem(request, this.CurrentContext);
            if (request != null)
            {
                govXmlIn.getWorkflow.capIds = new CAPIds();
                govXmlIn.getWorkflow.capIds.capId = new CAPId[1];
                govXmlIn.getWorkflow.capIds.capId[0] = new CAPId();
                govXmlIn.getWorkflow.capIds.capId[0].keys = KeysHelper.CreateXMLKeys(request.RecordId);

                govXmlIn.getWorkflow.contextType = "Multiple";
            }

            GovXML response = CommonHelper.Post(govXmlIn,
                                                govXmlIn.getWorkflow.system,
                                                (o) => o.getWorkflowResponse == null ? null : o.getWorkflowResponse.system);

            WorkflowTasksResponse result = WorkflowHelper.ToClientWorkflowTasks(response.getWorkflowResponse);

            return result;
        }

        public Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses.UpdateWorkflowTaskResponse UpdateWorkflowTask(UpdateWorkflowTaskRequest request)
        {
            //GovXML govXmlIn = WorkflowHelper.ToXMLUpdateWorkflowModel(request);

            GovXML govXmlIn = new GovXML();
            govXmlIn.updateWorkflowTask = WorkflowHelper.ToXMLUpdateWorkflowTask(request);
            govXmlIn.updateWorkflowTask.system = CommonHelper.GetSystem(request, this.CurrentContext);

            GovXML response = CommonHelper.Post(govXmlIn,
                                                govXmlIn.updateWorkflowTask.system,
                                                (o) => o.updateWorkflowTaskResponse == null ? null : o.updateWorkflowTaskResponse.system);

            Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses.UpdateWorkflowTaskResponse clientResponse = WorkflowHelper.ToClientUpdateWorkflowTask(response.updateWorkflowTaskResponse);

            return clientResponse;
        }

        public RecordContactsResponse GetRecordContacts(RecordContactsRequest request)
        {
            var recordRequest = new RecordsRequest();
            //recordRequest.SystemInfo = request.SystemInfo;
            recordRequest.Criteria = new RecordCriteria();
            recordRequest.Criteria.RecordIds = new List<string>();
            recordRequest.Criteria.RecordIds.Add(request.RecordId);
            recordRequest.Elements = new List<string>();
            recordRequest.Elements.Add("Contacts");

            RecordsResponse recordResponse = this.GetRecords(recordRequest);
            if (recordResponse == null || recordResponse.Records == null || recordResponse.Records.Count != 1)
            {
                throw new NotFoundException("The Record: " + request.RecordId + " does not exist.");
            }

            var currentRecord = recordResponse.Records[0];

            var result = new RecordContactsResponse();
            result.Events = recordResponse.Events;

            var contacts = new List<ContactModel>();

            if (currentRecord != null
                && currentRecord.Contacts != null
                && currentRecord.Contacts.Count > 0)
            {
                foreach (var contact in currentRecord.Contacts)
                {
                    if (!(contact != null && contact.Identifier != null && contact.Identifier.IndexOf("owner", StringComparison.OrdinalIgnoreCase) != -1))
                    {
                        contacts.Add(contact);
                    }
                }
            }

            result.Contacts = contacts;

            return result;
        }

        public Accela.Apps.Apis.Models.DTOs.Responses.AddressResponses.AddressesResponse GetAddresses(AddressesRequest request)
        {
            RecordsRequest recordRequest = new RecordsRequest();

            recordRequest.Criteria = new RecordCriteria();
            recordRequest.Criteria.RecordIds = new List<string>();
            recordRequest.Criteria.RecordIds.Add(request.RecordId);

            recordRequest.Elements = new List<string>();
            recordRequest.Elements.Add("Addresses");

            RecordsResponse recordResponse = this.GetRecords(recordRequest);

            if (recordResponse == null || recordResponse.Records == null || recordResponse.Records.Count != 1)
            {
                throw new NotFoundException("The Record: " + request.RecordId + " didn't exist");
            }

            Accela.Apps.Apis.Models.DTOs.Responses.AddressResponses.AddressesResponse response = new Accela.Apps.Apis.Models.DTOs.Responses.AddressResponses.AddressesResponse();
            response.Events = recordResponse.Events;
            response.Addresses = recordResponse.Records[0].Addresses;

            return response;
        }

        /// <summary>
        /// Counts the daily records.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the daily records count.</returns>
        public DailyRecordsCountResponse CountDailyRecords(DailyRecordsCountRequest request)
        {
            DailyRecordsCountResponse result = null;
            var govXmlIn = new GovXML();
            var countDailyRecords = new CountDailyRecords();
            countDailyRecords.system = CommonHelper.GetSystem(request, this.CurrentContext);

            if (request != null)
            {
                if (!String.IsNullOrWhiteSpace(request.DateFrom) || !String.IsNullOrWhiteSpace(request.DateTo))
                {
                    DateTime tempDateTime;
                    var dateFrom = DateTime.TryParse(request.DateFrom, out tempDateTime);
                    countDailyRecords.DateRange = new DateRange();

                    if (!String.IsNullOrWhiteSpace(request.DateFrom) && DateTime.TryParse(request.DateFrom, out tempDateTime))
                    {
                        countDailyRecords.DateRange.from = tempDateTime.ToString("MM/dd/yyyy");
                    }

                    if (!String.IsNullOrWhiteSpace(request.DateTo) && DateTime.TryParse(request.DateTo, out tempDateTime))
                    {
                        countDailyRecords.DateRange.to = tempDateTime.ToString("MM/dd/yyyy");
                    }
                }

                if (request.Modules != null)
                {
                    countDailyRecords.Module = string.Join("@", request.Modules.ToArray());
                }

                countDailyRecords.RecordType = request.RecordType;
                countDailyRecords.ReturnType = request.ReturnType;
            }

            govXmlIn.countDailyRecords = countDailyRecords;

            GovXML response = CommonHelper.Post(govXmlIn,
                countDailyRecords.system,
                (o) => o.countDailyRecordsResponse == null ? null : o.countDailyRecordsResponse.system);

            if (response != null)
            {
                result = new DailyRecordsCountResponse();
                result.DailyRecords = new List<DailyRecordModel>();

                if (response.countDailyRecordsResponse != null && response.countDailyRecordsResponse.DailyRecords != null && response.countDailyRecordsResponse.DailyRecords.DailyRecord != null)
                {
                    var dailyRecords = response.countDailyRecordsResponse.DailyRecords.DailyRecord;
                    foreach (var dailyRecord in dailyRecords)
                    {
                        var dailyRecordModel = new DailyRecordModel();
                        dailyRecordModel.Day = dailyRecord.Day != null ? dailyRecord.Day.Value : 0;

                        dailyRecordModel.Modules = new List<ModuleModel>();

                        if (dailyRecord.Modules != null && dailyRecord.Modules.Module != null)
                        {
                            foreach (var module in dailyRecord.Modules.Module)
                            {
                                var moduleModel = new ModuleModel();
                                moduleModel.Key = module.Key;
                                moduleModel.Value = module.Value;
                                dailyRecordModel.Modules.Add(moduleModel);
                            }
                        }

                        result.DailyRecords.Add(dailyRecordModel);
                    }
                }
            }

            return result;
        }

        //public IAgencyAppContext CurrentContext
        //{
        //    get { return _agencyContext; }
        //}
    }
}
