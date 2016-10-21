using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for UpdateDocument.
	/// </summary>
	public class UpdateDocument:Sys
	{
		public UpdateDocument()
		{
		}
		[XmlElement(ElementName="Document")]
		public Document document;
	}
}
