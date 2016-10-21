using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Shared;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.WSModels.Departments;
using Accela.Apps.Apis.Models.DTOs.Requests.Departments;
using Accela.Apps.Apis.Models.DTOs.Responses.Departments;
using System.Web.Http;

namespace Accela.Apps.Apis.Services.V2.PublicAPIs
{
    [RoutePrefix("v3/system/agency")]
    [APIControllerInfoAttribute(Name = "Departments", Group = "Agency", Order = 18, Description = "System Common REST API")]
    public class DepartmentsController : ControllerBase
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

        public DepartmentsController(IReferenceBusinessEntity referenceBusinessEntity)
        {
            this.referenceBusinessEntity = referenceBusinessEntity;
        }

        [Route("departments")]
        [APIActionInfoAttribute(Name = "Get Departments", Order = 1, Scope = "get_ref_departments", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves departments given the agency.")]
        public WSSystemDepartmentsResponse GetDepartments(string lang = null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            SystemDepartmentsRequest request = new SystemDepartmentsRequest();
            SetPageRangeToRequest(request, offset, limit);

            var response = this.ExcuteV1_2<SystemDepartmentsResponse, SystemDepartmentsRequest>
                (
                    o => referenceBusinessEntity.GetDepartments(request),
                    request);

            return WSSystemDepartmentsResponse.FromEntityModel(response);
        }
    }
}
