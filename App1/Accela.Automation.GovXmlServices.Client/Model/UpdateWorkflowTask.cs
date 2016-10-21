using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class UpdateWorkflowTask
    {
        public UpdateWorkflowTask()
        {

        }
        [XmlElement(ElementName = "System")]
        public Sys system;

        [XmlElement(ElementName = "CAPId")]
        public CAPId capId;

        [XmlElement(ElementName = "TaskItem")]
        public TaskItem taskItem;
    }
}
