
namespace Accela.Apps.Apis.Models.DomainModels.RecordModels
{
    public class WorkOrderTaskModel : DataModel, IDataModel
    {
        public string Action { get; set; }

        public string Order { get; set; }

        public string TaskCode { get; set; }

        public string Estimate { get; set; }

        public string Actual { get; set; }

        public string Unit { get; set; }

        public string CompletedDate { get; set; }

        public string TotalCost { get; set; }

        public string Description { get; set; }

        public string CompletedBy { get; set; }

        public string UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public string Comments { get; set; }

        public string StandardOperatingProcedures { get; set; }

        public string Status { get; set; }

        public string Complete { get; set; }

        public string WorkflowTaskStatus { get; set; }

        public string ProcessCode { get; set; }

        public string ProcessID { get; set; }

        public string StepNumber { get; set; }

        /// <summary>
        /// the special property for workorder template.
        /// </summary>
        public string TaskDescription { get; set; }

        public string TaskCodeIndex { get; set; }
    }
}
