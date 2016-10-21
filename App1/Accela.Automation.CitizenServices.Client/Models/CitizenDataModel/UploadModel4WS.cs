/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: UploadModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: UploadModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [DataContract]
    public partial class UploadModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public byte[] dataHandler { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fileName { get; set; }
    }
}
