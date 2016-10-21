/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: DuplicatedAPOKeyModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: DuplicatedAPOKeyModel.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    
    public partial class DuplicatedAPOKeyModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string refAPONumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string sourceNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string UID { get; set; }
    }
}
