using System;
using System.Collections.Generic;

using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Shared;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;
using Accela.Apps.Apis.WSModels.Documents;
using Accela.Apps.Apis.WSModels.Assessments;
using Accela.Apps.Apis.WSModels.Models.Assessments;
using Accela.Apps.Apis.Models.DTOs.Responses.AssessmentResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;
using System.Web.Http;
using System.Web.Http;
using System.Net;
using Accela.Apps.Shared.APIHandlers;
using Accela.Apps.Shared.WSModels;
using Accela.Apps.Shared.Exceptions;
using Accela.Apps.Apis.WSModels.Assets;
using Accela.Apps.Shared.FormatHelpers;
using Accela.Apps.Apis.Resources;

namespace Accela.Apps.Apis.Services.V2.PublicAPIs
{
    [RoutePrefix("v3/assessments")]
    [APIControllerInfoAttribute(Name = "Assessments", Group = "Entities", Order=16, Description = "The following API is exposed to assessments.")]
    public class AssessmentsController:ControllerBase
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

        //private IAssessmentBusinessEntity _assessmentBusinessEntity = null;
        private readonly IAssessmentBusinessEntity assessmentBusinessEntity;
        //{
        //    get
        //    {
        //        if (_assessmentBusinessEntity == null)
        //        {
        //            Dictionary<string, object> ctorParams = MakeConstructorParameters();
        //            _assessmentBusinessEntity = IocContainer.Resolve<IAssessmentBusinessEntity>(ctorParams);
        //        }

        //        return _assessmentBusinessEntity;
        //    }
        //}

        public AssessmentsController(IAssessmentBusinessEntity assessmentBusinessEntity)
        {
            this.assessmentBusinessEntity = assessmentBusinessEntity;
        }

