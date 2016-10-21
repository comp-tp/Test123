/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: SupportedLanguageModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: SupportedLanguageModel.cs 185374 2010-11-26 09:47:10Z ACHIEVO\xinter.peng $.
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
    
    
    
    public partial class SupportedLanguageModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string locale { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string localeLabel { get; set; }
    }
}
