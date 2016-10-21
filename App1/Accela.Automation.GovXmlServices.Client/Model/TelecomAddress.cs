using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for TelecomAddress.
	/// </summary>
	/// 
	[XmlType(Namespace="http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
	public class TelecomAddress
	{
		public TelecomAddress()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "telephoneNumbers")]
		public TelephoneNumbers telephoneNumbers;

        [XmlElement(ElementName = "phoneCountryCodes")]
        public PhoneCountryCodes phoneCountryCodes;

		[XmlElement(ElementName = "facsimileNumbers")]
		public FacsimileNumbers facsimileNumbers;

        [XmlElement(ElementName = "facsimileCountryCodes")]
        public FacsimileCountryCodes facsimileCountryCodes;

		[XmlElement(ElementName = "electronicMailAddresses")]
		public ElectronicMailAddresses electronicMailAddresses;
	
//		[XmlElement(ElementName = "wWWHomePageURL")]
//		public WWWHomePageURL wWWHomePageURL;
	}
}
