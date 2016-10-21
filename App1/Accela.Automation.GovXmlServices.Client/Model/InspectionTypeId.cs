using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{

	public class InspectionTypeId
	{
		public InspectionTypeId()
		{

		}
		[XmlElement(ElementName="Keys")]
		public Keys keys;

		[XmlElement(ElementName="IdentifierDisplay")]
		public string identifierDisplay;

	}
}
