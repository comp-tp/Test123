using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for HoldTypeId.
	/// </summary>
	public class HoldTypeId
	{
		public HoldTypeId()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "Keys")]
		public Keys keys;
		
		[XmlElement(ElementName = "IdentifierDisplay")]
		public string identifierDisplay;
	}
}