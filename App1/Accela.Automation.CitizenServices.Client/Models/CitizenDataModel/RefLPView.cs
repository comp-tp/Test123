#region Header

/**
 * <pre>
 *
 *  Accela Citizen Access
 *  File: RefLPView.cs
 *
 *  Accela, Inc.
 *  Copyright (C): 2009
 *
 *  Description:
 *  
 *
 *  Notes:
 *  $Id: RefLPView.cs 130988 2009-9-8  9:31:01Z ACHIEVO\jackie.yu $.
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
    
    
    
    public partial class RefLPView
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string address { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string businessName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contact { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string licSeqNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string licenseExpirationDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string licenseIssueDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string licenseNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string licenseType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }
    }
}
