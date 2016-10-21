/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ASISecurityModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ASISecurityModelWS.cs 209458 2011-12-12 06:03:07Z ACHIEVO\daly.zeng $.
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
    
    
    
    public partial class ASISecurityModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string asiDBType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string asiType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool asiTypePolicy { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fieldName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string group { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string subgroup { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public XPolicyModel XPolicy { get; set; }
    }
}