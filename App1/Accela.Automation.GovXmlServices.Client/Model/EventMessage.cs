using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// EventMessage handling element
	/// </summary>
	/// 
	
	public class EventMessage
	{
		public EventMessage(){}

		[XmlElement(ElementName = "Code")]
		public string Code;

		[XmlElement(ElementName = "Text")]
		public string Text;

		[XmlElement(ElementName = "Detail")]
		public string Detail;
	}
}
