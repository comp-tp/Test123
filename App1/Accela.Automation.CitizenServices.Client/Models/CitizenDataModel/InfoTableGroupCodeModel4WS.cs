/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: InfoTableGroupCodeModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: InfoTableGroupCodeModel4WS.cs 172809 2010-05-15 07:24:27Z ACHIEVO\daly.zeng $.
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
    
    
    
    public partial class InfoTableGroupCodeModel4WS
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string capId1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string capId2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string capId3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string category { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string id { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string name { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string referenceDesc { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string referenceId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string referenceType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public InfoTableSubgroupModel4WS[] subgroups { get; set; }
    }
}
