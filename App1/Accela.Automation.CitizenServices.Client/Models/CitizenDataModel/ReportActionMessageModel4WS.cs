/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: AppSpecificInfoModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ReportActionMessageModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class ReportActionMessageModel4WS
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int action { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int code { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string message { get; set; }
    }
    
}
