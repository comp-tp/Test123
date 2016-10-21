using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// This operation returns the inspection lists for a given inspector
	/// </summary>
	/// 
	
	public class GetInspectionsResponse
	{
		public GetInspectionsResponse()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "Inspections")]
		public Inspections inspections;

		[XmlElement(ElementName = "InspectionSheets")]
		public InspectionSheets inspectionSheets;

		[XmlElement(ElementName = "CAPs")]
		public CAPs caps;
		
	}
}
