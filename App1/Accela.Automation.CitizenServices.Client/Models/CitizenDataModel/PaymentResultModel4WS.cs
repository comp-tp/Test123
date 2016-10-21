/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: PaymentResultModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: PaymentResultModel4WS.cs 185374 2010-11-26 09:47:10Z ACHIEVO\xinter.peng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.832")]
    [DataContract]
    
    
    
    public partial class PaymentResultModel4WS
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel4WS capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool parentCap { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] serviceNames { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool succeed { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool hasFee { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string moduleName { get; set; }
    }
}
