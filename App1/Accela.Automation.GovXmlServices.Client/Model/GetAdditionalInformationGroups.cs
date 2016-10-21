using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for GetAdditionalInformationGroups.
	/// </summary>
	public class GetAdditionalInformationGroups
	{
		public GetAdditionalInformationGroups()
		{
		}

		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "contextType")]
		public string contextType;
	}
}
