using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for GetDocumentsResponse.
	/// </summary>
	public class GetDocumentsResponse
	{
		public GetDocumentsResponse()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "DocumentSets")]
		public DocumentSets documentSets;
	}
}
