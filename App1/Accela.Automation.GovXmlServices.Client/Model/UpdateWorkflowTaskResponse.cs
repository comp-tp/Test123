using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class UpdateWorkflowTaskResponse
    {
        public UpdateWorkflowTaskResponse()
        {

        }
        [XmlElement(ElementName = "System")]
        public Sys system;

        [XmlElement(ElementName = "CAPId")]
        public CAPId capId;

        [XmlElement(ElementName = "result")]
        public string result;
    }
}
