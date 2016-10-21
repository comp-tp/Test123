using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public  class GetDocumentGroupsResponse : OperationResponse
    {
        [XmlElement(ElementName = "DocumentGroups")]
        public DocumentGroups DocumentGroups;
    }
}
