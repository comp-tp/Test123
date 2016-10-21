using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	public class MapReference
	{
		public MapReference()
		{
		}
		[XmlElement(ElementName = "map")]
		public string map;

		[XmlElement(ElementName = "tract")]
		public string tract;

		[XmlElement(ElementName = "block")]
		public string block;

		[XmlElement(ElementName = "lot")]
		public string lot;

        [XmlElement(ElementName = "subdivision")]
        public string subdivision;

        [XmlElement(ElementName = "referenceAddress")]
        public string referenceAddress;

        [XmlElement(ElementName = "referenceEntity")]
        public string referenceEntity;

        [XmlElement(ElementName = "referenceLandType")]
        public string referenceLandType;

        [XmlElement(ElementName = "section")]
        public string section;

        [XmlElement(ElementName = "township")]
        public string township;

        [XmlElement(ElementName = "range")]
        public string range;
    }
}
