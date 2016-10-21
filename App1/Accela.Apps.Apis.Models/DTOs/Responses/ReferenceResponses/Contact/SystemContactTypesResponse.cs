using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses.Contact
{
    public class SystemContactTypesResponse : PagedResponse
    {
        public List<ContactRoleModel> Types { get; set; } 
    }
}
