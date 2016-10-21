using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for GetDocuments.
	/// </summary>
	public class GetDocuments
	{
		public GetDocuments()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "CAPId")]
		public CAPId capID;
	}
}
