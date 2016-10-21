/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: CheckModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: CheckModel.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{ /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.42")]
    [DataContract]
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://adaptor.onlinePayment.cashier.finance.aa.accela.com")]
    public partial class CheckModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string accountNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string checkNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string checkProType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string checkType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string city { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string email { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string licenseNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string name { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string phoneNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string postalCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string routingNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ssNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string state { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string streetAddress { get; set; }
    }
}
