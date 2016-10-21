using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for InspectionTypeSets.
	/// </summary>
	public class InspectionTypeSets
	{
		public InspectionTypeSets()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName="InspectionTypeSet")]
		public InspectionTypeSet[] inspectionTypeSet;
	}
}
