/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ACATemplateConfigModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ACATemplateConfigModel.cs 171698 2010-04-29 09:39:39Z ACHIEVO\grady.lu $.
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
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://service.webservice.accela.com/")]
    public partial class ACATemplateConfigModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fieldLabel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string instruction { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resFieldLabel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resInstruction { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resWaterMark { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string waterMark { get; set; }
    }
}
