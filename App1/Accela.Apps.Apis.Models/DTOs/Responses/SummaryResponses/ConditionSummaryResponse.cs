using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DTOs.Responses.SummaryResponses
{
    [DataContract]
    public class ConditionSummaryResponse : ResponseBase
    {
        [DataMember(Name = "conditionSummary", EmitDefaultValue = false)]
        public Accela.Apps.Apis.Models.DomainModels.SummaryModels.ConditionSummaryModel ConditionSummary { get; set; }
    }
}
