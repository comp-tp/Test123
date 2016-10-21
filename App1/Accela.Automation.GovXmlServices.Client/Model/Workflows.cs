using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class Workflows
    {
        [XmlElement(ElementName = "Workflow")]
        public Workflow[] workflows;
    }

    public class Workflow
    {
        [XmlElement(ElementName = "Processes")]
        public Processes processes;

        [XmlElement(ElementName = "WorkflowHistory")]
        public TaskItems workflowHistory;

        [XmlElement(ElementName = "CAPId")]
        public CAPId capId;
    }
}
