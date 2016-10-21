#region Header

/**
 * <pre>
 *
 *  Accela Citizen Access
 *  File: InspectionTypeModel.cs
 *
 *  Accela, Inc.
 *  Copyright (C): 2010-2011
 *
 *  Description:
 *
 *  Notes:
 * $Id: InspectionTypeModel.cs 178385 2010-08-06 07:47:06Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 *  05/09/2007    troy.yang    Initial version.
 * </pre>
 */

#endregion Header

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    
    public partial class InspectionTypeModel : LanguageModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool isActive { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string allowFailGuideSheetItems { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string allowMultiInsp { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> auditDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string autoAssign { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CalendarInspectionTypeModel calendarInspectionType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> cancelDaysInACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> cancelHoursInACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string cancelOptionInACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string cancelTimeInACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string carryoverFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool isCompleted { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool isConfiguredInInspFlow { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string displayInACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string flowEnabledFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string grade { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string groupCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string groupCodeName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string hasFlowFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool isInAdvance { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string inspEditable { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> inspUnits { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ivrNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> maxPoints { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string priority { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> reScheduleDaysInACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> reScheduleHoursInACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string reScheduleOptionInACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string reScheduleTimeInACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string requiredInspection { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resGroupCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resGroupCodeName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public InspectionResultGroupModel resultGroup { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long sequenceNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int totalScore { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool totalScoreSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string totalScoreOption { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string type { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string unitNBR { get; set; }
    }
}
