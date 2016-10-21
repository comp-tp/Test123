using System.Collections.Generic;
using System.Web.Http;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.InspectionRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Apis.WSModels.Inspections;
using Accela.Apps.Shared;

using System.Web.Http;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v3/search/inspections")]
    [APIControllerInfoAttribute(Name = "Inspections", Group = "Entities", Order = 3, Description = "")]
    public class InspectionsSearchController : ControllerBase
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

        public InspectionsSearchController(IInspectionBusinessEntity inspectionBusinessEntity)
        {
            this.inspectionBusinessEntity = inspectionBusinessEntity;
        }

        [HttpPost]
        [Route("")]
        [APIActionInfoAttribute(Name = "Advanced Search Inspections", Order = 5, Scope = "search_inspections", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves inspections matching the query. The inspection IDs should be comma separated.")]
        public WSInspectionsResponse GetInspections([FromBody]WSInspectionsSearchRequest request, [FromUri]string expand = null, string lang = null, int offset = 0, int limit = 0)
        {
            InspectionsRequest entityRequest = new InspectionsRequest();
            entityRequest.Elements = this.GetReturnElements(expand);

            SetPageRangeToRequest(entityRequest, offset, limit);

            if (request.Filter != null)
            {
                WSInspectionFilter filter = request.Filter;

                entityRequest.Criteria = WSInspectionFilter.ToEntityModel(filter);
            }

            var entityResult = this.ExcuteV1_2<InspectionsResponse, InspectionsRequest>(
                (o) =>
                {
                    return inspectionBusinessEntity.GetInspections(entityRequest);
                },
                entityRequest);

            return WSInspectionsResponse.FromEntityModel(entityResult);
        }
    }
}
