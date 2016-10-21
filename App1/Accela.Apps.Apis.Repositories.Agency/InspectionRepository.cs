using System;
using System.Collections.Generic;
using System.Linq;
using Accela.Apps.Apis.Models.DomainModels;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.InspectionRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;
using Accela.Apps.Apis.Repositories.GovXmlHelpers;
using Accela.Apps.Apis.Repositories.GovXmlQueries;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Apis.Repositories.Interfaces.Admin;
using Accela.Apps.Shared;
using Accela.Apps.Apis.Resources;
using Accela.Core.Ioc;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Apis.Models.Common;

namespace Accela.Apps.Apis.Repositories.Agency
{
    public class InspectionRepository : RepositoryBase, IInspectionRepository
    {
        #region Properties

        private IMobileEntityRepository<InspectionModel> _inspectionMECache;
        private IMobileEntityRepository<InspectionModel> InspectionMECache
        {
            get
            {
                if (_inspectionMECache == null)
                {
                    _inspectionMECache = IocContainer.Resolve<IMobileEntityRepository<InspectionModel>>();
                }

                return _inspectionMECache;
            }
        }

        private InspectionCache _inspectionCache;
        private InspectionCache InspectionCache
        {
            get
            {
                if (_inspectionCache == null)
                {
                    _inspectionCache = InspectionCache.Instance;
                }

                return _inspectionCache;
            }
        }

        private IAppSettingsRepository _appSettingsRepository;
        private IAppSettingsRepository AppSettingsRepository
        {
            get
            {
                if (_appSettingsRepository == null)
                {
                    _appSettingsRepository = IocContainer.Resolve<IAppSettingsRepository>();
                }

                return _appSettingsRepository;
            }
        }

        private IAppRepository _appRepository;
        private IAppRepository AppRepository
        {
            get
            {
                if (_appRepository == null)
                {
                    _appRepository = IocContainer.Resolve<IAppRepository>();
                }

                return _appRepository;
            }
        }

        private IRecordRepository _recordRepository;

        private InspectionHelper _inspectionHelper;

        #endregion

        public InspectionRepository(IRecordRepository RecordRepository, IAgencyAppContext contextEntity)
            : base(contextEntity)
        {
            //this.currentAgencyContext = contextEntity;
            this._recordRepository = RecordRepository;
            var bizServerVersion = this.Environment == null ? "" : this.Environment.BizServerVersion;
            if (!string.IsNullOrEmpty(bizServerVersion))
            {
                _inspectionHelper = new InspectionHelper(bizServerVersion, ShouldAutoCorrectCoordinate);
            }
        }

        /// <summary>
        /// Clear specified user's cache so that client is able to get latest data from next access.
        /// </summary>
        /// <param name="refreshRequest">Refresh request model.</param>
        public void RefreshData(RefreshRequest refreshRequest)
        {
            EntityScope scope = new EntityScope();
            scope.Agency = this.CurrentContext.Agency;
            scope.ProductName = this.CurrentContext.App;
            scope.UserId = this.CurrentContext.ContextUser.Id;

            InspectionMECache.DeleteEntitiesByUser(scope);
        }

