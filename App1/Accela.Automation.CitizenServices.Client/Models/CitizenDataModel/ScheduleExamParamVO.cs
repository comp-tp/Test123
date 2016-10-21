#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ScheduleExamParamVO.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ScheduleExamParamVO.cs 181867 2011-09-27 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    
    public partial class ScheduleExamParamVO
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> calendarID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string callerID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> endTime { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> examDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string examName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> examSeqNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool existingACAUser { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool fromACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string inputEmail { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool isBeyondAllowanceDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool isFromReferenceSide { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> locationID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> proctorID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long providerNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> refExamNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string reschedCancelReason { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> rosterID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool sameProviderForReschedule { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> scheduleDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> scheduleID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string scheduleType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> startTime { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public StudentInfoVO studentInfo { get; set; }
    }
}
