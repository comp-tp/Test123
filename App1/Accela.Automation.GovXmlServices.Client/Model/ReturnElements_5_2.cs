using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for ReturnElements_5_2.
	/// </summary>
	public class ReturnElements_5_2
	{
		public ReturnElements_5_2()
		{
		}
		[XmlElement(ElementName = "returnElement", IsNullable=true)]
		public string[] returnElement;
	}
}
