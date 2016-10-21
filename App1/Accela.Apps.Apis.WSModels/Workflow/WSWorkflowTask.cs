using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.WSModels.Workflow
{
    [DataContract]
    public class WSWorkflowTask : WSWorkflowTaskBase
    {
        [DataMember(Name = "histories", EmitDefaultValue = false)]
        public List<WSWorkflowTaskHistory> Histories { get; set; }

        [DataMember(Name = "statuses", EmitDefaultValue = false)]
        public List<WSWorkflowTaskStatus> Statuses { get; set; }

        public static WSWorkflowTask FromEntityModel(WorkflowTaskModel task)
        {
            WSWorkflowTask result = null;
            if (task != null)
            {
                result = new WSWorkflowTask();
                result.FromEntityModelInner(task);
            }

            return result;
        }

        protected override void FromEntityModelInner(WorkflowTaskModel task)
        {
            base.FromEntityModelInner(task);
            this.Histories = WSWorkflowTaskHistory.FromEntityModels(task.Histories);
            this.Statuses = WSWorkflowTaskStatus.FromEntityModels(task.statuses);
        }
    }
}