        public InspectionResponse UpdateJob(InspectionRequest inspectionRequest)
        {
            InspectionResponse result = null;

            var inspectionModel = inspectionRequest.InspectionModel;

            if (inspectionModel != null)
            {
                var identifier = inspectionModel.Identifier;
                inspectionModel = MergeInspectionModel(inspectionModel);

                Accela.Automation.GovXmlClient.Model.GovXML govXmlIn = new Accela.Automation.GovXmlClient.Model.GovXML();
                govXmlIn.updateInspection = new Accela.Automation.GovXmlClient.Model.UpdateInspection();
                govXmlIn.updateInspection.system = CommonHelper.GetSystem(inspectionRequest, this.CurrentContext);
                govXmlIn.updateInspection.inspection = _inspectionHelper.ToXmlInspection(inspectionModel);

                Accela.Automation.GovXmlClient.Model.GovXML response = CommonHelper.Post(govXmlIn,
                                                                                         govXmlIn.updateInspection.system,
                                                                                         (o) => o.updateInspectionResponse == null ? null : o.updateInspectionResponse.system);

                InspectionResponse tem = _inspectionHelper.ToClientInspection(response.updateInspectionResponse);

                //According to test, the server returned date is not completed. so here will get data again
                string inspId = inspectionModel.Identifier;
                if (inspId == null)
                {
                    inspId = tem.Inspection.Identifier;
                }

                result = new InspectionResponse();
                result.Inspection = this.GetInspectionWithoutCache(inspectionModel.Identifier);
                try { 
                    if (response.updateInspectionResponse.inspection != null && response.updateInspectionResponse.inspection.guidesheets != null)
                    {
                        var guidesheetList = response.updateInspectionResponse.inspection.guidesheets.guidesheet;
                        if (guidesheetList != null)
                        {
                            List<string[]> idMapping = new List<string[]>();
                            foreach (var guidesheet in guidesheetList)
                            {
                                if (guidesheet.keys != null && guidesheet.oldGuideSheetSeqNbr != null && guidesheet.oldGuideSheetSeqNbr.keys != null)
                                {
                                    idMapping.Add(new string[] { guidesheet.oldGuideSheetSeqNbr.keys.key[0], guidesheet.keys.key[0]});
                                }
                            }
                            result.Inspection.ChecklistIdMapping = idMapping;
                        }
                    }
                }
                catch (Exception e)
                {
                    // TODO: handle error later; won't escalate in case break old customer w/o the feature
                }
                InspectionCache.UpdateInspectionRelatedData(result.Inspection, this.CurrentContext);
            }

            return result;
        }

        public JoblistResponse GetJobs(JoblistRequest request)
        {
            JoblistResponse result = null;

            var govXmlIn = new Automation.GovXmlClient.Model.GovXML
            {
                getInspections =
                    new Automation.GovXmlClient.Model.GetInspections {system = CommonHelper.GetSystem(request, this.CurrentContext)}
            };

            var criteria = new InspectionCriteria
            {
                ScheduleDateFrom = request.ScheduleDateFrom,
                ScheduleDateTo = request.ScheduleDateTo
            };

            if (!request.FetchInspectionsForAllInspectors)
            {
                criteria.InspectorIds = new List<string>(1) { this.CurrentContext.LoginName.ToUpper() };
            }

            criteria.Districts = request.Districts;

            var returnElements = new List<string> { AAReturnElements.Inspection.Basic, AAReturnElements.Inspection.Departments };

            _inspectionHelper.SetGovXmlFromCriteria(govXmlIn.getInspections, criteria, returnElements);

            Accela.Automation.GovXmlClient.Model.GovXML response = CommonHelper.Post(govXmlIn,
                                                                                     govXmlIn.getInspections.system,
                                                                                     (o) => o.getInspectionsResponse == null ? null : o.getInspectionsResponse.system);

            if (response != null
                && response.getInspectionsResponse != null)
            {
                result = new JoblistResponse();

                result.PageInfo = CommonHelper.GetPaginationFromSystem(response.getInspectionsResponse.system);
                result.Events = CommonHelper.GetClientEventMessage(response.getInspectionsResponse.system.eventMessages);
                result.Inspections = _inspectionHelper.ToClientInspections(response.getInspectionsResponse, null);

                if (result.Inspections != null
                    && result.Inspections.Count > 0)
                {
                    var recordIds = (from i in result.Inspections
                                     where i != null
                                     && i.Record != null
                                     && !String.IsNullOrWhiteSpace(i.Record.Identifier)
                                     select i.Record.Identifier).Distinct().ToArray();

                    var records = GetRecordsWithContactAndAddress(recordIds);

                    InspectionHelper.AssignContactAndAddress(result.Inspections, records);

                    if (ShouldAutoCorrectCoordinate)
                    {
                        InspectionHelper.SetCoordinates(result.Inspections.ToArray());
                    }

                    InspectionHelper.AssginRecordName(result.Inspections, records);
                }
            }

            return result;
        }

