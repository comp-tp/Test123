using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	public class element
	{
		public element()
		{
		}
		[XmlAttribute(AttributeName="action")]
		public string action;	
	}
}
