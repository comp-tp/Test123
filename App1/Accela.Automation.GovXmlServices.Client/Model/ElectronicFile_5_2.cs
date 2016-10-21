using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for ElectronicFile_5_2.
	/// </summary>
	public class ElectronicFile_5_2
	{
		public ElectronicFile_5_2()
		{
		}
		[XmlElement(ElementName = "Description")]
		public string description;

		[XmlElement(ElementName = "Keys")]
		public Keys keys;

		[XmlElement(ElementName = "IdentifierDisplay")]
		public string identifierDisplay;

		[XmlElement(ElementName = "fileName")]
		public string fileName;

		[XmlElement(ElementName = "mimeType")]
		public string mimeType;

		[XmlElement(ElementName = "data")]
		public string data;
	}
}
