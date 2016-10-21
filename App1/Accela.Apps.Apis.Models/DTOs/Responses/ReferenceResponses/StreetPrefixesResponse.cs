using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses
{
    [DataContract(Name = "getStreetPrefixesResponse")]
    public class StreetPrefixesResponse : PagedResponse
    {
        [DataMember(Name = "streetPrefixes", EmitDefaultValue = false)]
        public List<StreetPrefixModel> StreetPrefixes { get; set; }
    }
}
