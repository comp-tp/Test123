#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: TemplateSubgroup.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: TemplateSubgroup.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.225")]
    [DataContract]
    
    
    
    public partial class TemplateSubgroup
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string displayName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> displayOrder { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public GenericTemplateAttribute[] fields { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<bool> readOnly { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TemplateRow[] rows { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string subgroupName { get; set; }
    }
}
