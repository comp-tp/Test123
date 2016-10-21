using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.RecordComments
{
    [DataContract]
    public class WSA311RecordComment : WSEntityState
    {
        /// <summary>
        /// Gets or Sets the Key.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false, Order = 0)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets the display.
        /// </summary>
        //[DataMember(Name = "display", EmitDefaultValue = false)]
        //public string Display { get; set; }

        /// <summary>
        /// Gets or Sets the Comments.
        /// </summary>
        [DataMember(Name = "comment", EmitDefaultValue = false, Order = 1)]
        public string Comments { get; set; }

        /// <summary>
        /// Gets or Sets the UserID.
        /// </summary>
        [DataMember(Name = "createdBy", EmitDefaultValue = false, Order = 2)]
        public string UserID { get; set; }

        /// <summary>
        /// Gets or Sets the Date.
        /// </summary>
        [DataMember(Name = "createdDate", EmitDefaultValue = false, Order = 3)]
        public string Date { get; set; }

        /// <summary>
        /// Gets or Sets the ShowOnInspection.
        /// </summary>
        //[DataMember(Name = "showOnInspection", EmitDefaultValue = false)]
        //public bool? ShowOnInspection { get; set; }

        /// <summary>
        /// Convert RecordCommnetModel to WSA311RecordComment.
        /// </summary>
        /// <param name="contactModel">RecordCommnetModel.</param>
        /// <returns>WSA311RecordComment.</returns>
        public static List<WSA311RecordComment> FromEntityModels(List<RecordCommentModel> recordCommentModels)
        {
            List<WSA311RecordComment> retu = null;
            if (recordCommentModels != null)
            {
                retu = new List<WSA311RecordComment>();
                foreach (var item in recordCommentModels)
                {
                    retu.Add(FromEntityModel(item));
                }
            }

            return retu;
        }

        /// <summary>
        /// Convert WSA311RecordComment to RecordCommnetModel.
        /// </summary>
        /// <param name="wsContact">WSA311RecordComment.</param>
        /// <returns>RecordCommnetModel.</returns>
        public static WSA311RecordComment FromEntityModel(RecordCommentModel recordCommentModel)
        {
            if (recordCommentModel != null)
            {
                return new WSA311RecordComment()
                {
                    Id = recordCommentModel.Id,
                    UserID = recordCommentModel.UserId,
                    //Display = recordCommentModel.Display,
                    Comments = recordCommentModel.Comments,
                    Date = recordCommentModel.Date,
                    //ShowOnInspection = recordCommentModel.ShowOnInspection,
                    EntityState = ConvertActionToEntityState(recordCommentModel.Action)
                };
            }
            return null;
        }

        public static RecordCommentModel ToEntityModel(WSA311RecordComment wsRecordComment)
        {
            if (wsRecordComment != null)
            {
                return new RecordCommentModel()
                {
                    Id = wsRecordComment.Id,
                    UserId = wsRecordComment.UserID,
                    //Display = wsRecordComment.Display,
                    Comments = wsRecordComment.Comments,
                    Date = wsRecordComment.Date,
                    //ShowOnInspection = wsRecordComment.ShowOnInspection,
                    Action = WSEntityState.ConvertEntityStateToAction(wsRecordComment.EntityState)
                };
            }
            return null;
        }
    }
}
