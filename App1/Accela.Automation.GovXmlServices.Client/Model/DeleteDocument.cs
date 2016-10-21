using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for DeleteDocument.
	/// </summary>
	public class DeleteDocument:Sys
	{
		public DeleteDocument()
		{
		}
		[XmlElement(ElementName="DocumentId")]
		public DocumentId documentId;
	}
}
