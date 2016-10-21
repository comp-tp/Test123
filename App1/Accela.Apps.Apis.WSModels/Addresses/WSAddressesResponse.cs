using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.AddressResponses;

namespace Accela.Apps.Apis.WSModels.Addresses
{
    [DataContract(Name = "getAddresssResponse")]
    public class WSAddressesResponse : WSPagedResponse
    {
        [DataMember(Name = "addresses", EmitDefaultValue = false)]
        public List<WSAddress> Addresses { get; set; }

        public static WSAddressesResponse FromEntityModel(AddressesResponse entityResponse)
        {
            WSAddressesResponse response = new WSAddressesResponse
            {
                PageInfo = WSPagination.FromEntityModel(entityResponse.PageInfo)
            };

            response.Addresses = new List<WSAddress>();

            if (entityResponse!=null && entityResponse.Addresses != null)
            {
                entityResponse.Addresses.ForEach(model => response.Addresses.Add(WSAddress.FromEntityModel(model)));
            }

            return response;
        }
    }
}
