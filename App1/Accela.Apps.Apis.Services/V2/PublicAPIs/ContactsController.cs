using System.Collections.Generic;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.ContactRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ContactResponses;
using Accela.Apps.Apis.WSModels.Contacts;
using Accela.Apps.Shared;

using System.Web.Http;
using Accela.Apps.Apis.Services.Attributes;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v3/contacts")]
    [APIControllerInfoAttribute(Name = "Contacts", Group = "Entities", Order=11, Description = "")]
    public class ContactsController : ControllerBase
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

        //private IContactBusinessEntity _contactBusinessEntity = null;
        private readonly IContactBusinessEntity contactBusinessEntity;
        //{
        //    get
        //    {
        //        if (_contactBusinessEntity == null)
        //        {
        //            Dictionary<string, object> ctorParams = MakeConstructorParameters();
        //            _contactBusinessEntity = IocContainer.Resolve<IContactBusinessEntity>(ctorParams);
        //        }

        //        return _contactBusinessEntity;
        //    }
        //}

        public ContactsController(IContactBusinessEntity contactBusinessEntity)
        {
            this.contactBusinessEntity = contactBusinessEntity;
        }

        [Route("")]
        [APIActionInfoAttribute(Name = "Simple Search Contacts", Scope = "get_contacts", Order=1, Applicability = APIActionInfoAttribute.APPLICABILITY_CIVIC, Description = "Returns a list of contacts.")]
        public WSGetContactsResponse GetContacts(string lang = null, int offset = 0, int limit = 0, string type = null, string fullName = null)
        {
            var getContactsRequest = new GetContactsRequest();

            getContactsRequest.Type = type;
            getContactsRequest.FullName = fullName;
            SetPageRangeToRequest(getContactsRequest, offset, limit);

            GetContactsResponse response = this.ExcuteV1_2<GetContactsResponse, GetContactsRequest>(
             (o) =>
             {
                 return contactBusinessEntity.GetContacts(o);
             },
             getContactsRequest);

            return WSGetContactsResponse.FromEntityModel(response);

        }
    }
}
