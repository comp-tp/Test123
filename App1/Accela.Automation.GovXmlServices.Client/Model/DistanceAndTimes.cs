using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for DistanceAndTimes.
	/// </summary>
	public class DistanceAndTimes
	{
		public DistanceAndTimes()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName="DistanceAndTime")]
		public DistanceAndTime[] distanceAndTime;
	}
}
