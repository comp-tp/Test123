using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for MiddleNames.
	/// </summary>
	public class MiddleNames
	{
		public MiddleNames()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName="String")]
			public string[] String;
	}
}
