#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: PasswordResultModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C):2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: PasswordResultModel.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class PasswordResultModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public object data2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int errorCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string errorMessage { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public object parameter { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int pwdScore { get; set; }

    }
}
