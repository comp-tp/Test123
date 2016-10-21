using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class CapConditions
    {
        [XmlElement(ElementName = "CapCondition")]
        public SummaryItem[] CapCondition { get; set; }
    }
}
