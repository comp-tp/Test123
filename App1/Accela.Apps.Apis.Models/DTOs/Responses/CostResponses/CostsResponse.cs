using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.CostModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.CostResponses
{
    [DataContract(Name = "GetCostsResponse")]
    public class CostsResponse : ResponseBase
    {
        [DataMember(Name = "costs", EmitDefaultValue = false)]
        public List<CostModel> Costs { get; set; }
    }
}
