using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model

{
	/// <summary>
	/// Summary description for ConditionTypeIds.
	/// </summary>
	public class ConditionTypeIds
	{
		public ConditionTypeIds()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "ConditionTypeId")]
		public ConditionTypeId[] conditionTypeId;
	}
}
