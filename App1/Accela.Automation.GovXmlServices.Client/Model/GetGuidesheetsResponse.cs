using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for FGetGuidesheetListOut.
	/// </summary>
	public class GetGuidesheetsResponse
	{
		public GetGuidesheetsResponse()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "Guidesheets")]
		public Guidesheets guidesheets;
	}
}
