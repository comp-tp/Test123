using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.SummaryModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.SummaryResponses
{
    [DataContract]
    public class FeeSummaryResponse : ResponseBase
    {
        [DataMember(Name = "feeSummary", EmitDefaultValue = false)]
        public FeeSummaryModel FeeSummary { get; set; }
    }
}
