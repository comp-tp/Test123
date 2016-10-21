using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for CAP.
	/// </summary>
	/// 
	
	public class CAPRelation
	{
		[XmlElement(ElementName = "Keys")]
		public Keys keys;

		[XmlElement(ElementName = "CAPId")]
		public CAPId capId;

		[XmlElement(ElementName = "contextType")]
		public string contextType;

		[XmlElement(ElementName = "Description")]
		public string description;

		[XmlElement(ElementName = "AdditionalInformation")]
		public AdditionalInformation additionalInformation;

		[XmlAttribute(AttributeName="action")]
		public string action;
	}
}