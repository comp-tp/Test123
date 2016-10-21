using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class CapContacts
    {
        [XmlElement(ElementName = "CapContact")]
        public CapContact[] CapContact { get; set; }
    }

    public class CapContact
    {
        [XmlElement(ElementName = "Key")]
        public string Key { get; set; }

        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "Address")]
        public string Address { get; set; }

        [XmlElement(ElementName = "FullName")]
        public string FullName { get; set; }

        [XmlElement(ElementName = "PhoneNumber")]
        public string PhoneNumber { get; set; }

        [XmlElement(ElementName = "Email")]
        public string Email { get; set; }
    }
}