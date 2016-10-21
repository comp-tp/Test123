using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.SummaryModels
{
    [DataContract]
    public class RecordSummaryModel
    {
        [DataMember(Name = "conditionSummary", EmitDefaultValue = false)]
        public ConditionSummaryModel ConditionSummary { get; set; }

        [DataMember(Name = "feeSummary", EmitDefaultValue = false)]
        public FeeSummaryModel FeeSummary { get; set; }

        [DataMember(Name = "inspectionSummary", EmitDefaultValue = false)]
        public InspectionSummaryModel InspectionSummary { get; set; }

        [DataMember(Name = "workflowSummary", EmitDefaultValue = false)]
        public WorkflowSummaryModel WorkflowSummary { get; set; }

        [DataMember(Name = "contactSummaries", EmitDefaultValue = false)]
        public List<ContactSummaryModel> ContactSummaries { get; set; }

        [DataMember(Name = "projectInformations", EmitDefaultValue = false)]
        public List<ProjectInformationModel> ProjectInformations { get; set; }
    }
}
