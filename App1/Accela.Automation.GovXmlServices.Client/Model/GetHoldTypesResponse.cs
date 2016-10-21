using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for GetHoldTypesResponse.
	/// </summary>
	public class GetHoldTypesResponse
	{
		public GetHoldTypesResponse()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "HoldTypes")]
		public HoldTypes holdTypes;
	}
}
