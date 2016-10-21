using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract(Name = "checklist")]
    public class WSChecklist : WSEntityState
    {
        /// <summary>
        /// Gets or sets the checklist keys.
        /// It is primary keys for server side.
        /// if the property is null or empty, the mean the record is created by client and it didn't sync to server yet.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the checklist Subject.
        /// </summary>
        [DataMember(Name = "subject", EmitDefaultValue = false)]
        public string Subject { get; set; }

        /// <summary>
        /// The item is coresponse for id field in AMO
        /// </summary>
        [DataMember(Name = "label", EmitDefaultValue = false)]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the total score string.
        /// </summary>
        /// <value>
        /// The total score string.
        /// </value>
        [DataMember(Name = "totalScore", EmitDefaultValue = false)]
        public double? TotalScore { get; set; }

        /// <summary>
        /// Toes the entity models.
        /// </summary>
        /// <param name="wsModels">The web service models.</param>
        /// <returns>the entity models.</returns>
        public static List<ChecklistModel> ToEntityModels(List<WSChecklist> wsModels)
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
        public static List<WSChecklist> FromEntityModels(List<ChecklistModel> entityModels)
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
        public static ChecklistModel ToEntityModel(WSChecklist wsModel)
        {
            if (wsModel == null)
            {
                return null;
            }

            var result = new ChecklistModel()
            {
                Action = WSEntityState.ConvertEntityStateToAction(wsModel.EntityState),
                Identifier = wsModel.Id,
                Label = wsModel.Label,
                Subject = wsModel.Subject,
                TotalScore = wsModel.TotalScore != null ? wsModel.TotalScore.Value.ToString() : String.Empty
            };

            return result;
        }

        /// <summary>
        /// Froms the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>the entity model.</returns>
        public static WSChecklist FromEntityModel(ChecklistModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSChecklist()
            {
                EntityState = WSEntityState.ConvertEntityStateToAction(entityModel.Action),
                Id = entityModel.Identifier,
                Label = entityModel.Label,
                Subject = entityModel.Subject,
                TotalScore = !String.IsNullOrWhiteSpace(entityModel.TotalScore) ? Convert.ToDouble(entityModel.TotalScore, NumberFormatInfo.InvariantInfo) : (double?)null
            };

            return result;
        }
    }
}
