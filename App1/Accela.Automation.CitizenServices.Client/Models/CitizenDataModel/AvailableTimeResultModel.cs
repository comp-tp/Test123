/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: AvailableTimeResultModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2012
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: AvailableTimeResultModel.cs 171698 2012-05-18 18:20:39Z ACHIEVO\jone.lu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    
    public partial class AvailableTimeResultModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string actualMessage { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double actualUnit { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long calendarID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string endAMPM { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string endTime { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string flag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long idNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public InspectionScheduleModel inspSchdlModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string inspType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SysUserModel inspector { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string message { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public object[] messageParams { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int resultType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> scheduleDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public AvailableTimeResultModel secondValidationResult { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string startAMPM { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string startTime { get; set; }
    }
}
