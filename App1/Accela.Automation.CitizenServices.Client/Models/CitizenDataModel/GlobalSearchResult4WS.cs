#region Header

/**
 * <pre>
 *
 *  Accela Citizen Access
 *  File: GlobalSearchResult4WS.cs
 *
 *  Accela, Inc.
 *  Copyright (C): 2009
 *
 *  Description:
 *  
 *
 *  Notes:
 *  $Id: GlobalSearchResult4WS.cs 130988 2009-8-21  10:23:01Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */

#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    
    public partial class GlobalSearchResult4WS
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapView[] capViews { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RefAddressView[] refAddressViews { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RefLPView[] refLPViews { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RefParcelView[] refParcelViews { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int startNumber { get; set; }
    }
}
