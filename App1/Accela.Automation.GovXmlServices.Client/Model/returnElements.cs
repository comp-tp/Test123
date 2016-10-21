using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{

	public class returnElements
	{
		public returnElements()
		{
		}
		[XmlElement(ElementName = "returnElement", IsNullable=true)]
		public string[] returnElement;
	}
}
