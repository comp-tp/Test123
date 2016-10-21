using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for FCancelInspectionIn.
	/// </summary>
	public class CancelInspection
	{
		public CancelInspection()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "InspectionId")]
		public InspectionId[] inspectionId;

		[XmlElement(ElementName = "Licenses")]
		public Licenses licenses;
	}
}
