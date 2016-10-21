using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.SummaryModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.SummaryResponses
{
    [DataContract]
    public class InspectionSummaryResponse : ResponseBase
    {
        [DataMember(Name = "inspectionSummary", EmitDefaultValue = false)]
        public InspectionSummaryModel InspectionSummary { get; set; }
    }
}
