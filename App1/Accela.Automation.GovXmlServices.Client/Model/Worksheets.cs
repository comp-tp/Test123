using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	public class Worksheets
	{
		public Worksheets()
		{
		}
		[XmlElement(ElementName="Worksheet")]
		public Worksheet[] worksheet;
	}
}
