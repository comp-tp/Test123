/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: GActivitySpecInfoGroupCodeModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: GActivitySpecInfoGroupCodeModel.cs 130107 2011-06-16 12:23:56Z ACHIEVO\jackie.yu $.
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
    
    
    
    public partial class GActivitySpecInfoGroupCodeModel : LanguageModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string groupCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resSubGroup { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string subGroup { get; set; }
    }
}
