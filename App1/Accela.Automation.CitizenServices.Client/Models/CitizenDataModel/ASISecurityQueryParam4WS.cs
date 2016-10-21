/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ASISecurityQueryParam4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ASISecurityQueryParam4WS.cs 169604 2010-03-30 09:59:38Z ACHIEVO\daly.zeng $.
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
    
    
    
    public partial class ASISecurityQueryParam4WS
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string agency { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ASISecurityModel4WS asiSecurityModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string module { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string userGroup { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string userName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string userType { get; set; }
    }
 }
