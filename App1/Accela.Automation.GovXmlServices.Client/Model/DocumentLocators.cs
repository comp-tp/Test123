using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	public class DocumentLocators
	{
		public DocumentLocators()
		{
		}
		[XmlElement(ElementName="ElectronicFileLocator")] 
		public ElectronicFileLocator electronicFileLocator;

		[XmlElement(ElementName="PhysicalDocumentLocator")] 
		public PhysicalDocumentLocator physicalDocumentLocator;

		[XmlElement(ElementName="UniversalDocumentLocator")] 
		public UniversalDocumentLocator universalDocumentLocator;
	}
}
