using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.AddressResponses;

namespace Accela.Apps.Apis.WSModels.Addresses
{
    [DataContract]
    public class WSAddressResponse : WSResponseBase
    {
        [DataMember(Name = "address", EmitDefaultValue = false)]
        public WSAddress Address { get; set; }

        public static WSAddressResponse FromEntityModel(AddressResponse addressResponse)
        {
            WSAddressResponse wsAddressResponse = new WSAddressResponse
            {
            };

            wsAddressResponse.Address = WSAddress.FromEntityModel(addressResponse.Address);

            return wsAddressResponse;
        }
    }
}
