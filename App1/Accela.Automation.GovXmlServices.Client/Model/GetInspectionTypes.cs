using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for FGetInspectionTypeListIn.
	/// </summary>
	public class GetInspectionTypes
	{
		public GetInspectionTypes()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "CAPId")]
		public CAPId capId;

		[XmlElement(ElementName = "CAPTypeId")]
		public CAPTypeId capTypeId;

		[XmlElement(ElementName = "InspectorId")]
		public InspectorId inspectorId;
	}
}
