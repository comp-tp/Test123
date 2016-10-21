using System.Collections.Generic;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.ContactRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ContactResponses;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Apis.WSModels.Contacts;
using Accela.Apps.Shared;

using System.Web.Http;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v3/search/contacts")]
    [APIControllerInfoAttribute(Name = "Contacts", Group = "Entities", Order = 11, Description = "")]
    public class ContactsSearchController : ControllerBase
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

        public ContactsSearchController(IContactBusinessEntity contactBusinessEntity)
        {
            this.contactBusinessEntity = contactBusinessEntity;
        }

        [Route("")]
        [APIActionInfoAttribute(Name = "Advanced Search Contacts", Scope = "search_contacts", Order=2, Applicability = APIActionInfoAttribute.APPLICABILITY_CIVIC, Description = "Returns a list of relevant contacts that match specified critiria.")]
        public WSSearchContactsResponse SearchContacts(WSSearchContactsRequest wsSearchContactsRequest, string lang = null, int offset = 0, int limit = 0)
        {
            var searchContactsRequest = new SearchContactsRequest();

            SetPageRangeToRequest(searchContactsRequest, offset, limit);
            ConvertWSSearchContactsRequestToSearchContactsRequest(wsSearchContactsRequest, searchContactsRequest);

            SearchContactsResponse response = this.ExcuteV1_2<SearchContactsResponse, SearchContactsRequest>(
             (o) =>
             {
                 return contactBusinessEntity.SearchContacts(o);
             },
             searchContactsRequest);

            return WSSearchContactsResponse.FromEntityModel(response);

        }

        private void ConvertWSSearchContactsRequestToSearchContactsRequest(WSSearchContactsRequest wsSearchContactsRequest, SearchContactsRequest searchContactsRequest)
        {
            if (wsSearchContactsRequest != null)
            {
                searchContactsRequest.Person = new Person();
                searchContactsRequest.Person.GivenName = wsSearchContactsRequest.Filter.GivenName;
                searchContactsRequest.Person.MiddleNames = wsSearchContactsRequest.Filter.MiddleNames;
                searchContactsRequest.Person.FamilyName = wsSearchContactsRequest.Filter.FamilyName;
                searchContactsRequest.Person.FullName = wsSearchContactsRequest.Filter.FullName;

                searchContactsRequest.Person.Role = new ActorRole();
                searchContactsRequest.Person.Role.UserDefinedRole = wsSearchContactsRequest.Filter.Role;


                searchContactsRequest.Person.Addresses = new Addresses();
                searchContactsRequest.Person.Addresses.PostalAddress = new PostalAddress();
                searchContactsRequest.Person.Addresses.PostalAddress.AddressLines = wsSearchContactsRequest.Filter.AddressLines;
                searchContactsRequest.Person.Addresses.PostalAddress.PostalCode = wsSearchContactsRequest.Filter.PostalCode;
                searchContactsRequest.Person.Addresses.PostalAddress.Region = wsSearchContactsRequest.Filter.Region;
                searchContactsRequest.Person.Addresses.PostalAddress.Town = wsSearchContactsRequest.Filter.Town;

                searchContactsRequest.Person.Addresses.TelecomAddress = new TelecomAddress();
                searchContactsRequest.Person.Addresses.TelecomAddress.TelephoneNumbers = wsSearchContactsRequest.Filter.TelephoneNumbers;
                searchContactsRequest.Person.Addresses.TelecomAddress.FacsimileNumbers = wsSearchContactsRequest.Filter.FacsimileNumbers;
                searchContactsRequest.Person.Addresses.TelecomAddress.ElectronicMailAddresses = new List<string>() { wsSearchContactsRequest.Filter.ElectronicMailAddresses };

                searchContactsRequest.Organization = new Organization();
                searchContactsRequest.Organization.Name = wsSearchContactsRequest.Filter.ContactBusinessName;
                searchContactsRequest.Organization.ContactBusinessName = wsSearchContactsRequest.Filter.ContactBusinessName;

            }
        }
    }
}
