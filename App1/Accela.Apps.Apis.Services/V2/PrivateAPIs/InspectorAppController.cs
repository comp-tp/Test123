using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DomainModels;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Requests.AttachmentRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.InspectionRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.ReferenceRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.SummaryRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AttachmentResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.CommonResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.SummaryResponses;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Apis.WSModels;
using Accela.Apps.Apis.WSModels.ASIs.InspectorApp;
using Accela.Apps.Apis.WSModels.InspectorApp;
using Accela.Apps.Apis.WSModels.InspectorApp.Records;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Exceptions;

using System.Web.Http;
using Accela.Apps.Apis.Resources;



namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v3/inspectorapp")]
    [APIControllerInfoAttribute(Name = "InspectorApp", Description = "The following APIs are exposed to inspector apps.")]
    public class InspectorAppController : ControllerBase
    {
        private const string INSPECTION = "Inspection";

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

        //private IReferenceBusinessEntity _referenceBusinessEntity = null;
        private readonly IReferenceBusinessEntity referenceBusinessEntity;
        //{
        //    get
        //    {
        //        if (_referenceBusinessEntity == null)
        //        {
        //            Dictionary<string, object> ctorParams = MakeConstructorParameters();
        //            _referenceBusinessEntity = IocContainer.Resolve<IReferenceBusinessEntity>(ctorParams);
        //        }

        //        return _referenceBusinessEntity;
        //    }
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

        public InspectorAppController(IInspectionBusinessEntity inspectionBusinessEntity, IJobBusinessEntity jobBusinessEntity, IReferenceBusinessEntity referenceBusinessEntity, IRecordBusinessEntity recordBusinessEntity)
        {
            this.inspectionBusinessEntity = inspectionBusinessEntity;
            this.jobBusinessEntity = jobBusinessEntity;
            this.referenceBusinessEntity = referenceBusinessEntity;
            this.recordBusinessEntity = recordBusinessEntity;
        }

        /// <summary>
        /// Clear current user's cache so that client is able to get latest data from next access.
        /// </summary>
        [HttpGet]
        [Route("cleanupcache")]
        [APIActionInfoAttribute(Name = "Clear Up Cache", Scope = "inspectorapp_clearup_cache", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Clear up cache of inspection related data generated by Inspector private APIs if you want to get the latest version of inspection reelated data.")]
        public WSInspectorAppCleanupCacheResponse CleanupCache()
        {
            WSInspectorAppCleanupCacheResponse result = null;
            var request = new RefreshRequest();
            var tempResult = Excute<RefreshDataResponse, RefreshRequest>((o) =>
            {
                jobBusinessEntity.RefreshData(o);
                return new RefreshDataResponse();
            }, request);
            result = WSInspectorAppCleanupCacheResponse.FromEntityModel(tempResult);
            return result;
        }

        /// <summary>
        /// Updates the inspection.
        /// </summary>
        /// <param name="inspectionId">The inspection id.</param>
        /// <param name="wsUpdateInspectionRequest">The inspection model.</param>
        /// <returns>the updated inspection</returns>
        [HttpPost]
        [Route("inspections/{inspectionid}")]
        [APIActionInfoAttribute(Name = "Update Inspection", Scope = "inspectorapp_update_inspection", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Update inspection, you can only send partial update-needed data to current API.")]
        public WSInspectorAppUpdateInspectionResponse UpdateInspection(string inspectionId, WSInspectorAppUpdateInspectionRequest wsUpdateInspectionRequest)
        {
            if (String.IsNullOrWhiteSpace(inspectionId))
            {
                throw new MobileException(MobileResources.GetString("inspection_id_required"));
            }

            if (wsUpdateInspectionRequest == null
                || wsUpdateInspectionRequest.Inspection == null)
            {
                throw new MobileException(MobileResources.GetString("inspection_info_required"));
            }

            WSInspectorAppUpdateInspectionResponse result = null;
            var request = WSInspectorAppUpdateInspectionRequest.ToEntityModel(inspectionId, wsUpdateInspectionRequest);

            UpdateASITActionValue(request.InspectionModel);
            var tempResult = Excute<InspectionResponse, InspectionRequest>((o) =>
            {
                var updateResult = jobBusinessEntity.UpdateJob(o);

                if (updateResult != null)
                {
                    IListExtension.SetIgnoreEmitFields(new List<InspectionModel>() { updateResult.Inspection }, "Checklists,Comments");
                }

                return updateResult;
            }, request);

            result = WSInspectorAppUpdateInspectionResponse.FromEntityModel(tempResult);

            return result;
        }

        private void UpdateASITActionValue(InspectionModel inspectionModel)
        {
            if (inspectionModel != null && inspectionModel.AdditionalTables != null &&
                inspectionModel.AdditionalTables.Count > 0)
            {
                foreach (var asit in inspectionModel.AdditionalTables)
                {
                    if (asit.Rows != null && asit.Rows.Count > 0)
                    {
                        foreach (var row in asit.Rows)
                        {
                            // row.EntityState seems always null as nowhere fill its value from WSModel from API
                            if (row.EntityState != null)
                            {
                                row.Action = WSEntityState.ConvertEntityStateToAction(row.EntityState);
                            }

                            if (row.Values != null && row.Values.Count > 0)
                            {

                                foreach (var value in row.Values)
                                {
                                    //when subGroup eq "delete", the value will eq "update"
                                    if (row.Action == ActionDataModel.DELETED)
                                    {
                                        value.Action = ActionDataModel.UPDATED;
                                    }
                                    else if ( value.EntityState != null)
                                    {
                                        // value.EntityState seems always null as nowhere fill its value from WSModel from API
                                        value.Action = WSEntityState.ConvertEntityStateToAction(value.EntityState);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets User's Job list items
        /// </summary>
        /// <returns>List of JobListItems</returns>
        [HttpGet]
        [Route("jobs")]
        [APIActionInfoAttribute(Name = "Get Job List", Scope = "inspectorapp_get_job_list", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get Job List.")]
        public WSInspectorAppInspectionsResponse GetJobList(string scheduleDateRange = null, string assignedTo = null, string districtIds = null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            /*
             * We set a default value of scheduleDateRange to null in order to avoid the below kind of error:
             * "No HTTP resource was found that matches the request URI"
            //*/
            if (String.IsNullOrEmpty(scheduleDateRange))
            {
                throw new MobileException("The query parameter scheduleDateRange is required.");
            }

            JoblistRequest request = MakeJobListRequest(scheduleDateRange, assignedTo, districtIds, offset, limit);

            var entityResponse = Excute<JoblistResponse, JoblistRequest>((o) =>
            {
                var result = jobBusinessEntity.GetJobList(o);

                if (result != null)//&& result.Inspections!=null
                {
                    IListExtension.SetIgnoreEmitFields(result.Inspections as IList, "Checklists,Comments");//result.Inspections
                }

                return result;
            }, request);

            return WSInspectorAppInspectionsResponse.FromEntityModel(entityResponse);
        }

        private JoblistRequest MakeJobListRequest(string scheduleDateRange, string assignedTo, string districtIds, int offset, int limit)
        {
            JoblistRequest request = new JoblistRequest()
            {
                Offset = offset,
                Limit = limit
            };

            string[] dates = scheduleDateRange.Split('-');
            if (dates.Length > 2)
            {
                throw new MobileException(MobileResources.GetString("scheduledaterange_format_invalid"));
            }

            ValidateDateFormat(dates);

            if (dates.Length == 2)
            {
                request.ScheduleDateFrom = dates[0];
                request.ScheduleDateTo = dates[1];
            }
            else
            {
                if (dates.Length == 1)
                {
                    request.ScheduleDateFrom = dates[0];
                }
            }

            if (!String.IsNullOrEmpty(assignedTo))
            {
                if (String.Compare(assignedTo, "all", true) == 0)
                {
                    request.FetchInspectionsForAllInspectors = true;
                }
            }

            if (!String.IsNullOrEmpty(districtIds))
            {
                request.Districts = this.SpliteIdsToList(districtIds);
            }
            return request;
        }

        private void ValidateDateFormat(string[] dates)
        {
            CultureInfo enUS = new CultureInfo("en-US");
            string dateFormat = "yyyyMMdd";
            DateTime dateValue;

            for (int i = 0; i < dates.Length; i++)
            {
                if (!DateTime.TryParseExact(dates[i], dateFormat, enUS, DateTimeStyles.None, out dateValue))
                {
                    throw new MobileException(MobileResources.GetString("date_format_invalid"));
                }

                dates[i] = dateValue.ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// Get inspection type list.
        /// </summary>
        /// <param name="offset">item offset</param>
        /// <param name="limit">Number of items to return in paged collection</param>
        /// <returns>WSInspectorAppInspectionTypeResponse.</returns>
        [Route("inspectiontypes")]
        [APIActionInfoAttribute(Name = "Get Inspection Types", Scope = "inspectorapp_get_inspection_types", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get inspection types.")]
        public WSInspectorAppInspectionTypeResponse GetInspetionTypes(int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            WSInspectorAppInspectionTypeResponse result = null;
            InspectionTypeRequest request = new InspectionTypeRequest();
            SetPageRangeToRequest(request, offset, limit);
            var tempResult = Excute<InspectionTypeResponse, InspectionTypeRequest>((o) =>
            {
                var inspectionTypeResult = referenceBusinessEntity.GetInspetionTypes(o);

                if (inspectionTypeResult != null)
                {
                    IListExtension.SetIgnoreEmitFields(inspectionTypeResult.InspectionTypes as IList, "StatusList");
                }

                return inspectionTypeResult;
            }, request);
            result = WSInspectorAppInspectionTypeResponse.FromEntityModels(tempResult);
            return result;
        }

        /// <summary>
        /// Gets the inspection statuses.
        /// </summary>
        /// <param name="inspectionTypeId">The inspection type id.</param>
        /// <returns>
        /// the inspection statuses.
        /// </returns>
        [Route("inspectionstatuses")]
        [APIActionInfoAttribute(Name = "Get Inspection Statuses", Scope = "inspectorapp_get_inspection_statuses", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get inspection statuses of one specific insepction type.")]
        public WSInspectionAppInspectionStatusResponse GetInspetionStatuses(string inspectionTypeId = null)
        {
            WSInspectionAppInspectionStatusResponse result = null;
            InspectionStatusRequest request = new InspectionStatusRequest() { InspectionTypeId = inspectionTypeId };
            var tempResult = Excute<InspectionStatusResponse, InspectionStatusRequest>((o) =>
            {
                var inspectionStatusResults = referenceBusinessEntity.GetInspetionStatuses(o);
                return inspectionStatusResults;
            }, request);

            result = WSInspectionAppInspectionStatusResponse.FromEntityModels(tempResult);

            return result;
        }

        [Route("Inspections/{inspectionId}/Comments")]
        [APIActionInfoAttribute(Name = "Get Inspection's Comments", Scope = "inspectorapp_get_inspection_comments", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get specific inspection's comments.")]
        public WSInspectorAppInspectionCommentResponse GetInspetionComments(string inspectionId)
        {
            InspectionCommentRequest request = new InspectionCommentRequest() { InspectionId = inspectionId };
            var inspectionCommentResponse = Excute<InspectionCommentResponse, InspectionCommentRequest>((o) =>
            {
                var result = jobBusinessEntity.GetInspetionComments(o);
                return result;
            }, request);

            return WSInspectorAppInspectionCommentResponse.FromEntityModel(inspectionCommentResponse);
        }

        /// <summary>
        /// Gets the inspection attachments.
        /// </summary>
        /// <param name="inspectionId">The inspection id.</param>
        /// <param name="offset">offset</param>
        /// <param name="limit">limit.</param>
        /// <returns>
        /// the inspection attachments.
        /// </returns>
        [Route("inspections/{inspectionId}/attachments")]
        [APIActionInfoAttribute(Name = "Get Inspection Attachments", Scope = "inpsectorapp_get_inspection_attachments", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get the inspection attachments")]
        public WSInspectorAppDocumentsResponse GetInspetionAttachments(string inspectionId, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            AttachmentsRequest request = new AttachmentsRequest()
            {
                EntityId = inspectionId,
                EntityType = INSPECTION,
                Offset = offset,
                Limit = limit
            };

            var response = ExcuteV1_2<AttachmentsResponse, AttachmentsRequest>((o) =>
            {
                var result = AttachmentBussinessEntity.GetAttachments(o);
                return result;
            }, request);

            return WSInspectorAppDocumentsResponse.FromEntityModel(response);
        }

        /// <summary>
        /// Downloads the attachment.
        /// </summary>
        /// <param name="inspectionId">The inspection id.</param>
        /// <param name="attachmentId">The attachment id.</param>
        /// <returns>
        /// the file stream
        /// </returns>
        [HttpGet]
        [Route("inspections/{inspectionId}/attachments/{attachmentId}/file")]
        [APIActionInfoAttribute(Name = "Download Inspection Attachment", Scope = "inpsectorapp_get_inspection_attachment", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Download the inspection attachment")]
        public HttpResponseMessage DownloadAttachment(string inspectionId, string attachmentId)
        {
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK);

            var attachmentContentRequest = new AttachmentContentRequest()
            {
                EntityId = inspectionId,
                EntityType = INSPECTION,
                AttachmentId = attachmentId
            };
            var response = Excute<AttachmentContentRequest>((o) =>
            {
                return AttachmentBussinessEntity.GetAttachment(o);
            }, attachmentContentRequest);

            if (response.Error == null)
            {
                if (response.FileContent != null)
                {
                    response.FileContent.Position = 0;
                }

                result.Content = new StreamContent(response.FileContent);
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            }
            else
            {
                string error = JsonConverter.ToJson(response);

                result.StatusCode = HttpStatusCode.InternalServerError;
                result.Content = new StringContent(error);
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            }

            return result;
        }

        /// <summary>
        /// Downloads the attachment thumbnail.
        /// </summary>
        /// <param name="inspectionId">The inspection id.</param>
        /// <param name="attachmentId">The attachment id.</param>
        /// <param name="pixelWidth">Width of the pixel.</param>
        /// <param name="pixelHeight">Height of the pixel.</param>
        /// <returns>
        /// the attachment thumbnail.
        /// </returns>
        [HttpGet]
        [Route("inspections/{inspectionId}/attachments/{attachmentId}/filethumbnail")]
        [APIActionInfoAttribute(Name = "Download Inspection Attachment Thumbnail", Scope = "inpsectorapp_get_inspection_attachment_thumbnail", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Download the inspection attachment thumbnail")]
        public HttpResponseMessage DownloadAttachmentThumbnail(string inspectionId, string attachmentId, int pixelWidth = 20, int pixelHeight = 20)
        {
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK);
            var attachmentThumbContentRequest = new AttachmentThumbContentRequest()
            {
                EntityId = inspectionId,
                EntityType = INSPECTION,
                AttachmentId = attachmentId,
                PixelWidth = pixelWidth,
                PixelHeight = pixelHeight
            };
            var response = Excute<AttachmentThumbContentRequest>((o) =>
            {
                return AttachmentBussinessEntity.GetAttachmentThumbnail(o);
            }, attachmentThumbContentRequest);

            if (response.Error == null)
            {
                if (response.FileContent != null)
                {
                    response.FileContent.Position = 0;
                }

                result.Content = new StreamContent(response.FileContent);
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            }
            else
            {
                string error = JsonConverter.ToJson(response);

                result.StatusCode = HttpStatusCode.InternalServerError;
                result.Content = new StringContent(error);
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            }

            return result;
        }

        /// <summary>
        /// Upload Attachment description
        /// </summary>
        /// <param name="inspectionId"></param>
        /// <param name="desc"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("inspections/{inspectionId}/attachments")]
        [APIActionInfoAttribute(Name = "Upload Inspection Attachment Description", Scope = "inpsectorapp_upload_inspection_attachment_desc", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Upload the inspection attachment description")]
        public WSInspectorAppUploadAttachmentDescResponse UploadAttachmentDesc(string inspectionId, string desc = null, string fileName = null)
        {
            var request = new UploadAttachmentDescRequest();
            request.Desc = desc;
            request.InspectionId = inspectionId;
            request.FileName = fileName;

            var response = ExcuteV1_2<UploadAttachmentDescResponse, UploadAttachmentDescRequest>((o) =>
            {
                var result = AttachmentBussinessEntity.UploadAttachmentDesc(o);
                return result;
            }, request);

            return WSInspectorAppUploadAttachmentDescResponse.FromEntityModel(response);
        }

        /*
         * Implementation Notes:
         
         A parameter of Stream type works as a place holder will cause a problem after upgrading to ASP.NET Web API.
         Here is the error message:
         No MediaTypeFormatter is available to read an object of type 'Stream' from content with media type 'multipart/form-data'.
         
         To solve this kind of problem, we simply remove this parameter.
         Everything works fine after removing it.
        */
        [HttpPost]
        [Route("attachment/{descKey}")]
        [APIActionInfoAttribute(Name = "Create Inspection Attachment", Scope = "inpsectorapp_create_inspection_attachment", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Create the inspection attachment")]
        public WSInspectorAppDocumentCreationResponse CreateAttachment(string descKey)
        {
            DateTime dtServiceMethod_CreateAttachment_Begin = DateTime.UtcNow;
            var memoryStream = GetMemoryStream(Request.Content.ReadAsStreamAsync().Result);

            var attachmentUploadRequest = new AttachmentUploadRequest();
            attachmentUploadRequest.DescKey = descKey;

            var response = ExcuteV1_2<CreateAttachmentResponse, AttachmentUploadRequest>((o) =>
            {
                string id = AttachmentBussinessEntity.CreateAttachment(o, memoryStream);
                CreateAttachmentResponse resp = new CreateAttachmentResponse();
                resp.Identifier = id;
                return resp;

            }, attachmentUploadRequest);

            return WSInspectorAppDocumentCreationResponse.FromEntityModel(response);
        }

        [Route("Inspections/{inspectionId}/Checklists")]
        [APIActionInfoAttribute(Name = "Gets the checklists", Scope = "inspectorapp_get_inspection_checklists", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Gets the checklists.")]
        public WSInspectorAppInspectionChecklistResponse GetChecklists(string inspectionId, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            InspectionChecklistRequest request = new InspectionChecklistRequest()
            {
                InspectionId = inspectionId,
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

            return WSInspectorAppInspectionChecklistResponse.FromEntityModel(inspectionChecklistResponse);
        }

        [Route("Inspections/{inspectionId}/Checklists/{checklistId}/ChecklistItems")]
        [APIActionInfoAttribute(Name = "Gets the checklist items", Scope = "inspectorapp_get_inspection_checklist_items", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Gets the checklist items.")]
        public WSInspectorAppInspectionChecklistItemResponse GetChecklistItems(string inspectionId, string checklistId, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            var request = new InspectionChecklistItemRequest()
            {
                InspectionId = inspectionId,
                ChecklistId = checklistId,
                Offset = offset,
                Limit = limit
            };

            var inspectionChecklistItemResponse = Excute<InspectionChecklistItemResponse, InspectionChecklistItemRequest>((o) =>
            {
                var result = jobBusinessEntity.GetChecklistItems(o);

                return result;
            }, request);

            return WSInspectorAppInspectionChecklistItemResponse.FromEntityModel(inspectionChecklistItemResponse);
        }

        /// <summary>
        /// Gets the standard comment groups.
        /// </summary>
        /// <param name="offset">offset.</param>
        /// <param name="limit">limit.</param>
        /// <returns>
        /// the standard comment groups.
        /// </returns>
        [Route("standardcommentgroups")]
        [APIActionInfoAttribute(Name = "Get Standard Comment Groups", Scope = "inpsectorapp_get_standard_comment_groups", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get standard comment groups")]
        public WSInspectorAppStandardCommentGroupResponse GetStandardCommentGroups(int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            StandardCommentGroupRequest request = new StandardCommentGroupRequest()
                                                      {
                                                          Offset = offset,
                                                          Limit = limit
                                                      };
            var response = ExcuteV1_2<StandardCommentGroupResponse, StandardCommentGroupRequest>((o) =>
            {
                var result = referenceBusinessEntity.GetStandardCommentGroups(o);

                return result;
            }, request);

            return WSInspectorAppStandardCommentGroupResponse.FromEntityModel(response);
        }

        /// <summary>
        /// Gets the standard comments.
        /// </summary>
        /// <param name="offset">Index of the page.</param>
        /// <param name="limit">Size of the page.</param>
        /// <returns>
        /// the standard comments.
        /// </returns>
        [Route("standardcomments")]
        [APIActionInfoAttribute(Name = "Get Standard Comments", Scope = "inpsectorapp_get_standard_comments", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get standard comments")]
        public WSInspectorAppStandardCommentResponse GetStandardComments(int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            StandardCommentRequest request = new StandardCommentRequest()
                                                 {
                                                     Offset = offset,
                                                     Limit = limit
                                                 };
            var response = ExcuteV1_2<StandardCommentResponse, StandardCommentRequest>((o) =>
            {
                StandardCommentResponse result = null;
                result = referenceBusinessEntity.GetStandardComments(o);

                return result;
            }, request);

            return WSInspectorAppStandardCommentResponse.FromEntityModel(response);
        }

        /// <summary>
        /// Gets the departments.
        /// </summary>
        /// <returns>
        /// the departments.
        /// </returns>
        [Route("departments")]
        [APIActionInfoAttribute(Name = "Get Departments", Scope = "inpsectorapp_get_departments", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get departments")]
        public WSInspectorAppDepartmentResponse GetDepartments()
        {
            DepartmentRequest request = new DepartmentRequest();
            var response = ExcuteV1_2<DepartmentResponse, DepartmentRequest>((o) =>
            {
                var result = referenceBusinessEntity.GetDepartments(o);

                if (result != null)
                {
                    IListExtension.SetIgnoreEmitFields(result.Departments as IList, "inspectors");
                }

                return result;
            }, request);

            return WSInspectorAppDepartmentResponse.FromEntityModel(response);
        }

        /// <summary>
        /// Gets the inspectors.
        /// </summary>
        /// <param name="departmentId">The department id.</param>
        /// <returns>the inspectors.</returns>
        [Route("departments/{departmentId}/inspectors")]
        [APIActionInfoAttribute(Name = "Get Inspectors", Scope = "inpsectorapp_get_inspectors", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get inspectors by department Id.")]
        public WSInspectorAppInspectorResponse GetInspectors(string departmentId)
        {
            InspectorRequest request = new InspectorRequest() { DepartmentId = departmentId };
            var response = ExcuteV1_2<InspectorResponse, InspectorRequest>((o) =>
            {
                var result = referenceBusinessEntity.GetInspectors(o);
                return result;
            }, request);

            return WSInspectorAppInspectorResponse.FromEntityModel(response);
        }

        /// <summary>
        /// Gets the memory stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>the memory stream.</returns>
        private MemoryStream GetMemoryStream(Stream stream)
        {
            MemoryStream result = null;

            if (stream != null)
            {
                stream.Position = 0;

                result = new MemoryStream();
                var buff = new byte[0x10000];
                int bytesRead = 0;

                do
                {
                    bytesRead = stream.Read(buff, 0, buff.Length);
                    result.Write(buff, 0, bytesRead);
                }
                while (bytesRead > 0);
            }

            return result;
        }

        [Route("record/{recordid}/inspections")]
        [APIActionInfoAttribute(Name = "Get Inspection Histories", Scope = "inspectorapp_get_record_inspections", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get inspection histories of one specific record.")]
        public WSInspectorAppInspectionsResponse GetInspectionsOfRecord(string recordid, string resultTypes = null)
        {
            WSInspectorAppInspectionsResponse result = null;
            InspectionsRequest request = new InspectionsRequest();
            request.Criteria = new InspectionCriteria();
            request.Criteria.RecordId = recordid;
            request.Criteria.OpenInspectionsOnly = "false";
            //request.Criteria.DaysBefore = -1;
            //request.Criteria.DaysAfter = -1;
            request.Elements = new List<string>();
            request.Elements.Add("Basic");

            var tempResult = Excute<InspectionsResponse, InspectionsRequest>((o) =>
            {
                var inspectionHistoryResults = inspectionBusinessEntity.GetInspectionHistories(request);
                return inspectionHistoryResults;
            }, request);

            result = WSInspectorAppInspectionsResponse.FromEntityModel(tempResult);

            return result;
        }

        [Route("record/{recordid}/conditionsummary")]
        [APIActionInfo(Name = "Get Condition Summary", Scope = "inpsectorapp_get_condition_summary", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Return condition summary.")]
        public WSInspectorAppConditionSummaryResponse GetConditionSummary(string recordid)
        {
            ConditionSummaryRequest request = new ConditionSummaryRequest();
            request.RecordId = recordid;

            var response = this.ExcuteV1_2<ConditionSummaryResponse, ConditionSummaryRequest>(
                (o) =>
                {
                    return recordBusinessEntity.GetConditionSummary(o);
                },
                request);

            return WSInspectorAppConditionSummaryResponse.FromEntityModel(response);
        }

        [Route("record/{recordid}/inspectionsummary")]
        [APIActionInfo(Name = "Get Inspection Summary", Scope = "inpsectorapp_get_inspection_summary", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Return inspection summary.")]
        public WSInspectorAppInspectionSummaryResponse GetInspectionSummary(string recordid)
        {
            InspectionSummaryRequest request = new InspectionSummaryRequest();

            request.RecordId = recordid;

            var response = this.ExcuteV1_2<InspectionSummaryResponse, InspectionSummaryRequest>(
                (o) =>
                {
                    return recordBusinessEntity.GetInspectionSummary(o);
                },
                request);

            return WSInspectorAppInspectionSummaryResponse.FromEntityModel(response);
        }

        [Route("record/{recordid}/workflowsummary")]
        [APIActionInfo(Name = "Get Workflow Summary", Scope = "inpsectorapp_get_workflow_summary", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Return workflow summary.")]
        public WSInspectorAppWorkflowSummaryResponse GetWorkflowSummary(string recordid)
        {
            WorkflowSummaryRequest request = new WorkflowSummaryRequest();

            request.RecordId = recordid;

            var response = this.ExcuteV1_2<WorkflowSummaryResponse, WorkflowSummaryRequest>(
                (o) =>
                {
                    return recordBusinessEntity.GetWorkflowSummary(o);
                },
                request);

            return WSInspectorAppWorkflowSummaryResponse.FromEntityModel(response);
        }

        [Route("record/{recordid}/feesummary")]
        [APIActionInfo(Name = "Get Fee Summary", Scope = "inpsectorapp_get_fee_summary", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Return fee summary.")]
        public WSInspectorAppFeeSummaryResponse GetFeeSummary(string recordid)
        {
            FeeSummaryRequest request = new FeeSummaryRequest();

            request.RecordId = recordid;

            var response = this.Excute<FeeSummaryResponse, FeeSummaryRequest>(
                (o) =>
                {
                    return recordBusinessEntity.GetFeeSummary(o);
                },
                request);

            return WSInspectorAppFeeSummaryResponse.FromEntityModel(response);
        }

        [Route("record/{recordid}/contactsummary")]
        [APIActionInfo(Name = "Get Contact Summary", Scope = "inpsectorapp_get_contact_summary", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Return contact summary.")]
        public WSInspectorAppContactSummaryResponse GetContactSummary(string recordid)
        {
            ContactSummaryRequest request = new ContactSummaryRequest();

            request.RecordId = recordid;

            var response = this.ExcuteV1_2<ContactSummaryResponse, ContactSummaryRequest>(
                (o) =>
                {
                    return recordBusinessEntity.GetContactSummary(o);
                },
                request);

            return WSInspectorAppContactSummaryResponse.FromEntityModel(response);
        }

        [Route("record/{recordid}/contacts")]
        [APIActionInfoAttribute(Name = "Get Record Contacts", Scope = "inspectorapp_get_record_contacts", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get record's contacts.")]
        public WSInspectorAppContactsResponse GetRecordContacts(string recordid)
        {
            WSInspectorAppContactsResponse result = null;
            ContactsRequest request = new ContactsRequest();
            request.RecordId = recordid;

            var tempResult = this.Excute<ContactsResponse, ContactsRequest>(
                (o) =>
                {
                    return recordBusinessEntity.GetRecordContacts(o);
                },
                request);

            result = WSInspectorAppContactsResponse.FromEntityModel(tempResult);

            return result;
        }

        [Route("record/{recordid}/conditions")]
        [APIActionInfoAttribute(Name = "Get Record Conditions", Scope = "inspectorapp_get_record_conditions", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get record's conditions.")]
        public WSInspectorAppConditionsResponse GetRecordConditions(string recordid, string filter = null)
        {
            WSInspectorAppConditionsResponse result = null;
            ConditionsRequest request = new ConditionsRequest();
            request.RecordId = recordid;
            request.Filter = filter;

            var tempResult = this.Excute<ConditionsResponse, ConditionsRequest>(
                (o) =>
                {
                    return recordBusinessEntity.GetRecordConditions(o);
                },
                request);

            result = WSInspectorAppConditionsResponse.FromEntityModel(tempResult);

            return result;
        }

        [Route("record/{recordid}")]
        [APIActionInfoAttribute(Name = "Get Record by ID", Scope = "inspectorapp_get_record_by_id", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get record by ID.")]
        public WSInspectorAppRecordResponse GetRecord(string recordid)
        {
            WSInspectorAppRecordResponse result = null;
            RecordRequest request = new RecordRequest();
            request.RecordId = recordid;

            var tempResult = this.Excute<RecordResponse, RecordRequest>(
                (o) =>
                {
                    return recordBusinessEntity.GetRecord(o);
                },
                request);

            result = WSInspectorAppRecordResponse.FromEntityModel(tempResult);

            return result;
        }

        [Route("records/{id}/asis")]
        [APIActionInfoAttribute(Name = "Get Record's ASI", Order = 10, Scope = "inspectorapp_get_record_asis", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves additional information about the record.")]
        public WSInspectorAppASIResponse GetRecordASIs(string id, string lang = null)
        {
            AdditionalRequest request = new AdditionalRequest();
            request.RelatedId = id;


            AdditionalResponse response = ExcuteV1_2<AdditionalResponse, AdditionalRequest>(
            (o) =>
            {
                return recordBusinessEntity.GetRecordAdditionals(o);
            },
            request);

            return WSInspectorAppASIResponse.FromEntityModel(response);
        }

        [Route("records/{id}/asits")]
        [APIActionInfoAttribute(Name = "Get Record's ASIT", Order = 11, Scope = "inspectorapp_get_record_asits", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves additional information tables for the record.")]
        public WSInspectorAppASITResponse GetRecordASITs(string id)
        {
            AdditionalTableRequest request = new AdditionalTableRequest();
            request.RelatedId = id;

            AdditionalTableResponse response = ExcuteV1_2<AdditionalTableResponse, AdditionalTableRequest>(
            (o) =>
            {
                return recordBusinessEntity.GetRecordAdditionalTables(o);
            },
            request);

            return WSInspectorAppASITResponse.FromEntityModel(response);
        }

        [Route("records/{recordid}/asis/drilldowns/{drilldownid}")]
        [APIActionInfoAttribute(Name = "Get Record ASI Drilldown", Order = 10, Scope = "inspectorapp_get_record_asi_drilldown", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get the record's project informations by record id and some specified parameters.")]
        public WSInspectorAppDrillDownValuesResponse GetRecordASIDrillDownValues(string recordid, string drilldownid)
        {
            DrillDownValuesRequest request = new DrillDownValuesRequest();

            request.RecordId = recordid;
            request.DrillDownId = drilldownid;

            DrillDownValuesResponse response = this.ExcuteV1_2<DrillDownValuesResponse, DrillDownValuesRequest>(
            (o) =>
            {
                return recordBusinessEntity.GetASIDrillDownValues(o);
            },
            request);

            return WSInspectorAppDrillDownValuesResponse.FromEntityModel(response);
        }

        [Route("records/{recordid}/asis/drilldowns/{drilldownid}/{parentvalueid}")]
        [APIActionInfoAttribute(Name = "Get Record ASI Drilldown With Parent Item", Order = 10, Scope = "inspectorapp_get_record_asi_drilldown_parent", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get the record's project informations by record id and some specified parameters.")]
        public WSInspectorAppDrillDownValuesResponse GetDrillDownValuesForParent(string recordid, string drilldownid, string parentvalueid)
        {
            var request = new DrillDownValuesRequest();

            request.RecordId = recordid;
            request.DrillDownId = drilldownid;
            request.ParentValueId = parentvalueid;

            DrillDownValuesResponse response = this.ExcuteV1_2<DrillDownValuesResponse, DrillDownValuesRequest>(
            (o) =>
            {
                return recordBusinessEntity.GetASIDrillDownValuesForParent(o);
            },
            request);

            return WSInspectorAppDrillDownValuesResponse.FromEntityModel(response);
        }

        [Route("records/{recordid}/asits/drilldowns/{drilldownid}")]
        [APIActionInfoAttribute(Name = "Get Drilldowns", Order = 10, Scope = "inspectorapp_get_record_asit_drilldown", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get the record''s project informations by record id and some specified parameters.")]
        public WSInspectorAppDrillDownValuesResponse GetASITDrillDownValues(string recordid, string drilldownid)
        {
            var request = new DrillDownValuesRequest();

            request.RecordId = recordid;
            request.DrillDownId = drilldownid;

            DrillDownValuesResponse response = this.ExcuteV1_2<DrillDownValuesResponse, DrillDownValuesRequest>(
            (o) =>
            {
                return recordBusinessEntity.GetASITDrillDownValues(o);
            },
            request);
            return WSInspectorAppDrillDownValuesResponse.FromEntityModel(response);
        }

        [Route("records/{recordid}/asits/drilldowns/{drilldownid}/{parentvalueid}")]
        [APIActionInfoAttribute(Name = "Get Record ASIT Drilldown For Parent Item", Order = 10, Scope = "inspectorapp_get_record_asit_drilldown_parent", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get the record''s project informations by record id and some specified parameters.")]
        public WSInspectorAppDrillDownValuesResponse GetASITDrillDownValuesForParent(string recordid, string drilldownid, string parentvalueid)
        {
            var request = new DrillDownValuesRequest();

            request.RecordId = recordid;
            request.DrillDownId = drilldownid;
            request.ParentValueId = parentvalueid;

            DrillDownValuesResponse response = this.ExcuteV1_2<DrillDownValuesResponse, DrillDownValuesRequest>(
            (o) =>
            {
                return recordBusinessEntity.GetASITDrillDownValuesForParent(o);
            },
            request);

            return WSInspectorAppDrillDownValuesResponse.FromEntityModel(response);
        }

    }

}