#region Header

/**
 * <pre>
 *
 *  Accela Citizen Access
 *  File: RefParcelView.cs
 *
 *  Accela, Inc.
 *  Copyright (C): 2009
 *
 *  Description:
 *  
 *
 *  Notes:
 *  $Id: RefParcelView.cs 130988 2009-9-8  9:30:01Z ACHIEVO\jackie.yu $.
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
    
    
    
    public partial class RefParcelView
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] fullAddress { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string parcelNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] refOwnerName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string sourceSeqNbr { get; set; }
    }
}
