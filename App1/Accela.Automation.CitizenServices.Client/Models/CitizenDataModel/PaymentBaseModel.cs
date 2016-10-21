/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: PaymenttBaseModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: PaymentBaseModel.cs 182693 2010-10-19 08:24:27Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PaymentModel))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    
    public partial class PaymentBaseModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string acctID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double amountNotAllocated { get; set; }

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
        public string CCAuthCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string cardHolderName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string cashierID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> ccExpDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ccType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double changeDue { get; set; }

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
        public string payeePhoneCountryCode { get; set; }

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
        public System.Nullable<System.DateTime> paymentDate { get; set; }

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
        public string receiptCustomizedNBR { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long receiptNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string receivedType { get; set; }

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
        public CapIDModel transferCapID { get; set; }

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
