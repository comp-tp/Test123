using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for ElectronicMailAddresses.
	/// </summary>
	public class ElectronicMailAddresses
	{
		public ElectronicMailAddresses()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "String", IsNullable = true)]
		public string[] str;
	}
}
