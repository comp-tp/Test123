using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;
using Accela.Apps.Apis.Models.DomainModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppChecklistItem : WSAction
    {
        /// <summary>
        /// Gets or sets the record type keys.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false, Order = 1)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the display for record type
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false, Order = 2)]
        public string Display { get; set; }

        /// <summary>
        /// Gets or sets the checklist item content.
        /// </summary>
        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "description")]
        public WSInspectorAppDescription Description { get; set; }

        /// <summary>
        /// Gets or sets the checklist item status.
        /// </summary>
        [DataMember(Name = "status")]
        public WSInspectorAppChecklistItemStatus Status { get; set; }

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
        //[DataMember(Name = "additionalInfo")]
        //public List<AdditionalTableModel> AdditionalInfo { get; set; }

        /// <summary>
        /// Gets or sets the status group.
        /// </summary>
        [DataMember(Name = "statusGroup")]
        public WSInspectorAppChecklistItemStatusGroup StatusGroup { get; set; }

        /// <summary>
        /// Gets or sets the StandardCommentsGroupIds
        /// </summary>
        public List<string> StandardCommentsGroupIds { get; set; }

        [DataMember(Name = "violationCode")]
        public string ViolationCode { get; set; }

        [DataMember(Name = "critical")]
        public string Critical { get; set; }

        [DataMember(Name = "recordedBy")]
        public string RecordedBy { get; set; }

        [DataMember(Name = "carryOverFlag")]
        public string CarryOverFlag { get; set; }

        public static ChecklistItemModel ToEntityModel(WSInspectorAppChecklistItem model)
        {
            ChecklistItemModel result = null;

            if (model != null)
            {
                result = new ChecklistItemModel()
                {
                    Action = model.Action,
                    AdditionalVisible = model.AdditionalVisible,
                    Comments = model.Comments,
                    CommentVisible = model.CommentVisible,
                    Content = model.Content,
                    DefaultScore = model.DefaultScore,
                    Description = WSInspectorAppDescription.ToEntityModel(model.Description),
                    Display = model.Display,
                    Identifier = model.Id,
                    MaxScore = model.MaxScore,
                    Score = model.Score,
                    ScoreVisible = model.ScoreVisible,
                    StandardCommentsGroupIds = model.StandardCommentsGroupIds,
                    Status = WSInspectorAppChecklistItemStatus.ToEntityModel(model.Status),
                    StatusGroup = WSInspectorAppChecklistItemStatusGroup.ToEntityModel(model.StatusGroup),
                    StatusVisible = model.StatusVisible,
                    ViolationCode = model.ViolationCode,
                    Critical = model.Critical,
                    RecordedBy = model.RecordedBy,
                    CarryOverFlag = model.CarryOverFlag
                };
            }

            return result;
        }

        public static List<ChecklistItemModel> ToEntityModels(List<WSInspectorAppChecklistItem> models)
        {
            List<ChecklistItemModel> result = null;

            if (models != null && models.Count > 0)
            {
                result = new List<ChecklistItemModel>();
                foreach (var m in models)
                {
                    var entityModel = ToEntityModel(m);
                    result.Add(entityModel);
                }
            }

            return result;
        }

        public static WSInspectorAppChecklistItem FromEntityModel(ChecklistItemModel model)
        {
            WSInspectorAppChecklistItem result = null;

            if (model != null)
            {
                result = new WSInspectorAppChecklistItem()
                {
                    Action = model.Action,
                    AdditionalVisible = model.AdditionalVisible,
                    Comments = model.Comments,
                    CommentVisible = model.CommentVisible,
                    Content = model.Content,
                    DefaultScore = model.DefaultScore,
                    Description = WSInspectorAppDescription.FromEntityModel(model.Description),
                    Display = model.Display,
                    Id = model.Identifier,
                    MaxScore = model.MaxScore,
                    Score = model.Score,
                    ScoreVisible = model.ScoreVisible,
                    StandardCommentsGroupIds = model.StandardCommentsGroupIds,
                    Status = WSInspectorAppChecklistItemStatus.FromEntityModel(model.Status),
                    StatusGroup = WSInspectorAppChecklistItemStatusGroup.FromEntityModel(model.StatusGroup),
                    StatusVisible = model.StatusVisible,
                    ViolationCode = model.ViolationCode,
                    Critical = model.Critical,
                    RecordedBy = model.RecordedBy,
                    CarryOverFlag = model.CarryOverFlag
                };
            }

            return result;
        }

        public static List<WSInspectorAppChecklistItem> FromEntityModels(List<ChecklistItemModel> models)
        {
            List<WSInspectorAppChecklistItem> result = null;

            if (models != null && models.Count > 0)
            {
                result = new List<WSInspectorAppChecklistItem>();
                foreach (var m in models)
                {
                    var entityModel = FromEntityModel(m);
                    result.Add(entityModel);
                }
            }

            return result;
        }
    }
}
