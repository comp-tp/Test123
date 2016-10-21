using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract(Name = "checklistItem")]
    public class WSChecklistItem : WSEntityState
    {
        /// <summary>
        /// Gets or sets the checklist item keys.
        /// </summary>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the checklist item content.
        /// </summary>
        [DataMember(Name = "content")]
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the checklist item status.
        /// </summary>
        [DataMember(Name = "status")]
        public WSChecklistItemStatus Status { get; set; }

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
        public double? MaxScore { get; set; }

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
        public double? Score { get; set; }

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
        /// Gets or sets the status group.
        /// </summary>
        [DataMember(Name = "statusGroup")]
        public WSChecklistItemStatusGroup StatusGroup { get; set; }

        /// <summary>
        /// Gets or sets the StandardCommentsGroupIds
        /// </summary>
        public List<string> StandardCommentsGroupIds { get; set; }

        /// <summary>
        /// Toes the entity models.
        /// </summary>
        /// <param name="wsModels">The web service models.</param>
        /// <returns>the entity models.</returns>
        public static List<ChecklistItemModel> ToEntityModels(List<WSChecklistItem> wsModels)
        {
            if (wsModels == null)
            {
                return null;
            }

            var result = wsModels.Select(m => ToEntityModel(m)).ToList();
            return result;
        }

        /// <summary>
        /// Froms the entity models.
        /// </summary>
        /// <param name="entityModels">The entity models.</param>
        /// <returns>the entity models.</returns>
        public static List<WSChecklistItem> FromEntityModels(List<ChecklistItemModel> entityModels)
        {
            if (entityModels == null)
            {
                return null;
            }

            var result = entityModels.Select(m => FromEntityModel(m)).ToList();
            return result;
        }

        /// <summary>
        /// Toes the entity model.
        /// </summary>
        /// <param name="wsModel">The web service model.</param>
        /// <returns>The entity model.</returns>
        public static ChecklistItemModel ToEntityModel(WSChecklistItem wsModel)
        {
            if (wsModel == null)
            {
                return null;
            }

            var result = new ChecklistItemModel()
            {
                Action = WSEntityState.ConvertEntityStateToAction(wsModel.EntityState),
                Comments = wsModel.Comments,
                CommentVisible = wsModel.CommentVisible,
                Content = wsModel.Content,
                Identifier = wsModel.Id,
                MaxScore = wsModel.MaxScore != null ? wsModel.MaxScore.ToString() : String.Empty,
                Score = wsModel.Score != null ? wsModel.Score.ToString() : String.Empty,
                ScoreVisible = wsModel.ScoreVisible,
                StandardCommentsGroupIds = wsModel.StandardCommentsGroupIds,
                Status = WSChecklistItemStatus.ToEntityModel(wsModel.Status),
                StatusGroup = WSChecklistItemStatusGroup.ToEntityModel(wsModel.StatusGroup),
                StatusVisible = wsModel.StatusVisible
            };

            return result;
        }

        /// <summary>
        /// Froms the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>the entity model.</returns>
        public static WSChecklistItem FromEntityModel(ChecklistItemModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSChecklistItem()
            {
                EntityState = WSEntityState.ConvertEntityStateToAction(entityModel.Action),
                Comments = entityModel.Comments,
                CommentVisible = entityModel.CommentVisible,
                Content = entityModel.Content,
                Id = entityModel.Identifier,
                MaxScore = !String.IsNullOrWhiteSpace(entityModel.MaxScore) ? Convert.ToDouble(entityModel.MaxScore, NumberFormatInfo.InvariantInfo) : (double?)null,
                Score = !String.IsNullOrWhiteSpace(entityModel.Score) ? Convert.ToDouble(entityModel.Score, NumberFormatInfo.InvariantInfo) : (double?)null,
                ScoreVisible = entityModel.ScoreVisible,
                StandardCommentsGroupIds = entityModel.StandardCommentsGroupIds,
                Status = WSChecklistItemStatus.FromEntityModel(entityModel.Status),
                StatusGroup = WSChecklistItemStatusGroup.FromEntityModel(entityModel.StatusGroup),
                StatusVisible = entityModel.StatusVisible
            };

            return result;
        }
    }
}
