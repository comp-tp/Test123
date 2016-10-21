using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	public class Workitems
	{
		public Workitems()
		{
		}
		[XmlElement(ElementName="Workitem")]
		public Workitem[] workitem;
	}
}
