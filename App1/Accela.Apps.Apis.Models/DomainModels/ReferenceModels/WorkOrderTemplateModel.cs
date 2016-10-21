using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.CostModels;
using Accela.Apps.Apis.Models.DomainModels.PartModels;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.Models.DomainModels.ReferenceModels
{
    [DataContract]
    public class WorkOrderTemplateModel : DataModel
    {
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        [DataMember(Name = "priority", EmitDefaultValue = false)]
        public string Priority { get; set; }

        [DataMember(Name = "comments", EmitDefaultValue = false)]
        public string Comments { get; set; }

        [DataMember(Name = "primary", EmitDefaultValue = false)]
        public string Primary { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false)]
        public RecordTypeModel Type { get; set; }

        [DataMember(Name = "costs", EmitDefaultValue = false)]
        public List<CostModel> Costs { get; set; }

        [DataMember(Name = "parts", EmitDefaultValue = false)]
        public List<PartModel> Parts { get; set; }

        [DataMember(Name = "workorderTasks", EmitDefaultValue = false)]
        public List<WorkOrderTaskModel> WorkOrderTasks { get; set; }

        [DataMember(Name = "department", EmitDefaultValue = false)]
        public DepartmentModel Department { get; set; }
    }
}
