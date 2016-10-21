#region Header

/**
 * <pre>
 *
 *  Accela Citizen Access
 *  File: RefAddressView.cs
 *
 *  Accela, Inc.
 *  Copyright (C): 2009
 *
 *  Description:
 *  
 *
 *  Notes:
 *  $Id: RefAddressView.cs 148017 2009-09-16 08:31:21Z ACHIEVO\xinter.peng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */

#endregion Header

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    
    public partial class RefAddressView
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string addressNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fullAddress { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] parcelNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] primaryOwner { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string sourceSeqNbr { get; set; }
    }
}
