/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: CommentModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: CommentModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class CommentModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string activityIDNumber { get; set; }

        /// <remarks/>
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
        public string commentIDNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string commentType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string synopsis { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string text { get; set; }
    }
}
