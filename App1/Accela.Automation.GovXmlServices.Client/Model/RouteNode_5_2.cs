using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for RouteNode_5_2.
	/// </summary>
	public class RouteNode_5_2
	{
		public RouteNode_5_2()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "Keys")]
		public Keys keys;

		[XmlElement(ElementName = "IdentifierDisplay")]
		public string identifierDisplay;

		[XmlElement(ElementName = "DetailAddress")]
		public DetailAddress detailAddress;
	}
}
