using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for FGetDispositionListIn.
	/// </summary>
	public class GetDispositionsResponse
	{
		public GetDispositionsResponse()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "Dispositions")]
		public Dispositions dispositions;
	}
}
