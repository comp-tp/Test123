/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ReceiptModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ReceiptModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
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
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://model.webservice.accela.com")]
    public partial class ReceiptModel4WS {
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
        public string cashierID { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long changeDue { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double receiptAmount { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string receiptBatchDate { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long receiptBatchNbr { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string receiptComment { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string receiptCustomizedNBR { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string receiptDate { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long receiptNbr { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string receiptStatus { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string registerNbr { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }
        
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
