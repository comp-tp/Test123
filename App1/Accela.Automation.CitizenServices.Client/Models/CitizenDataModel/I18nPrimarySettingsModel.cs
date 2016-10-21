/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: I18nPrimarySettingsModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: I18nPrimarySettingsModel.cs 185374 2010-11-26 09:47:10Z ACHIEVO\xinter.peng $.
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
    
    
    
    public partial class I18nPrimarySettingsModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string addressLocale { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string currencyLocale { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool hideLanguageOptions { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool multipleLanguageSupport { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string primaryLanguage { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SupportedLanguageModel[] supportLanguages { get; set; }
    }
}
