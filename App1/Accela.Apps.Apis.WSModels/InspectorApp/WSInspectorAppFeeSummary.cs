using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.SummaryModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppFeeSummary
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

        public static WSInspectorAppFeeSummary FromEntityModel(FeeSummaryModel model)
        {
            if (model == null)
            {
                return null;
            }

            var result = new WSInspectorAppFeeSummary()
            {
                 Due=model.Due,
                 LastPayment= model.LastPayment,
                 LastPaymentDate=model.LastPaymentDate,
                 Paid=model.Paid,
                 Total =model.Total
            };

            return result;
        }
    }
}
