using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for CompactAddress.
	/// </summary>
	/// 
	
	public class CompactAddress
	{
		public CompactAddress()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "Keys")]
		public Keys keys;

		[XmlElement(ElementName = "addressLines")]
		public AddressLines addressLines;

		[XmlElement(ElementName = "City")]
		public string city;

		[XmlElement(ElementName = "State")]
		public string state;

		[XmlElement(ElementName = "PostalCode")]
		public string postalCode;

		[XmlElement(ElementName = "Alias")]
		public string alias;

	}
}
