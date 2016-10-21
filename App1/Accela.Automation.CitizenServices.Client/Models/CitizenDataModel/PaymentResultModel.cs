/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: PaymentResultModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: PaymentResultModel.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
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
    public partial class PaymentResultModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string authCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resultCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resultMessage { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string transCode { get; set; }
    }
}
