using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for GetSeverityLevelsResponse.
	/// </summary>
	public class GetSeverityLevelsResponse
	{
		public GetSeverityLevelsResponse()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "SeverityLevels")]
		public SeverityLevels severityLevels;
	}
}
