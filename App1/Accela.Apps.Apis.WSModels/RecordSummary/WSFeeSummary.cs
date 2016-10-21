using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.SummaryModels;

namespace Accela.Apps.Apis.WSModels.RecordSummary
{
    [DataContract(Name = "feeSummary")]
    public class WSFeeSummary : WSDataModel
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

        public static WSFeeSummary FromEntityModel(FeeSummaryModel model)
        {
            WSFeeSummary result = null;

            if (model != null)
            {
                result = new WSFeeSummary()
                {
                    Due = model.Due,
                    LastPayment = model.LastPayment,
                    LastPaymentDate = model.LastPaymentDate,
                    Paid = model.Paid,
                    Total = model.Total
                };
            }

            return result;
        }
    }
}
