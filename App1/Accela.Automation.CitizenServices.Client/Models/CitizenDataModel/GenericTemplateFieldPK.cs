/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: GenericTemplateFieldPK.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: GenericTemplateFieldPK.cs 171698 2010-04-29 09:39:39Z ACHIEVO\daly.zeng $.
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GenericTemplateTableValuePK))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GenericTemplateTableValue))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GenericTemplateAttribute))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.225")]
    [DataContract]
    
    
    
    public partial class GenericTemplateFieldPK
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fieldName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string groupName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string subgroupName { get; set; }
    }
}
