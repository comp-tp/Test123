#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: TimeLogModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: TimeLogModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
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
    public partial class TimeLogModel : LanguageModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string accessModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string billable { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel capIDModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string createdBy { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime createdDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool createdDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime dateLogged { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool dateLoggedSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime endTime { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool endTimeSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double entryCost { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool entryCostSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double entryPct { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool entryPctSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double entryRate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool entryRateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime lastChangeDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool lastChangeDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string lastChangeUser { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string materials { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double materialsCost { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool materialsCostSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double milageTotal { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool milageTotalSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double mileageEnd { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool mileageEndSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double mileageStart { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool mileageStartSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string notation { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string reference { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime startTime { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool startTimeSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime timeElapsed { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool timeElapsedSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long timeGroupSeq { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool timeGroupSeqSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long timeLogSeq { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool timeLogSeqSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string timeLogStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TimeTypeModel timeTypeModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long timeTypeSeq { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool timeTypeSeqSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int totalMinutes { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool totalMinutesSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long userGroupSeqNbr { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool userGroupSeqNbrSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string vehicleId { get; set; }
    }
}
