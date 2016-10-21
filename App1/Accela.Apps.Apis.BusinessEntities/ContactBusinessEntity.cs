using System.Collections.Generic;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Requests.ContactRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ContactResponses;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared;

namespace Accela.Apps.Apis.BusinessEntities
{
    public class ContactBusinessEntity : BusinessEntityBase, IContactBusinessEntity
    {

        public ContactBusinessEntity(IContactRepository contactRepository)
        {
            this.ContactRepository = contactRepository;           
        }

        //private IContactRepository _contactRepository = null;
        private readonly IContactRepository ContactRepository;

        public GetContactsResponse GetContacts(GetContactsRequest getContactRequest)
        {
            var GetContactsResponse = new GetContactsResponse();
            Pagination pageInfo;
            var contactModels = ContactRepository.GetContacts(getContactRequest.Type, getContactRequest.FullName, getContactRequest.Offset, getContactRequest.Limit, out pageInfo);
            GetContactsResponse.ContactModels = contactModels;
            GetContactsResponse.PageInfo = pageInfo;
            return GetContactsResponse;
        }

        public SearchContactsResponse SearchContacts(SearchContactsRequest searchContactRequest)
        {
            var searchContactsResponse = new SearchContactsResponse();
            Pagination pageInfo;
            var contactModels = ContactRepository.SearchContacts(searchContactRequest, out pageInfo);
            searchContactsResponse.ContactModels = contactModels;
            searchContactsResponse.PageInfo = pageInfo;
            return searchContactsResponse;
        }
    }
}