        [HttpPut]
        [Route("{id}")]
        [APIActionInfoAttribute(Name = "Update Assessment", Order = 10, Scope = "update_assessment", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Update assessment")]
        public WSGetAssetCABasicInfoResponse UpdateAssessment([FromBody]WSUpdateAssetCABasicInfoRequest wsUpdateAssetCABasicInfoRequest, string id, string lang = null)
        {            
            var wsCABasicInfo = GetAssessment(id, lang);
            if (wsCABasicInfo == null || wsCABasicInfo.AssetCA == null)
            {
                throw new MobileException(MobileResources.GetString("assessment_not_found"), string.Empty, "404");
            }

            var updateAssetCARequest = WSUpdateAssetCABasicInfoRequest.ToEntityModel(wsUpdateAssetCABasicInfoRequest, wsCABasicInfo.AssetCA.Attributes, wsCABasicInfo.AssetCA.Observations);

            var updateAssetCAResponse = this.ExcuteV1_2<UpdateAssetCAResponse, UpdateAssetCARequest>(
                                    (o) =>
                                    {
                                        return assessmentBusinessEntity.UpdateAssetCA(o);
                                    },
                                    updateAssetCARequest);

            var wsUpdateAssetCAResponse = WSUpdateAssetCAResponse.FromEntityModel(updateAssetCAResponse);
            return WSGetAssetCABasicInfoResponse.FromWSUpdateAssetCAResponse(wsUpdateAssetCAResponse);

        }

        [HttpPut]
        [Route("{caid}/attributes/{attrid}/subgroups/{id}")]
        [APIActionInfoAttribute(Name = "Update Assessment Attributes", Order = 11, Scope = "update_assessment_attributes", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Update assessment attributes")]
        public WSGetCAAttributesDetailResponse UpdateAssessmentAttributes([FromBody]WSUpdateAssetCAAttributesRequest wsUpdateAssetCAAttributesRequest, string caId, string attrId, string id, string lang = null)
        {
            var wsCABasicInfo = GetAssessment(caId, lang);
            if (wsCABasicInfo == null || wsCABasicInfo.AssetCA == null)
            {
                throw new MobileException(MobileResources.GetString("assessment_not_found"), string.Empty, "404");
            }          

            var wsUpdateAssetCARequest = WSUpdateAssetCARequest.FromWSAssetCA(wsCABasicInfo.AssetCA);
            if (wsUpdateAssetCAAttributesRequest != null && wsUpdateAssetCAAttributesRequest.SubGroup != null)
            {
                wsUpdateAssetCARequest.AssetCA.Observations = null;
                var attribute = wsUpdateAssetCARequest.AssetCA.Attributes.Find(atr => atr.Id == attrId);
                if (attribute != null)
                {
                    var oldSubGroup = attribute.SubGroups.Find(sub => sub.Id == id);
                    if (oldSubGroup != null)
                    {
                        attribute.SubGroups.Remove(oldSubGroup);
                        attribute.SubGroups.Add(wsUpdateAssetCAAttributesRequest.SubGroup);
                    }
                }                   
            }

            var updateAssetCARequest = WSUpdateAssetCARequest.ToEntityModel(wsUpdateAssetCARequest);
            var updateAssetCAResponse = this.ExcuteV1_2<UpdateAssetCAResponse, UpdateAssetCARequest>(
                                    (o) =>
                                    {
                                        return assessmentBusinessEntity.UpdateAssetCA(o);
                                    },
                                    updateAssetCARequest);

            var result = WSUpdateAssetCAResponse.FromEntityModel(updateAssetCAResponse);
            return WSGetCAAttributesDetailResponse.FromWSASI(result.AssetCA);
        }

        [HttpPut]
        [Route("{caid}/observations/{obserid}")]
        [APIActionInfoAttribute(Name = "Update Assessment Observations", Order = 12, Scope = "update_assessment_observations", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Update assessment observations")]
        public WSGetObservationDetailsResponse UpdateAssessmentObservations([FromBody]WSUpdateAssetCAObservationsRequest wsUpdateAssetCAObservationsRequest, string caId, string obserId, string lang = null)
        {
            var wsCABasicInfo = GetAssessment(caId, lang);
            if (wsCABasicInfo == null || wsCABasicInfo.AssetCA == null)
            {
                throw new MobileException(MobileResources.GetString("assessment_not_found"), string.Empty, "404");
            }            

            var wsUpdateAssetCARequest = WSUpdateAssetCARequest.FromWSAssetCA(wsCABasicInfo.AssetCA);            
            if (wsUpdateAssetCAObservationsRequest != null && wsUpdateAssetCAObservationsRequest.ASIT != null)
            {
                if (wsUpdateAssetCARequest.AssetCA.Observations != null && wsUpdateAssetCARequest.AssetCA.Observations.Count > 0)
                {
                    var oldASIT = wsUpdateAssetCARequest.AssetCA.Observations.Find(asit => asit.Id == obserId);
                    if (oldASIT != null)
                    {
                        wsUpdateAssetCARequest.AssetCA.Observations.Remove(oldASIT);
                    }
                    wsUpdateAssetCARequest.AssetCA.Observations.Add(wsUpdateAssetCAObservationsRequest.ASIT);
                }
            }

            var updateAssetCARequest = WSUpdateAssetCARequest.ToEntityModel(wsUpdateAssetCARequest);
            var updateAssetCAResponse = this.ExcuteV1_2<UpdateAssetCAResponse, UpdateAssetCARequest>(
                                    (o) =>
                                    {
                                        return assessmentBusinessEntity.UpdateAssetCA(o);
                                    },
                                    updateAssetCARequest);

            var result = WSUpdateAssetCAResponse.FromEntityModel(updateAssetCAResponse);
            return WSGetObservationDetailsResponse.FromEntityModel(result.AssetCA.Observations);
        }

        [Route("")]
        [APIActionInfoAttribute(Name = "Create Assessment", Order = 7, Scope = "create_assessment", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Create assessment")]
        public WSCreateAssetCAResponse CreateAssessment([FromBody]WSCreateAssetCABasicInfoRequest wsCreateAssetCABasicInfoRequest, string lang = null)
        {
            var createAssetCARequest = WSCreateAssetCABasicInfoRequest.ToEntityModel(wsCreateAssetCABasicInfoRequest);
            var createAssetCAResponse = this.ExcuteV1_2<CreateAssetCAResponse, CreateAssetCARequest>(
                                    (o) =>
                                    {
                                        return assessmentBusinessEntity.CreateAssetCA(o);
                                    },
                                    createAssetCARequest);

            return WSCreateAssetCAResponse.FromEntityModel(createAssetCAResponse);
        }

        [Route("{id}/attributes")]
        [APIActionInfoAttribute(Name = "Create Assessment Attributes", Order = 9, Scope = "create_assessment_attributes", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Create assessment attributes")]
        public WSGetCAAttributesDetailResponse CreateAssessmentAttributes([FromBody]WSCreateAssetCAAttributesRequest wsCreateAssetCAAttributesRequest, string id, string lang = null)
        {
            var wsCABasicInfo = GetAssessment(id, lang);
            if (wsCABasicInfo == null || wsCABasicInfo.AssetCA == null)
            {
                throw new MobileException(MobileResources.GetString("assessment_not_found"), string.Empty, "404");
            }
            var wsUpdateAssetCARequest = WSUpdateAssetCARequest.FromWSAssetCA(wsCABasicInfo.AssetCA);
            if (wsCreateAssetCAAttributesRequest != null)
            {
                wsUpdateAssetCARequest.AssetCA.Attributes = wsCreateAssetCAAttributesRequest.Attributes;
            }

            var updateAssetCARequest = WSUpdateAssetCARequest.ToEntityModel(wsUpdateAssetCARequest);
            var updateAssetCAResponse = this.ExcuteV1_2<UpdateAssetCAResponse, UpdateAssetCARequest>(
                                    (o) =>
                                    {
                                        return assessmentBusinessEntity.UpdateAssetCA(o);
                                    },
                                    updateAssetCARequest);

            var result = WSUpdateAssetCAResponse.FromEntityModel(updateAssetCAResponse);
            return WSGetCAAttributesDetailResponse.FromWSASI(result.AssetCA);
        }

        [Route("{id}/observations")]
        [APIActionInfoAttribute(Name = "Create Assessment Observations", Order = 10, Scope = "create_assessment_observations", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Create assessment observations")]
        public WSGetObservationDetailsResponse CreateAssessmentObservations([FromBody]WSCreateAssetCAObservationsRequest wsCreateAssetCAObservationsRequest, string id, string lang = null)
        {
            var wsCABasicInfo = GetAssessment(id, lang);
            if (wsCABasicInfo == null || wsCABasicInfo.AssetCA == null)
            {
                throw new MobileException(MobileResources.GetString("assessment_not_found"), string.Empty, "404");
            }
            var wsUpdateAssetCARequest = WSUpdateAssetCARequest.FromWSAssetCA(wsCABasicInfo.AssetCA);
            if (wsCreateAssetCAObservationsRequest != null)
            {
                wsUpdateAssetCARequest.AssetCA.Observations = wsCreateAssetCAObservationsRequest.Observations;
            }

            var updateAssetCARequest = WSUpdateAssetCARequest.ToEntityModel(wsUpdateAssetCARequest);
            var updateAssetCAResponse = this.ExcuteV1_2<UpdateAssetCAResponse, UpdateAssetCARequest>(
                                    (o) =>
                                    {
                                        return assessmentBusinessEntity.UpdateAssetCA(o);
                                    },
                                    updateAssetCARequest);

            var result = WSUpdateAssetCAResponse.FromEntityModel(updateAssetCAResponse);
            return WSGetObservationDetailsResponse.FromEntityModel(result.AssetCA.Observations); 
        }

        [Route("{id}/observation/describe")]
        [APIActionInfoAttribute(Name = "Describe Assessment Observation", Order = 2, Scope = "get_assessment_observation_describe", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get assessment observation describe")]
        public WSGetObservationDescribesResponse GetAssessmentObservationDescribe(string id, string lang = null)
        {
            var wsAssetCA = GetAssessment(id, lang);
            if (wsAssetCA == null || wsAssetCA.AssetCA == null)
            {
                throw new MobileException(MobileResources.GetString("assessment_not_found"), string.Empty, "404");
            }

            if (wsAssetCA.AssetCA.Observations == null || wsAssetCA.AssetCA.Observations.Count == 0)
            {
                throw new MobileException(MobileResources.GetString("no_observations_exist"), string.Empty, "404");
            }
            
            return WSGetObservationDescribesResponse.FromEntityModel(wsAssetCA.AssetCA.Observations);
        }

        [Route("{id}/observations")]
        [APIActionInfoAttribute(Name = "Get Assessment Observation Details.", Scope = "get_assessment_observation_details", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get assessment observation details")]
        public WSGetObservationDetailsResponse GetAssessmentObservationDetails(string id, string lang = null)
        {
            var wsAssetCA = GetAssessment(id, lang);
            if (wsAssetCA == null || wsAssetCA.AssetCA == null)
            {
                throw new MobileException(MobileResources.GetString("assessment_not_found"), string.Empty, "404");
            }

            if (wsAssetCA.AssetCA.Observations == null || wsAssetCA.AssetCA.Observations.Count == 0)
            {
                throw new MobileException(MobileResources.GetString("no_observations_exist"), string.Empty, "404");
            }

            return WSGetObservationDetailsResponse.FromEntityModel(wsAssetCA.AssetCA.Observations);
        }

        [Route("{id}/document")]
        [APIActionInfoAttribute(Name = "Create Assessment Attachment", Order = 8, Scope = "create_assessment_document", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Upload attachment")]
        public WSDocumentCreationResponse UploadAttachment(string id, string lang = null)
        {
            var entityResult = UploadFile(id, "AssetCA", lang);
            return WSDocumentCreationResponse.FromEntityModel(entityResult);
        }

       //[Route("{id}")]
       //[APIActionInfoAttribute(Name = "Get Assessment", Scope = "get_assessment", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get assessment")]
       private WSGetAssetCAResponse GetAssessment(String id, string lang = null)
       {
           var assessmentSearchRequest = new AssessmentsSearchRequest();

           assessmentSearchRequest.AssessmentId = id;
           GetAssetCAsResponse response = this.ExcuteV1_2<GetAssetCAsResponse, AssessmentsSearchRequest>(
           (o) =>
           {
               return assessmentBusinessEntity.SearchAssessments(o);
           },
           assessmentSearchRequest);
           return WSGetAssetCAResponse.FromEntityModel(response);
       } 


        [Route("{id}")]
        [APIActionInfoAttribute(Name = "Simple Search Assessment", Order = 4, Scope = "get_assessment", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get assessment")]
        public WSGetAssetCABasicInfoResponse GetAssessmentBasicInfo(String id, string lang = null)
        {
            WSGetAssetCAResponse wsAssetCA = GetAssessment(id, lang);

            if (wsAssetCA == null || wsAssetCA.AssetCA == null)
            {
                throw new MobileException(MobileResources.GetString("assessment_not_found"), string.Empty, "404");
            }            

            return WSGetAssetCABasicInfoResponse.FromWSGetAssetCAResponse(wsAssetCA);
        }
        
        [Route("{id}/attributes/describe")]
        [APIActionInfoAttribute(Name = "Describe Assessment Attributes", Order =1, Scope = "get_assessment_attributes_describe", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get Assessment Attributes Describe")]
        public WSGetCAAttributesDescribeResponse GetCAAttributeDescribe(String id, string lang = null)
        { 
            WSGetAssetCAResponse wsAssetCA = GetAssessment(id, lang);

            if (wsAssetCA == null || wsAssetCA.AssetCA == null)
            {
                throw new MobileException(MobileResources.GetString("assessment_not_found"), string.Empty, "404");
            }

            if (wsAssetCA.AssetCA.Attributes == null || wsAssetCA.AssetCA.Attributes.Count == 0)
            {
                throw new MobileException(MobileResources.GetString("no_attributes_exist"), string.Empty, "404");
            } 

            return WSGetCAAttributesDescribeResponse.FromWSASI(wsAssetCA);
        }

        [Route("{id}/attributes")]
        [APIActionInfoAttribute(Name = "Get Assessment Attributes Detail", Order = 6, Scope = "get_assessment_attributes_detail", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get Assessment Attributes Detail")]
        public WSGetCAAttributesDetailResponse GetCAAttributesDetail(String id, string lang = null)
        {
            WSGetAssetCAResponse wsAssetCA = GetAssessment(id, lang);

            if (wsAssetCA == null || wsAssetCA.AssetCA == null)
            {
                throw new MobileException(MobileResources.GetString("assessment_not_found"), string.Empty, "404");
            }

            if (wsAssetCA.AssetCA.Attributes == null || wsAssetCA.AssetCA.Attributes.Count == 0)
            {
                throw new MobileException(MobileResources.GetString("no_attributes_exist"), string.Empty, "404");
            } 

            return WSGetCAAttributesDetailResponse.FromWSASI(wsAssetCA);
        }        
    }
}
