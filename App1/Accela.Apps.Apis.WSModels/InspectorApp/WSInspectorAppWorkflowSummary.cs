using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.SummaryModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppWorkflowSummary
    {
        [DataMember(Name = "currentTask", EmitDefaultValue = false)]
        public string CurrentTask { get; set; }

        [DataMember(Name = "totalSpendDays")]
        public int TotalSpendDays { get; set; }

        [DataMember(Name = "currentSpendDays")]
        public int CurrentSpendDays { get; set; }

        [DataMember(Name = "lastComplete", EmitDefaultValue = false)]
        public string LastComplete { get; set; }

        public static WSInspectorAppWorkflowSummary FromEntityModel(WorkflowSummaryModel model)
        {
            if (model == null)
            {
                return null;
            }

            var result = new WSInspectorAppWorkflowSummary()
            {
                CurrentSpendDays=model.CurrentSpendDays,
                CurrentTask=model.CurrentTask,
                LastComplete=model.LastComplete,
                TotalSpendDays= model.TotalSpendDays
            };

            return result;
        }
    }
}
