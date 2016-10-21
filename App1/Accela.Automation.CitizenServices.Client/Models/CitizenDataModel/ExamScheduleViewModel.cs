#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ExamScheduleViewModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011-2012
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ExamScheduleViewModel.cs 181867 2011-09-27 08:06:18Z ACHIEVO\daly.zeng $.
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
    
    
    
    public partial class ExamScheduleViewModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int availableSeats { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string batchJobName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> calendarID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> date { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dispTime { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> endTime { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RefFeeDsecVO[] refFeeDsecVOs { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string examName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool external { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string instructions { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> locationID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RProviderLocationModel locationModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string providerName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long providerNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> refExamNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> scheduleID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> startTime { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string supportLang { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string totalFeeAmount { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string weekday { get; set; }
    }
}