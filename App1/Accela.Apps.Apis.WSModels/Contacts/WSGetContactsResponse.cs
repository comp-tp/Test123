using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ContactResponses;

namespace Accela.Apps.Apis.WSModels.Contacts
{
    [DataContract(Name = "getContactsResponse")]
    public class WSGetContactsResponse : WSPagedResponse
    {
        [DataMember(Name="contacts", EmitDefaultValue = false)]
        public List<WSContact> Contacts { get; set; }

        public static WSGetContactsResponse FromEntityModel(GetContactsResponse getContactResponse)
        {
            var wsGetContactsResponse = new WSGetContactsResponse
            {
                PageInfo = WSPagination.FromEntityModel(getContactResponse.PageInfo)
            };

            if (getContactResponse != null && getContactResponse.ContactModels != null && getContactResponse.ContactModels.Count > 0)
            {
                wsGetContactsResponse.Contacts = new List<WSContact>();
                wsGetContactsResponse.Contacts.AddRange(WSContact.FromEntityModels(getContactResponse.ContactModels));
            }

            return wsGetContactsResponse;
        }
    }
}