        private List<RecordModel> GetRecordsWithContactAndAddress(string[] recordIds)
        {
            List<RecordModel> result = null;

            if (recordIds != null && recordIds.Length > 0)
            {
                var recordRequest = new RecordsRequest();
                recordRequest.Criteria = new RecordCriteria();
                recordRequest.Criteria.RecordIds = new List<string>();
                recordRequest.Criteria.RecordIds.AddRange(recordIds);
                recordRequest.Elements = new List<string>();
                recordRequest.Elements.Add(AAReturnElements.Record.Contacts);
                recordRequest.Elements.Add(AAReturnElements.Record.Addresses);
                recordRequest.IgnoreCoordinatesSearch = true;

                var recordResponse = _recordRepository.GetRecords(recordRequest);

                if (recordResponse != null && recordResponse.Records != null && recordResponse.Records.Count > 0)
                {
                    result = recordResponse.Records;
                }
            }

            return result;
        }

        public InspectionCommentResponse GetInspetionComments(InspectionCommentRequest request)
        {
            InspectionCommentResponse result = null;

            if (request != null)
            {
                var inspectionModel = this.GetInspection(request.InspectionId);

                if (inspectionModel != null && inspectionModel.Comments != null)
                {
                    result = new InspectionCommentResponse()
                    {
                        InspectionComments = inspectionModel.Comments
                    };
                }
            }

            return result;
        }

        public InspectionChecklistResponse GetChecklists(InspectionChecklistRequest request)
        {
            InspectionChecklistResponse result = null;

            if (request != null)
            {
                var inspectionModel = this.GetInspection(request.InspectionId);

                if (inspectionModel != null && inspectionModel.Checklists != null)
                {
                    inspectionModel.Checklists.ForEach((o) => o.ChecklistItems = null);

                    result = new InspectionChecklistResponse()
                    {
                        InspectionChecklists = inspectionModel.Checklists
                    };
                }
            }

            return result;
        }

        public InspectionChecklistItemResponse GetChecklistItems(InspectionChecklistItemRequest request)
        {
            InspectionChecklistItemResponse result = null;

            if (request != null)
            {
                var inspectionModel = this.GetInspection(request.InspectionId);
                var currentChecklist = inspectionModel == null ? null : inspectionModel.Checklists.Where(cl => cl.Identifier == request.ChecklistId).FirstOrDefault();

                if (currentChecklist != null && currentChecklist.ChecklistItems != null)
                {
                    result = new InspectionChecklistItemResponse()
                    {
                        InspectionChecklistItems = currentChecklist.ChecklistItems
                    };
                }
            }

            return result;
        }

        public InspectionsResponse GetInspections(InspectionsRequest request, List<string> conversionElement)
        {
            InspectionsResponse result = null;

            Accela.Automation.GovXmlClient.Model.GovXML govXmlIn = new Automation.GovXmlClient.Model.GovXML();
            govXmlIn.getInspections = new Automation.GovXmlClient.Model.GetInspections();
            govXmlIn.getInspections.system = CommonHelper.GetSystem(request, this.CurrentContext);

            _inspectionHelper.SetGovXmlFromCriteria(govXmlIn.getInspections, request.Criteria, request.Elements);

            Accela.Automation.GovXmlClient.Model.GovXML response = CommonHelper.Post(govXmlIn,
                                                                                     govXmlIn.getInspections.system,
                                                                                     (o) => o.getInspectionsResponse == null ? null : o.getInspectionsResponse.system);

            if (response != null
                && response.getInspectionsResponse != null)
            {
                result = new InspectionsResponse();

                result.Inspections = _inspectionHelper.ToClientInspections(response.getInspectionsResponse, conversionElement);

                //No need for creating PagedList as response from GovXML is already paged as per request
                //if (result.Inspections != null)
                //{
                //    result.Inspections = result.Inspections.ToPagedList(request);
                //}

                //var totalCount = result.Inspections != null ? result.Inspections.Count : 0;
                //result.PageInfo = CommonHelper.GetPaginationFromResult(request, result.Inspections, totalCount);

                result.PageInfo = CommonHelper.GetPaginationFromSystem(response.getInspectionsResponse.system);
            }

            return result;
        }

