/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: TransactionModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: TransactionModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
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
    
    
    
    public partial class TransactionModel4WS
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string accountNumber { get; set; }

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
        public string authCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string batchTransCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ccHolderName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ccNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ccType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string clientNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string endDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string feeType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string procRespMsg { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string procResult { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string procTransID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string procTransType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string procZipResp { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string startDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string status { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string terminalID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string totalFee { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string transType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string transactionNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string workstationID { get; set; }
    }
}
