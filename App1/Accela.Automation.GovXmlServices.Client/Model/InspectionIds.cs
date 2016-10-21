using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for InspectionIds.
	/// </summary>
	public class InspectionIds
	{
		public InspectionIds()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "InspectionId")]
		public InspectionId[] inspectionId;
	}
}
