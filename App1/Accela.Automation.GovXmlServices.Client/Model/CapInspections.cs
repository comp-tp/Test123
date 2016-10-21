using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class CapInspections
    {
        [XmlElement(ElementName = "CapInspection")]
        public SummaryItem[] CapInspection { get; set; }

        [XmlElement(ElementName = "NextInspection")]
        public string NextInspection { get; set; }

        [XmlElement(ElementName = "NextScheduleDate")]
        public string NextScheduleDate { get; set; }
    }
}