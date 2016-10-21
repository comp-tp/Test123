using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.Assessments
{
    [DataContract(Name = "assessmentfilter")]
    public class WSAssessmentFilter
    {
        [DataMember(Name = "assessmentId", EmitDefaultValue = false)]
        public string AssessmentId { get; set; }

        [DataMember(Name = "assessmentTypeId", EmitDefaultValue = false)]
        public string AssessmentTypeId { get; set; }

        [DataMember(Name = "assessmentStatusId", EmitDefaultValue = false)]
        public string AssessmentStatusId { get; set; }

        [DataMember(Name = "assetId", EmitDefaultValue = false)]
        public string AssetId { get; set; }

        [DataMember(Name = "assetIdDisplay", EmitDefaultValue = false)]
        public string AssetIdDisplay { get; set; }

        [DataMember(Name = "assetTypeId", EmitDefaultValue = false)]
        public string AssetTypeId { get; set; }

        [DataMember(Name = "assetName", EmitDefaultValue = false)]
        public string AssetName { get; set; }

        [DataMember(Name = "scheduledDateFrom", EmitDefaultValue = false)]
        public string ScheduledDateFrom { get; set; }

        [DataMember(Name = "scheduledDateTo", EmitDefaultValue = false)]
        public string ScheduledDateTo { get; set; }

        [DataMember(Name = "inspectionDateFrom", EmitDefaultValue = false)]
        public string InspectionDateFrom { get; set; }

        [DataMember(Name = "inspectionDateTo", EmitDefaultValue = false)]
        public string InspectionDateTo { get; set; }

        [DataMember(Name = "departmentId", EmitDefaultValue = false)]
        public string DepartmentId { get; set; }

        [DataMember(Name = "inspectorId", EmitDefaultValue = false)]
        public string inspectorId { get; set; }
    }
}
