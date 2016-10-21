/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ReportResultModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ReportResultModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [DataContract]
    public partial class ReportResultModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public byte[] content { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string format { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string name { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool printOnly { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ReportActionMessageModel4WS[] reportMessages { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] responseHeaders { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] responseHeadersValues { get; set; }
    }
}
