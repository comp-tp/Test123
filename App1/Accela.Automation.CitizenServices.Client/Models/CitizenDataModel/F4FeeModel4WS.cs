/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: F4FeeModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: F4FeeModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
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
    
    
    
    public partial class F4FeeModel4WS
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public F4FeeItemModel4WS f4FeeItemModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public long receiptNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public X4FeeItemInvoiceModel4WS x4FeeItemInvoiceModel { get; set; }
    }
}
