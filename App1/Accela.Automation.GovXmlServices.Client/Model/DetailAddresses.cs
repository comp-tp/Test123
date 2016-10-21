using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for DetailAddresses.
	/// </summary>
	public class DetailAddresses
	{
		public DetailAddresses()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName="DetailAddress")]
		public DetailAddress[] detailAddress;
	}
}
