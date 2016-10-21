using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	public class RouteNodeIds_5_2
	{
		public RouteNodeIds_5_2()
		{
		}
		[XmlElement(ElementName = "RouteNodeId")]
		public RouteNodeId_5_2[] routeNodeId;
	}
}
