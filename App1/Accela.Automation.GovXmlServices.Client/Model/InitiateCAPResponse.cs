using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	public class InitiateCAPResponse
	{
		public InitiateCAPResponse()
		{}

		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "CAPId")]
		public CAPId capId;

		[XmlElement(ElementName = "CAP")]
		public CAP cap;
	}
}
