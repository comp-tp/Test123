/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ProcessRelationModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ProcessRelationModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class ProcessRelationModel4WS
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditDateString { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel4WS capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long parentProcessID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string parentTaskName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string processCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long processID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int stepNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string subflowCompletionReq { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string taskActivation { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string workflowName { get; set; }
    }
    
}
