/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: gFilterScreenPermissionModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: gFilterScreenPermissionModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\grady.lu $.
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
    
    
    
    public partial class GFilterScreenPermissionModel4WS
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string permissionLevel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string permissionValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recFulName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }
    }
}
