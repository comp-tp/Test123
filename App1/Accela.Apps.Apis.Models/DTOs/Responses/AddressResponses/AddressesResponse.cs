using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.AddressResponses
{
    [DataContract(Name = "AddressesResponse")]
    public class AddressesResponse : PagedResponse
    {
        [DataMember(Name = "addresses", EmitDefaultValue = false)]
        public List<AddressModel> Addresses { get; set; }
    }
}
