using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.SummaryModels
{
    [DataContract]
    public class WorkflowSummaryModel : DataModel
    {
        [DataMember(Name = "currentTask", EmitDefaultValue = false)]
        public string CurrentTask { get; set; }

        [DataMember(Name = "totalSpendDays")]
        public int TotalSpendDays { get; set; }

        [DataMember(Name = "currentSpendDays")]
        public int CurrentSpendDays { get; set; }

        [DataMember(Name = "lastComplete", EmitDefaultValue = false)]
        public string LastComplete { get; set; }
    }
}