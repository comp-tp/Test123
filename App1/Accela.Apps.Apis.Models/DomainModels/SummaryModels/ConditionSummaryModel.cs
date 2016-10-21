using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.SummaryModels
{
    [DataContract]
    public class ConditionSummaryModel : DataModel
    {
        [DataMember(Name = "requireCount")]
        public int RequireCount { get; set; }

        [DataMember(Name = "noticeCount")]
        public int NoticeCount { get; set; }

        [DataMember(Name = "holdCount")]
        public int HoldCount { get; set; }

        [DataMember(Name = "lockCount")]
        public int LockCount { get; set; }
    }
}
