using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class Processes
    {
        [XmlElement(ElementName = "Process")]
        public Process[] processes;
    }

    public class Process
    {
        [XmlElement(ElementName = "TaskItems")]
        public TaskItems taskItems;

        [XmlElement(ElementName = "stepNumber")]
        public int stepNumber;

        [XmlElement(ElementName = "parentProcessID")]
        public long parentProcessID;

        [XmlElement(ElementName = "processID")]
        public long processID;

        [XmlElement(ElementName = "isAdHocTask")]
        public string isAdHocTask;
    }
}
