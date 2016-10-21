/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: EventModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2008-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: EventModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy.WSModel
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.42")]
    [DataContract]
    
    
    
    public partial class EventModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string actionCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string eventName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string scriptCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }
    }
}
