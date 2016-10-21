using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.PartModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses
{
    [DataContract(Name="getPartsResponse")]
    public class PartsResponse : PagedResponse
    {
        /// <summary>
        /// The record part information
        /// </summary>
        [DataMember(Name = "parts", EmitDefaultValue = false)]
        public List<PartModel> Parts { get; set; }
    }
}
