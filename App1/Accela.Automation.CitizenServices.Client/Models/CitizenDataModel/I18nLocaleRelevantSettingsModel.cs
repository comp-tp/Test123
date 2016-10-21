/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: I18nLocaleRelevantSettingsModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: I18nLocaleRelevantSettingsModel.cs 209168 2011-12-07 06:31:49Z ACHIEVO\alan.hu $.
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
    
    
    
    public partial class I18nLocaleRelevantSettingsModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string currencySymbol { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dateFormat { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dateTimeFormat { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string inspectionDateTimeFormat { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string inspectionTimeFormat { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string locale { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string longDateFormat { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string timeFormat { get; set; }
    }
}
