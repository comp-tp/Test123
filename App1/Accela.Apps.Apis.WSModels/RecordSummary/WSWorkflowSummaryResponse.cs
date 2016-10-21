using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.SummaryResponses;

namespace Accela.Apps.Apis.WSModels.RecordSummary
{
    [DataContract(Name = "workflowSummaryResponse")]
    public class WSWorkflowSummaryResponse : WSResponseBase
    {
        [DataMember(Name = "workflowSummary", EmitDefaultValue = false)]
        public WSWorkflowSummary WorkflowSummary { get; set; }

        public static WSWorkflowSummaryResponse FromEntityModel(WorkflowSummaryResponse response)
        {
            WSWorkflowSummaryResponse result = null;

            if (response != null)
            {
                result = new WSWorkflowSummaryResponse()
                {
                    WorkflowSummary = WSWorkflowSummary.FromEntityModel(response.WorkflowSummary)
                };
            }

            return result;
        }
    }
}
