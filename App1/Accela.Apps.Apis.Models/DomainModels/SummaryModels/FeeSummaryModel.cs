using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.SummaryModels
{
    [DataContract]
    public class FeeSummaryModel : DataModel
    {
        [DataMember(Name = "total")]
        public decimal Total { get; set; }

        [DataMember(Name = "paid")]
        public decimal Paid { get; set; }

        [DataMember(Name = "due")]
        public decimal Due { get; set; }

        [DataMember(Name = "lastPayment")]
        public decimal LastPayment { get; set; }

        [DataMember(Name = "lastPaymentDate", EmitDefaultValue = false)]
        public string LastPaymentDate { get; set; }
    }
}
