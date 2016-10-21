using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.WSModels.Workflow
{
    [DataContract(Name = "workflowTaskStatus")]
    public class WSWorkflowTaskStatus
    {
        [DataMember(Name = "processCode", EmitDefaultValue = false)]
        public string ProcessCode { get; set; }

        [DataMember(Name = "taskStatusCode", EmitDefaultValue = false)]
        public string TaskStatusCode { get; set; }

        [DataMember(Name = "taskDescription", EmitDefaultValue = false)]
        public string TaskDescription { get; set; }

        [DataMember(Name = "statusDescription", EmitDefaultValue = false)]
        public string StatusDescription { get; set; }

        [DataMember(Name = "resultingAction", EmitDefaultValue = false)]
        public string ResultingAction { get; set; }

        [DataMember(Name = "recordDate", EmitDefaultValue = false)]
        public string RecordDate { get; set; }

        [DataMember(Name = "recorderID", EmitDefaultValue = false)]
        public string RecorderID { get; set; }

        [DataMember(Name = "applicationStatus", EmitDefaultValue = false)]
        public string ApplicationStatus { get; set; }

        [DataMember(Name = "parentStatus", EmitDefaultValue = false)]
        public string ParentStatus { get; set; }

        [DataMember(Name = "timeTrackerClockAction", EmitDefaultValue = false)]
        public string TimeTrackerClockAction { get; set; }

        [DataMember(Name = "ACADisplayable", EmitDefaultValue = false)]
        public string ACADisplayable { get; set; }

        [DataMember(Name = "status", EmitDefaultValue = false)]
        public string Status { get; set; }

        protected virtual void FromEntityModelInner(WorkflowTaskStatusModel statusModel)
        {
            this.ProcessCode = statusModel.ProcessCode;
            this.TaskStatusCode = statusModel.TaskStatusCode;
            this.TaskDescription = statusModel.TaskDescription;
            this.StatusDescription = statusModel.StatusDescription;
            this.ResultingAction = statusModel.ResultingAction;
            this.RecordDate = statusModel.RecordDate;
            this.RecorderID = statusModel.RecorderID;
            this.ApplicationStatus = statusModel.ApplicationStatus;
            this.ParentStatus = statusModel.ParentStatus;
            this.TimeTrackerClockAction = statusModel.TimeTrackerClockAction;
            this.ACADisplayable = statusModel.ACADisplayable;
            this.Status = statusModel.Status;
        }

        protected virtual void ToEntityModelInner(WorkflowTaskStatusModel statusModel)
        {
            statusModel.ProcessCode = this.ProcessCode;
            statusModel.TaskStatusCode = this.TaskStatusCode;
            statusModel.TaskDescription = this.TaskDescription;
            statusModel.StatusDescription = this.StatusDescription;
            statusModel.ResultingAction = this.ResultingAction;
            statusModel.RecordDate = this.RecordDate;
            statusModel.RecorderID = this.RecorderID;
            statusModel.ApplicationStatus = this.ApplicationStatus;
            statusModel.ParentStatus = this.ParentStatus;
            statusModel.TimeTrackerClockAction = this.TimeTrackerClockAction;
            statusModel.ACADisplayable = this.ACADisplayable;
            statusModel.Status = this.Status;
        }

        public static List<WSWorkflowTaskStatus> FromEntityModels(List<WorkflowTaskStatusModel> entityObjs)
        {
            if (entityObjs != null && entityObjs.Count > 0)
            {
                var wsObjs = new List<WSWorkflowTaskStatus>();
                foreach (var entityObj in entityObjs)
                {
                    wsObjs.Add(FromEntityModel(entityObj));
                };

                return wsObjs;
            }

            return null;
        }

        /// <summary>
        /// Convert CostStatusModel to WSCostStatus.
        /// </summary>
        /// <param name="statusModel">CostStatusModel.</param>
        /// <returns>WSCostStatus.</returns>
        public static WSWorkflowTaskStatus FromEntityModel(WorkflowTaskStatusModel statusModel)
        {
            if (statusModel != null)
            {
                WSWorkflowTaskStatus status= new WSWorkflowTaskStatus();
                status.FromEntityModelInner(statusModel);
                return status;
            }

            return null;
        }

        public static WorkflowTaskStatusModel ToEntityModel(WSWorkflowTaskStatus wsStatus)
        {
            if (wsStatus != null)
            {
                WorkflowTaskStatusModel status = new WorkflowTaskStatusModel();
                wsStatus.ToEntityModelInner(status);
                return status;
            }

            return null;
        }
    }
}
