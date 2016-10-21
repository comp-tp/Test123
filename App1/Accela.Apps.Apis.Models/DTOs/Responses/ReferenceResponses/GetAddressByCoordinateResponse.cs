using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses
{
    [DataContract]
    public class GetAddressByCoordinateResponse : ResponseBase
    {
        [DataMember(Name = "address")]
        public AddressModel Address { get; set; }
    }
}
