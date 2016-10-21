using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for InspectionTypeSetIds.
	/// </summary>
	public class InspectionTypeSetIds
	{
		public InspectionTypeSetIds()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "InspectionTypeSetId")]
		public InspectionTypeSetId[] inspectionTypeSetId;
	}
}
