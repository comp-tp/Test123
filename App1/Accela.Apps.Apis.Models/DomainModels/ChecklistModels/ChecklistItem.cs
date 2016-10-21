using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;

namespace Accela.Apps.Apis.Models.DomainModels.ChecklistModels
{
    /// <summary>
    /// ChecklistItems class
    /// </summary>
    [DataContract]
    public class ChecklistItemModel : ActionDataModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the checklist item keys.
        /// </summary>
        [DataMember(Name = "identifier")]
        public string Identifier { get; set; }

        [DataMember(Name = "display")]
        public string Display { get; set; }

        /// <summary>
        /// Gets or sets the checklist item content.
        /// </summary>
        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "description")]
        public DescriptionModel Description { get; set; }

        /// <summary>
        /// Gets or sets the checklist item status.
        /// </summary>
        [DataMember(Name = "status")]
        public ChecklistItemStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the commets.
        /// </summary>
        [DataMember(Name = "comments")]
        public string Comments { get; set; }

        /// <summary>
        /// Gets or sets the max score string.
        /// </summary>
        /// <value>
        /// The max score string.
        /// </value>
        [DataMember(Name = "maxScore")]
        public string MaxScore { get; set; }

        ////The property have be removed. becuase the min value is 0
        ///// <summary>
        ///// Gets or sets the min-score.
        ///// </summary>
        //[DataMember(Name = "minScore")]
        //public decimal? MinScore { get; set; }

        /// <summary>
        /// Gets or sets the score string.
        /// </summary>
        /// <value>
        /// The score string.
        /// </value>
        [DataMember(Name = "score")]
        public string Score { get; set; }

        /// <summary>
        /// Gets or sets the Status Visible.
        /// </summary>
        [DataMember(Name = "statusVisible")]
        public bool StatusVisible { get; set; }

        /// <summary>
        /// Gets or sets the Comment Visible.
        /// </summary>
        [DataMember(Name = "commentVisible")]
        public bool CommentVisible { get; set; }

        /// <summary>
        /// Gets or sets the Score Visible.
        /// </summary>
        [DataMember(Name = "scoreVisible")]
        public bool ScoreVisible { get; set; }

        /// <summary>
        /// Gets or sets the default score string.
        /// </summary>
        /// <value>
        /// The default score string.
        /// </value>
        [DataMember(Name = "defaultScore")]
        public string DefaultScore { get; set; }

        /// <summary>
        /// Gets or sets the Additional Visible
        /// </summary>
        [DataMember(Name = "additionalVisible")]
        public bool AdditionalVisible { get; set; }

        /// <summary>
        /// Gets or sets the additionoal information.
        /// </summary>
        /// <value>
        /// The additional info.
        /// </value>
        [DataMember(Name = "additionalInfo")]
        public List<AdditionalGroupModel> AdditionalInfo { get; set; }

        [DataMember(Name = "additionalTableInfo")]
        public List<AdditionalTableModel> AdditionalTableInfo { get; set; }

        /// <summary>
        /// Gets or sets the status group.
        /// </summary>
        [DataMember(Name = "statusGroup")]
        public ChecklistItemStatusGroup StatusGroup { get; set; }

        /// <summary>
        /// Gets or sets the StandardCommentsGroupIds
        /// </summary>
        [DataMember(Name = "standardCommentsGroupIds")]
        public List<string> StandardCommentsGroupIds { get; set; }

        [DataMember(Name = "violationCode")]
        public string ViolationCode { get; set; }

        [DataMember(Name = "critical")]
        public string Critical { get; set; }

        [DataMember(Name = "recordedBy")]
        public string RecordedBy { get; set; }

        [DataMember(Name = "carryOverFlag")]
        public string CarryOverFlag { get; set; }

        #endregion Properties
    }

    [DataContract]
    public class DescriptionModel
    {
        [DataMember(Name = "id", Order = 1)]
        public string ID { get; set; }

        [DataMember(Name = "display", Order = 2)]
        public string Display { get; set; }
    }
}