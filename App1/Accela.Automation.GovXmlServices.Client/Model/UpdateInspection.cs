using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for FUpdateInspectionIn.
	/// </summary>
	public class UpdateInspection
	{
		public UpdateInspection()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "Inspection")]
		public Inspection inspection;

	}
}
