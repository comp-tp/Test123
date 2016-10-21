using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model

{
	/// <summary>
	/// Summary description for ParcelId.
	/// </summary>
	public class ParcelId
	{
		public ParcelId()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName="Keys")]
		public Keys keys;     

		[XmlElement(ElementName="IdentifierDisplay")]
		public string identifierDisplay;

		[XmlElement(ElementName="Value")]
		public string val;

		[XmlAttribute(AttributeName="action")]
		public string action;
	}
}
