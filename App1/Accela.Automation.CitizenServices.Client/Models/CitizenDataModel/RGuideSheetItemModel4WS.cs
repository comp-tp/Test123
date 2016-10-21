/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: RGuideSheetItemModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: RGuideSheetItemModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.42")]
    [DataContract]
    
    
    
    public partial class RGuideSheetItemModel4WS
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
        public string guideItemComment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string guideItemCommentVisible { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string guideItemDisplayOrder { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string guideItemScore { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string guideItemScoreVisible { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string guideItemSeqNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string guideItemStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string guideItemStatusGroupName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string guideItemStatusVisible { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string guideItemText { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string guideItemTextVisible { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string guideType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string lhsType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string maxPoints { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string maxPointsVisible { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }
    }
}
