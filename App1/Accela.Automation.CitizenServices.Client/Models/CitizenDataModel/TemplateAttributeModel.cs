/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: TemplateAttributeModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: TemplateAttributeModel.cs 171698 2010-04-29 09:39:39Z ACHIEVO\daly.zeng $.
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    
    public partial class TemplateAttributeModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string attributeLabel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string attributeName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string attributeScriptCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string attributeUnitType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string attributeValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string attributeValueDataType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string attributeValueReqFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> auditDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string defaultAttributeLabel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> displayOrder { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TemplateEntityType entityType { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool entityTypeSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string instruction { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resAttributeUnitType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resInstruction { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resWaterMark { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TemplateAttrValueModel[] selectOptions { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string templateObjectNum { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string templateType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string vchFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string waterMark { get; set; }
    }
}
