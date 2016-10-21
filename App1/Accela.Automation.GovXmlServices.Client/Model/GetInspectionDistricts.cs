using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	public class GetInspectionDistricts
	{
		public GetInspectionDistricts()
		{}

		[XmlElement(ElementName = "System")]
		public Sys system;
	}
}
