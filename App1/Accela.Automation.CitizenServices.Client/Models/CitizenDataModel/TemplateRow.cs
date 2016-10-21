#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: TemplateRow.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: TemplateRow.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
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
    
    
    
    public partial class TemplateRow
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> rowIndex { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public GenericTemplateTableValue[] values { get; set; }
    }
}
