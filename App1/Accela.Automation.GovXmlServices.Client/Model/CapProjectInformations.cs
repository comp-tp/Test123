using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlServices.Client.Model
{
    public class CapProjectInformations
    {
        [XmlElement(ElementName = "CapProjectInformation")]
        public CapProjectInformation[] CapProjectInformation { get; set; }
    }
}
