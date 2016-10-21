using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for FScheduleInspectionOut.
	/// </summary>
	public class ScheduleInspectionResponse
	{
		public ScheduleInspectionResponse()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "RowStatus")]
		public RowStatus rowStatus;

		[XmlElement(ElementName = "InspectionId")]
		public InspectionId inspectionId;

		[XmlElement(ElementName = "Inspection")]
		public Inspection inspection;
	}
}
