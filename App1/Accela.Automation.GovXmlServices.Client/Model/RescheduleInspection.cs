using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for FRescheduleInspectionIn.
	/// </summary>
	public class RescheduleInspection
	{
		public RescheduleInspection()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "Inspection")]
		public Inspection inspection;

		[XmlElement(ElementName = "Licenses")]
		public Licenses licenses;

        [XmlElement(ElementName = "reassign")]
	    public string reassign;
	}
}
