using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for HoldLevel.
	/// </summary>
	public class HoldLevel
	{
		public HoldLevel()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "Keys")]
		public Keys keys;

		[XmlElement(ElementName = "IdentifierDisplay")]
		public string identifierDisplay;

		[XmlElement(ElementName = "level")]
		public string level;
	}
}
