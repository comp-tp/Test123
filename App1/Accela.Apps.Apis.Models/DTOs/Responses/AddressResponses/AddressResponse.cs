using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.AddressResponses
{
    [DataContract(Name = "addressResponse")]
    public class AddressResponse : ResponseBase
    {
        [DataMember(Name = "address", EmitDefaultValue = false)]
        public AddressModel Address { get; set; }
    }
}
