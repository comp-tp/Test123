using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for EventMessages.
	/// </summary>
	public class EventMessages
	{
		public EventMessages()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "Message")]
		public EventMessage[] eventMessage;
	}
}
