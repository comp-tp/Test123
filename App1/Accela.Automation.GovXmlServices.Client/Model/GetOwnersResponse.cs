using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class GetOwnersResponse
    {
        public GetOwnersResponse()
        {
        }

        [XmlElement(ElementName = "System")]
        public Sys system;

        [XmlElement(ElementName = "Contacts")]
        public Contacts Contacts;
    }
}
