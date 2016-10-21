using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.Checklists
{
    [DataContract(Name = "checklistItemStatus")]
    public class WSChecklistItemStatus
    {
        [DataMember(Name = "id", Order = 1, EmitDefaultValue = false)]
        public string ID { get; set; }

        [DataMember(Name = "display", Order = 2, EmitDefaultValue = false)]
        public string Display { get; set; }

        [DataMember(Name = "type", Order = 3, EmitDefaultValue = false)]
        public string Type { get; set; }

        [DataMember(Name = "defaultScore", Order = 4, EmitDefaultValue = false)]
        public string DefaultScore { get; set; }        
    }
}
