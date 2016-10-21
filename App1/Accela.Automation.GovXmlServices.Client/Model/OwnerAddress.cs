using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class OwnerAddress
    {
        public OwnerAddress()
        {
        }

        [XmlElement(ElementName = "addressLines")]
        public AddressLinesIFC addressLines;

        [XmlElement(ElementName = "postalCode")]
        public string postalCode;

        [XmlElement(ElementName = "town")]
        public string town;

        [XmlElement(ElementName = "region")]
        public string region;

        [XmlElement(ElementName = "countryCode")]
        public string countryCode;
    }
}
