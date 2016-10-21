using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	public class distance
	{
		public distance()
		{}
		[XmlElement(ElementName="start")]
		public double start;

		[XmlElement(ElementName="end")]
		public double end;

		[XmlElement(ElementName="total")]
		public double total;

		[XmlElement(ElementName="UnitOfMeasurement")]
		public string unitOfMeasurement;
	}
}
