using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class CapFees
    {
        [XmlElement(ElementName = "CapFee")]
        public SummaryItem[] CapFee { get; set; }

        [XmlElement(ElementName = "LastPayment")]
        public string LastPayment { get; set; }

        [XmlElement(ElementName = "LastPaymentTime")]
        public string LastPaymentTime { get; set; }
    }
}