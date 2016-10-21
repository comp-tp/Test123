using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for CAPStatusResponse.
	/// </summary>
	public class GetCAPStatusResponse
	{
		public GetCAPStatusResponse()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "Statuses")]
		public Statuses Statuses;
	}
}
