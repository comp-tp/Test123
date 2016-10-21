/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: UploadResult4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: UploadResult4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [DataContract]
    public partial class UploadResult4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public byte[] dataHandler { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fileName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string message { get; set; }
    }
}
