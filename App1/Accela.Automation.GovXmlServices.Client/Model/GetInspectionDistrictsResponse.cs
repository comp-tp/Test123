using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for InspectionDistrictsResponse.
	/// </summary>
	public class GetInspectionDistrictsResponse
	{
		public GetInspectionDistrictsResponse()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName="InspectionDistricts")]
		public InspectionDistricts inspectionDistricts;
	}
}
