using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.Common;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;
using Accela.Apps.Apis.Models.DomainModels.ConditionModels;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;
using Accela.Apps.Apis.Models.DomainModels.GISModels;
using Accela.Apps.Apis.Models.DomainModels.GlobalEntityModels;
using Accela.Apps.Apis.Models.DomainModels.LocationModels;
using Accela.Apps.Apis.Models.DomainModels.ParcelModels;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Requests.AddressRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.CostRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.InspectionRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.ParcelRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.ReferenceRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.SummaryRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AddressResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;
using Accela.Apps.Apis.Models.DTOs.Responses.CommonResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.CostResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.ParcelResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.SummaryResponses;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Apis.Repositories.Interfaces.Admin;
using Accela.Apps.Shared.Contants;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Shared.FormatHelpers;
using Accela.Core.Ioc;
using Accela.Apps.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using AddressModel = Accela.Apps.Apis.Models.DomainModels.ReferenceModels.AddressModel;


namespace Accela.Apps.Apis.BusinessEntities
{
    public class RecordBusinessEntity : BusinessEntityBase, IRecordBusinessEntity
    {
        #region Private Variables

        //private string _appId;
        //private string _agencyName;
        //private string _serviceProvCode;
        //private string _agencyUserId;
        //private string _agencyUsername;
        //private string _token;
        //private string _environmentName;
        //private string _language;

        //private Dictionary<string, object> MakeConstructorParameters()
        //{
        //    Dictionary<string, object> tmpParams = new Dictionary<string, object>();

        //    tmpParams.Add("appId", _appId);
        //    tmpParams.Add("agencyName", _agencyName);
        //    tmpParams.Add("serviceProvCode", _serviceProvCode);
        //    tmpParams.Add("agencyUserId", _agencyUserId);
        //    tmpParams.Add("agencyUsername", _agencyUsername);
        //    tmpParams.Add("token", _token);
        //    tmpParams.Add("environmentName", _environmentName);
        //    tmpParams.Add("language", _language);

        //    return tmpParams;
        //}

        #endregion

        //public RecordBusinessEntity(string appId,
        //                             string agencyName,
        //                             string serviceProvCode,
        //                             string agencyUserId,
        //                             string agencyUsername,
        //                             string token,
        //                             string environmentName,
        //                             string language)
        //{
        //    _appId = appId;
        //    _agencyName = agencyName;
        //    _serviceProvCode = serviceProvCode;
        //    _agencyUserId = agencyUserId;
        //    _agencyUsername = agencyUsername;
        //    _token = token;
        //    _environmentName = environmentName;
        //    _language = language;
        //}

        public RecordBusinessEntity(IRecordRepository recordRepository)
        {
            if(recordRepository == null)
            {
                throw new ArgumentNullException("recordRepository");
            }

            this.recordRepository = recordRepository;

        }

        #region Properties

        private const string GLOBAL_ENTITY_RECORD_TYPE = "RECORD";
        
        private IGlobalEntityRepository _globalEntityRepository = null;
        private IGlobalEntityRepository GlobalEntityRepository
        {
            get
            {
                if (_globalEntityRepository == null)
                {
                    _globalEntityRepository = IocContainer.Resolve<IGlobalEntityRepository>();
                }

                return _globalEntityRepository;
            }
        }

        private readonly IRecordRepository recordRepository;

        private IInspectionRepository _inspectionRepository = null;
        private IInspectionRepository InspectionRepository
        {
            get
            {
                if (_inspectionRepository == null)
                {
                    //Dictionary<string, object> ctorParams = MakeConstructorParameters();
                    _inspectionRepository = IocContainer.Resolve<IInspectionRepository>();
                }

                return _inspectionRepository;
            }
        }

        private ICoordinateRepository _coordinateRepository = null;
        private ICoordinateRepository CoordinateRepository
        {
            get
            {
                if (_coordinateRepository == null)
                {
                    _coordinateRepository = IocContainer.Resolve<ICoordinateRepository>();
                }

                return _coordinateRepository;
            }
        }

        private IAddressBusinessEntity _addressBusinessEntity = null;
        private IAddressBusinessEntity AddressBusinessEntity
        {
            get
            {
                if (_addressBusinessEntity == null)
                {
                    //Dictionary<string, object> ctorParams = MakeConstructorParameters();
                    _addressBusinessEntity = IocContainer.Resolve<IAddressBusinessEntity>();
                }

                return _addressBusinessEntity;
            }
        }

        private IASISecurityBusinessEntity _asiSecurityBusinessEntity = null;
        private IASISecurityBusinessEntity ASISecurityBusinessEntity
        {
            get
            {
                if (_asiSecurityBusinessEntity == null)
                {
                    //Dictionary<string, object> ctorParams = MakeConstructorParameters();
                    _asiSecurityBusinessEntity = IocContainer.Resolve<IASISecurityBusinessEntity>();
                }

                return _asiSecurityBusinessEntity;
            }
        }

        private IUserRepository _userRepository = null;
        private IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    //Dictionary<string, object> ctorParams = MakeConstructorParameters();
                    _userRepository = IocContainer.Resolve<IUserRepository>();
                }

