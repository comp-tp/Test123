using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for WWWHomePageURL.
	/// </summary>
	public class WWWHomePageURL
	{
		public WWWHomePageURL()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "String", IsNullable = true)]
		public string[] str;
	}
}
