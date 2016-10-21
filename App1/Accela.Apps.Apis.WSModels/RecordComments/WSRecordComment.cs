using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.WSModels.RecordComments
{
    [DataContract]
    public class WSRecordComment : WSEntityState
    {
        /// <summary>
        /// Gets or Sets the Key.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets the UserID.
        /// </summary>
        [DataMember(Name = "userId", EmitDefaultValue = false)]
        public string UserID { get; set; }

        /// <summary>
        /// Gets or Sets the display.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        /// <summary>
        /// Gets or Sets the Comments.
        /// </summary>
        [DataMember(Name = "comments", EmitDefaultValue = false)]
        public string Comments { get; set; }

        /// <summary>
        /// Gets or Sets the Date.
        /// </summary>
        [DataMember(Name = "date", EmitDefaultValue = false)]
        public string Date { get; set; }

        /// <summary>
        /// Gets or Sets the ShowOnInspection.
        /// </summary>
        [DataMember(Name = "showOnInspection", EmitDefaultValue = false)]
        public bool? ShowOnInspection { get; set; }
         
        /// <summary>
        /// Convert RecordCommnetModel to WSRecordComment.
        /// </summary>
        /// <param name="contactModel">RecordCommnetModel.</param>
        /// <returns>WSRecordComment.</returns>
        public static List<WSRecordComment> FromEntityModels(List<RecordCommentModel> recordCommentModels)
        {
            List<WSRecordComment> retu = null;
            if (recordCommentModels != null)
            {
                retu = new List<WSRecordComment>();
                foreach (var item in recordCommentModels)
                {
                    retu.Add(FromEntityModel(item));
                }
            }

            return retu;
        }

        /// <summary>
        /// Convert WSRecordComment to RecordCommnetModel.
        /// </summary>
        /// <param name="wsContact">WSRecordComment.</param>
        /// <returns>RecordCommnetModel.</returns>
        public static WSRecordComment FromEntityModel(RecordCommentModel recordCommentModel)
        {
            if (recordCommentModel != null)
            {
                return new WSRecordComment()
                {
                    Id = recordCommentModel.Id,
                    UserID = recordCommentModel.UserId,
                    Display = recordCommentModel.Display,
                    Comments = recordCommentModel.Comments,
                    Date = recordCommentModel.Date,
                    ShowOnInspection = recordCommentModel.ShowOnInspection,
                    EntityState = ConvertActionToEntityState(recordCommentModel.Action)
                };
            }
            return null;
        }

        public static RecordCommentModel ToEntityModel(WSRecordComment wsRecordComment)
        {
            if (wsRecordComment != null)
            {
                return new RecordCommentModel()
                {
                    Id = wsRecordComment.Id,
                    UserId = wsRecordComment.UserID,
                    Display = wsRecordComment.Display,
                    Comments = wsRecordComment.Comments,
                    Date = wsRecordComment.Date,
                    ShowOnInspection = wsRecordComment.ShowOnInspection,
                    Action = WSEntityState.ConvertEntityStateToAction(wsRecordComment.EntityState)
                };
            }
            return null;
        }
    }
}
