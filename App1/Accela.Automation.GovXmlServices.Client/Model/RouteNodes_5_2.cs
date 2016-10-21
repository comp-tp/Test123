using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for RouteNodes.
	/// </summary>
	public class RouteNodes_5_2
	{
		public RouteNodes_5_2()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "RouteNode")]
		public RouteNode_5_2[] routeNode;
	}
}
