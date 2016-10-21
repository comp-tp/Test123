using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for Documents.
	/// </summary>
	public class Documents
	{
		public Documents()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "Document")]
		public Document[] document;
	}
}
