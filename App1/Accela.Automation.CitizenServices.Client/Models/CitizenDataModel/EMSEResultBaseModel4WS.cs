/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: EMSEResultBaseModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2008-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: EMSEResultBaseModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    
    public partial class EMSEResultBaseModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public byte[] handler { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string result { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string returnCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string returnMessage { get; set; }
    }
}
