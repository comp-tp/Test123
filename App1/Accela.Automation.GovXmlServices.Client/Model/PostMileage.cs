using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for PostMileage.
	/// </summary>
	public class PostMileage
	{
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "InspectorId")]
		public InspectorId inspectorId;
		
		[XmlElement(ElementName = "DistanceAndTimes")]
		public DistanceAndTimes distanceAndTimes;

		public PostMileage()
		{
		}
	}
}
