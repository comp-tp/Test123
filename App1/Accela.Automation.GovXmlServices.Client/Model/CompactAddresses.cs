using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for CompactAddresses.
	/// </summary>
	public class CompactAddresses
	{
		public CompactAddresses()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName="CompactAddress")]
		public CompactAddress[] compactAddress;
	}
}
