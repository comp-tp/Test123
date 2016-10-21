using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	public class GetWorksheetsResponse
	{
		public GetWorksheetsResponse()
		{
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "Worksheets")]
		public Worksheets worksheets;
	}
}
