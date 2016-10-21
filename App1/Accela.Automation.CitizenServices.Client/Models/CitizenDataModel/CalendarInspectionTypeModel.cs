#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: CalendarInspectionTypeModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: CalendarInspectionTypeModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
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
    
    
    
    public partial class CalendarInspectionTypeModel : LanguageModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> calendarID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string cancelInspectionInACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string enableReadyTimeInACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string groupCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string groupCodeName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> inspectionTypeID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> recDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recFullName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string rescheduleInspectionInACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string scheduleInspectionInACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string type { get; set; }
    }
}
