using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for FGetDispositionListOut.
	/// </summary>

	public class GetDispositions
	{
		public GetDispositions()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "contextType")]
		public string contextType;
	}
}