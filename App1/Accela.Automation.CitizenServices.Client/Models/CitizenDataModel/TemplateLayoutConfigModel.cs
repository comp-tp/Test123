/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: TemplateLayoutConfigModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2012
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: TemplateLayoutConfigModel.cs 130107 2010-08-13 12:23:56Z ACHIEVO\alan.hu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */

using System;using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    
    public partial class TemplateLayoutConfigModel : TemplateLayoutConfigPKModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SimpleAuditModel auditModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public Nullable<ColumnArrangement> columnArrangement { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public Nullable<int> columnLayout { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ConfigLevel configLevel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TemplateEntityType entityType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fieldName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TemplateLayoutConfigI18NModel i18NModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string instruction { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public Nullable<LableDisplay> labelDisplay { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string templateCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TemplateLayoutConfigI18NModel[] templateLayoutConfigI18NModels { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string templateType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string waterMark { get; set; }
    }


    public enum ColumnArrangement
    {

        /// <remarks/>
        Horizontal,

        /// <remarks/>
        Vertical,
    }

    public enum ConfigLevel
    {

        /// <remarks/>
        TEMPLATECODE,

        /// <remarks/>
        TEMPLATENAME,

        /// <remarks/>
        FIELDNAME,
    }

    public enum TemplateEntityType
    {

        /// <remarks/>
        ASI,

        /// <remarks/>
        ASITABLE,

        /// <remarks/>
        APOTEMPLATE,

        /// <remarks/>
        PEOPLETEMPLATE,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    public enum LableDisplay
    {

        /// <remarks/>
        TOP,

        /// <remarks/>
        LEFT,
    }
}
