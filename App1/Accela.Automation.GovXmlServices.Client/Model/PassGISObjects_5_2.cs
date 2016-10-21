using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for PassGISObjects_5.
	/// </summary>
	public class PassGISObjects_5_2
	{
		public PassGISObjects_5_2()
		{
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "returnElements")]
		public ReturnElements_5_2 returnElements;

		[XmlElement(ElementName = "MapServiceId")]
		public MapServiceId_5_2 mapServiceId;

		[XmlElement(ElementName = "GISObjects")]
		public GISObjects gisObjects;

		[XmlElement(ElementName = "Extent")]
		public Extent_5_2 extent;

		[XmlElement(ElementName = "showRoute")]
		public string showRoute;
	}
}
