using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	public class Workitem
	{
		public Workitem()
		{
		}
		[XmlElement(ElementName = "globalId", Namespace = "http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
		public string globalId;
		
		[XmlElement(ElementName = "ownerHistory", Namespace = "http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
		public string ownerHistory;

		[XmlElement(ElementName = "Keys")]
		public Keys keys;

		[XmlElement(ElementName = "IdentifierDisplay")]
		public string identifierDisplay;

		[XmlElement(ElementName = "Date")]
		public string date;
		[XmlElement(ElementName = "Time")]
		public string time;
		[XmlElement(ElementName = "Fee")]
		public Fee fee;
	}
}
