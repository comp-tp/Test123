using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for Range.
	/// </summary>
	/// 
	public class Range
	{
		public Range()
		{
		}

		[XmlElement(ElementName = "minValue")]
		public double minValue;

		[XmlElement(ElementName = "minConstraint")]
		public string minConstraint;

		[XmlElement(ElementName = "maxValue")]
		public double maxValue;

		[XmlElement(ElementName = "maxConstraint")]
		public string maxConstraint;

		[XmlElement(ElementName = "processValue")]
		public string processValue;
	}
}
