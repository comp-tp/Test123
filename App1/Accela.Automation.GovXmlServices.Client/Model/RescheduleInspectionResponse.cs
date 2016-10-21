using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for FRescheduleInspectionOut.
	/// </summary>
	public class RescheduleInspectionResponse
	{
		public RescheduleInspectionResponse()
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


        [XmlElement(ElementName = "ConfirmationNumber")]
	    public string confirmationNumber;
	}
}
