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
    [APIControllerInfoAttribute(Name = "Staff", Group = "Agency", Order = 19, Description = "System Common REST API")]
    public class StaffController : ControllerBase
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

        public StaffController(IReferenceBusinessEntity referenceBusinessEntity)
        {
            this.referenceBusinessEntity = referenceBusinessEntity;
        }

        [Route("departments/{id}/staffs")]
        [APIActionInfoAttribute(Name = "Get Department Staff", Order = 1, Scope = "get_ref_staffs", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves staffs who belong to the given department.")]
        public WSSystemDepartmentStaffsResponse GetDepartmentStaffs(string id, string lang = null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            SystemDepartmentStaffsRequest request = new SystemDepartmentStaffsRequest();
            request.DepartmentId = id;
            SetPageRangeToRequest(request, offset, limit);

            var response = this.ExcuteV1_2<SystemDepartmentStaffsResponse, SystemDepartmentStaffsRequest>
                (
                    o => referenceBusinessEntity.GetDepartmentStaffs(o),
                    request);

            return WSSystemDepartmentStaffsResponse.FromEntityModel(response);
        }
    }
}
