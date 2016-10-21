using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for ElectronicFileLocator.
	/// </summary>
	public class ElectronicFileLocator
	{
		public ElectronicFileLocator()
		{
		}
		[XmlElement(ElementName="Keys")] 
		public Keys keys;

		[XmlElement(ElementName="IdentifierDisplay")] 
		public string identifierDisplay;

		[XmlElement(ElementName="contextType")] 
		public string contextType;

		[XmlElement(ElementName="fileName")] 
		public string fileName;

		[XmlElement(ElementName="fileDateTime")] 
		public string fileDateTime;

		[XmlElement(ElementName="fileLocation")] 
		public string fileLocation;

		[XmlElement(ElementName="fileSize")] 
		public string fileSize;

        [XmlElement(ElementName="fileType")]
        public string fileType;

		[XmlElement(ElementName="serverAddress")] 
		public string serverAddress;

		[XmlElement(ElementName="serverDescription")] 
		public string serverDescription;

		[XmlElement(ElementName="serverType")] 
		public string serverType;

		[XmlElement(ElementName="serverPlatform")] 
		public string serverPlatform;

		[XmlElement(ElementName="serverVendor")] 
		public string serverVendor;

		[XmlElement(ElementName="ElectronicSignature")] 
		public string electronicSignature;

		[XmlElement(ElementName="ElectronicFileUploaded")] 
		public string electronicFileUploaded;
	}
}
