/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: X4FeeItemInvoiceModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: X4FeeItemInvoiceModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.42")]
    [DataContract]
    
    
    
    public partial class X4FeeItemInvoiceModel4WS
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
        public CapIDModel4WS capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double fee { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string feeCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string feeDescription { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string feeSchedule { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long feeSeqNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string feeitemStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long invoiceNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string paymentPeriod { get; set; }

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
        public double unit { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string userDescription { get; set; }
    }
}
