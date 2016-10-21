using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Key identifier for records
	/// </summary>
	/// 
	public class Keys
	{
		[XmlElement(ElementName = "Key", IsNullable=true)]
		public string[] key;
	}
}