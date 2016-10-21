using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for FGetInspectionTypeListOut.
	/// </summary>
	public class GetInspectionTypesResponse
	{
		public GetInspectionTypesResponse()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName="InspectionTypeSets")]
		public InspectionTypeSets inspectionTypeSets;
	}
}
