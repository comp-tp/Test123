using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class WOTTask
    {
        [XmlElement(ElementName = "globalId", Namespace = "http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
        public string globalId;

        [XmlElement(ElementName = "ownerHistory", Namespace = "http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
        public string ownerHistory;

        [XmlElement(ElementName = "taskCode")]
        public string TaskCode;

        [XmlElement(ElementName = "processCode")]
        public string ProcessCode;

        [XmlElement(ElementName = "taskDescription")]
        public string TaskDescription;

        [XmlElement(ElementName = "processID")]
        public string ProcessID;

        [XmlElement(ElementName = "stepNumber")]
        public string StepNumber;

        [XmlElement(ElementName = "workflowTaskStatusCode")]
        public string WorkflowTaskStatus;

        [XmlElement(ElementName = "taskSOP")]
        public string StandardOperatingProcedures;

        [XmlElement(ElementName = "estimate")]
        public string Estimate;

        [XmlElement(ElementName = "order")]
        public string Order;

        [XmlElement(ElementName = "updatedDate")]
        public string UpdatedDate;

        [XmlElement(ElementName = "updatedBy")]
        public string UpdatedBy;

        [XmlElement(ElementName = "durationUnit")]
        public string Unit;

        [XmlElement(ElementName = "comments")]
        public string Comments;

        [XmlElement(ElementName = "description")]
        public string Description;
    }

    public class WOTTasks
    {
        public WOTTasks()
        { }
        [XmlElement(ElementName = "WOTTask")]
        public WOTTask[] WOTTask;
    }
}
