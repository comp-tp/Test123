/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: RFeeItemModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: RFeeItemModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class RFeeItemModel4WS
    {/// <remarks/>
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
        public string appendFlag { get; set; }

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
        public string autoInvoicedFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string calProc { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string crDr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string defaultFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string defaultValue { get; set; }

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
        public string effectDateString { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string expireDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string expireDateString { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double fac { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string feeCalcID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string feeCalculatedFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string feeCod { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string feeCodeStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string feeDes { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string feeSchedule { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double feeunit { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double fix { get; set; }

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
        public string moduleName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string negativeFeeFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string netFeeFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string paymentPeriod { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string preProc { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string quantity { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double rangeHigh { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double rangeIncrement { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double rangeLow { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string requiredFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string subGroup { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string taxFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double taxPercentage { get; set; }

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
    }
    
}
