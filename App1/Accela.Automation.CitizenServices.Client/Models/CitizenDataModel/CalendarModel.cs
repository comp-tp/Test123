#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: CalendarModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 *
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class CalendarModel : LanguageModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string calendarAfterCutOff { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> calendarAttempts { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> calendarBlockSize { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string calendarBlockUnit { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string calendarComment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string calendarCutOffTime { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string calendarEnableForACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> calendarID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string calendarName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> calendarPriority { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string calendarType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> calendarUnit { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string hideInspectionTimesInACA { get; set; }

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
        public string resCalendarComment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resCalendarContacts { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resCalendarName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resCalendarReason { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> scheduleNumberOfDays { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }
    }
}
