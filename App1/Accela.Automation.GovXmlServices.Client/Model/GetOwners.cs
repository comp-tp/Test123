using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class GetOwners
    {
        public GetOwners()
        {
        }

        [XmlElement(ElementName = "System")]
        public Sys system;

        [XmlElement(ElementName = "Contacts")]
        public Contacts contacts;

        [XmlElement(ElementName = "GISObjects")]
        public GISObjects GisObjects;
    }
}
