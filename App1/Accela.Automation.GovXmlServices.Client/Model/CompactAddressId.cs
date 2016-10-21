using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for CompactAddressId.
	/// </summary>
	public class CompactAddressId
	{
		public CompactAddressId()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "Identifier")]
		public string identifier;
	}
}
