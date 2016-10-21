using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class StandardCommentsGroups
    {
        public StandardCommentsGroups()
        {
        }

        [XmlElement(ElementName = "StandardCommentsGroup")]
        public StandardCommentsGroup[] standardCommentsGroups;
    }
}
