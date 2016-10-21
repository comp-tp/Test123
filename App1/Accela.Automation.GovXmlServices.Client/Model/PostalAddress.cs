using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for PostalAddress.
	/// </summary>
	/// 
	[XmlType(Namespace="http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
	public class PostalAddress
	{
		public PostalAddress()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//We have to use the IFC class in this case.
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
