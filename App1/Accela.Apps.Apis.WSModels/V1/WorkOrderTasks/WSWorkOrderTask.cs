using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.WSModels.V1.WorkOrderTasks
{
    [DataContract(Name = "workOrderTask")]
    public class WSWorkOrderTask : WSEntityState
    {
        [DataMember(Name = "order", EmitDefaultValue = false)]
        public string Order { get; set; }

        [DataMember(Name = "taskCode", EmitDefaultValue = false)]
        public string TaskCode { get; set; }

        [DataMember(Name = "estimate", EmitDefaultValue = false)]
        public string Estimate { get; set; }

        [DataMember(Name = "actual", EmitDefaultValue = false)]
        public string Actual { get; set; }

        [DataMember(Name = "unit", EmitDefaultValue = false)]
        public string Unit { get; set; }

        [DataMember(Name = "completedDate", EmitDefaultValue = false)]
        public string CompletedDate { get; set; }

        [DataMember(Name = "totalCost", EmitDefaultValue = false)]
        public string TotalCost { get; set; }

        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        [DataMember(Name = "taskDescriptin", EmitDefaultValue = false)]
        public string TaskDescriptin { get; set; }

        [DataMember(Name = "workflowTask", EmitDefaultValue = false)]
        public string WorkflowTask { get; set; }

        [DataMember(Name = "completedBy", EmitDefaultValue = false)]
        public string CompletedBy { get; set; }

        [DataMember(Name = "updatedDate", EmitDefaultValue = false)]
        public string UpdatedDate { get; set; }

        [DataMember(Name = "updatedBy", EmitDefaultValue = false)]
        public string UpdatedBy { get; set; }

        [DataMember(Name = "comments", EmitDefaultValue = false)]
        public string Comments { get; set; }

        [DataMember(Name = "standardOperatingProcedures", EmitDefaultValue = false)]
        public string StandardOperatingProcedures { get; set; }

        [DataMember(Name = "status", EmitDefaultValue = false)]
        public string Status { get; set; }

        [DataMember(Name = "complete", EmitDefaultValue = false)]
        public string Complete { get; set; }

        [DataMember(Name = "workflowTaskStatus", EmitDefaultValue = false)]
        public string WorkflowTaskStatus { get; set; }

        [DataMember(Name = "processCode", EmitDefaultValue = false)]
        public string ProcessCode { get; set; }

        [DataMember(Name = "processID", EmitDefaultValue = false)]
        public string ProcessID { get; set; }

        [DataMember(Name = "stepNumber", EmitDefaultValue = false)]
        public string StepNumber { get; set; }

        [DataMember(Name = "taskSuffix", EmitDefaultValue = false)]
        public string TaskSuffix { get; set; }

        /// <summary>
        /// Convert CostModel to WSCost.
        /// </summary>
        /// <param name="task">CostModel.</param>
        /// <returns>WSCost.</returns>
        public static WSWorkOrderTask FromEntityModel(WorkOrderTaskModel task)
        {
            if (task != null)
            {
                var wsTask = new WSWorkOrderTask();
                wsTask.EntityState = WSEntityState.ConvertActionToEntityState(task.Action);

                wsTask.Order=task.Order;
                wsTask.TaskCode=task.TaskCode;
                wsTask.Estimate=task.Estimate;
                wsTask.Actual=task.Actual;
                wsTask.Unit=task.Unit;
                wsTask.CompletedDate=task.CompletedDate;
                wsTask.TotalCost=task.TotalCost;
                wsTask.Description=task.Description;
                wsTask.TaskDescriptin = task.TaskDescription;
                if (!string.IsNullOrEmpty(task.ProcessCode) && !string.IsNullOrEmpty(task.TaskDescription))
                {
                    wsTask.WorkflowTask = task.ProcessCode + ">" + task.TaskDescription;
                }
                wsTask.CompletedBy=task.CompletedBy;
                wsTask.UpdatedDate=task.UpdatedDate;
                wsTask.UpdatedBy=task.UpdatedBy;
                wsTask.Comments=task.Comments;
                wsTask.StandardOperatingProcedures=task.StandardOperatingProcedures;
                wsTask.Status=task.Status;
                wsTask.Complete=task.Complete;
                wsTask.WorkflowTaskStatus = task.WorkflowTaskStatus;
                wsTask.ProcessCode = task.ProcessCode;
                wsTask.ProcessID = task.ProcessID;
                wsTask.StepNumber = task.StepNumber;
                wsTask.TaskSuffix = task.TaskCodeIndex;
                return wsTask;
            }

            return null;
        }

        public static WorkOrderTaskModel ToEntityModel(WSWorkOrderTask wsTask)
        {
            if (wsTask != null)
            {
                var task = new WorkOrderTaskModel();
                task.Action = WSEntityState.ConvertEntityStateToAction(wsTask.EntityState);
                task.Order = wsTask.Order;
                task.TaskCode = wsTask.TaskCode;
                task.Estimate = wsTask.Estimate;
                task.Actual = wsTask.Actual;
                task.Unit = wsTask.Unit;
                task.CompletedDate = wsTask.CompletedDate;
                task.TotalCost = wsTask.TotalCost;
                task.Description = wsTask.Description;
                task.CompletedBy = wsTask.CompletedBy;
                task.UpdatedDate = wsTask.UpdatedDate;
                task.UpdatedBy = wsTask.UpdatedBy;
                task.Comments = wsTask.Comments;
                task.StandardOperatingProcedures = wsTask.StandardOperatingProcedures;
                task.Status = wsTask.Status;
                task.Complete = wsTask.Complete;
                task.WorkflowTaskStatus = wsTask.WorkflowTaskStatus;
                task.ProcessCode = wsTask.ProcessCode;
                task.ProcessID = wsTask.ProcessID;
                task.StepNumber = wsTask.StepNumber;
                task.TaskDescription = wsTask.TaskDescriptin;
                task.TaskCodeIndex = wsTask.TaskSuffix;
                return task;
            }

            return null;
        }
    }
}

