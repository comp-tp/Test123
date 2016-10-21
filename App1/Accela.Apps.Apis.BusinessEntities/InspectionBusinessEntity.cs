using System;
using System.Collections.Generic;
using System.Net;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Requests.InspectionRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Exceptions;

namespace Accela.Apps.Apis.BusinessEntities
{
    /// <summary>
    /// Inspection Business Entity.
    /// </summary>
    public class InspectionBusinessEntity : BusinessEntityBase, IInspectionBusinessEntity
    {
        
        public InspectionBusinessEntity(IInspectionRepository inspectionRepository)
        {
            this.InspectionRepository = inspectionRepository;
        }

        private readonly IInspectionRepository InspectionRepository;

        public InspectionsResponse GetInspections(InspectionsRequest request)
        {
            return InspectionRepository.GetInspections(request, null);
        }

        public InspectionResponse GetInspection(InspectionRequest request)
        {
            InspectionsRequest inspectionsRequest = new InspectionsRequest();
            inspectionsRequest.Offset = 0;
            inspectionsRequest.Limit = 0;            
            inspectionsRequest.Criteria = new InspectionCriteria();
            inspectionsRequest.Criteria.InspectionId = request.InspectionId;

            InspectionsResponse response = InspectionRepository.GetInspections(inspectionsRequest, null);

            InspectionResponse result = new InspectionResponse();
            result.Error = response.Error;
            result.Events = response.Events;
            if (response.Inspections != null && response.Inspections.Count > 0)
            {
                result.Inspection = response.Inspections[0];
            }
            else
            {
                throw new NotFoundException("The inspection didn't exist.");
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
            UpdateInspectionResponse result = InspectionRepository.UpdateInspection(request);
            InspectionRequest inspReq = new InspectionRequest();

            inspReq.InspectionId = request.Inspection.Identifier;
            var getInspResp = this.GetInspection(inspReq);
            result.Inspection = getInspResp.Inspection;
            return result;
        }

        public CreateInspectionResponse CreateInspection(CreateInspectionRequest request)
        {
            #region Parameter validation
            if (request.Inspection == null)
            {
                throw new BadRequestException("Inspection is required."); 
            }
            

            if (request.Inspection.Record == null || string.IsNullOrEmpty(request.Inspection.Record.Identifier))
            {
                throw new BadRequestException("Record id is required.");
            }

            if (request.Inspection.Type == null || string.IsNullOrEmpty(request.Inspection.Type.Identifier))
            {
                throw new BadRequestException("Inspection type id is required.");
            }

             #endregion

            if (request.Inspection.AutoAssign)
            {
                if (request.Inspection.Inspector != null)
                {
                    request.Inspection.Inspector.Identifier = null;
                }

                request.Inspection.ScheduleDate = "";
                request.Inspection.ScheduleTime = "";
            }
            else
            {
                if (string.IsNullOrEmpty(request.Inspection.ScheduleDate))
                {
                    throw new BadRequestException("Schedule date is required.");
                }
            }

            return InspectionRepository.CreateInspection(request);
        }

        /// <summary>
        /// Get Inspection Histories. in returned data model, it don't need checklist and 
        /// </summary>
        /// <param name="request">the condition for histories</param>
        /// <returns>all matched inspection histories</returns>
        public InspectionsResponse GetInspectionHistories(InspectionsRequest request)
        {
            InspectionsResponse result = InspectionRepository.GetInspections(request, new List<string>() { "comments" });
            //remove unfinished
            if (result != null && result.Inspections != null)
            {
                for (int i = result.Inspections.Count - 1; i >= 0; i--)
                {
                    var insp = result.Inspections[i];
                    if (!(insp != null && insp.Status != null && insp.Status.Type != null && (insp.Status.Type.Trim().ToUpper() == "DENIED" || insp.Status.Type.Trim().ToUpper() == "APPROVED")))
                    {
                        result.Inspections.RemoveAt(i);
                    }
                }
            }

            return result;
        }

        public RescheduleInspectionResponse RescheduleInspection(RescheduleInspectionRequest request)
        {
            if (request.Inspection == null)
            {
                throw new BadRequestException("request's inspection cannot be null.");
 
            }

            if (request.Inspection.Type.Identifier == null || string.IsNullOrEmpty(request.Inspection.Type.Identifier))
            {
                throw new BadRequestException("request inspection's TypeId cannot be empty.");
            }

            if (!request.Inspection.AutoAssign && request.Inspection.ScheduleDate == null)
            {
                throw new BadRequestException("schedule date cannot be null.");
            }
            return InspectionRepository.RescheduleInspection(request);
        }
      
        public ReassignInspectionResponse ReassignInspection(ReassignInspectionRequest request)
        {
            CheckReassignInspectionRequest(request);
            return InspectionRepository.ReassignInspection(request);
        }

        public CancelInspectionResponse CancelInspection(CancelInspectionRequest request)
        {
            return InspectionRepository.CancelInspection(request);
        }

        public AvailableInspectionDatesResponse GetAvailableInspectionDates(AvailableInspectionDatesRequest request)
        {
            return InspectionRepository.GetAvailableInspectionDates(request);
        }

        private void CheckReassignInspectionRequest(ReassignInspectionRequest request)
        {
            if (request.Inspection.AutoAssign)
            {
                if (
                    !(string.IsNullOrEmpty(request.Inspection.ScheduleDate) ||
                      string.IsNullOrEmpty(request.Inspection.ScheduleTime) || request.Inspection.Inspector == null))
                {
                     ThrowMobileException("when AutoAssign was ture, the ScheduleData/ScheduleTime/Inspector must be empty.");
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
                    ThrowMobileException("when AutoAssign was false, the ScheduleDate must need a valid value.");
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
                        ThrowMobileException("the ScheduleTime must be a valid Datetime format.");
                    }
                }
            }
        }

        private static void ThrowMobileException(string message)
        {
            throw new BadRequestException(message);
        }
    }
}
