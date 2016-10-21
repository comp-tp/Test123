/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: GenericTemplateTableValuePK.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: GenericTemplateTableValuePK.cs 171698 2010-04-29 09:39:39Z ACHIEVO\daly.zeng $.
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GenericTemplateTableValue))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.225")]
    [DataContract]
    
    
    
    public partial class GenericTemplateTableValuePK : GenericTemplateFieldPK
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long rowIndex { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool rowIndexSpecified { get; set; }
    }
}
