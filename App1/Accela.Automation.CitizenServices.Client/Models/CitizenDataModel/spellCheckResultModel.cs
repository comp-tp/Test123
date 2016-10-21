/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: SpellCheckerResultModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: SpellCheckerResultModel.cs 130107 2009-05-11 12:23:56Z ACHIEVO\weiky chen $.
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
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://spellchecker.aa.accela.com/")]
    public partial class SpellCheckerResultModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string returnCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string returnMessage { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SpellCheckerWordSuggestionsModel[] suggestions { get; set; }
    }
}
