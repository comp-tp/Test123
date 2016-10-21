/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: F4FeeItemModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: F4FeeItemModel4WS.cs 156903 2009-11-17 08:38:35Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class F4FeeItemModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string accCodeL1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string accCodeL2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string accCodeL3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string adjusted { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string applyDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string autoAssessFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string autoInvoiceFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string calcFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string calculatedFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel4WS capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string display { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string displayOrder { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string effectDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string expireDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double fee { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string feeCalcID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string feeCalcProc { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string feeCod { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string feeDescription { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string feeNotes { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string feeSchudle { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long feeSeqNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double feeUnit { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string feeitemStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string formula { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string maxFee { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string minFee { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string negativeFeeFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string netFeeFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string parentFeeItemSeqNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string paymentPeriod { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string posTransSeq { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resFeeCod { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resFeeDescription { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string subGroup { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string udes { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string udf1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string udf2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string udf3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string udf4 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string version { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string acaRequiredFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string defaultFlag { get; set; }
    }
}
