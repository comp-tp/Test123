using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.CommonResponses
{
    [DataContract]
    public class ContactsResponse: ResponseBase
    {
        [DataMember(Name = "contacts", EmitDefaultValue = false)]
        public List<ContactModel> Contacts { get; set; }
    }
}
