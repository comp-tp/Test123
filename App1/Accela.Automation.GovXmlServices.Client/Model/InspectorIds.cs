using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for InspectorIds.
	/// </summary>
	public class InspectorIds
	{
		public InspectorIds()
		{
		}
		[XmlElement(ElementName = "InspectorId")]
		public InspectorId[] inspectorId;
	}
}
