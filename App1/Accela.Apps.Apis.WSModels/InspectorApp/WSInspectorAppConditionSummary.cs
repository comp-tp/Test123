using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.SummaryModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppConditionSummary
    {
        [DataMember(Name = "requireCount")]
        public int RequireCount { get; set; }

        [DataMember(Name = "noticeCount")]
        public int NoticeCount { get; set; }

        [DataMember(Name = "holdCount")]
        public int HoldCount { get; set; }

        [DataMember(Name = "lockCount")]
        public int LockCount { get; set; }

        public static WSInspectorAppConditionSummary FromEntityModel(ConditionSummaryModel conditionSummaryModel)
        {
            if (conditionSummaryModel == null)
            {
                return null;
            }

            var result = new WSInspectorAppConditionSummary()
            {
                HoldCount= conditionSummaryModel.HoldCount,
                LockCount=conditionSummaryModel.LockCount,
                NoticeCount= conditionSummaryModel.NoticeCount,
                RequireCount= conditionSummaryModel.RequireCount
            };

            return result;
        }
    }
}
