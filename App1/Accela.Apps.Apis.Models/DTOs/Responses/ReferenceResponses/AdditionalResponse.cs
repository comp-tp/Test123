using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses
{
    [DataContract(Name = "GetAdditionalInfoResponse")]
    public class AdditionalResponse : PagedResponse
    {
        /// <summary>
        /// Additional Info
        /// </summary>
        [DataMember(Name = "additionals", EmitDefaultValue = false)]
        public List<AdditionalGroupModel> Additionals { get; set; }
    }
}
