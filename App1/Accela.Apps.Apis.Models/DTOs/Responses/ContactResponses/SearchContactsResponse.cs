using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ContactResponses
{
    public class SearchContactsResponse : PagedResponse
    {
        public List<ContactModel> ContactModels { get; set; }
    }
}
