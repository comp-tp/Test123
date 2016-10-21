using System.Collections.Generic;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.ReferenceRequests.Contact;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses.Contact;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Apis.WSModels.Contacts;
using Accela.Apps.Shared;

using System.Web.Http;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v3/system/contact")]
    [APIControllerInfoAttribute(Name = "Contacts", Group = "Entities", Order = 11, Description = "")]
    public class SystemContactController : ControllerBase
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

        public SystemContactController(IReferenceBusinessEntity referenceBusinessEntity)
        {
            this.referenceBusinessEntity = referenceBusinessEntity;
        }

        /// <summary>
        /// Get contact type resource
        /// </summary>
        /// <returns></returns>
        [Route("types")]
        [APIActionInfoAttribute(Name = "Describe Contact Types", Order=1, Scope = "get_ref_contact_types", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves contact types given the agency.")]
        public WSSystemContactTypesResponse GetContactTypes(string lang = null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            SystemContactTypesRequest request = new SystemContactTypesRequest();

            SetPageRangeToRequest(request, offset, limit);

            var entityResponse = this.ExcuteV1_2<SystemContactTypesResponse, SystemContactTypesRequest>(
                    o => referenceBusinessEntity.GetContactTypes(request),
                    request
                );

            return WSSystemContactTypesResponse.FromEntityModel(entityResponse);
        }
    }
}
