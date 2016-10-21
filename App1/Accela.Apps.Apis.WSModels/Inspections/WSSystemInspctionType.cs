using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract(Name = "inspectionType")]
    public class WSSystemInspectionType : WSDataModel
    {
        [DataMember(Name = "id", EmitDefaultValue = false, Order = 0)]
        public string Id { get; set; }

        [DataMember(Name = "display", EmitDefaultValue = false, Order = 1)]
        public string Display { get; set; }

        [DataMember(Name = "status", EmitDefaultValue = false, Order = 2)]
        public List<WSSystemInspectionStatus> Status { get; set; }

        [DataMember(Name = "checklistGroup", EmitDefaultValue = false, Order = 3)]
        public WSSystemInspectionChecklistGroup CheckListGroup { get; set; }
    }
}
