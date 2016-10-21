using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for FCancelInspectionOut.
	/// </summary>
	public class CancelInspectionResponse
	{
		public CancelInspectionResponse()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "RowStatus")]
		public RowStatus[] rowStatus;

		[XmlElement(ElementName = "Inspection")]
		public Inspection inspection;

		[XmlElement(ElementName = "InspectionId")]
		public InspectionId inspectionId;
	}
}
