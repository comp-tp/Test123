using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Automation.GovXmlClient.Model
{
    using System;
    using System.Xml.Serialization;

    public class GetContacts
    {
        public GetContacts()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "System")]
		public Sys system;

        [XmlElement(ElementName = "Contact")]
        public Contact Contact;

        [XmlElement(ElementName = "returnElements")]
        public returnElements returnElements;
    }
}
