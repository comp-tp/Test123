using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses.Contact;

namespace Accela.Apps.Apis.WSModels.Contacts
{
    [DataContract(Name = "getContactTypesResponse")]
    public class WSSystemContactTypesResponse : WSPagedResponse
    {
        [DataMember(Name = "contactTypes", EmitDefaultValue = false, Order = 1)]
        public List<WSSystemContactType> Types { get; set; }

        public static WSSystemContactTypesResponse FromEntityModel(SystemContactTypesResponse entityResponse)
        {
            var result = new WSSystemContactTypesResponse();

            result.PageInfo = WSPagination.FromEntityModel(entityResponse.PageInfo);

            if (entityResponse != null
                && entityResponse.Types != null)
            {
                result.Types = new List<WSSystemContactType>();

                foreach (var type in entityResponse.Types)
                {
                    result.Types.Add(new WSSystemContactType
                    {
                        Id = type.Identifier,
                        Display = type.Display
                    });
                }
            }

            return result;
        }
    }
}
