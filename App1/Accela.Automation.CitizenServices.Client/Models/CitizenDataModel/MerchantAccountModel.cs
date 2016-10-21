/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: MerchantAccountModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: MerchantAccountModel.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
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
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://adaptor.onlinePayment.cashier.finance.aa.accela.com")]
    public partial class MerchantAccountModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> accountNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string active { get; set; }

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
        public string description { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> endDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string mid { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string partner { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string password { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> processNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> startDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string tid { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string userName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string vendor { get; set; }
    }

}
