using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for HoldType.
	/// </summary>
	public class HoldType:ConditionType
	{
		public HoldType()
		{
			//
			// TODO: Add constructor logic here
			//
		}
//		[XmlElement(ElementName = "Keys")]
//		public Keys keys;
//
//		[XmlElement(ElementName = "IdentifierDisplay")]
//		public string identifierDisplay;

		[XmlElement(ElementName = "HoldLevels")]
		public HoldLevels holdLevels;
	}
}
