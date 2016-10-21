using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ParcelModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ParcelResponses
{
    [DataContract(Name = "GetParcelResponse")]
    public class ParcelResponse : ResponseBase
    {
        [DataMember(Name = "parcel", EmitDefaultValue = false)]
        public ParcelModel Parcel { get; set; }
    }
}
