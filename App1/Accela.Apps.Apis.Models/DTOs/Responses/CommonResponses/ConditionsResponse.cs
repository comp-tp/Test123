using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ConditionModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.CommonResponses
{
    [DataContract]
    public class ConditionsResponse : ResponseBase
    {
        [DataMember(Name = "conditions", EmitDefaultValue = false)]
        public List<ConditionModel> Conditions { get; set; }
    }
}
