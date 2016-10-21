#region Header

/**
 * <pre>
 *
 *  Accela Mobile Office
 *  File: WorkflowStatuses.cs
 *
 *  Accela, Inc.
 *  Copyright (C): 2012
 *
 *  Description:
 *
 *  Note
 *  Created By: Ness Su 06/18/2012
 *
 * </pre>
 */

#endregion Header

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class WorkflowTaskStatus
    {
        [XmlElement(ElementName = "processCode")]
        public string processCode;

        [XmlElement(ElementName = "taskStatusCode")]
        public string taskStatusCode;

        [XmlElement(ElementName = "taskDescription")]
        public string taskDescription;

        [XmlElement(ElementName = "statusDescription")]
        public string statusDescription;

        [XmlElement(ElementName = "resultAction")]
        public string resultingAction;

        [XmlElement(ElementName = "recordDate")]
        public string recordDate;

        [XmlElement(ElementName = "recorderID")]
        public string recorderID;

        [XmlElement(ElementName = "applicationStatus")]
        public string applicationStatus;

        [XmlElement(ElementName = "parentStatus")]
        public string parentStatus;

        [XmlElement(ElementName = "timeTrackerClockAction")]
        public string timeTrackerClockAction;

        [XmlElement(ElementName = "aCADisplayable")]
        public string aCADisplayable;

        [XmlElement(ElementName = "status")]
        public string status;

    }

    public class WorkflowTaskStatuses
    {
        [XmlElement(ElementName = "WorkflowTaskStatus")]
        public WorkflowTaskStatus[] workflowTaskStatus;
    }
}
