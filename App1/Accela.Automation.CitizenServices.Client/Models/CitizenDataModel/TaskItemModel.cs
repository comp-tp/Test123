#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: TaskItemModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: TaskItemModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://service.webservice.accela.com/")]
    public partial class TaskItemModel : LanguageModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string actionDepartmentName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string activeFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string adHocName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string appStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string appStatusGroupCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string approval { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string asgnDept { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string asgnEmailDisp { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string asgnStaff { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string assignDepartmentName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string assignedStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SysUserModel assignedUser { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime assignmentDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool assignmentDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string assignmentDateString { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime auditDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool auditDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditDateString { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string billable { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long calendarID { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool calendarIDSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string calendarIdString { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string checkboxCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string checkboxGroup { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string completeFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string currentTaskID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string customProcedure { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int daysDue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string daysDueString { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string deleteFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string displayInACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TimeLogModel[] displayTimeModels { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string disposition { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dispositionComment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime dispositionDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool dispositionDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dispositionDateString { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime dispositionEndDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool dispositionEndDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dispositionNote { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime dueDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool dueDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dueDateString { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime endAssignmentDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool endAssignmentDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime endDispositionDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool endDispositionDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime endDueDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool endDueDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime endTime { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool endTimeSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime estimatedDueDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool estimatedDueDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TimeLogModel[] existTimeModels { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string generalFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string hoursSpent { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string hoursSpentRequired { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double inPossessionTime { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool inPossessionTimeSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string isRestrictView4ACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string langID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string loopCount { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string mouClockAction { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string nextTaskID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string overTime { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string parallelInd { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string parentTaskName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string processCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long processHistorySeq { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long processID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string refActStatusFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resDisposition { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resDispositionComment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string restrictRole { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string shortNotes { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public StandardCommentModel[] standardComments { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime startTime { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool startTimeSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime statusDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool statusDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string statusDateString { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime statusEndDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool statusEndDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int stepNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SysUserModel sysUser { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string taskDescription { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime timerStartTime { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool timerStartTimeSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime trackStartDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool trackStartDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public UserRolePrivilegeModel userRolePrivilegeModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string workflowID { get; set; }
    }
}
