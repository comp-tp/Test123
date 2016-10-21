using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.CommonResponses;

namespace Accela.Apps.Apis.WSModels.InspectorApp.Records
{
    [DataContract]
    public class WSInspectorAppContactsResponse
    {
        [DataMember(Name = "contacts", EmitDefaultValue = false)]
        public List<WSInspectorAppContact> Contacts { get; set; }

        public static WSInspectorAppContactsResponse FromEntityModel(ContactsResponse model)
        {
            WSInspectorAppContactsResponse result = null;

            if (model != null)
            {
                result = new WSInspectorAppContactsResponse()
                {
                    Contacts = WSInspectorAppContact.FromEntityModels(model.Contacts)
                };
            }

            return result;
        }
    }
}
