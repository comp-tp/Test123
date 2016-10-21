using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.WSModels.Common;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;

namespace Accela.Apps.Apis.WSModels.Checklists
{
    [DataContract(Name = "checklistItem")]
    public class WSChecklistItem
    {
        [DataMember(Name = "id", Order = 1, EmitDefaultValue = false)]
        public string ID { get; set; }

        [DataMember(Name = "display", Order = 2, EmitDefaultValue = false)]
        public string Display { get; set; }

        [DataMember(Name = "content", Order = 3, EmitDefaultValue = false)]
        public string Content { get; set; }

        [DataMember(Name = "description", Order = 4, EmitDefaultValue = false)]
        public WSDescription Description { get; set; }

        [DataMember(Name = "status", Order = 5, EmitDefaultValue = false)]
        public WSChecklistItemStatus Status { get; set; }

        [DataMember(Name = "comments", Order = 6, EmitDefaultValue = false)]
        public string Comments { get; set; }

        [DataMember(Name = "maxScore", Order = 7, EmitDefaultValue = false)]
        public string MaxScore { get; set; }

        [DataMember(Name = "score", Order = 8, EmitDefaultValue = false)]
        public string Score { get; set; }

        [DataMember(Name = "defaultScore", Order = 9, EmitDefaultValue = false)]
        public string DefaultScore { get; set; }

        [DataMember(Name = "statusVisible", Order = 10, EmitDefaultValue = false)]
        public bool? StatusVisible { get; set; }

        [DataMember(Name = "commentVisible", Order = 11, EmitDefaultValue = false)]
        public bool? CommentVisible { get; set; }

        [DataMember(Name = "scoreVisible", Order = 12, EmitDefaultValue = false)]
        public bool? ScoreVisible { get; set; }

        [DataMember(Name = "statusGroup", Order = 13, EmitDefaultValue = false)]
        public WSChecklistItemStatusGroup StatusGroup { get; set; }

        public static WSChecklistItem FromEntityModel(ChecklistItemModel checklistItemModel)
        {
            WSChecklistItem wsChecklistItem = null;
            if (checklistItemModel != null)
            {
                wsChecklistItem = new WSChecklistItem();
                wsChecklistItem.ID = checklistItemModel.Identifier;
                wsChecklistItem.Display = checklistItemModel.Display;
                wsChecklistItem.Content = checklistItemModel.Content;
                wsChecklistItem.Description = WSDescription.FromEntityModel(checklistItemModel.Description);
                if (checklistItemModel.Status != null)
                {
                    wsChecklistItem.Status = new WSChecklistItemStatus();
                    wsChecklistItem.Status.ID = checklistItemModel.Status.Identifier;
                    wsChecklistItem.Status.Display = checklistItemModel.Status.Display;
                    wsChecklistItem.Status.Type = checklistItemModel.Status.Type;
                    wsChecklistItem.Status.DefaultScore = checklistItemModel.Status.DefaultScore;
                }
                wsChecklistItem.Comments = checklistItemModel.Comments;
                wsChecklistItem.MaxScore = checklistItemModel.MaxScore;
                wsChecklistItem.Score = checklistItemModel.Score;
                wsChecklistItem.DefaultScore = checklistItemModel.DefaultScore;
                wsChecklistItem.StatusVisible = checklistItemModel.StatusVisible;
                wsChecklistItem.CommentVisible = checklistItemModel.CommentVisible;
                wsChecklistItem.ScoreVisible = checklistItemModel.ScoreVisible;
                if (checklistItemModel.StatusGroup != null)
                {
                    wsChecklistItem.StatusGroup = new WSChecklistItemStatusGroup();
                    wsChecklistItem.StatusGroup.ID = checklistItemModel.StatusGroup.Identifier;
                    wsChecklistItem.StatusGroup.Display = checklistItemModel.StatusGroup.Display;
                    if (checklistItemModel.StatusGroup.ChecklistItemStatuses != null)
                    {
                        wsChecklistItem.StatusGroup.ChecklistItemStatuses = new List<WSChecklistItemStatus>();
                        foreach (var itemStatus in checklistItemModel.StatusGroup.ChecklistItemStatuses)
                        {
                            var wsItemStatus = new WSChecklistItemStatus()
                            {
                                ID = itemStatus.Identifier,
                                Display = itemStatus.Display,
                                Type = itemStatus.Type,
                                DefaultScore = itemStatus.DefaultScore
                            };

                            wsChecklistItem.StatusGroup.ChecklistItemStatuses.Add(wsItemStatus);
                        }
                    }
                }                
            }
            return wsChecklistItem;
        }

        public static List<WSChecklistItem> FromEntityModels(List<ChecklistItemModel> checklistItemModels)
        {
            List<WSChecklistItem> wsChecklistItems = null;
            if (checklistItemModels != null && checklistItemModels.Count > 0)
            { 
                wsChecklistItems = new List<WSChecklistItem>();
                foreach (var checklistModel in checklistItemModels)
                {
                    wsChecklistItems.Add(FromEntityModel(checklistModel));
                }
            }
            return wsChecklistItems;
        }
    }
}
