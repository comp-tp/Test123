using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Requests.InspectionRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Apis.WSModels.Inspections;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Exceptions;

using System.Web.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Http;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v3/inspections")]
    [APIControllerInfoAttribute(Name = "Inspections", Group = "Entities", Order = 15, Description = "The following APIs are exposed to inspections.")]
    public class InspectionsController : ControllerBase
    {
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

        //private IInspectionBusinessEntity _inspectionBusinessEntity;
        private readonly IInspectionBusinessEntity inspectionBusinessEntity;
        //{
        //    get
        //    {
        //        if (_inspectionBusinessEntity == null)
        //        {
        //            Dictionary<string, object> ctorParams = MakeConstructorParameters();
        //            _inspectionBusinessEntity = IocContainer.Resolve<IInspectionBusinessEntity>(ctorParams);
        //        }

        //        return _inspectionBusinessEntity;
        //    }
        //}

        //private IJobBusinessEntity _jobBusinessEntity;
        private readonly IJobBusinessEntity jobBusinessEntity;
        //{
        //    get
        //    {
        //        if (_jobBusinessEntity == null)
        //        {
        //            Dictionary<string, object> ctorParams = MakeConstructorParameters();
        //            _jobBusinessEntity = IocContainer.Resolve<IJobBusinessEntity>(ctorParams);
        //        }

        //        return _jobBusinessEntity;
        //    }
        //}

        public InspectionsController(IInspectionBusinessEntity inspectionBusinessEntity, IJobBusinessEntity jobBusinessEntity)
        {
            this.inspectionBusinessEntity = inspectionBusinessEntity;
            this.jobBusinessEntity = jobBusinessEntity;
        }

        [Route("")]
        [APIActionInfoAttribute(Name = "Simple Search Inspection", Order = 4, Scope = "get_inspections", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves inspections matching the query.Note: The inspection IDs should be comma separated.When defining a date range, refer to the example: scheduleDateRange=20120708-20120813")]
        public WSInspectionsResponse GetInspections(string scheduleDateRange = null, string inspectorIds = null, string districtIds = null,
                                                    string types = null, string module = null, string lang = null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            InspectionsRequest request = new InspectionsRequest();

            SetPageRangeToRequest(request, offset, limit);

            request.Criteria = new InspectionCriteria();

            /*
             * No need to use the dayBefore and the dayAfter to represent a range of dates.
             * As the document indicated, API supports dates in ISO 8601 (http://en.wikipedia.org/wiki/ISO_8601) YYYYMMDD without dashes.
             * The separator used between date values (year, month, week, and day) is the hyphen ('-'),
             * while the colon (':') is used as the separator between time values (hours, minutes, and seconds).
             * 
             * For example, the 9th day of the 4th month of the year 2013 may be written as "2013-04-09" in the extended format
             * or simply as "20130409" in the basic format.
            //*/
            string[] separatedDate = SpliteDateRange(scheduleDateRange);
            if (separatedDate.Length == 2)
            {
                request.Criteria.ScheduleDateFrom = separatedDate[0];
                request.Criteria.ScheduleDateTo = separatedDate[1];
            }
            else
            {
                if (separatedDate.Length == 1)
                {
                    request.Criteria.ScheduleDateFrom = separatedDate[0];
                }
            }

            if (!String.IsNullOrWhiteSpace(inspectorIds))
            {
                request.Criteria.InspectorIds = this.SpliteIdsToList(inspectorIds);
            }

            if (!String.IsNullOrWhiteSpace(districtIds))
            {
                request.Criteria.Districts = this.SpliteIdsToList(districtIds);
            }

            if (!String.IsNullOrWhiteSpace(types))
            {
                request.Criteria.Types = this.SpliteIdsToList(types);
            }

            request.Criteria.Module = module;

            var entityResult = this.ExcuteV1_2<InspectionsResponse, InspectionsRequest>(
                                (o) =>
                                {
                                    return inspectionBusinessEntity.GetInspections(request);
                                },
                                request);

            return WSInspectionsResponse.FromEntityModel(entityResult);
        }

        [Route("{id}")]
        [APIActionInfoAttribute(Name = "Get Single Inspection", Order = 6, Scope = "get_inspection", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves a single inspection.")]
        public WSInspectionResponse GetInspection(string id, string lang = null)
        {
            var inspectionRequest = new InspectionRequest();
            inspectionRequest.InspectionId = id;

            var inspectionResponse = this.ExcuteV1_2<InspectionResponse, InspectionRequest>(
                (o) =>
                {
                    return inspectionBusinessEntity.GetInspection(o);
                },
                inspectionRequest);

            return WSInspectionResponse.FromEntityModel(inspectionResponse);
        }        

        [HttpPut]
        [Route("{id}/reschedule")]
        [APIActionInfoAttribute(Name = "Reschedule Inspection", Order = 9, Scope = "reschedule_inspection", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Reschedule the specified inspection. Note that in the JSON payload, if auto assign is set, schedule date/time will be ignored; otherwise, it is required.")]
        public WSRescheduleInspectionResponse RescheduleInspection(WSRescheduleInspectionRequest request, string id, string lang = null)
        {
            if (string.IsNullOrWhiteSpace(request.Inspection.Id))
            {
                request.Inspection.Id = id;
            }

            var newRequest = WSRescheduleInspectionRequest.ToEntityModels(request);

            var tempResult = this.ExcuteV1_2<RescheduleInspectionResponse, RescheduleInspectionRequest>(
                (o) =>
                {
                    return inspectionBusinessEntity.RescheduleInspection(o);
                },
                newRequest);

            var result = WSRescheduleInspectionResponse.FromEntityModel(tempResult);

            return result;
        }

        private void CheckedTheWSRescheduleInspectionRequest(WSRescheduleInspectionRequest request, string id, string lang)
        {
            if (request.Inspection == null)
            {
                throw new BadRequestException("request's inspection cannot be null.");
            }

            if (string.IsNullOrEmpty(request.Inspection.InspectionTypeId))
            {
                throw new BadRequestException("request inspection's TypeId cannot be empty.");
            }

            if (!request.Inspection.AutoAssign && request.Inspection.ScheduleDate == null)
            {
                throw new BadRequestException("schedule date cannot be null");
            }
        }

        [Route("")]
        [APIActionInfoAttribute(Name = "Schedule Inspection", Order = 7, Scope = "create_inspection", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Schedules an inspection.If the subobjects (comment, checklist, checklistItem) are created, the entityState property of the object (inspection) will be set as Added; if the subobjects are updated, the entityState property of the object will be set as Updated; if the subobjects are deleted, the entityState property of the object will be set as Deleted.")]
        public WSCreateInspectionResponse CreateInspection(WSCreateInspectionRequest request, string lang = null)
        {
            var newRequest = WSCreateInspectionRequest.ToEntityModels(request);

            var tempResult = this.ExcuteV1_2<CreateInspectionResponse, CreateInspectionRequest>(
            (o) =>
            {
                return inspectionBusinessEntity.CreateInspection(o);
            },
            newRequest);

            return WSCreateInspectionResponse.FromEntityModel(tempResult);
        }

        [HttpPut]
        [Route("{id}/reassign")]
        [APIActionInfoAttribute(Name = "Reassign Inspection", Order = 8, Scope = "reassign_inspection", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Reassign the specified inspection. Note that in the JSON payload, if auto assign is set, schedule date/time will be ignored; otherwise, it is required.")]
        public WSReassignInspectionResponse ReassignInspection(WSReassignInspectionRequest request, string id, string lang = null)
        {
            CheckReassignInspectionArguments(request, id);
            ReassignInspectionRequest bizRequest = WSReassignInspectionRequest.ToEntityModels(request);

            ReassignInspectionResponse tempResult = this.ExcuteV1_2<ReassignInspectionResponse, ReassignInspectionRequest>
                (o => inspectionBusinessEntity.ReassignInspection(o), bizRequest);

            var result = WSReassignInspectionResponse.FromEntityModel(tempResult);

            return result;
        }

        [HttpPut]
        [Route("{id}/cancel")]
        [APIActionInfo(Name = "Cancel Inspection", Order = 9, Scope = "cancel_inspection", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Cancel the specified inspection.")]
        public WSCancelInspectionResponse CancelInspection(string id, string lang = null)
        {
            CancelInspectionRequest request = new CancelInspectionRequest
            {
                InspectionId = id
            };

            CancelInspectionResponse entityResult = ExcuteV1_2<CancelInspectionResponse, CancelInspectionRequest>(
                o => inspectionBusinessEntity.CancelInspection(o), request
                );

            return WSCancelInspectionResponse.FromEntityModel(entityResult);
        }

        [Route("{id}/Checklists")]
        [APIActionInfoAttribute(Name = "Gets the checklists", Scope = "get_inspection_checklists", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Gets the checklists.")]
        public WSInspectionChecklistResponse GetChecklists(string id, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            InspectionChecklistRequest request = new InspectionChecklistRequest()
            {
                InspectionId = id,
                Offset = offset,
                Limit = limit
            };

            var inspectionChecklistResponse = Excute<InspectionChecklistResponse, InspectionChecklistRequest>((o) =>
            {
                var result = jobBusinessEntity.GetChecklists(o);

                if (result != null)
                {
                    IListExtension.SetIgnoreEmitFields(result.InspectionChecklists as IList, "ChecklistItems");
                }

                return result;
            }, request);

            return WSInspectionChecklistResponse.FromEntityModel(inspectionChecklistResponse);
        }

        [Route("{id}/checklists/{checklistid}/checklistitems")]
        [APIActionInfoAttribute(Name = "Gets the checklist items", Scope = "get_inspection_checklist_items", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Gets the checklist items.")]
        public WSInspectionChecklistItemResponse GetChecklistItems(string id, string checklistid, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            var request = new InspectionChecklistItemRequest()
            {
                InspectionId = id,
                ChecklistId = checklistid,
                Offset = offset,
                Limit = limit
            };

            var inspectionChecklistItemResponse = Excute<InspectionChecklistItemResponse, InspectionChecklistItemRequest>((o) =>
            {
                var result = jobBusinessEntity.GetChecklistItems(o);

                return result;
            }, request);

            return WSInspectionChecklistItemResponse.FromEntityModel(inspectionChecklistItemResponse);
        }

        [Route("availableDates")]
        [APIActionInfo(Name = "Available Inspection Dates", Order = 10, Scope = "get_available_inspection_dates", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get Available Inspection Dates.")]
        public WSAvailableInspectionDatesResponse GetAvailableInspectionDates(string recordId = null, string inspectionTypeId = null, string startDate = null, int datesCount = 0)
        {
            if (String.IsNullOrEmpty(recordId))
            {
                throw new BadRequestException("recordId is required.");
            }

            if (String.IsNullOrEmpty(inspectionTypeId))
            {
                throw new BadRequestException("inspectionTypeId is required.");
            }

            AvailableInspectionDatesRequest request = new AvailableInspectionDatesRequest
            {
                RecordId = recordId,
                InspectionTypeId = inspectionTypeId
            };

            if (!String.IsNullOrEmpty(startDate))
            {
                try
                {
                    DateTime dateValue = DateTime.Parse(startDate);
                    request.StartDate = dateValue.ToString("yyyy-MM-dd");
                }
                catch (FormatException)
                {

                    throw new BadRequestException("startDate is in an invalid format. The valid format is in the following format: 'yyyy-MM-dd'");
                }
            }

            if (datesCount < 0)
            {
                throw new BadRequestException("datesCount must greater than 0.");
            }

            request.DatesCount = datesCount;

            var entityResponse = Excute<AvailableInspectionDatesResponse, AvailableInspectionDatesRequest>(
                o =>
                {
                    return inspectionBusinessEntity.GetAvailableInspectionDates(o);
                }, request);

            return WSAvailableInspectionDatesResponse.FromEntityModel(entityResponse);
        }

        private static void CheckReassignInspectionArguments(WSReassignInspectionRequest request, string id)
        {
            if (request.Inspection == null)
            {
                throw new BadRequestException("inspection cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(request.Inspection.Identifier))
            {
                request.Inspection.Identifier = id;
            }
            else
            {
                if (request.Inspection.Identifier != id)
                {
                    throw new BadRequestException("id must match with inspection.Identifier.");
                }
            }

            if (string.IsNullOrEmpty(request.Inspection.InspectionTypeId))
            {
                throw new BadRequestException("inspectionTypeId cannot be empty.");
            }

        }
    }
}
