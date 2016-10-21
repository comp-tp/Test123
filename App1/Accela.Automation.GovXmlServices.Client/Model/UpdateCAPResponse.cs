using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	public class UpdateCAPResponse
	{
		public UpdateCAPResponse()
		{
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "CAP")]
		public CAP cap;

		[XmlElement(ElementName = "CAPId")]
		public CAPId capId;
	}
}
