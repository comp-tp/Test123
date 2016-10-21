using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class TaskItems
    {
        [XmlElement(ElementName = "TaskItem")]
        public TaskItem[] taskItems;
    }
}
