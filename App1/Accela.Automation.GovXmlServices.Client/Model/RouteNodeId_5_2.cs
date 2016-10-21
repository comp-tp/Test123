using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
	
{
	/// <summary>
	/// Summary description for RouteNodeId_5_2.
	/// </summary>
	public class RouteNodeId_5_2
	{
		public RouteNodeId_5_2()
		{
		}
		[XmlElement(ElementName = "Keys")]
		public Keys keys;

		[XmlElement(ElementName = "IdentifierDisplay")]
		public string identifierDisplay;
	}
}
