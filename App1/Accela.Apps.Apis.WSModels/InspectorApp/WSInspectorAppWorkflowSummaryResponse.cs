using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Models.DTOs.Responses.SummaryResponses;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppWorkflowSummaryResponse
    {
        [DataMember(Name = "workflowSummary", EmitDefaultValue = false)]
        public WSInspectorAppWorkflowSummary WorkflowSummary { get; set; }

        public static WSInspectorAppWorkflowSummaryResponse FromEntityModel(WorkflowSummaryResponse response)
        {
            if (response == null)
            {
                return null;
            }

            var result = new WSInspectorAppWorkflowSummaryResponse()
            {
                WorkflowSummary = WSInspectorAppWorkflowSummary.FromEntityModel(response.WorkflowSummary)
            };

            return result;
        }
    }
}
