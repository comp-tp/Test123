/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: EdmsPolicyModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: EdmsPolicyModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
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
    
    
    
    public partial class EdmsPolicyModel4WS
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string agenctName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string agencyName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string configuration { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string data2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string data5 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string defaultRight { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string deleteRight { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string downloadRight { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public long policySeq { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string sourceName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string uploadRight { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string viewRight { get; set; }
    }
}
