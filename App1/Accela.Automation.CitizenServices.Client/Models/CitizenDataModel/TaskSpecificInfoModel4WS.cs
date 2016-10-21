/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: TaskSpecificInfoModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: TaskSpecificInfoModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class TaskSpecificInfoModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string actStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string attributeUnitType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string attributeValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string attributeValueReqFeeClacFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string attributeValueReqFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditid { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string bgroupDsoOrder { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string bgroupDspOrder { get; set; }

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
        public string displayLength { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long displayOrder { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string endDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string feeIndicator { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fieldLabel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fieldType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string groupCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string isCalculate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string maxLength { get; set; }

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
        public long processID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string requiredFeeCalc { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string requiredFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resAttributeValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resCheckboxDesc { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resCheckboxType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string startDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int stepNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string taskStatusReqFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string unit { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string validationScriptName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RefAppSpecInfoDropDownModel4WS[] valueList { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string vchDispFlag { get; set; }
    }
}
