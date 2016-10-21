using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for GetAdditionalInformationGroupsResponse.
	/// </summary>
	public class GetAdditionalInformationGroupsResponse
	{
		public GetAdditionalInformationGroupsResponse()
		{
		}

		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName="AdditionalInformation")]
		public AdditionalInformation additionalInformation;
	}
}
