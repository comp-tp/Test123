using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class StandardCommentsGroup
    {
        public StandardCommentsGroup()
        {
        }

        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        [XmlElement(ElementName = "IdentifierDisplay")]
        public string identifierDisplay;

        [XmlElement(ElementName = "contextType")]
        public string contextType;

        [XmlElement(ElementName = "Description")]
        public string description;

        [XmlElement(ElementName = "StandardComments")]
        public StandardComments standardComment;
    }
}
