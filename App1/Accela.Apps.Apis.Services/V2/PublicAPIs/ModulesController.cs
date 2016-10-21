using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Shared;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.WSModels.Modules;
using Accela.Apps.Apis.Models.DTOs.Requests.ReferenceRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using System.Web.Http;

namespace Accela.Apps.Apis.Services.V2.PublicAPIs
{
    [RoutePrefix("v3/system/common")]
    [APIControllerInfoAttribute(Name = "Modules", Group = "Agency", Order=17, Description = "")]
    public class ModulesController : ControllerBase
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

        public ModulesController(IReferenceBusinessEntity referenceBusinessEntity)
        {
            this.referenceBusinessEntity = referenceBusinessEntity;
        }

        [Route("modules")]
        [APIActionInfoAttribute(Name = "Get Modules", Scope = "get_ref_modules", Order = 1, Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves modules given the agency.")]
        public WSModulesResponse GetModules(string lang = null)
        {
            var request = new ModulesRequest();

            var tempResult = this.ExcuteV1_2<ModulesResponse, ModulesRequest>(
                (o) =>
                {
                    return referenceBusinessEntity.GetModules(o);
                },
                request);

            var result = WSModulesResponse.FromEntityModel(tempResult);
            return result;
        }

    }
}
