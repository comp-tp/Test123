using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class GetAvailableInspectionDates
    {
        public GetAvailableInspectionDates()
		{
		}

		[XmlElement(ElementName = "System")]
		public Sys system;

        [XmlElement(ElementName = "CAPId")]
        public CAPId CAPId;

        [XmlElement(ElementName = "InspectionTypeId")]
        public InspectionTypeId InspectionTypeId;

        [XmlElement(ElementName="startDate")]
        public string startDate;

        [XmlElement(ElementName="availableDatesCount")]
        public string availableDatesCount;
    }
}
