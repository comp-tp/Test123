using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.Checklists
{
    [DataContract(Name = "statusGroup")]
    public class WSChecklistItemStatusGroup
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string ID { get; set; }

        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        [DataMember(Name = "statuses", EmitDefaultValue = false)]
        public List<WSChecklistItemStatus> ChecklistItemStatuses { get; set; }
    }
}
