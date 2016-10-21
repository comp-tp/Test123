/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: RGuideSheetGroupModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: RGuideSheetGroupModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class RGuideSheetGroupModel4WS
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string autoCreate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string displayOrder { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string guideGroup { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RGuideSheetModel4WS[] guideSheets { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string guideType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }
    }
}
