using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Accela.Automation.GovXmlServices.Client.Model;

namespace Accela.Automation.GovXmlClient.Model
{
    public class CapSummary
    {
        public CapSummary()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        [XmlElement(ElementName = "IdentifyDisplay")]
        public string IdentifyDisplay { get; set; }

        [XmlElement(ElementName = "Addresses")]
        public Addresses Addresses { get; set; }

        [XmlElement(ElementName = "CapConditions")]
        public CapConditions CapConditions { get; set; }

        [XmlElement(ElementName = "CapInspections")]
        public CapInspections CapInspections { get; set; }

        [XmlElement(ElementName = "CapFees")]
        public CapFees CapFees { get; set; }

        [XmlElement(ElementName = "CapWorkflows")]
        public CapWorkflows CapWorkflows { get; set; }

        [XmlElement(ElementName = "CapContacts")]
        public CapContacts CapContacts { get; set; }

        [XmlElement(ElementName = "CapProjectInformations")]
        public CapProjectInformations CapProjectInformations { get; set; }
    }
}
