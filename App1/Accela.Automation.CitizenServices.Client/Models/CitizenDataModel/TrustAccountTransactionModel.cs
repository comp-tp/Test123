/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: TrustAccountTransactionModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: TrustAccountTransactionModel.cs 182693 2010-10-19 08:24:27Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    
    public partial class TrustAccountTransactionModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string acctID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> acctSeq { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string altID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> balance { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> batchSeqNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string cashierID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ccAuthCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> ccExpDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ccHolderName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> clientReceiptNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> clientTransNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string comment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string depositMethod { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> endRecDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string officeCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string paymentRefNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> paymentSeqNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string payor { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string procTransID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> processingFee { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> recDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recFulNam { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string receiptCustomizedNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string receivedType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string registerNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long sessionNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string targetAcctID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string terminalID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> transAmount { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> transSeq { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string transType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string workstationID { get; set; }
    }
    
}
