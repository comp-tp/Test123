using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.Models.DomainModels.RecordModels
{
    public class WorkflowTaskModel : DataModel
    {
        public string ProcessID { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public string StatusDate { get; set; }

        public string ActionBy { get; set; }

        public string RecordDateAndTime { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string HoursSpent { get; set; }

        public bool? Billable { get; set; }

        public string Overtime { get; set; }

        public string RecordBy { get; set; }

        public string TimeTrackingStartDate { get; set; }

        public string EstimateCompletionDate { get; set; }

        public string InPossessionHours { get; set; }

        public string Comments { get; set; }

        public string StepNumber { get; set; }

        public string AssignTo { get; set; }

        public string AssignDepartment { get; set; }

        public string AssignmentDate { get; set; }

        public string ActionByDepartment { get; set; }

        public string DueDate { get; set; }

        public bool? ActiveFlag { get; set; }

        public bool? IsAdHocTask { get; set; }

        public bool? CompleteFlag { get; set; }

        public string ParentProcessID { get; set; }

        public List<WorkflowTaskModel> Histories { get; set; }

        public List<WorkflowTaskStatusModel> statuses { get; set; }

        public DepartmentModel Department { get; set; }

        public string ProcessCode { get; set; }
    }
}
