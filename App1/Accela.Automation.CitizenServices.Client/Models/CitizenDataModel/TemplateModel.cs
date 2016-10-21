/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: TemplateModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: TemplateModel.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.225")]
    [DataContract]
    
    
    
    public partial class TemplateModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SimpleAuditModel auditModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public EntityPKModel entityPKModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<bool> readOnly { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TemplateGroup[] templateForms { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TemplateGroup[] templateTables { get; set; }
    }
}
