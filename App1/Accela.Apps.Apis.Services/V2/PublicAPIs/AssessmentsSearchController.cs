using System.Collections.Generic;
using System.Web.Http;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Apis.WSModels.Assessments;
using Accela.Apps.Apis.WSModels.Assets;
using Accela.Apps.Apis.WSModels.Models.Assessments;
using Accela.Apps.Shared;
using Accela.Apps.Shared.FormatHelpers;

using System.Web.Http;

namespace Accela.Apps.Apis.Services.V2.PublicAPIs
{
    [RoutePrefix("v3/search/assessments")]
    [APIControllerInfoAttribute(Name = "Assessments", Group = "Entities", Order = 16, Description = "The following API is exposed to assessments.")]
    public class AssessmentsSearchController : ControllerBase
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

        public AssessmentsSearchController(IAssessmentBusinessEntity assessmentBusinessEntity)
        {
            this.assessmentBusinessEntity = assessmentBusinessEntity;
        }

        [Route("")]
        [APIActionInfoAttribute(Name = "Advanced Search Assessments", Order = 5, Scope = "search_assessments", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Search Assessments")]
        public WSGetAssetCABasicInfosResponse SearchAssessments([FromBody]WSAssessmenSearchtRequest wsRequest, string lang = null, int offset = 0, int limit = 20)
        {
            var assessmentSearchRequest = new AssessmentsSearchRequest();
            SetPageRangeToRequest(assessmentSearchRequest, offset, limit);
            ConverWSAssessmentsSearchRequestToAssessmentsSearchRequest(wsRequest, assessmentSearchRequest);
            GetAssetCAsResponse response = this.ExcuteV1_2<GetAssetCAsResponse, AssessmentsSearchRequest>(
            (o) =>
            {
                return assessmentBusinessEntity.SearchAssessments(o);
            },
            assessmentSearchRequest);
            var assetCAs = WSGetAssetCAsResponse.FromEntityModel(response);
            return WSGetAssetCABasicInfosResponse.FromWSGetAssetCAsResponse(assetCAs);
        }

        private void ConverWSAssessmentsSearchRequestToAssessmentsSearchRequest(WSAssessmenSearchtRequest wsRequest, AssessmentsSearchRequest request)
        {
            if (wsRequest != null && wsRequest.Filter != null)
            {
                request.AssessmentId = wsRequest.Filter.AssessmentId;
                request.AssessmentStatusId = wsRequest.Filter.AssessmentStatusId;
                request.AssessmentTypeId = wsRequest.Filter.AssessmentTypeId;
                request.AssetId = wsRequest.Filter.AssetId;
                request.AssetName = wsRequest.Filter.AssetName;
                request.AssetTypeId = wsRequest.Filter.AssetTypeId;

                request.ScheduledDateFrom = DateTimeFormat.ToMetaDateStringFromUIDateString(wsRequest.Filter.ScheduledDateFrom);
                request.ScheduledDateTo = DateTimeFormat.ToMetaDateStringFromUIDateString(wsRequest.Filter.ScheduledDateTo);

                request.InspectionDateFrom = DateTimeFormat.ToMetaDateStringFromUIDateString(wsRequest.Filter.InspectionDateFrom);
                request.InspectionDateTo = DateTimeFormat.ToMetaDateStringFromUIDateString(wsRequest.Filter.InspectionDateTo);

                request.AssetIdDisplay = wsRequest.Filter.AssetIdDisplay;
                request.DepartmentId = wsRequest.Filter.DepartmentId;
                request.InspectorId = wsRequest.Filter.inspectorId;
            }
        }
    }
}
