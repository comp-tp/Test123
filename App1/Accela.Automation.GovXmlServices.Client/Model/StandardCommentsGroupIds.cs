using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class StandardCommentsGroupIds
    {
        public StandardCommentsGroupIds()
        {
        }

        [XmlElement(ElementName = "StandardCommentsGroupId")]
        public StandardCommentsGroupId[] standardCommentsGroupIds;
    }
}
