using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ParcelModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ParcelResponses
{
    [DataContract(Name="GetParcelsResponse")]
    public class ParcelsResponse : PagedResponse
    {
        [DataMember(Name = "parcels", EmitDefaultValue = false)]
        public List<ParcelModel> Parcels { get; set; }
    }
}