        /// <summary>
        /// Update inspection. each record will be mark as action.
        /// the method difference updatejob. the updatejob serve with inspectorappservice.
        /// </summary>
        /// <param name="request">request that need updated inspection</param>
        /// <returns>return the keys after updated</returns>
        public UpdateInspectionResponse UpdateInspection(UpdateInspectionRequest request)
        {
            UpdateInspectionResponse result = null;

            if (request.Inspection != null)
            {
                Accela.Automation.GovXmlClient.Model.GovXML govXmlIn = new Automation.GovXmlClient.Model.GovXML();
                govXmlIn.updateInspection = new Automation.GovXmlClient.Model.UpdateInspection();
                govXmlIn.updateInspection.system = CommonHelper.GetSystem(request, this.CurrentContext);
                govXmlIn.updateInspection.inspection = _inspectionHelper.ToXmlInspection(request.Inspection);

                Accela.Automation.GovXmlClient.Model.GovXML response = CommonHelper.Post(govXmlIn,
                                                                                         govXmlIn.updateInspection.system,
                                                                                         (o) => o.updateInspectionResponse == null ? null : o.updateInspectionResponse.system);

                result = _inspectionHelper.ToClientUpdateInspection(response.updateInspectionResponse);

                InspectionCache.UpdateInspectionRelatedData(result.Inspection, this.CurrentContext);
            }
            else
            {
                throw new Exception(MobileResources.GetString("inspection_no_exsist"));
            }

            return result;
        }

        public CreateInspectionResponse CreateInspection(CreateInspectionRequest request)
        {
            CreateInspectionResponse result = null;

            if (request.Inspection != null)
            {
                Accela.Automation.GovXmlClient.Model.GovXML govXmlIn = new Automation.GovXmlClient.Model.GovXML();
                govXmlIn.scheduleInspection = new Automation.GovXmlClient.Model.ScheduleInspection();
                govXmlIn.scheduleInspection.system = CommonHelper.GetSystem(request, this.CurrentContext);
                govXmlIn.scheduleInspection.inspection = _inspectionHelper.ToXmlInspection(request.Inspection);
                if (govXmlIn.scheduleInspection.inspection != null)
                {
                    govXmlIn.scheduleInspection.inspection.contextType = "New";

                    if (request.Inspection.Record != null
                        && String.IsNullOrEmpty(request.Inspection.Record.Identifier)
                        && String.IsNullOrEmpty(request.Inspection.Record.Display))
                    {
                        CreateRecordRequest createRecordRequest = new CreateRecordRequest();
                        createRecordRequest.Record = request.Inspection.Record;
                        IRecordRepository recordRepository = IocContainer.Resolve<IRecordRepository>();
                        CreateRecordResponse createRecordResponse = recordRepository.CreateRecord(createRecordRequest);

                        govXmlIn.scheduleInspection.inspection.capId = new Accela.Automation.GovXmlClient.Model.CAPId();
                        govXmlIn.scheduleInspection.inspection.capId.keys = KeysHelper.CreateXMLKeys(createRecordResponse.RecordId.Identifier);
                    }
                }

                Accela.Automation.GovXmlClient.Model.GovXML response = CommonHelper.Post(govXmlIn,
                                                                                         govXmlIn.scheduleInspection.system,
                                                                                         (o) => o.scheduleInspectionResponse == null ? null : o.scheduleInspectionResponse.system);

                result = InspectionHelper.ToClientCreateInspection(response.scheduleInspectionResponse);

                // For inspection creation, after creating the new inspection successfully, it needs to send the request again to fetch the inspection detail information.
                if (result.Inspection != null
                    && !String.IsNullOrEmpty(result.Inspection.Identifier))
                {
                    var inspection = GetInspectionWithoutCache(result.Inspection.Identifier);

                    if (inspection != null)
                    {
                        result.Inspection = inspection;
                    }
                }
            }

            return result;
        }

