using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for FGetCAPInspectionTypeListIn.
	/// </summary>
	public class FGetCAPInspectionTypeListIn
	{
		public FGetCAPInspectionTypeListIn()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "InspectorId")]
		public InspectorId inspectorId;
	}
}
