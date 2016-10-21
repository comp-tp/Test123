using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	public class time
	{
		public time()
		{}
		[XmlElement(ElementName="start")]
		public string start;

		[XmlElement(ElementName="end")]
		public string end;

		[XmlElement(ElementName="total")]
		public string total;

		[XmlElement(ElementName="UnitOfMeasurement")]
		public string unitOfMeasurement;
	}
}
