using System.Runtime.Serialization;
using System.Collections.Generic;
using Accela.Apps.Apis.WSModels.RelatedRecords;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.WSModels.Workflow
{
    [DataContract]
    public class WSWorkflowTaskBase
    {
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "status", EmitDefaultValue = false)]
        public string Status { get; set; }

        [DataMember(Name = "statusDate", EmitDefaultValue = false)]
        public string StatusDate { get; set; }

        [DataMember(Name = "actionBy", EmitDefaultValue = false)]
        public string ActionBy { get; set; }

        [DataMember(Name = "recordDateAndTime", EmitDefaultValue = false)]
        public string RecordDateAndTime { get; set; }

        [DataMember(Name = "startTime", EmitDefaultValue = false)]
        public string StartTime { get; set; }

        [DataMember(Name = "endTime", EmitDefaultValue = false)]
        public string EndTime { get; set; }

        [DataMember(Name = "hoursSpent", EmitDefaultValue = false)]
        public string HoursSpent { get; set; }

        [DataMember(Name = "billable", EmitDefaultValue = false)]
        public bool? Billable { get; set; }

        [DataMember(Name = "overtime", EmitDefaultValue = false)]
        public string Overtime { get; set; }

        [DataMember(Name = "recordBy", EmitDefaultValue = false)]
        public string RecordBy { get; set; }

        [DataMember(Name = "timeTrackingStartDate", EmitDefaultValue = false)]
        public string TimeTrackingStartDate { get; set; }

        [DataMember(Name = "estimateCompletionDate", EmitDefaultValue = false)]
        public string EstimateCompletionDate { get; set; }

        [DataMember(Name = "inPossessionHours", EmitDefaultValue = false)]
        public string InPossessionHours { get; set; }

        [DataMember(Name = "comments", EmitDefaultValue = false)]
        public string Comments { get; set; }

        [DataMember(Name = "processId", EmitDefaultValue = false)]
        public string ProcessId { get; set; }

        [DataMember(Name = "stepNumber", EmitDefaultValue = false)]
        public string StepNumber { get; set; }

        [DataMember(Name = "assignTo", EmitDefaultValue = false)]
        public string AssignTo { get; set; }

        [DataMember(Name = "assignDepartment", EmitDefaultValue = false)]
        public string AssignDepartment { get; set; }

        [DataMember(Name = "assignmentDate", EmitDefaultValue = false)]
        public string AssignmentDate { get; set; }

        [DataMember(Name = "actionByDepartment", EmitDefaultValue = false)]
        public string ActionByDepartment { get; set; }

        [DataMember(Name = "dueDate", EmitDefaultValue = false)]
        public string DueDate { get; set; }

        [DataMember(Name = "active", EmitDefaultValue = false)]
        public bool? ActiveFlag { get; set; }

        [DataMember(Name = "isAdHocTask", EmitDefaultValue = false)]
        public bool? IsAdHocTask { get; set; }

        [DataMember(Name = "completed", EmitDefaultValue = false)]
        public bool? CompletedFlag { get; set; }

        [DataMember(Name = "parentProcessID", EmitDefaultValue = false)]
        public string ParentProcessID { get; set; }

        [DataMember(Name = "department", EmitDefaultValue = false)]
        public WSDepartmentWithStaffs Department { get; set; }

        [DataMember(Name = "processCode", EmitDefaultValue = false)]
        public string ProcessCode { get; set; }

        protected virtual void FromEntityModelInner(WorkflowTaskModel task)
        {
            if (task != null)
            {
                this.Name = task.Description;
                this.Status = task.Status;
                this.StatusDate = task.StatusDate;
                this.ActionBy = task.ActionBy;
                this.RecordDateAndTime = task.RecordDateAndTime;
                this.StartTime = task.StartTime;
                this.EndTime = task.EndTime;
                this.HoursSpent = task.HoursSpent;
                this.Billable = task.Billable;
                this.Overtime = task.Overtime;
                this.RecordBy = task.RecordBy;
                this.TimeTrackingStartDate = task.TimeTrackingStartDate;
                this.EstimateCompletionDate = task.EstimateCompletionDate;
                this.InPossessionHours = task.InPossessionHours;
                this.ProcessId = task.ProcessID;
                this.StepNumber = task.StepNumber;
                this.AssignTo = task.AssignTo;
                this.AssignmentDate = task.AssignmentDate;
                this.AssignDepartment = task.AssignDepartment;
                this.ActionByDepartment = task.ActionByDepartment;
                this.DueDate = task.DueDate;
                this.ActiveFlag = task.ActiveFlag;
                this.IsAdHocTask = task.IsAdHocTask;
                this.CompletedFlag = task.CompleteFlag;
                this.ParentProcessID = task.ParentProcessID;
                this.Comments = task.Comments;
                this.Department = WSDepartmentWithStaffs.FromEntityModel(task.Department);

                this.ProcessCode = task.ProcessCode;
            }
        }

        protected virtual void ToEntityModelInner(WorkflowTaskModel task)
        {
            if (task != null)
            {
                task.Description = this.Name;
                task.Status = this.Status;
                task.StatusDate = this.StatusDate;
                task.ActionBy = this.ActionBy;
                task.RecordDateAndTime = this.RecordDateAndTime;
                task.StartTime = this.StartTime;
                task.EndTime = this.EndTime;
                task.HoursSpent = this.HoursSpent;
                task.Billable = this.Billable;
                task.Overtime = this.Overtime;
                task.RecordBy = this.RecordBy;
                task.TimeTrackingStartDate = this.TimeTrackingStartDate;
                task.EstimateCompletionDate = this.EstimateCompletionDate;
                task.InPossessionHours = this.InPossessionHours;
                task.ProcessID = this.ProcessId;
                task.StepNumber = this.StepNumber;
                task.AssignTo = this.AssignTo;
                task.AssignmentDate = this.AssignmentDate;
                task.AssignDepartment = this.AssignDepartment;
                task.ActionByDepartment = this.ActionByDepartment;
                task.DueDate = this.DueDate;
                task.ActiveFlag = this.ActiveFlag;
                task.IsAdHocTask = this.IsAdHocTask;
                task.CompleteFlag = this.CompletedFlag;
                task.ParentProcessID = this.ParentProcessID;
                task.Comments = this.Comments;
                task.Department = WSDepartmentWithStaffs.ToEntityModel(this.Department);

                task.ProcessCode = this.ProcessCode;
            }
        }
    }
}
