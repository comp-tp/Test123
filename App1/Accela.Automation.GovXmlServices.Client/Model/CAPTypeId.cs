using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model

{
	/// <summary>
	/// Summary description for CAPTypeId.
	/// </summary>
	public class CAPTypeId
	{
		public CAPTypeId()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName="Keys")]
		public Keys keys;

		[XmlElement(ElementName="IdentifierDisplay")]
		public string identifierDisplay;

	}
}
