using System.Collections.Generic;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.ReferenceRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Apis.WSModels.V1.Inspectors;
using Accela.Apps.Shared;

using System.Web.Http;
using Accela.Apps.Shared.Contexts;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v3/inspector")]
    [APIControllerInfoAttribute(Name = "Inspector", Group = "Agency", Order = 20, Description = "")]
    public class InspectorController : ControllerBase
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

        private readonly IAgencyAppContext agencyContext;

        public InspectorController(IReferenceBusinessEntity referenceBusinessEntity, IAgencyAppContext agencyContext)
        {
            this.referenceBusinessEntity = referenceBusinessEntity;
            this.agencyContext = agencyContext;
        }

        [Route("")]
        [APIActionInfoAttribute(Name = "Get User Inspector Profile", Order =1, Scope = "get_inspector", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Returns information about the logged inspector, including department to which the inspector belongs.")]
        public WSInspectorResponse GetMyInspector()
        {
            // So far, the backend database in AA uses the uppercase charactor to save the user id.

            var result = new WSInspectorResponse();
            result.Inspector = new WSInspectorWithDepartment();
            result.Inspector.Id = agencyContext.ContextUser.LoginName.ToUpper();

            var request = new DepartmentRequest();
            request.InspectorId = result.Inspector.Id;

            var tempResult = this.ExcuteV1_2<DepartmentResponse, DepartmentRequest>(
                (o) =>
                {
                    return referenceBusinessEntity.GetDepartments(o);
                },
                request);

            if (tempResult != null && tempResult.Departments != null && tempResult.Departments.Count == 1 && tempResult.Departments[0] != null)
            {
                result.Inspector.DepartmentId = tempResult.Departments[0].Identifier;
                result.Inspector.DepartmentName = tempResult.Departments[0].Display;
            }

            return result;

        }
    }
}
