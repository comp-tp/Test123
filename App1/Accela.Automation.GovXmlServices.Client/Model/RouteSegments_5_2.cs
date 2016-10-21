using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	public class RouteSegments_5_2
	{
		public RouteSegments_5_2()
		{
		}
		[XmlElement(ElementName = "RouteSegment")]
		public RouteSegment_5_2[] routeSegment;


	}
}
