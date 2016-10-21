using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for DocumentSet.
	/// </summary>
	public class DocumentSet
	{
		public DocumentSet()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
		[XmlElement(ElementName = "Keys")]
		public Keys keys;

		[XmlElement(ElementName = "IdentifierDisplay")]
		public string identifierDisplay;

		[XmlElement(ElementName = "Documents")]
		public Documents documents;
	}
}
