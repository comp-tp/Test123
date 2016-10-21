using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for InspectionStatus.
	/// </summary>
	/// 
	public class InspectionStatus
	{
		public InspectionStatus()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "Value")]
		public string val;

		[XmlElement(ElementName = "Date")]
		public string date;

		[XmlElement(ElementName = "Time")]
		public string time;

		[XmlElement(ElementName = "Keys")]
		public Keys keys;
	}
}