        public RescheduleInspectionResponse RescheduleInspection(RescheduleInspectionRequest request)
        {
            RescheduleInspectionResponse result = null;

            if (request.Inspection != null)
            {
                Accela.Automation.GovXmlClient.Model.GovXML govXmlIn = new Automation.GovXmlClient.Model.GovXML();
                govXmlIn.rescheduleInspection = new Automation.GovXmlClient.Model.RescheduleInspection();
                govXmlIn.rescheduleInspection.system = CommonHelper.GetSystem(request, this.CurrentContext);
                govXmlIn.rescheduleInspection.inspection = _inspectionHelper.ToXmlInspection(request.Inspection);
                if (govXmlIn.rescheduleInspection.inspection != null)
                {
                    govXmlIn.rescheduleInspection.inspection.contextType = "Reschedule";
                }

                Accela.Automation.GovXmlClient.Model.GovXML response = CommonHelper.Post(govXmlIn,
                                                                                         govXmlIn.rescheduleInspection.system,
                                                                                         (o) => o.rescheduleInspectionResponse == null ? null : o.rescheduleInspectionResponse.system);

                result = _inspectionHelper.ToClientRescheduleInspection(response.rescheduleInspectionResponse);
            }

            return result;
        }

        public ReassignInspectionResponse ReassignInspection(ReassignInspectionRequest request)
        {
            ReassignInspectionResponse result = null;

            if (request.Inspection != null)
            {
                var govXmlIn = new Automation.GovXmlClient.Model.GovXML
                {
                    rescheduleInspection = new Automation.GovXmlClient.Model.RescheduleInspection
                    {
                        reassign = "true",
                        system = CommonHelper.GetSystem(request, this.CurrentContext),
                        inspection = _inspectionHelper.ToXmlInspection(request.Inspection)
                    }
                };

                if (govXmlIn.rescheduleInspection.inspection != null)
                {
                    govXmlIn.rescheduleInspection.inspection.contextType = "Assigned";
                }

                Accela.Automation.GovXmlClient.Model.GovXML response = CommonHelper.Post(govXmlIn,
                                                                                         govXmlIn.rescheduleInspection.system,
                                                                                         (o) => o.rescheduleInspectionResponse == null ? null : o.rescheduleInspectionResponse.system);

                result = _inspectionHelper.ToClientReassignInspection(response.rescheduleInspectionResponse);
            }

            return result;
        }

        public CancelInspectionResponse CancelInspection(CancelInspectionRequest request)
        {
            Accela.Automation.GovXmlClient.Model.GovXML govXmlIn = new Automation.GovXmlClient.Model.GovXML();
            govXmlIn.cancelInspection = new Automation.GovXmlClient.Model.CancelInspection();
            govXmlIn.cancelInspection.system = CommonHelper.GetSystem(request, this.CurrentContext);
            govXmlIn.cancelInspection.inspectionId = new Automation.GovXmlClient.Model.InspectionId[1];
            govXmlIn.cancelInspection.inspectionId[0] = new Automation.GovXmlClient.Model.InspectionId
            {
                keys = KeysHelper.CreateXMLKeys(request.InspectionId)
            };

            Accela.Automation.GovXmlClient.Model.GovXML response = CommonHelper.Post(govXmlIn,
                                                                                     govXmlIn.cancelInspection.system,
                                                                                     (o) => o.cancelInspectionResponse == null ? null : o.cancelInspectionResponse.system);

            return _inspectionHelper.ToClientCancelInspection(response.cancelInspectionResponse);
        }

