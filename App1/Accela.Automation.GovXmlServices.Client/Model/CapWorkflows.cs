using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class CapWorkflows
    {
        [XmlElement(ElementName = "CurrentTask")]
        public string CurrentTask { get; set; }

        [XmlElement(ElementName = "TotalSpendDays")]
        public string TotalSpendDays { get; set; }

        [XmlElement(ElementName = "CurrentSpendDays")]
        public string CurrentSpendDays { get; set; }

        [XmlElement(ElementName = "LastComplete")]
        public string LastComplete { get; set; }
    }
}