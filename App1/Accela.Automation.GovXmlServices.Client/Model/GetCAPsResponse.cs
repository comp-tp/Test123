using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for FGetCAPListByCollectionOut.
	/// </summary>
	public class GetCAPsResponse
	{
		public GetCAPsResponse()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName="CAPs")]
		public CAPs caps;
	}
}
