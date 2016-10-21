using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class GetCAPDetail
    {
        public GetCAPDetail()
		{
		}

		[XmlElement(ElementName = "System")]
		public Sys system;

        [XmlElement(ElementName = "CAPId")]
        public CAPId CAPId;
    }
}
