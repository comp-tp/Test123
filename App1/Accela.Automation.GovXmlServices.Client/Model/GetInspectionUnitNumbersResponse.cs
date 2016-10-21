using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for GetInspectionUnitNumbersResponse.
	/// </summary>
	public class GetInspectionUnitNumbersResponse
	{
		public GetInspectionUnitNumbersResponse()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "InspectionUnitNumbers")]
		public InspectionUnitNumbers inspectionUnitNumbers;

	}
}
