using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlServices.Client.Model
{
    public class CapProjectInformation
    {
        [XmlElement(ElementName = "CapId")]
        public string CapId { get; set; }

        [XmlElement(ElementName = "CapType")]
        public string CapType { get; set; }

        [XmlElement(ElementName = "ShotComment")]
        public string ShortComments { get; set; }
    }
}
