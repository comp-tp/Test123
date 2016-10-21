using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.SummaryModels;

namespace Accela.Apps.Apis.WSModels.RecordSummary
{
    [DataContract(Name = "workflowSummary")]
    public class WSWorkflowSummary : WSDataModel
    {
        [DataMember(Name = "currentTask", EmitDefaultValue = false)]
        public string CurrentTask { get; set; }

        [DataMember(Name = "totalSpendDays")]
        public int TotalSpendDays { get; set; }

        [DataMember(Name = "currentSpendDays")]
        public int CurrentSpendDays { get; set; }

        [DataMember(Name = "lastComplete", EmitDefaultValue = false)]
        public string LastComplete { get; set; }

        public static WSWorkflowSummary FromEntityModel(WorkflowSummaryModel model)
        {
            WSWorkflowSummary result = null;

            if (model != null)
            {
                result = new WSWorkflowSummary()
                {
                    CurrentSpendDays = model.CurrentSpendDays,
                    CurrentTask = model.CurrentTask,
                    LastComplete = model.LastComplete,
                    TotalSpendDays = model.TotalSpendDays
                };
            }

            return result;
        }
    }
}
