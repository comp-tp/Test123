#region Header

/**
 * <pre>
 *
 *  Accela Mobile Office
 *  File: TaskItem.cs
 *
 *  Accela, Inc.
 *  Copyright (C): 2012
 *
 *  Description:
 *  This is TaskItem's model
 *
 *  Note
 *  Created By: Jaison Yang
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
    public class TaskItem
    {
        [XmlElement(ElementName = "stepNumber")]
        public int stepNumber;

        [XmlElement(ElementName = "processID")]
        public long processID;

        [XmlElement(ElementName = "processCode")]
        public string processCode;

        [XmlElement(ElementName = "taskDescription")]
        public string taskDescription;

        [XmlElement(ElementName = "assignmentDate")]
        public string assignmentDate;

        [XmlElement(ElementName = "dueDate")]
        public string dueDate;

        [XmlElement(ElementName = "disposition")]
        public string disposition;

        [XmlElement(ElementName = "statusDate")]
        public string statusDate;

        [XmlElement(ElementName = "startTime")]
        public string startTime;

        [XmlElement(ElementName = "endTime")]
        public string endTime;

        [XmlElement(ElementName = "hoursSpent")]
        public string hoursSpent;

        [XmlElement(ElementName = "billable")]
        public string billable;

        [XmlElement(ElementName = "overTime")]
        public string overTime;

        //[XmlElement(ElementName = "estimatedDueDate")]
        //public DateTime estimatedDueDate;

        //[XmlElement(ElementName = "isRestrictView4ACA")]
        //public string isRestrictView4ACA;

        //[XmlElement(ElementName = "restrictRole")]
        //public string restrictRole;

        [XmlElement(ElementName = "inPossessionTime")]
        public double inPossessionTime;

        //[XmlElement(ElementName = "trackStartDate")]
        //public DateTime trackStartDate;

        //[XmlElement(ElementName = "assignDepartmentName")]
        //public string assignDepartmentName;

        //[XmlElement(ElementName = "assignedUserName")]
        //public string assignedUserName;

        //[XmlElement(ElementName = "actionBy")]
        //public string actionBy;

        //[XmlElement(ElementName = "actionDepartmentName")]
        //public string actionDepartmentName;

        [XmlElement(ElementName = "hoursSpentRequired")]
        public string hoursSpentRequired;

        [XmlElement(ElementName = "dispositionNote")]
        public string dispositionNote;

        [XmlElement(ElementName = "estimatedDueDate")]
        public string estimatedDueDate;

        [XmlElement(ElementName = "isRestrictView4ACA")]
        public string isRestrictView4ACA;

        [XmlElement(ElementName = "restrictRole")]
        public string restrictRole;

        [XmlElement(ElementName = "trackStartDate")]
        public string trackStartDate;

        [XmlElement(ElementName = "assignDepartmentName")]
        public string assignDepartmentName;

        [XmlElement(ElementName = "assignedUserName")]
        public string assignedUserName;

        [XmlElement(ElementName = "actionBy")]
        public string actionBy;

        [XmlElement(ElementName = "actionDepartmentName")]
        public string actionDepartmentName;

        [XmlElement(ElementName = "activeFlag")]
        public string activeFlag;

        [XmlElement(ElementName = "completeFlag")]
        public string completeFlag;

        [XmlElement(ElementName = "daysDue")]
        public int daysDue;

        [XmlElement(ElementName = "calendarID")]
        public long calendarID;

        [XmlElement(ElementName = "approval")]
        public string approval;

        [XmlElement(ElementName = "dispositionComment")]
        public string dispositionComment;

        [XmlElement(ElementName = "asgnEmailDisp")]
        public string asgnEmailDisp;

        [XmlElement(ElementName = "recordBy")]
        public string recordBy;

        [XmlElement(ElementName = "recordDateTime")]
        public string recordDateTime;

        [XmlElement(ElementName = "deleteFlag")]
        public string deleteFlag;
        //[XmlElement(ElementName = "standardComment")]
        //public string standardComment;

        //[XmlElement(ElementName = "standardCommentI18n")]
        //public string standardCommentI18n;

        //[XmlElement(ElementName = "relationSeqId")]
        //public Guid relationSeqId;

        //[XmlElement(ElementName = "StaffPerson")]
        //public StaffPerson staffPerson;

        [XmlElement(ElementName = "Department")]
        public Department department;

        //[XmlElement(ElementName = "Process")]
        //public Process process;

        //[XmlElement(ElementName = "AdditionalInformation")]
        //public AdditionalInformation additionalInformation;

        [XmlElement(ElementName = "WorkflowTaskStatuses")]
        public WorkflowTaskStatuses workflowStatuses;

    }
}
