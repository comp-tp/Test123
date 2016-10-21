/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: TransactionModel4WS4TrustAcc.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: TransactionModel4WS4TrustAcc.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{

    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class TransactionModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> accountNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string actionSource { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> auditDate { get; set; }

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
        public System.Nullable<long> batchTransCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string CCHolderName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string CCNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string CCType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> clientNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> endDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> exportDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string exportFileName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string feeType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string gateWayTransactionID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string gatewayTransTtatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string isExported { get; set; }

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
        public string provider { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> startDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string status { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string terminalID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> totalFee { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string transType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> transactionNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string workstationID { get; set; }
    }
}
