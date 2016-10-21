/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ACAModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ACAModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.42")]
    [DataContract]
    
    
    
    public partial class ACAModel4WS
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string callerID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string capStateAfterApply { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string isACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string module { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serverName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string strAction { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SysUserModel4WS suModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string taskDispositionComment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool updateStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public BizDomainModel4WS[] workflowTasks { get; set; }
    }
}
