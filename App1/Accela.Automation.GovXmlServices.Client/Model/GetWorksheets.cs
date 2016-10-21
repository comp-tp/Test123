using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for GetWorksheets.
	/// </summary>
	public class GetWorksheets
	{
		public GetWorksheets()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "CAPIds")]
		public CAPIds capIds;
	}
}
