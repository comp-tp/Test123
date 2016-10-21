using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for DocumentSets.
	/// </summary>
	public class DocumentSets
	{
		public DocumentSets()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "DocumentSet")]
		public DocumentSet[] documentSet;
	}
}
