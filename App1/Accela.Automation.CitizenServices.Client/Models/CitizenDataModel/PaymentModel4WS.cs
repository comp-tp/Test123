/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: PaymentModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: PaymentModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
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
    
    
    
	public partial class PaymentModel4WS {
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string acctID { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double amountNotAllocated { get; set; }
        
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
        public string batchTransCode { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel4WS capID { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string cashierID { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ccAuthCode { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ccExpDate { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ccHolderName { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ccType { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long changeDue { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ftPerID1 { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ftPerID2 { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ftPerID3 { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string officeCode { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string payee { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string payeeAddress { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string payeePhone { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double paymentAmount { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double paymentChange { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string paymentComment { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string paymentDate { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string paymentMethod { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string paymentRefNbr { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long paymentSeqNbr { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string paymentStatus { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string posTransSeq { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double processingFee { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string receiptCustomizedNBR { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long receiptNbr { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string registerNbr { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long sessionNbr { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string terminalID { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double totalInvoiceAmount { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double totalPaidAmount { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string tranCode { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string tranNbr { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel4WS transferCapID { get; set; }
        
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
        public string workstationID { get; set; }
    }
}
