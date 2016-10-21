#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: PersonModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: PersonModel.cs 170671 2010-04-16 05:52:20Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SysUserModel))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PeopleModel))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AssetContactModel))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    
    public partial class PersonModel : LanguageModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string firstName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fullName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string lastName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string middleName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string namesuffix { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string rate1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string searchFullName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string title { get; set; }
    }    
}
