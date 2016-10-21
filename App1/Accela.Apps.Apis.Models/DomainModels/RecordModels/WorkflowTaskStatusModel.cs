
namespace Accela.Apps.Apis.Models.DomainModels.RecordModels
{
    public class WorkflowTaskStatusModel : DataModel
    {
        public string ProcessCode { get; set; }

        public string TaskStatusCode { get; set; }

        public string TaskDescription { get; set; }

        public string StatusDescription { get; set; }

        public string ResultingAction { get; set; }

        public string RecordDate { get; set; }

        public string RecorderID { get; set; }

        public string ApplicationStatus { get; set; }

        public string ParentStatus { get; set; }

        public string TimeTrackerClockAction { get; set; }

        public string ACADisplayable { get; set; }

        public string Status { get; set; }
    }
}
