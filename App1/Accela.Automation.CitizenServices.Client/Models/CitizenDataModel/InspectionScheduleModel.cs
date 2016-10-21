/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: InspectionScheduleModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2012
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: InspectionScheduleModel.cs 171698 2012-05-18 18:20:39Z ACHIEVO\jone.lu $.
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
    public partial class InspectionScheduleModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double actualUnits { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CalendarModel calendar { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime endTime { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public InspectionModel inspection { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SysUserModel inspector { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int scheduleOrder { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime startTime { get; set; }
    }
}
