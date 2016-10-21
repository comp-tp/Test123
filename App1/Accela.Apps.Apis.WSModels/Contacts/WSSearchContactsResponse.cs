using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ContactResponses;

namespace Accela.Apps.Apis.WSModels.Contacts
{
    [DataContract(Name = "searchContactsResponse")]
    public class WSSearchContactsResponse : WSPagedResponse
    {
        [DataMember(Name="contacts", EmitDefaultValue = false)]
        public List<WSContact> Contacts { get; set; }

        public static WSSearchContactsResponse FromEntityModel(SearchContactsResponse searchContactResponse)
        {
            var wsSearchContactsResponse = new WSSearchContactsResponse
            {
                PageInfo = WSPagination.FromEntityModel(searchContactResponse.PageInfo)
            };

            if (searchContactResponse != null && searchContactResponse.ContactModels != null && searchContactResponse.ContactModels.Count > 0)
            {
                wsSearchContactsResponse.Contacts = new List<WSContact>();
                wsSearchContactsResponse.Contacts.AddRange(WSContact.FromEntityModels(searchContactResponse.ContactModels));
            }

            return wsSearchContactsResponse;
        }
    }
}
