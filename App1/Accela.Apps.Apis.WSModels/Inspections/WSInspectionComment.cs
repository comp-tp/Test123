using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.CommentModels;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract(Name = "inspectionComment")]
    public class WSInspectionComment : WSEntityState
    {
        /// <summary>
        /// Gets or sets the fill date.
        /// </summary>
        [DataMember(Name = "fillDate", EmitDefaultValue = false)]
        public string FillDate { get; set; }

        /// <summary>
        /// Gets or sets the fill people name.
        /// </summary>
        [DataMember(Name = "fillPeopleName", EmitDefaultValue = false)]
        public string FillPeopleName { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        [DataMember(Name = "content", EmitDefaultValue = false)]
        public string Content { get; set; }

        /// <summary>
        /// Toes the entity models.
        /// </summary>
        /// <param name="wsModels">The web service models.</param>
        /// <returns>the entity models.</returns>
        public static List<Comment> ToEntityModels(List<WSInspectionComment> wsModels)
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
        public static List<WSInspectionComment> FromEntityModels(List<Comment> entityModels)
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
        public static Comment ToEntityModel(WSInspectionComment wsModel)
        {
            if (wsModel == null)
            {
                return null;
            }

            var result = new Comment()
            {
                Action = WSEntityState.ConvertEntityStateToAction(wsModel.EntityState),
                Content = wsModel.Content,
                FillDate = wsModel.FillDate,
                FillPeopleName = wsModel.FillPeopleName
            };

            return result;
        }

        /// <summary>
        /// Froms the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>the entity model.</returns>
        public static WSInspectionComment FromEntityModel(Comment entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSInspectionComment()
            {
                Content = entityModel.Content,
                EntityState = WSEntityState.ConvertEntityStateToAction(entityModel.Action),
                FillDate = entityModel.FillDate,
                FillPeopleName = entityModel.FillPeopleName
            };

            return result;
        }
    }
}
