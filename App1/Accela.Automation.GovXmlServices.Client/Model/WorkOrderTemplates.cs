using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Accela.Automation.GovXmlClient.Model;
using Accela.Automation.GovXmlServices.Client.Model;

namespace Accela.Automation.GovXmlClient.Model
{
    public class WorkOrderTemplate
    {
        [XmlElement(ElementName = "globalId", Namespace = "http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
        public string globalId;

        [XmlElement(ElementName = "ownerHistory", Namespace = "http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
        public string ownerHistory;

        [XmlElement(ElementName = "workOrderTemplateName")]
        public string Name;

        [XmlElement(ElementName = "CAPType")]
        public CAPTypeId WorkOrderType;

        [XmlElement(ElementName = "CostItems")]
        public CostItems Costs;

        [XmlElement(ElementName = "Parts")]
        public Parts Parts;

        [XmlElement(ElementName = "WOTTasks")]
        public WOTTasks WorkOrderTasks;

        [XmlElement(ElementName = "description")]
        public string Description;

        [XmlElement(ElementName = "workOrderPriority")]
        public string Priority;

        [XmlElement(ElementName = "Department")]
        public Department Department;

        [XmlElement(ElementName = "comments")]
        public string Comments;

        [XmlElement(ElementName = "primary")]
        public string Primary;
    }

    public class WorkOrderTemplates
    {
        [XmlElement(ElementName = "WorkOrderTemplate")]
        public WorkOrderTemplate[] WorkOrderTemplate;
    }
}
