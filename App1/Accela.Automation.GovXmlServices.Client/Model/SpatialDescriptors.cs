using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for SpatialDescriptors.
	/// </summary>
	public class SpatialDescriptors
	{
		public SpatialDescriptors()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName="GPSReference")]
		public GPSReference GPSReference;

		[XmlElement(ElementName="MapReference")]
		public MapReference mapReference;
	}

	public class GPSReference
	{
		[XmlElement(ElementName="latitude")]
		public string latitude;

		[XmlElement(ElementName="longitude")]
		public string longitude;
	}
}
