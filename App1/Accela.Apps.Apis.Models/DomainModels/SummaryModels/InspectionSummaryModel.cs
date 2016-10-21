using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.SummaryModels
{
    [DataContract]
    public class InspectionSummaryModel : DataModel
    {
        [DataMember(Name = "total")]
        public int Total { get; set; }

        [DataMember(Name = "passedCount")]
        public int PassedCount { get; set; }

        [DataMember(Name = "failedCount")]
        public int FailedCount { get; set; }

        [DataMember(Name = "scheduledCount")]
        public int ScheduledCount { get; set; }

        [DataMember(Name = "completedCount")]
        public int CompletedCount { get; set; }

        [DataMember(Name = "nextInspection", EmitDefaultValue = false)]
        public string NextInspection { get; set; }

        [DataMember(Name = "nextScheduleDate", EmitDefaultValue = false)]
        public string NextScheduleDate { get; set; }
    }
}
