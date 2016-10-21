using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for GetSeverityLevels.
	/// </summary>
	public class GetSeverityLevels
	{
		public GetSeverityLevels()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "contextType")]
		public string contextType;
	
		[XmlElement(ElementName = "ConditionTypeIds")]
		public ConditionTypeIds conditionTypeIds;
	
		[XmlElement(ElementName = "HoldTypeIds")]
		public HoldTypeIds holdTypeIds;
	}
}
