using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for FGetInspectorListOut.
	/// </summary>
	public class GetInspectorsResponse
	{
		public GetInspectorsResponse()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "Inspectors")]
		public Inspectors inspectors;

	}
}
