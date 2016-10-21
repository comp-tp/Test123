using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class MapServerID
    {
        [XmlElement(ElementName = "Keys")]
        public Keys Keys;
    }
}