        public AvailableInspectionDatesResponse GetAvailableInspectionDates(AvailableInspectionDatesRequest request)
        {
            Accela.Automation.GovXmlClient.Model.GovXML govXmlIn = new Automation.GovXmlClient.Model.GovXML();
            govXmlIn.getAvailableInspectionDates = new Automation.GovXmlClient.Model.GetAvailableInspectionDates();
            govXmlIn.getAvailableInspectionDates.system = CommonHelper.GetSystem(request, this.CurrentContext);
            govXmlIn.getAvailableInspectionDates.CAPId = new Automation.GovXmlClient.Model.CAPId
            {
                keys = KeysHelper.CreateXMLKeys(request.RecordId)
            };
            govXmlIn.getAvailableInspectionDates.InspectionTypeId = new Automation.GovXmlClient.Model.InspectionTypeId
            {
                keys = KeysHelper.CreateXMLKeys(request.InspectionTypeId)
            };
            if (!String.IsNullOrEmpty(request.StartDate))
            {
                govXmlIn.getAvailableInspectionDates.startDate = request.StartDate;
            }
            if (request.DatesCount != 0)
            {
                govXmlIn.getAvailableInspectionDates.availableDatesCount = request.DatesCount.ToString();
            }

            Accela.Automation.GovXmlClient.Model.GovXML response = CommonHelper.Post(govXmlIn,
                                                                                     govXmlIn.getAvailableInspectionDates.system,
                                                                                     (o) => o.getAvailableInspectionDatesResponse == null ? null : o.getAvailableInspectionDatesResponse.system);

            return _inspectionHelper.ToClientAvailableInspectionDates(response.getAvailableInspectionDatesResponse);
        }

        private void CheckReassignInspectionRequest(ReassignInspectionRequest request)
        {
            if (request.Inspection.AutoAssign)
            {
                if (
                    !(string.IsNullOrEmpty(request.Inspection.ScheduleDate) ||
                      string.IsNullOrEmpty(request.Inspection.ScheduleTime) || request.Inspection.Inspector == null))
                {
                    throw new ArgumentException(
                        "when AutoAssign was ture, the ScheduleData/ScheduleTime/Inspector must be empty.");
                }
            }
            else
            {
                DateTime scheduleDate;
                if (DateTime.TryParse(request.Inspection.ScheduleDate, out scheduleDate))
                {
                    request.Inspection.ScheduleDate = scheduleDate.ToString("yyyy-MM-dd");

                }
                else
                {
                    throw new ArgumentException("when AutoAssign was false, the ScheduleDate must need a valid value.");
                }


                if (!string.IsNullOrEmpty(request.Inspection.ScheduleTime))
                {
                    DateTime scheduleTime;
                    if (DateTime.TryParse(request.Inspection.ScheduleTime, out scheduleTime))
                    {
                        request.Inspection.ScheduleTime = scheduleTime.ToString("HH:mm");
                    }
                    else
                    {
                        throw new ArgumentException("the ScheduleTime must be a valid Datetime format.");
                    }
                }
            }
        }

        private InspectionModel GetInspection(string inspectionIdentifier)
        {
            InspectionModel result = null;

            result = InspectionCache.GetInspection(EntityTypes.Inspection, inspectionIdentifier, this.CurrentContext);

            if (result == null)
            {
                result = GetInspectionWithoutCache(inspectionIdentifier);

                if (result != null)
                {
                    InspectionCache.CacheOneInspectionData(result, this.CurrentContext);
                }
            }

            return result;
        }

