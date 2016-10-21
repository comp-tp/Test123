/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: TemplateGroup.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: TemplateGroup.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
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
    
    
    
    public partial class TemplateGroup
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string groupName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<bool> readOnly { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TemplateSubgroup[] subgroups { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public templateType templateType { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool templateTypeSpecified { get; set; }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.225")]
    [DataContract]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://model.webservice.accela.com/")]
    public enum templateType
    {

        /// <remarks/>
        DefaultType,

        /// <remarks/>
        Form,

        /// <remarks/>
        Table,
    }
}
