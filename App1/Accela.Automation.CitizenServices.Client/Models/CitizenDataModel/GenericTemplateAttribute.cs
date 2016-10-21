/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: GenericTemplateAttribute.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: GenericTemplateAttribute.cs 171698 2010-04-29 09:39:39Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    
    public partial class GenericTemplateAttribute : GenericTemplateFieldPK
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ACATemplateConfigModel acaTemplateConfig { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string align { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SimpleAuditModel auditModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string defaultValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string displayFieldName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int displayLen { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool displayLenSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int displayOrder { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool displayOrderSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public EntityPKModel entityPKModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int entityType { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool entityTypeSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int fieldType { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool fieldTypeSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int maxLen { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool maxLenSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public GenericTemplateAttributeEntry[] options { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool readOnly { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool readOnlySpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string required { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long seqNum { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool seqNumSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int subgroupDispOrder { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool subgroupDispOrderSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int templateType { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool templateTypeSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string unitType { get; set; }
    }
}
