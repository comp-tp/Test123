/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: TaskItemModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: TaskItemModel4WS.cs 209458 2011-12-12 06:03:07Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */

using Accela.ACA.WSProxy.WSModel;
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class TaskItemModel4WS
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
        public string approval { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string asgnEmailDisp { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string assignDepartmentName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SysUserModel4WS assignedUser { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string assignmentDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string assignmentDateString { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditDate { get; set; }

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
        public string calendarID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string calendarIdString { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel4WS capID { get; set; }

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
        public string disposition { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dispositionComment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dispositionDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dispositionDateString { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dispositionEndDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dispositionNote { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dueDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dueDateString { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string endAssignmentDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string endDispositionDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string endDueDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string endTime { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string estimatedDueDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string generalFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TaskItemModel4WS[] historyTaskItems { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string hoursSpent { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string hoursSpentRequired { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string inPossessionTime { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string isRestrictView4ACA { get; set; }

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
        public long processID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resDisposition { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resDispositionComment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resTaskDescription { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string restrictRole { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public StandardCommentModel4WS[] standardComments { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string startTime { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string statusDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string statusDateString { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string statusEndDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int stepNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SysUserModel4WS sysUser { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string taskDescription { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TaskSpecificInfoModel4WS[] taskSpecItems { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string timerStartTime { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string trackStartDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public UserRolePrivilegeModel userRolePrivilegeModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string workflowID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string refActStatusFlag { get; set; }
    }
}
