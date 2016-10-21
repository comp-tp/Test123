using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for FGetCAPTypeListOut.
	/// </summary>
	public class GetCAPTypesResponse
	{
		public GetCAPTypesResponse()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "CAPTypes")]
		public CAPTypes capTypes;
	}
}