        private InspectionModel GetInspectionWithoutCache(string inspectionId)
        {
            var inspectionsQuery = new InspectionsQuery()
            {
                RowStart = 0,
                PageSize = 0,
                InsepctionId = inspectionId
            };

            var govXmlIn = new Automation.GovXmlClient.Model.GovXML
            {
                getInspections =
                    new Automation.GovXmlClient.Model.GetInspections {system = CommonHelper.GetSystemFromPosition(0, 0, this.CurrentContext)}
            };

            var criteria = new InspectionCriteria();

            const string dateFormatForMeta = "yyyy-MM-dd";
            DateTime today = DateTime.Today;
            criteria.ScheduleDateFrom = today.ToString(dateFormatForMeta);
            criteria.ScheduleDateTo = today.ToString(dateFormatForMeta);

            criteria.InspectionId = inspectionsQuery.InsepctionId;
            criteria.InspectorIds = inspectionsQuery.InspectorIds;

            var returnElements = new List<string> { "Departments", "Contacts", "Addresses" };

            _inspectionHelper.SetGovXmlFromCriteria(govXmlIn.getInspections, criteria, returnElements);

            Accela.Automation.GovXmlClient.Model.GovXML response = CommonHelper.Post(govXmlIn,
                                                                                     govXmlIn.getInspections.system,
                                                                                     (o) => o.getInspectionsResponse == null ? null : o.getInspectionsResponse.system);

            var inspections = _inspectionHelper.ToClientInspections(response.getInspectionsResponse, null);
            var inspection = inspections != null && inspections.Count > 0 ? inspections[0] : null;
            return inspection;
        }

        private InspectionModel MergeInspectionModel(InspectionModel oldModel)
        {
            InspectionModel result = oldModel;

            if (oldModel != null)
            {
                var oldInspectionId = oldModel.Identifier;
                result = this.GetInspection(oldInspectionId);

                if (result != null)
                {
                    result.Comments = oldModel.Comments;
                    result.Status = oldModel.Status;
                    result.ResultDate = oldModel.ResultDate;
                    result.Inspector = oldModel.Inspector;
                    result.Department = oldModel.Department;
                    result.ContactName = oldModel.ContactName;
                    result.Latitude = oldModel.Latitude;
                    result.Longitude = oldModel.Longitude;

                    if (result.Checklists != null && result.Checklists.Count > 0)
                    {
                        result.Checklists = MergeChecklists(result.Checklists, oldModel.Checklists);
                    }

                    result.StartTime = oldModel.StartTime;
                    result.EndTime = oldModel.EndTime;
                    result.TotalTime = oldModel.TotalTime;

                    result.ScheduleDate = oldModel.ScheduleDate;
                    result.ScheduleTime = oldModel.ScheduleTime;
                    result.ScheduleNotes = oldModel.ScheduleNotes;

                    result.IsBillable = oldModel.IsBillable;
                    result.IsOvertime = oldModel.IsOvertime;

                    result.StartMileage = oldModel.StartMileage;
                    result.EndMileage = oldModel.EndMileage;
                    result.TotalMileage = oldModel.TotalMileage;
                    result.VehicleId = oldModel.VehicleId;

                    result.EstimatedStartTime = oldModel.EstimatedStartTime;
                    result.EstimatedEndTime = oldModel.EstimatedEndTime;

                    result.InspectionScore = oldModel.InspectionScore;
                }
            }

            return result;
        }

        // 
        private List<ChecklistModel> MergeChecklists(List<ChecklistModel> cachedChecklists, List<ChecklistModel> userInputChecklists)
        {
            List<ChecklistModel> result = cachedChecklists;

            if (userInputChecklists != null && cachedChecklists != null)
            {
                foreach (var userChecklist in userInputChecklists)
                {
                    var cachedChecklist = userChecklist == null ? null : cachedChecklists.Where(c => c.Identifier == userChecklist.Identifier).FirstOrDefault();

                    if (userChecklist != null && cachedChecklist != null)
                    {
                        cachedChecklist.Action = ChecklistModel.NORMAL;
                        cachedChecklist.TotalScore = userChecklist.TotalScore;

                        if (userChecklist.ChecklistItems != null && cachedChecklist.ChecklistItems != null)
                        {
                            cachedChecklist.ChecklistItems = MergeChecklistItems(cachedChecklist.ChecklistItems, userChecklist.ChecklistItems);
                        }
                    }
                }
            }

            return result;
        }

