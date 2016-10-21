using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for ConditionTypes.
	/// </summary>
	public class ConditionTypes
	{
		public ConditionTypes()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "ConditionType")]
		public ConditionType[] conditionType;
	}
}
