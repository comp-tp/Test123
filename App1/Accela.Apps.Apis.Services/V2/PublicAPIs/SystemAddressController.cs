using System.Collections.Generic;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.ReferenceRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Apis.WSModels.Addresses;
using Accela.Apps.Shared;

using System.Web.Http;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v3/system/address")]
    [APIControllerInfoAttribute(Name = "Addresses", Group = "Entities", Order = 7, Description = "System Addresses REST API")]
    public class SystemAddressController : ControllerBase
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

        public SystemAddressController(IReferenceBusinessEntity referenceBusinessEntity)
        {
            this.referenceBusinessEntity = referenceBusinessEntity;
        }

        [Route("streetPrefixes")]
        [APIActionInfoAttribute(Name = "Describe Street Prefixes", Order = 1, Scope = "get_ref_street_prefixes", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves street prefixes for the reference addresses.")]
        public WSStreetPrefixesResponse GetStreetPrefixes(string lang = null)
        {

            StreetPrefixesRequest request = new StreetPrefixesRequest();

            var response = this.ExcuteV1_2<StreetPrefixesResponse, StreetPrefixesRequest>
                (
                (o) => { return referenceBusinessEntity.GetStreetPrefixes(o); },
                request);

            return WSStreetPrefixesResponse.FromEntityModel(response);
        }
    }
}
