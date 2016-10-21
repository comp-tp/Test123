using Accela.Apps.Apis.Models.DTOs.Requests.ContactRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ContactResponses;

namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    public interface IContactBusinessEntity : IBusinessEntity
    {
        GetContactsResponse GetContacts(GetContactsRequest getContactRequest);

        SearchContactsResponse SearchContacts(SearchContactsRequest getContactRequest);
    }
}
