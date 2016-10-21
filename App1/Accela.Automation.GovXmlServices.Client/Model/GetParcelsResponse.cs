using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for FGetParcelListByCollectionOut.
	/// </summary>
	public class GetParcelsResponse
	{
		public GetParcelsResponse()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "Parcels")]
		public Parcels parcels;
	}
}
