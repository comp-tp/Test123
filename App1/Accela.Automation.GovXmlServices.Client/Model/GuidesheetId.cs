using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for GuidesheetId.
	/// </summary>
	public class GuidesheetId
	{
		public GuidesheetId()
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
