#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: AppSpecificInfoModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: AppSpecificInfoModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
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
    public partial class AppSpecificInfoModel : LanguageModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string actStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string alignment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string alternativeLabel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string attributeUnitType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string attributeValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string attributeValueReqFlag { get; set; }

        ///// <remarks/>
        //[DataMember(EmitDefaultValue=false)]
        //public System.DateTime auditDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool auditDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditid { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int BGroupDspOrder { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool BGroupDspOrderSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string checkboxDesc { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string checkboxInd { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string checkboxType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string checklistComment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int displayLength { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool displayLengthSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long displayOrder { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime endDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool endDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string feeIndicator { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool fromAdmin { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string groupCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string groupCode2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool isCalculate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool isCalculateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool isConfigAsiDrillDown { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int maxLength { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool maxLengthSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string perSubType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string perType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string permitID1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string permitID2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string permitID3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string requiredFeeCalc { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string sharedDdListName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime startDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool startDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool supervisorEditOnly { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool supervisorEditOnlySpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string validationScriptName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public object[] valueList { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string vchDispFlag { get; set; }
    }
}
