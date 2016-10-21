#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ActivityModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ActivityModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
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
    
    
    
    public partial class ActivityModel : LanguageModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string actEndTime1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string actEndTime2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> activityDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string activityDescription { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string activityGroup { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string activityJval { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string activityType { get; set; }

        /// <remarks/>
        //[DataMember(EmitDefaultValue=false)]
        //public System.Nullable<System.DateTime> auditDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string autoAssign { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> calendarId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel capIDModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string capStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapTypeModel capType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string carryoverFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string completeTime1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string completeTime2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> completionDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contactFname { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contactLname { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contactMname { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contactNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contactPhoneNum { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contactPhoneNumIDD { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string createdByACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string displayInACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string docCategory { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string docGroup { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string documentDescription { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string documentID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public DocumentModel documentModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string documentName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> endActivityDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> endCompletionDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<float> endMilage { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> endRecordDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> endStatusDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> endTime { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string estimatedEndTime { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string estimatedStartTime { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fileKey { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fileName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string gisAreaName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string grade { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long idNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string inAdvanceFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string inspBillable { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string inspResultType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> inspSequenceNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> inspUnits { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string inspectionGroup { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string isBySupervisor { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string isRestrictView4ACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<float> latitude { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<float> longitude { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int majorViolation { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> maxPoints { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<float> milage { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string oldStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string overtime { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> recordDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recordDescription { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recordTime1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recordTime2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recordType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string reqPhoneNum { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string reqPhoneNumIDD { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string requestorFname { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string requestorLname { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string requestorMname { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string requestorUserID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string requiredInspection { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resActivityType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string restrictRole { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool scheduled { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool signOffWorkflowTask { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string source { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<float> startMilage { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> startTime { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string status { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> statusDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string statusTime1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string statusTime2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SysUserModel sysUser { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string time1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string time2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> timeTotal { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long totalScore { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string unitNBR { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public UserRolePrivilegeModel userRolePrivilegeModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string vehicleID { get; set; }
    }
}