                return _userRepository;
            }
        }

        private IReferenceDataRepository _referenceDataRepository;
        private IReferenceDataRepository ReferenceDataRepository
        {
            get
            {
                if (_referenceDataRepository == null)
                {
                    //Dictionary<string, object> ctorParams = MakeConstructorParameters();
                    _referenceDataRepository = IocContainer.Resolve<IReferenceDataRepository>();
                }

                return _referenceDataRepository;
            }
        }

        private IASIBusinessEntity asiBusinessEntity = null;
        private IASIBusinessEntity ASIBusinessEntity
        {
            get
            {
                if (asiBusinessEntity == null)
                {
                    asiBusinessEntity = IocContainer.Resolve<IASIBusinessEntity>();
                }

                return asiBusinessEntity;
            }
        }

        #endregion

        #region Public Methods

        public RecordsResponse GetRecords(RecordsRequest request, IAgencyAppContext context)
        {
            if (request.Criteria != null && request.Criteria.BBoxValue != null)
            {
                request.Criteria.RecordIds = GetRecordIdsByBBox(request.Criteria.BBoxValue);
            }
            else
            {
                if (request.Criteria != null
                    && request.Criteria.GeoCircle != null)
                {
                    request.Criteria.RecordIds = GetRecordIdsByGeoCircle(request.Criteria.GeoCircle);
                }
            }

            if (request.Criteria.ReturnElements == null || request.Criteria.ReturnElements.Count == 0)
            {
                // The "Basic" flag is useless in here.
                // And it has a side effect, if set, all information about detail and comment will be ignored.
                // So...
                // Simply remove this flag to solve this problem.
                // BTW, when set the "Comments" flag, it will return the cap detail as well, so no need to set the "CapDetails" flag.

                request.Criteria.ReturnElements = new List<string> { "Comments" };
            }

            var recordsResponse = recordRepository.GetRecords(request);

            if (context.AppType == AppType.Citizen)
            {
                if (recordsResponse != null
                    && recordsResponse.Records != null)
                {
                    foreach (var record in recordsResponse.Records)
                    {
                        var globalEntity = GlobalEntityRepository.GetGlobalEntity(record.Identifier, "RECORD", this.recordRepository.CurrentContext.Agency, this.recordRepository.CurrentContext.EnvName);

                        if (globalEntity != null)
                        {
                            record.User = GetCloudUser(globalEntity.CloudUserID);
                            record.CreatedDate = Accela.Apps.Shared.FormatHelpers.DateTimeFormat.ToMetaDateTimeString(globalEntity.CreatedDate);
                            if (record.RecordStatus != null && string.IsNullOrEmpty(record.RecordStatus.Identifier))
                            {
                                record.RecordStatus.Identifier = globalEntity.Keep4;
                                record.RecordStatus.Display = globalEntity.Keep4;
                            }
                        }
                    }
                }
            }

            return recordsResponse;
        }

        private CloudUserModel GetCloudUser(Guid cloudUserId)
        {
            return UserRepository.GetCloudUser(cloudUserId);
        }

        private List<string> GetRecordIdsByGeoCircle(GeoCircle geoCircle)
        {
            var entityIds = GetGlobalEntityIdsByGeoCircle(geoCircle);

            List<string> results = GetRecordIdsByGlobalEntityIds(entityIds);

            return results;
        }

        private List<string> GetRecordIdsByGlobalEntityIds(List<GeoCoordinateModel> globalEntities)
        {
            List<string> results = new List<string>();

            if (globalEntities != null
                && globalEntities.Count > 0)
            {
                foreach (var entityId in globalEntities)
                {
                    var entity = GlobalEntityRepository.GetGlobalEntity(entityId.GlobalEntityId);

                    if (entity != null)
                    {
                        results.Add(entity.EntityID);
                    }
                }
            }
            return results;
        }

        private List<GeoCoordinateModel> GetGlobalEntityIdsByGeoCircle(GeoCircle geoCircle)
        {
            var criterion = new GeoSearchRangeModel
            {
                CenterLocationX = geoCircle.CenterX,
                CenterLocationY = geoCircle.CenterY,
                Type = "RECORD"
            };

            int tmpRadius = 0;

            Int32.TryParse(geoCircle.Radius, out tmpRadius);

            criterion.Radius = tmpRadius;

            var entityIds = CoordinateRepository.GlobalEntityIdsWithinRange(criterion);

            return entityIds;
        }

        private List<string> GetRecordIdsByBBox(BBox bBox)
        {
            var entityIds = GetGlobalEntityIdsByBBox(bBox);

            List<string> results = GetRecordIdsByGlobalEntityIds(entityIds);

            return results;
        }

        private List<GeoCoordinateModel> GetGlobalEntityIdsByBBox(BBox bBox)
        {
            return CoordinateRepository.GetRecordIdsByBBox(bBox);
        }

        public RecordResponse GetRecord(RecordRequest request)
        {
            RecordsRequest recordsRequest = new RecordsRequest();
            request.Offset = 0;
            request.Limit = 0;
            //recordsRequest.SystemInfo = request.SystemInfo;
            recordsRequest.Criteria = new RecordCriteria();
            recordsRequest.Criteria.RecordIds = new List<string>();
            recordsRequest.Criteria.RecordIds.Add(request.RecordId);

            recordsRequest.Criteria.ReturnElements = new List<string> { "Basic", "CapDetails", "Comments" };

            RecordsResponse response = recordRepository.GetRecords(recordsRequest);
            if (response == null || response.Records == null || response.Records.Count == 0)
            {
                throw new NotFoundException("The record didn't exist.");
            }

            RecordResponse result = new RecordResponse();
            result.Record = response.Records[0];

            return result;
        }

        /// <summary>
        /// Create Record
        /// </summary>
        /// <param name="request">the record comming from client</param>
        /// <param name="needMakeUpCoordinates">indicates if need make up coordinates, true: needed, false: not needed</param>
        /// <returns>
        /// return created record
        /// </returns>
        public CreateRecordResponse CreateRecord(CreateRecordRequest request, IAgencyAppContext context, bool needMakeUpCoordinates = true)
        {
            // 1. Get address's coodinate(X,Y) if no address (x,y), then store the coodinate into Azure table-GeoCodeAddress
            if (context.AppType == AppType.Citizen && needMakeUpCoordinates)
            {
                AddressBusinessEntity.RetrieveAndSetCoodinateXY(request.Record.Addresses);
            }

            if (request.Record != null)
            {
                /*
                 * Sometimes, when the client App is trying to create a new record, it does not provide the ASI/T data since from the view of the client App, it does not edit 
                 * those data.
                 * 
                 * So we should add a empty ASI/T collection and then doing some security checking.
                 * 
                 * If a record type has been associated with a ASI/T group, the creation will fail if the GovXML server does not find it in the XML request.
                //*/
                if (request.Record.AdditionalInfo == null
                    && request.Record.AdditionalTableInfo == null)
                {
                    request.Record.AdditionalInfo = new List<AdditionalGroupModel>();
                    request.Record.AdditionalTableInfo = new List<AdditionalTableModel>();
                }
                else
                {
                    if (request.Record.AdditionalInfo != null)
                    {
                        if (request.Record.AdditionalTableInfo == null)
                        {
                            request.Record.AdditionalTableInfo = new List<AdditionalTableModel>();
                        }
                    }
                    else
                    {
                        request.Record.AdditionalInfo = new List<AdditionalGroupModel>();
                    }
                }

                ASISecurityBusinessEntity.AttachInvisableItemsForCreation(request.Record.RecordType, request.Record.AdditionalInfo, request.Record.AdditionalTableInfo);
            }

            // 2. Create record to AA/ACA
            CreateRecordResponse creationResult = recordRepository.CreateRecord(request);

            // 3.Cache Record Coordinate to cloud.
            if (context.AppType == AppType.Citizen)
            {
                //SaveCitizenRecordData(request, creationResult);
                var globalEntityId = CacheRecordCoordinates(request, creationResult);

            }

            return creationResult;
        }

        public UpdateRecordResponse UpdateRecord(UpdateRecordRequest request)
        {
            if (request.Record != null
                &&
                (request.Record.AdditionalInfo != null || request.Record.AdditionalTableInfo != null))
            {
                if (request.Record.AdditionalInfo != null)
                {
                    if (request.Record.AdditionalTableInfo == null)
                    {
                        request.Record.AdditionalTableInfo = new List<AdditionalTableModel>();
                    }
                }
                else
                {
                    request.Record.AdditionalInfo = new List<AdditionalGroupModel>();
                }

                ASISecurityBusinessEntity.AttachInvisableItemsForUpdate(request.Record.Identifier, request.Record.AdditionalInfo, request.Record.AdditionalTableInfo);
            }

            ValidateWorkOrderTasks(request);

            return recordRepository.UpdateRecord(request);
        }

        private void ValidateWorkOrderTasks(UpdateRecordRequest request)
        {
            /*
             * Per SF case 13ACC-02964, a required field named taskCodeIndex has been added to GovXML since AA 731.
             * So, when trying to update work order task, we need to add it in the GovXML request.
            //*/
            if (request.Record == null || request.Record.WorkOrderTasks == null) return;

            var taskWithoutIndex = request.Record.WorkOrderTasks.Find(task => String.IsNullOrEmpty(task.TaskCodeIndex));
            if (taskWithoutIndex != null)
            {
                throw new NotFoundException("taskSuffix cannot be empty when updating one or more work order tasks.");
            }
        }

        public ConditionSummaryResponse GetConditionSummary(ConditionSummaryRequest request)
        {
            RecordSummaryResponse recordSummaryResp = GetRecordSummary(request);
            ConditionSummaryResponse result = new ConditionSummaryResponse();
            result.ConditionSummary = recordSummaryResp.ConditionSummary; ;
            result.Events = recordSummaryResp.Events;
            return result;
        }

        public InspectionSummaryResponse GetInspectionSummary(InspectionSummaryRequest request)
        {
            RecordSummaryResponse recordSummaryResp = GetRecordSummary(request);
            InspectionSummaryResponse result = new InspectionSummaryResponse();
            result.InspectionSummary = recordSummaryResp.InspectionSummary;
            result.Events = recordSummaryResp.Events;
            return result;
        }

        public WorkflowSummaryResponse GetWorkflowSummary(WorkflowSummaryRequest request)
        {
            RecordSummaryResponse recordSummaryResp = GetRecordSummary(request);
            WorkflowSummaryResponse result = new WorkflowSummaryResponse();
            result.WorkflowSummary = recordSummaryResp.WorkflowSummary;
            result.Events = recordSummaryResp.Events;
            return result;
        }

        public FeeSummaryResponse GetFeeSummary(FeeSummaryRequest request)
        {
            RecordSummaryResponse recordSummaryResp = GetRecordSummary(request);
            FeeSummaryResponse result = new FeeSummaryResponse();
            result.FeeSummary = recordSummaryResp.FeeSummary;
            result.Events = recordSummaryResp.Events;
            return result;
        }

        public ContactSummaryResponse GetContactSummary(ContactSummaryRequest request)
        {
            RecordSummaryResponse recordSummaryResp = GetRecordSummary(request);
            ContactSummaryResponse result = new ContactSummaryResponse();
            result.ContactSummaries = recordSummaryResp.ContactSummaries;
            result.Events = recordSummaryResp.Events;
            return result;
        }

        public ProjectInformationResponse GetProjectInformations(ProjectInformationRequest request)
        {
            var recordSummaryResp = GetRecordSummary(request);
            var result = new ProjectInformationResponse();
            result.ProjectInformations = recordSummaryResp.ProjectInformations;
            result.Events = recordSummaryResp.Events;
            return result;
        }

        private RecordSummaryResponse GetRecordSummary(RecordSummaryRequest request)
        {
            //if same user, env and agency access summary, it should been waiting to get data
            string userInfo = recordRepository.CurrentContext.EnvName + "-" + recordRepository.CurrentContext.Agency + "-" + recordRepository.CurrentContext.LoginName;
            lock (userInfo)
            {
                return recordRepository.GetRecordSummary(request);
            }
        }

        /// <summary>
        /// The API only for Inspector App service. 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ContactsResponse GetRecordContacts(ContactsRequest request)
        {
            /*
             * I do not know why the original implementation treats the contacts in Inspector App private API 
             * as a different way as we do in public API.
             * 
             * They should have the same result. They are the same thing.
             * 
             * We keep this method in order to let it works as a place holder. 
             * If we finally find it is necessary to do that, we have a chance to do it.
             * 
            //*/
            RecordContactsRequest realRequest = new RecordContactsRequest();
            realRequest.RecordId = request.RecordId;

            var tmpResult = GetRecordContacts(realRequest);

            ContactsResponse result = new ContactsResponse();
            result.Events = tmpResult.Events;
            result.Contacts = tmpResult.Contacts;

            return result;
        }

        /// <summary>
        /// Gets the record owners.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the record owners.</returns>
        public RecordOwnersResponse GetRecordOwners(RecordOwnersRequest request)
        {
            var recordRequest = new RecordsRequest();
            recordRequest.Method = RecordsRequest.Methods.GetRecordsByIds.ToString();
            //recordRequest.SystemInfo = request.SystemInfo;
            recordRequest.Criteria = new RecordCriteria();
            recordRequest.Criteria.RecordIds = new List<string>();
            recordRequest.Criteria.RecordIds.Add(request.RecordId);
            recordRequest.Elements = new List<string>();
            recordRequest.Elements.Add("Contacts");

            RecordsResponse recordResponse = recordRepository.GetRecords(recordRequest);
            if (recordResponse == null || recordResponse.Records == null || recordResponse.Records.Count != 1)
            {
                throw new NotFoundException("The Record: " + request.RecordId + " does not exist.");
            }

            var currentRecord = recordResponse.Records[0];

            var retu = new RecordOwnersResponse();
            retu.Events = recordResponse.Events;

            if (currentRecord != null && currentRecord.Contacts != null && currentRecord.Contacts.Count > 0)
            {
                var owners = new List<OwnerModel>();
                foreach (var contact in currentRecord.Contacts)
                {
                    if (contact != null && contact.Identifier != null && contact.Identifier.IndexOf("owner", StringComparison.OrdinalIgnoreCase) != -1)
                    {
                        var clientOwner = ToClientOwner(contact);
                        owners.Add(clientOwner);
                    }
                }

                if (owners.Count > 0)
                {
                    retu.Owners = owners;
                }
            }

            return retu;
        }

        public RecordContactsResponse GetRecordContacts(RecordContactsRequest request)
        {
            return recordRepository.GetRecordContacts(request);
        }

        public ConditionsResponse GetRecordConditions(ConditionsRequest request)
        {
            RecordsRequest recordRequest = new RecordsRequest();
            //recordRequest.SystemInfo = request.SystemInfo;
            recordRequest.Criteria = new RecordCriteria();
            recordRequest.Criteria.RecordIds = new List<string>();
            recordRequest.Criteria.RecordIds.Add(request.RecordId);
            recordRequest.Elements = new List<string>();
            recordRequest.Elements.Add("Conditions");

            RecordsResponse recordResponse = recordRepository.GetRecords(recordRequest);
            if (recordResponse == null || recordResponse.Records == null || recordResponse.Records.Count != 1)
            {
                throw new NotFoundException("The Record: " + request.RecordId + " didn't exist");
            }

            ConditionsResponse retu = new ConditionsResponse();
            retu.Events = recordResponse.Events;
            retu.Conditions = recordResponse.Records[0].Conditions;

            if (retu.Conditions != null && !string.IsNullOrWhiteSpace(request.Filter) && retu.Conditions.Count > 0)
            {
                ConditionModel selectedItem = retu.Conditions[0];
                for (int i = 1; i < retu.Conditions.Count; i++)
                {
                    ConditionModel item = retu.Conditions[i];
                    int oldItemSev = GetSevLevel(selectedItem);
                    int newItemSev = GetSevLevel(item);

                    if (newItemSev > oldItemSev)
                    {
                        selectedItem = item;
                    }
                }

                retu.Conditions = new List<ConditionModel>();
                retu.Conditions.Add(selectedItem);
            }

            return retu;
        }

        /// <summary>
        /// Gets the record inspections.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the record inspections.</returns>
        public RecordInspectionsResponse GetRecordInspections(RecordInspectionsRequest request)
        {
            var inspectionsRequest = new InspectionsRequest();
            inspectionsRequest.Elements = new List<string> { AAReturnElements.Inspection.Basic, AAReturnElements.Inspection.Departments };
            inspectionsRequest.Criteria = new InspectionCriteria();
            inspectionsRequest.Criteria.RecordId = request.RecordId;
            inspectionsRequest.Criteria.ScheduleDateFrom = request.InspectionScheduledDateFrom;
            inspectionsRequest.Criteria.ScheduleDateTo = request.InspectionScheduledDateTo;

            inspectionsRequest.Criteria.OpenInspectionsOnly = request.OpenInspectionsOnly != null ? request.OpenInspectionsOnly.ToString() : null;

            InspectionsResponse response = InspectionRepository.GetInspections(inspectionsRequest, new List<string>() { "comments" });

            RecordInspectionsResponse result = new RecordInspectionsResponse();
            result.Error = response.Error;
            result.Events = response.Events;
            result.Inspections = response.Inspections;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public AdditionalResponse GetRecordAdditionals(AdditionalRequest request)
        {
            return GetRecordAdditionals(request, true);
        }

        public AdditionalResponse GetAllRecordAdditionals(AdditionalRequest request)
        {
            return GetRecordAdditionals(request, false);
        }

        private AdditionalResponse GetRecordAdditionals(AdditionalRequest request, bool applySecurity)
        {
            RecordsResponse recordResponse = GetRecordById(request.RelatedId);

            if (recordResponse == null || recordResponse.Records == null || recordResponse.Records.Count != 1)
            {
                throw new NotFoundException("The Record: " + request.RelatedId + " does not exist.");
            }

            var additionalResponse = new AdditionalResponse();

            additionalResponse.Additionals = recordResponse.Records[0].AdditionalInfo;

            if (applySecurity)
            {
                ASISecurityBusinessEntity.RemoveASIInvisableItems(additionalResponse.Additionals);
            }

            return additionalResponse;
        }

        public AdditionalTableResponse GetRecordAdditionalTables(AdditionalTableRequest request)
        {
            return GetRecordAdditionalTables(request, true);
        }

        public AdditionalTableResponse GetAllRecordAdditionalTables(AdditionalTableRequest request)
        {
            return GetRecordAdditionalTables(request, false);
        }

        private AdditionalTableResponse GetRecordAdditionalTables(AdditionalTableRequest request, bool applySecurity)
        {
            RecordsResponse recordResponse = GetRecordById(request.RelatedId);

            if (recordResponse == null || recordResponse.Records == null || recordResponse.Records.Count != 1)
            {
                throw new NotFoundException("The Record: " + request.RelatedId + " does not exist.");
            }

            var additionalResponse = new AdditionalTableResponse();

            additionalResponse.AdditionalTables = recordResponse.Records[0].AdditionalTableInfo;

            if (applySecurity)
            {
                ASISecurityBusinessEntity.RemoveASITInvisableItems(additionalResponse.AdditionalTables);
            }

            return additionalResponse;
        }

        public RecordsResponse GetRecordById(string recordId)
        {
            var recordRequest = new RecordsRequest();
            //recordRequest.SystemInfo = systemInfo;
            recordRequest.Criteria = new RecordCriteria();
            recordRequest.Criteria.RecordIds = new List<string>();
            recordRequest.Criteria.RecordIds.Add(recordId);
            recordRequest.Elements = new List<string>();
            recordRequest.Elements.Add("AdditionalInformation");
            recordRequest.Elements.Add("DrillDown");
            recordRequest.Method = RecordsRequest.Methods.GetRecordsByIds.ToString();

            return recordRepository.GetRecords(recordRequest);
        }

        public AddressesResponse GetAddresses(AddressesRequest request)
        {
            return recordRepository.GetAddresses(request);
        }

        /// <summary>
        /// Get Record's parcels
        /// </summary>
        /// <param name="request">the record id in request</param>
        /// <returns>return the parcel that below to record</returns>
        public ParcelsResponse GetRecordParcels(ParcelsRequest request)
        {
            RecordsRequest recordRequest = new RecordsRequest();
            recordRequest.Method = RecordsRequest.Methods.GetRecordsByIds.ToString();
            //recordRequest.SystemInfo = request.SystemInfo;
            recordRequest.Criteria = new RecordCriteria();
            recordRequest.Criteria.RecordIds = new List<string>();
            recordRequest.Criteria.RecordIds.Add(request.Criteria.RecordId);
            recordRequest.Elements = new List<string>();
            recordRequest.Elements.Add("Parcels");

            RecordsResponse recordResponse = recordRepository.GetRecords(recordRequest);
            if (recordResponse == null || recordResponse.Records == null || recordResponse.Records.Count != 1)
            {
                throw new NotFoundException("The Record: " + request.Criteria.RecordId + " doesn't exist");
            }
            ParcelsResponse retu = new ParcelsResponse();
            retu.Parcels = recordResponse.Records[0].Parcels;

            return retu;
        }

        /// <summary>
        /// Get Record's costs.
        /// </summary>
        /// <param name="request">CostsRequest.</param>
        /// <returns>CostsResponse.</returns>
        public CostsResponse GetRecordCosts(CostsRequest request)
        {
            RecordsRequest recordRequest = new RecordsRequest();
            recordRequest.Criteria = new RecordCriteria();
            recordRequest.Criteria.RecordIds = new List<string>();
            recordRequest.Criteria.RecordIds.Add(request.RecordId);
            recordRequest.Elements = new List<string>();
            recordRequest.Elements.Add("Costings");

            RecordsResponse recordResponse = recordRepository.GetRecords(recordRequest);
            if (recordResponse == null || recordResponse.Records == null || recordResponse.Records.Count != 1)
            {
                throw new NotFoundException("The Record: " + request.RecordId + " doesn't exist");
            }

            var costsResponse = new CostsResponse();
            costsResponse.Costs = recordResponse.Records[0].Costs;

            return costsResponse;
        }

        /// <summary>
        /// Get Record's parts
        /// </summary>
        /// <param name="request">the record id in request</param>
        /// <returns>return the part that below to record</returns>
        public PartsResponse GetRecordParts(PartsRequest request)
        {
            RecordsRequest recordRequest = new RecordsRequest();
            recordRequest.Criteria = new RecordCriteria();
            recordRequest.Criteria.RecordIds = new List<string>();
            recordRequest.Criteria.RecordIds.Add(request.RecordId);
            recordRequest.Elements = new List<string>();
            recordRequest.Elements.Add("Parts");

            RecordsResponse recordResponse = recordRepository.GetRecords(recordRequest);
            if (recordResponse == null || recordResponse.Records == null || recordResponse.Records.Count != 1)
            {
                throw new NotFoundException("The Record: " + request.RecordId + " doesn't exist");
            }

            PartsResponse retu = new PartsResponse();
            retu.Parts = recordResponse.Records[0].Parts;

            return retu;
        }

        public RelatedRecordsResponse GetRelatedRecords(RelatedRecordsRequest request)
        {
            RecordsRequest recordRequest = new RecordsRequest();

            recordRequest.Criteria = new RecordCriteria();

            recordRequest.Criteria.ReturnElements = new List<string> { "Basic", "CapDetails", "Comments", "CAPRelations" };

            recordRequest.Criteria.ParentRecordId = request.RecordId;

            recordRequest.Criteria.SubsidiaryRecordId = request.RecordId;

            RecordsResponse recordResponse = recordRepository.GetRecords(recordRequest);

            RelatedRecordsResponse response = new RelatedRecordsResponse();

            response.Events = recordResponse.Events;

            response.Records = recordResponse.Records;

            return response;
        }

        /// <summary>
        /// Get record's assets.
        /// </summary>
        /// <param name="recordAssetsRequest">RecordAssetsRequest.</param>
        /// <returns>RecordAssetsResponse.</returns>
        public RecordAssetsResponse GetRecordAssets(RecordAssetsRequest recordAssetsRequest)
        {
            RecordsRequest recordRequest = new RecordsRequest();
            recordRequest.Criteria = new RecordCriteria();
            recordRequest.Criteria.RecordIds = new List<string>();
            recordRequest.Criteria.RecordIds.Add(recordAssetsRequest.RecordId);
            recordRequest.Elements = new List<string>();
            recordRequest.Elements.Add("Assets");

            RecordsResponse recordResponse = recordRepository.GetRecords(recordRequest);
            if (recordResponse == null || recordResponse.Records == null || recordResponse.Records.Count != 1)
            {
                throw new NotFoundException("The Record: " + recordAssetsRequest.RecordId + " doesn't exist");
            }

            var recordAssetsResponse = new RecordAssetsResponse();
            recordAssetsResponse.Assets = recordResponse.Records[0].Assets;
            recordAssetsResponse.Error = recordResponse.Error;
            recordAssetsResponse.Events = recordResponse.Events;

            return recordAssetsResponse;
        }

        public RecordCommentsResponse GetRecordComments(RecordCommentsRequest request)
        {
            RecordsRequest recordRequest = new RecordsRequest();
            recordRequest.Method = RecordsRequest.Methods.GetRecordsByIds.ToString();
            recordRequest.Criteria = new RecordCriteria();
            recordRequest.Criteria.RecordIds = new List<string>();
            recordRequest.Criteria.RecordIds.Add(request.RecordId);
            recordRequest.Elements = new List<string>();
            recordRequest.Elements.Add("Comments");

            RecordsResponse recordResponse = recordRepository.GetRecords(recordRequest);
            if (recordResponse == null || recordResponse.Records == null || recordResponse.Records.Count != 1)
            {
                throw new NotFoundException("The Record: " + request.RecordId + " does not exist.");
            }

            var recordCommentsResponse = new RecordCommentsResponse();
            recordCommentsResponse.RecordComments = recordResponse.Records[0].RecordComments;
            recordCommentsResponse.Error = recordResponse.Error;
            recordCommentsResponse.Events = recordResponse.Events;
            return recordCommentsResponse;
        }

        public WorkflowTasksResponse GetWorkflowTasks(WorkflowTasksRequest request)
        {
            return recordRepository.GetWorkflowTasks(request);
        }

        public UpdateWorkflowTaskResponse UpdateWorkflowTask(UpdateWorkflowTaskRequest request)
        {
            return recordRepository.UpdateWorkflowTask(request);
        }

        public RecordLocationResponse GetRecordLocation(RecordLocationRequest request)
        {
            var result = new RecordLocationResponse();

            var recordsResponse = GetRecordsImp(request);

            if (recordsResponse != null
                && recordsResponse.Records != null
                && recordsResponse.Records.Count == 1)
            {
                var record = recordsResponse.Records[0];

                var location = LocationForRecord(record);

                if (location != null)
                {
                    result.Location = location;
                }
            }

            return result;
        }

        public RecordsLocationResponse GetRecordsLocation(RecordLocationRequest request)
        {
            RecordsLocationResponse result = new RecordsLocationResponse();

            if (request.Criteria.RecordIds == null)
            {
                return result;
            }

            var originalIds = new List<string>(request.Criteria.RecordIds);

            var recordIdMapping = new Dictionary<string, string>();

            for (int i = 0; i < request.Criteria.RecordIds.Count; i++)
            {
                var id = request.Criteria.RecordIds[i];
                var tmpIds = id.Split('-');

                string idWithoutServiceProviderCode = id;

                if (tmpIds.Length == 4)
                {
                    idWithoutServiceProviderCode = String.Join("-", tmpIds, 1, 3);
                }

                if (!recordIdMapping.ContainsKey(idWithoutServiceProviderCode))
                {
                    recordIdMapping.Add(idWithoutServiceProviderCode, id);
                }

                request.Criteria.RecordIds[i] = idWithoutServiceProviderCode;
            }

            request.Criteria.RecordIds = request.Criteria.RecordIds.Distinct().ToList();

            var recordsResponse = GetRecordsImp(request);

            Dictionary<string, LocationModel> recordsLocation = null;
            if (recordsResponse != null
                && recordsResponse.Records != null
                && recordsResponse.Records.Count > 0)
            {
                recordsLocation = new Dictionary<string, LocationModel>();
                recordsResponse.Records.ForEach(record =>
                {
                    string originalId = null;
                    if (recordIdMapping.ContainsKey(record.Identifier))
                    {
                        originalId = recordIdMapping[record.Identifier];
                    }

                    if (!String.IsNullOrEmpty(originalId))
                    {
                        recordsLocation.Add(originalId, LocationForRecord(record));
                    }
                });
            }

            if (recordsLocation != null)
            {
                result.Locations = new List<RecordLocationModel>();
                originalIds.ForEach(id =>
                {
                    if (recordsLocation.ContainsKey(id))
                    {
                        result.Locations.Add(new RecordLocationModel { Id = id, Location = recordsLocation[id] });
                    }
                    else
                    {
                        result.Locations.Add(new RecordLocationModel { Id = id, Location = null });
                    }
                });
            }

            return result;
        }

        public WorkOrderTasksResponse GetWorkOrderTasks(WorkOrderTasksRequest request)
        {
            RecordsRequest recordRequest = new RecordsRequest();
            recordRequest.Criteria = new RecordCriteria();
            recordRequest.Criteria.RecordIds = new List<string>();
            recordRequest.Criteria.RecordIds.Add(request.RecordId);
            recordRequest.Elements = new List<string>();
            recordRequest.Elements.Add("WorkOrderTasks");

            RecordsResponse recordResponse = recordRepository.GetRecords(recordRequest);
            if (recordResponse == null || recordResponse.Records == null || recordResponse.Records.Count != 1)
            {
                throw new NotFoundException("The Record: " + request.RecordId + " does not exist.");
            }

            var workOrderTasksResponse = new WorkOrderTasksResponse();
            workOrderTasksResponse.Tasks = recordResponse.Records[0].WorkOrderTasks;
            workOrderTasksResponse.Error = recordResponse.Error;
            workOrderTasksResponse.Events = recordResponse.Events;
            return workOrderTasksResponse;
        }

        /// <summary>
        /// Counts the daily records.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the daily records count.</returns>
        public DailyRecordsCountResponse CountDailyRecords(DailyRecordsCountRequest request)
        {
            return recordRepository.CountDailyRecords(request);
        }



        public RecordsGeoResponse GetRecordsViaCivicId(RecordsGeoRequest request)
        {
            RecordsGeoResponse response = new RecordsGeoResponse();

            if (request == null)
            {
                return response;
            }

            response.Records = new List<RecordGeoModel>();

            List<RecordGeoModel> results = new List<RecordGeoModel>();
            results = GlobalEntityRepository.GetGlobalEntitiesByCivicId(request.CivicId, GLOBAL_ENTITY_RECORD_TYPE, request.Environment, request.Offset, request.Limit);

            if (results != null && results.Count > 0)
            {
                response.Records = results;
                response.PageInfo = new Pagination()
                {
                    Offset = request.Offset,
                    Limit = request.Limit
                };
                response.PageInfo.TotalRows = GlobalEntityRepository.GetGlobalEntitiesCountByCivicId(request.CivicId, GLOBAL_ENTITY_RECORD_TYPE, request.Environment);
            }

            return response;
        }



        public DrillDownValuesResponse GetASIDrillDownValues(DrillDownValuesRequest request)
        {
            DrillDownValuesResponse result = new DrillDownValuesResponse();
            List<AdditionalGroupModel> asi = null;
            RecordsResponse recordResponse = GetRecordById(request.RecordId);

            if (recordResponse == null || recordResponse.Records == null || recordResponse.Records.Count != 1)
            {
                throw new NotFoundException("The Record: " + request.RecordId + " does not exist.");
            }

            if (recordResponse.Records[0].AdditionalInfo != null
                && recordResponse.Records[0].AdditionalInfo.Count > 0)
            {
                asi = recordResponse.Records[0].AdditionalInfo;
            }

            if (asi != null)
            {
                result = ASIBusinessEntity.GetASIDrilldownValue(request.DrillDownId, asi);
            }

            return result;
        }

        public DrillDownValuesResponse GetASIDrillDownValuesForParent(DrillDownValuesRequest request)
        {
            DrillDownValuesResponse result = new DrillDownValuesResponse();
            List<AdditionalGroupModel> asi = null;
            RecordsResponse recordResponse = GetRecordById(request.RecordId);

            if (recordResponse == null || recordResponse.Records == null || recordResponse.Records.Count != 1)
            {
                throw new NotFoundException("The Record: " + request.RecordId + " does not exist.");
            }

            if (recordResponse.Records[0].AdditionalInfo != null
                && recordResponse.Records[0].AdditionalInfo.Count > 0)
            {
                asi = recordResponse.Records[0].AdditionalInfo;
            }

            if (asi != null)
            {
                result = ASIBusinessEntity.GetASIDrilldownValueByParent(request.DrillDownId, request.ParentValueId, asi);
            }

            return result;
        }


        public DrillDownValuesResponse GetASITDrillDownValues(DrillDownValuesRequest request)
        {
            DrillDownValuesResponse result = new DrillDownValuesResponse();
            List<AdditionalTableModel> asit = null;
            RecordsResponse recordResponse = GetRecordById(request.RecordId);

            if (recordResponse == null || recordResponse.Records == null || recordResponse.Records.Count != 1)
            {
                throw new NotFoundException("The Record: " + request.RecordId + " does not exist.");
            }

            if (recordResponse.Records[0].AdditionalTableInfo != null
                && recordResponse.Records[0].AdditionalTableInfo.Count > 0)
            {
                asit = recordResponse.Records[0].AdditionalTableInfo;
            }

            if (asit != null)
            {
                result = ASIBusinessEntity.GetASITDrilldownValue(request.DrillDownId, asit);
            }

            return result;
        }

        public DrillDownValuesResponse GetASITDrillDownValuesForParent(DrillDownValuesRequest request)
        {
            DrillDownValuesResponse result = new DrillDownValuesResponse();
            List<AdditionalTableModel> asit = null;
            RecordsResponse recordResponse = GetRecordById(request.RecordId);

            if (recordResponse == null || recordResponse.Records == null || recordResponse.Records.Count != 1)
            {
                throw new NotFoundException("The Record: " + request.RecordId + " does not exist.");
            }

            if (recordResponse.Records[0].AdditionalTableInfo != null
            && recordResponse.Records[0].AdditionalTableInfo.Count > 0)
            {
                asit = recordResponse.Records[0].AdditionalTableInfo;
            }

            if (asit != null)
            {
                result = ASIBusinessEntity.GetASITDrilldownValueByParent(request.DrillDownId, request.ParentValueId, asit);
            }

            return result;
        }

        #endregion

        #region private methods

        /// <summary>
        /// Cache Record Coordinate in Cloud server.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="creationResult"></param>
        private Guid CacheRecordCoordinates(CreateRecordRequest request, CreateRecordResponse creationResult)
        {
            if (request == null || request.Record == null
                || creationResult == null || creationResult.RecordId == null)
            {
                return Guid.Empty; ;
            }

            // Here may exist potential bugs, when adding the record is exist
            #region Save coodinate to Cloud DB(GlobalEntities and GeoCoordinates)

            GlobalEntityModel globalEntity = new GlobalEntityModel
            {
                AgencyName = recordRepository.CurrentContext.Agency,
                Environment = recordRepository.CurrentContext.EnvName,
                EntityID = creationResult.RecordId.Identifier,
                EntityType = "RECORD",
                CreatedBy = recordRepository.CurrentContext.LoginName,
                CreatedDate = DateTime.UtcNow,
                LastUpdatedBy = recordRepository.CurrentContext.LoginName,
                LastUpdatedDate = DateTime.UtcNow,
                CloudUserID = recordRepository.CurrentContext.ContextUser.Id,
                Keep1 = request.Record.RecordType.Identifier,
                Keep2 = AddressModel.GetOneLineString(request.Record.Addresses),
                Keep3 = request.Record.Description,
                //Keep4 = creationResult.Status,
                OpenDate = DateTimeFormat.ToDateTimeFromUIDateTimeString(creationResult.OpenDate),
                ImageUrls = creationResult.ImageUrls,
                //AssignTo = creationResult.AssignTo,
                IsPrivate = request.Record.IsPrivate
            };

            if (request.Record.RecordStatus != null)
            {
                globalEntity.Keep4 = request.Record.RecordStatus.Identifier;
            }
            globalEntity = GlobalEntityRepository.AddIfNotExist(globalEntity);

            if (globalEntity != null && globalEntity.ID != null
                && request.Record != null && request.Record.Addresses != null
                && request.Record.Addresses.Count > 0)
            {
                foreach (var address in request.Record.Addresses)
                {
                    var recordCoordinateInfo = new GeoCoordinateModel
                    {
                        CoordinateX = address.XCoordinate,
                        CoordinateY = address.YCoordinate,
                        CreatedBy = recordRepository.CurrentContext.LoginName,
                        CreatedDate = DateTime.UtcNow,
                    };
                    recordCoordinateInfo.GlobalEntityId = globalEntity.ID;
                    CoordinateRepository.SaveRecordCoordinate(recordCoordinateInfo);
                }
            }

            return globalEntity.ID;
            #endregion
        }

        /// <summary>
        /// only return the highest severity level item to client(only one condition)
        /// lock>hold>required>notice>empty
        /// </summary>
        /// <param name="cond"></param>
        /// <returns></returns>
        private int GetSevLevel(ConditionModel cond)
        {
            int itemSev = 0;
            if (cond.SeverityLevel != null && cond.SeverityLevel.Identifier != null)
            {
                switch (cond.SeverityLevel.Identifier.Trim().ToLower())
                {
                    case "notice":
                        itemSev = 1;
                        break;
                    case "required":
                        itemSev = 2;
                        break;
                    case "hold":
                        itemSev = 3;
                        break;
                    case "lock":
                        itemSev = 4;
                        break;
                }
            }

            return itemSev;
        }

        /// <summary>
        /// Toes the client owner.
        /// </summary>
        /// <param name="contactModel">The contact model.</param>
        /// <returns>the client owner.</returns>
        private OwnerModel ToClientOwner(ContactModel contactModel)
        {
            OwnerModel result = null;

            if (contactModel != null)
            {
                result = new OwnerModel()
                {
                    Action = contactModel.Action,
                    Emails = contactModel.Emails,
                    Faxs = contactModel.Faxs,
                    FaxCountryCodes = contactModel.FaxCountryCodes,
                    GivenName = contactModel.GivenName,
                    FamilyName = contactModel.FamilyName,
                    MiddleNames = contactModel.MiddleNames,
                    FullName = contactModel.FullName,
                    Id = contactModel.Identifier,
                    IsPrimary = contactModel.IsPrimary,
                    Address = contactModel.Address,
                    MailingAddress = contactModel.MailingAddress,
                    PersonId = contactModel.PersonIdentifier,
                    Tels = contactModel.Tels,
                    TelCountryCodes = contactModel.TelCountryCodes,
                    CountryCode = contactModel.CountryCode
                };
            }

            return result;
        }


        private LocationModel FindLocationFromRecordGeocoding(RecordModel record)
        {
            if (record.Addresses != null
                && record.Addresses.Count > 0)
            {
                AddressModel address = record.Addresses.FirstOrDefault(item => item.IsPrimary.HasValue && item.IsPrimary.Value) ?? record.Addresses[0];

                return GetLocationByGeoCodingAddress(address);
            }

            return null;
        }

        private LocationModel GetLocationByGeoCodingAddress(AddressModel address)
        {
            CoordinateModel geocodingResult = CoordinateRepository.GetCoordinate(address);

            if (geocodingResult != null
                && !Double.IsNaN(geocodingResult.LocationX)
                && !Double.IsNaN(geocodingResult.LocationY))
            {
                var location = new LocationModel
                {
                    GeometryPoint = new GeometryPointModel
                    {
                        X = geocodingResult.LocationX.ToString("R"),
                        Y = geocodingResult.LocationY.ToString("R")
                    }
                };

                return location;
            }

            return null;
        }

        private LocationModel FindLocationFromRecordParcel(RecordModel record)
        {
            if (record.Parcels != null
                && record.Parcels.Count > 0)
            {
                ParcelModel parcelWithGISObject = record.Parcels.FirstOrDefault(item => item.GISObjects != null
                                                                                        && item.GISObjects.Count > 0);

                if (parcelWithGISObject != null)
                {
                    var location = new LocationModel { GisObject = parcelWithGISObject.GISObjects[0] };
                    return location;
                }
            }
            return null;
        }

        private LocationModel FindLocationFromRecordAsset(RecordModel record)
        {
            if (record.Assets != null
                && record.Assets.Count > 0)
            {
                var assetTypesRequest = new AssetTypesRequest
                {
                    Offset = 0,
                    Limit = 0
                };

                AssetTypesResponse assetTypesResponse = ReferenceDataRepository.GetAssetTypes(assetTypesRequest);

                AssetModel assetWithGISObject = record.Assets.FirstOrDefault(item => item.GISObjects != null
                                                                                     && item.GISObjects.Count > 0);

                var location = new LocationModel();

                if (assetWithGISObject != null)
                {
                    location.GisObject = assetWithGISObject.GISObjects[0];
                }

                if (location.GisObject != null
                    && assetTypesResponse != null
                    && assetTypesResponse.Types != null
                    && assetTypesResponse.Types.Count > 0)
                {
                    AssetTypeModel assetType =
                        assetTypesResponse.Types.FirstOrDefault(item => assetWithGISObject.AssetType != null
                                                                        && item.Id == assetWithGISObject.AssetType.Id);

                    if (assetType != null)
                    {
                        location.GisObject.FeatureIDFieldName = assetType.GISIDFieldName;
                    }
                }

                return location;
            }

            return null;
        }

        private LocationModel FindLocationFromRecordGISObject(RecordModel record)
        {
            if (record.GISObjects != null
                && record.GISObjects.Count > 0)
            {
                GISObjectModel primaryGISObject = record.GISObjects.Find(item => item.DetailAddress != null
                                                                                 && item.DetailAddress.IsPrimary.HasValue
                                                                                 && item.DetailAddress.IsPrimary.Value);

                var location = new LocationModel { GisObject = primaryGISObject ?? record.GISObjects[0] };

                return location;
            }

            return null;
        }

        private AddressModel FindAddressWithXY(RecordModel record)
        {
            var addressesWithXY = record.Addresses.FindAll(item => !String.IsNullOrEmpty(item.XCoordinate)
                                                                && !String.IsNullOrEmpty(item.YCoordinate));
            if (addressesWithXY.Count == 0)
            {
                return null;
            }

            return addressesWithXY.FirstOrDefault(item => item.IsPrimary.HasValue && item.IsPrimary.Value) ?? addressesWithXY.FirstOrDefault();
        }

        private bool IsXYValid(AddressModel address)
        {
            double xcoordinate = 0.0;
            Double.TryParse(address.XCoordinate, out xcoordinate);

            double ycoordinate = 0.0;
            Double.TryParse(address.YCoordinate, out ycoordinate);

            return (Math.Abs(xcoordinate) <= 180 && Math.Abs(ycoordinate) <= 90)
                   && (xcoordinate != 0.0 && ycoordinate != 0.0);
        }

        private LocationModel FindLocationFromAddressXY(RecordModel record)
        {
            if (record.Addresses == null || record.Addresses.Count <= 0) return null;

            var address = FindAddressWithXY(record);

            if (address == null) return null;

            if (ShouldAutoCorrectCoordinate)
            {
                if (IsXYValid(address))
                {
                    return new LocationModel
                    {
                        GeometryPoint = new GeometryPointModel { X = address.XCoordinate, Y = address.YCoordinate }
                    };
                }
                else
                {
                    address.XCoordinate = null;
                    address.YCoordinate = null;

                    return GetLocationByGeoCodingAddress(address);
                }
            }
            else
            {
                return new LocationModel
                {
                    GeometryPoint = new GeometryPointModel { X = address.XCoordinate, Y = address.YCoordinate }
                };
            }
        }

        private bool ShouldAutoCorrectCoordinate
        {
            get
            {
                // This kind of special geo-coding logic only applies to Accela mobile Apps.
                return IsAccelaMobileApps;
            }
        }

        private static readonly List<string> AccelaMobileAppIds = new List<string>
        {
            "com.accela.inspector",  // Accela Inspector
            "634787061125751953",    // Accela Code Officer
            "634787042277734375",    // Accela Work Crew
            "635042531515887177"     // Accela Analytics
        };

        private bool IsAccelaMobileApps
        {
            get { return AccelaMobileAppIds.Contains(recordRepository.CurrentContext.App); }
        }

        private LocationModel LocationForRecord(RecordModel record)
        {
            /*
             * Rules:
             * 
             * 1. If Record's Address has x and y coordinate information, use that Point as Location of the Record to show it in Map.
             * 2. If Record has primary GIS Object, use that as Location of the Record to show it in Map;
             *    If no primary GIS Object, just use one of all GIS Objects.
             * 3. Else, use Record Primary Asset Location.
             * 4. Else, use Record Primary Parcel Location.
             * 5. Else, use Record Address to show Record at Geo-coded Point.
             * 
            //*/

            return FindLocationFromAddressXY(record) ??
                   FindLocationFromRecordGISObject(record) ??
                   FindLocationFromRecordAsset(record) ??
                   FindLocationFromRecordParcel(record) ??
                   FindLocationFromRecordGeocoding(record) ?? null;
        }

        private RecordsResponse GetRecordsImp(RecordLocationRequest request)
        {
            var recordRequest = new RecordsRequest
            {
                Criteria = request.Criteria,
                Elements = request.Elements,
                IgnoreCoordinatesSearch = true
            };

            return recordRepository.GetRecords(recordRequest);
        }

        #endregion


    }
}
