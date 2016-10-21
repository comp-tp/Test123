using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for CalculateRoute_5_2.
	/// </summary>
	public class CalculateRoute_5_2
	{
		public CalculateRoute_5_2()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "MapServiceId")]
		public MapServiceId_5_2 mapServiceId;

		[XmlElement(ElementName = "calculationMethod")]
		public string calculationMethod;

		[XmlElement(ElementName = "calculationPriority")]
		public string calculationPriority;
		
		[XmlElement(ElementName = "reorderRoute")]
		public string reorderRoute;
		
		[XmlElement(ElementName = "returnRouteSegments")]
		public string returnRouteSegments;

		[XmlElement(ElementName = "RouteNodes")]
		public RouteNodes_5_2 routeNodes;
	}
}
