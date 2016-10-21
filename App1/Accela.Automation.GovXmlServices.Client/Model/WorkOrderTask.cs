/*
 * <pre>
 * 
 *  Accela Mobile Office
 *  File: WorkOrderTask.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2012
 * 
 *  Description:
 *  Create By Ness Su at 6/5/2012
 *  
 *  
 *  
 *  Notes:
 * </pre>
 */

using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class WorkOrderTask:element
    {
        [XmlElement(ElementName = "globalId", Namespace = "http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
        public string globalId;

        [XmlElement(ElementName = "ownerHistory", Namespace = "http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
        public string ownerHistory;

        [XmlElement(ElementName = "order")]
        public string Order;

        [XmlElement(ElementName = "taskCode")]
        public string TaskCode;

        [XmlElement(ElementName = "estimate")]
        public string Estimate;

        [XmlElement(ElementName = "actual")]
        public string Actual;

        [XmlElement(ElementName = "durationUnit")]
        public string Unit;

        [XmlElement(ElementName = "completedDate")]
        public string CompletedDate;

        [XmlElement(ElementName = "totalCost")]
        public string TotalCost;

        [XmlElement(ElementName = "description")]
        public string Description;

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

        [XmlElement(ElementName = "completedBy")]
        public string CompletedBy;

        [XmlElement(ElementName = "updatedDate")]
        public string UpdatedDate;

        [XmlElement(ElementName = "updatedBy")]
        public string UpdatedBy;

        [XmlElement(ElementName = "comments")]
        public string Comments;

        [XmlElement(ElementName = "taskSOP")]
        public string StandardOperatingProcedures;

        [XmlElement(ElementName = "status")]
        public string Status;

        [XmlElement(ElementName = "complete")]
        public string Complete;

        [XmlElement(ElementName = "taskCodeIndex")]
        public string TaskCodeIndex;
    }

    public class WorkOrderTasks : ElementList
    {
        [XmlElement(ElementName = "WorkOrderTask")]
        public WorkOrderTask[] WorkOrderTask;
    }
}
