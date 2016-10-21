using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class Module
    {
        public Module()
        {
        }

        [XmlElement(ElementName = "Key")]
        public string Key;

        [XmlElement(ElementName = "Value")]
        public string Value;
    }
}
