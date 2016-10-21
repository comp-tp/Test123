/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: GenericTemplateAttributeEntry.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: GenericTemplateAttributeEntry.cs 171698 2010-04-29 09:39:39Z ACHIEVO\daly.zeng $.
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
    
    
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://model.webservice.accela.com")]
    public partial class GenericTemplateAttributeEntry
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string key { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string value { get; set; }
    }
}
