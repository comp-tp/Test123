/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ProjectTreeNodeModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2008-2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ProjectTreeNodeModel4WS.cs 193571 2011-03-23 12:19:12Z ACHIEVO\hans.shi $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    
    public partial class ProjectTreeNodeModel4WS
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapModel4WS CAP { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ProjectTreeNodeModel4WS[] children { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool firstChild { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool lastChild { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int level { get; set; }
    }
}