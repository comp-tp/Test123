using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.SummaryModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppInspectionSummary
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

        public static WSInspectorAppInspectionSummary FromEntityModel(InspectionSummaryModel model)
        {
            if (model == null)
            {
                return null;
            }

            var result = new WSInspectorAppInspectionSummary()
            {
                CompletedCount= model.CompletedCount,
                FailedCount= model.FailedCount,
                NextInspection=model.NextInspection,
                NextScheduleDate=model.NextScheduleDate,
                PassedCount= model.PassedCount,
                ScheduledCount= model.ScheduledCount,
                Total= model.Total
            };

            return result;
        }
    }
}
