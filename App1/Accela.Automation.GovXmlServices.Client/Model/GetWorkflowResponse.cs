using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class GetWorkflowResponse
    {
        public GetWorkflowResponse()
        { }

        [XmlElement(ElementName = "System")]
        public Sys system;

        [XmlElement(ElementName = "Workflows")]
        public Workflows Workflows;
    }
}