        private List<ChecklistItemModel> MergeChecklistItems(List<ChecklistItemModel> cachedChecklistItems, List<ChecklistItemModel> oldChecklistItems)
        {
            List<ChecklistItemModel> result = cachedChecklistItems;

            if (oldChecklistItems != null && cachedChecklistItems != null)
            {
                foreach (var oldChecklistItem in oldChecklistItems)
                {
                    var cachedChecklistItem = oldChecklistItem == null ? null : cachedChecklistItems.Where(c => c.Identifier == oldChecklistItem.Identifier).FirstOrDefault();

                    if (oldChecklistItem != null && cachedChecklistItem != null)
                    {
                        cachedChecklistItem.Action = ChecklistModel.UPDATED;
                        cachedChecklistItem.Score = oldChecklistItem.Score;
                        cachedChecklistItem.Status = oldChecklistItem.Status;
                        cachedChecklistItem.Comments = oldChecklistItem.Comments;
                        // PMA-3140 V3 API didn't expose checklist ASI/T
                        // so only cached checklist item may contain ASI, which is loaded data from GovXMl, but not input checklist item
                        // thus, not overwrite cached checklist item ASI by user input
                        // if needs enhancement later, should merge ASI and ASIT
                        //cachedChecklistItem.AdditionalInfo = oldChecklistItem.AdditionalInfo;
                    }
                }
            }

            return result;
        }

        private List<string> GetInspectorIds(List<string> inspectorSettings, string currentInspectorIdentifier)
        {
            if (inspectorSettings != null && inspectorSettings.Count > 0 && !string.IsNullOrWhiteSpace(inspectorSettings[0]))
            {
                if (!string.IsNullOrEmpty(inspectorSettings.Find(v => v.Equals("All", StringComparison.InvariantCultureIgnoreCase))))
                {
                    return null;
                }

                if (!string.IsNullOrEmpty(inspectorSettings.Find(v => v.Equals("Self", StringComparison.InvariantCultureIgnoreCase))))
                {
                    return new List<string>() { currentInspectorIdentifier };
                }

                return inspectorSettings;
            }
            return new List<string>() { currentInspectorIdentifier };
        }

        private List<AppSettings> GetSettingValue(string appId, string agencyName, string settingName)
        {
            List<AppSettings> results = new List<AppSettings>();

            if (!String.IsNullOrWhiteSpace(appId))
            {
                var tmpResults = AppSettingsRepository.GetAppSettings(appId, agencyName, null);

                if (tmpResults != null)
                {
                    results = tmpResults as List<AppSettings>;
                }

                //var app = AppRepository.GetAppByAppId(appNumber);
                //AgencyModel agency = _iagencyRepository.GetAgency(agencyName);
                //Guid agencyId = agency.AgencyId.Value;
                //Guid? agencyParentId = agency.ParentAgencyId;
                //AppSettings appSettings = _iappSettingsRepository.GetAppSetting(app.Id, agencyId, agencyParentId, settingName);

                //string defaultSettingValue;
                //string hostSettingValue;
                //string agencySettingValue;
                //if (appSettings != null)
                //{
                //    defaultSettingValue = appSettings.DefaultValue;
                //    hostSettingValue = appSettings.HostSettingValue;
                //    agencySettingValue = appSettings.SettingsValue;
                //    if (!string.IsNullOrWhiteSpace(agencySettingValue))
                //    {
                //        return agencySettingValue;
                //    }
                //    else if (!string.IsNullOrWhiteSpace(hostSettingValue))
                //    {
                //        return hostSettingValue;
                //    }
                //    else
                //    {
                //        return defaultSettingValue;
                //    }
                //}
            }

            return results;
        }
    }
}
