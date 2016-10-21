using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract(Name = "checklistItemStatus")]
    public class WSChecklistItemStatus : WSDataModel
    {
        /// <summary>
        /// Gets or sets the checklist item status id.
        /// </summary>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the checklist item status id display.
        /// </summary>
        [DataMember(Name = "display")]
        public string Display { get; set; }

        /// <summary>
        /// Gets or sets the inspection statustype.
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the default score string.
        /// </summary>
        /// <value>
        /// The default score string.
        /// </value>
        [DataMember(Name = "defaultScore")]
        public double? DefaultScore { get; set; }

        /// <summary>
        /// Toes the entity models.
        /// </summary>
        /// <param name="wsModels">The web service models.</param>
        /// <returns>the entity models.</returns>
        public static List<ChecklistItemStatus> ToEntityModels(List<WSChecklistItemStatus> wsModels)
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
        public static List<WSChecklistItemStatus> FromEntityModels(List<ChecklistItemStatus> entityModels)
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
        public static ChecklistItemStatus ToEntityModel(WSChecklistItemStatus wsModel)
        {
            if (wsModel == null)
            {
                return null;
            }

            var result = new ChecklistItemStatus()
            {
                DefaultScore = wsModel.DefaultScore.ToString(),
                Display = wsModel.Display,
                Identifier = wsModel.Id,
                Type = wsModel.Type
            };

            return result;
        }

        /// <summary>
        /// Froms the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>the entity model.</returns>
        public static WSChecklistItemStatus FromEntityModel(ChecklistItemStatus entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSChecklistItemStatus()
            {
                DefaultScore = !String.IsNullOrWhiteSpace(entityModel.DefaultScore) ? Convert.ToDouble(entityModel.DefaultScore, NumberFormatInfo.InvariantInfo) : (double?)null,
                Display = entityModel.Display,
                Id = entityModel.Identifier,
                Type = entityModel.Type
            };

            return result;
        }
    }
}
