using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for CalculateRouteResponse_5_2.
	/// </summary>
	public class CalculateRouteResponse_5_2
	{
		public CalculateRouteResponse_5_2()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "RouteNodes")]
		public RouteNodes_5_2 routeNodes;

		[XmlElement(ElementName = "RouteNodeIds")]
		public RouteNodeIds_5_2 routeNodeIds;

		[XmlElement(ElementName = "RouteSegments")]
		public RouteSegments_5_2 routeSegments;

	}
}
