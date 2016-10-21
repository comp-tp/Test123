using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.SummaryModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.SummaryResponses
{
    [DataContract]
    public class WorkflowSummaryResponse : ResponseBase
    {
        [DataMember(Name = "workflowSummary", EmitDefaultValue = false)]
        public WorkflowSummaryModel WorkflowSummary { get; set; }
    }
}
