#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: GGuideSheetItemModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: GGuideSheetItemModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
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
    
    
    
    public partial class GGuideSheetItemModel : LanguageModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ActivityModel activityModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> auditDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string guideItemASIGroupName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string guideItemASIGroupVisible { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string guideItemASITableGroupName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string guideItemCarryCheck { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string guideItemComment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string guideItemCommentVisible { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> guideItemDisplayOrder { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> guideItemScore { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string guideItemScoreVisible { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> guideItemSeqNbr { get; set; }

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
        public string guideSheetId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string guideType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> guidesheetSeqNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public GGSItemASISubGroupModel[] itemASISubgroupList { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public GGSItemASITableSubGroupModel[] itemASITableSubgroupList { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string lhsType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string majorViolation { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string majorViolationVisible { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> maxPoints { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string maxPointsVisible { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resGuideItemComment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resGuideItemText { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }
    }
}