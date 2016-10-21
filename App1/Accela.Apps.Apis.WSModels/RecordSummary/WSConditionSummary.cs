using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.SummaryModels;

namespace Accela.Apps.Apis.WSModels.RecordSummary
{
    [DataContract(Name = "conditionSummary")]
    public class WSConditionSummary : WSDataModel
    {
        [DataMember(Name = "requireCount")]
        public int RequireCount { get; set; }

        [DataMember(Name = "noticeCount")]
        public int NoticeCount { get; set; }

        [DataMember(Name = "holdCount")]
        public int HoldCount { get; set; }

        [DataMember(Name = "lockCount")]
        public int LockCount { get; set; }

        public static WSConditionSummary FromEntityModel(ConditionSummaryModel model)
        {
            WSConditionSummary result = null;

            if (model != null)
            {
                result = new WSConditionSummary()
                {
                    HoldCount = model.HoldCount,
                    LockCount = model.LockCount,
                    NoticeCount = model.NoticeCount,
                    RequireCount = model.RequireCount
                };
            }

            return result;
        }
    }
}
