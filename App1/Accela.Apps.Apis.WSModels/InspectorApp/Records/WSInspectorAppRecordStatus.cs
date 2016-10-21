using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp.Records
{
    [DataContract(Name = "recordStatus")]
    public class WSInspectorAppRecordStatus : WSDataModel
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the display.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        /// <summary>
        /// Convert biz entity to response entity.
        /// </summary>
        /// <param name="recordStatus">Record status model.</param>
        /// <returns>WS record status model.</returns>
        public static WSInspectorAppRecordStatus FromEntityModel(RecordStatusModel recordStatus)
        {
            if (recordStatus != null)
            {
                return new WSInspectorAppRecordStatus()
                {
                    Id = recordStatus.Identifier,
                    Display = recordStatus.Display
                };
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wsRecordStatus"></param>
        /// <returns></returns>
        public static RecordStatusModel ToEntityModel(WSInspectorAppRecordStatus wsRecordStatus)
        {
            if (wsRecordStatus != null)
            {
                return new RecordStatusModel()
                {
                    Identifier = wsRecordStatus.Id,
                    Display = wsRecordStatus.Display
                };
            }

            return null;
        }

        public static RecordStatusModel ToEntityModel(string statusId)
        {
            if (!string.IsNullOrEmpty(statusId))
            {
                return new RecordStatusModel()
                {
                    Identifier = statusId
                };
            }
            return null;
        }

        /// <summary>
        /// Toes the entity models.
        /// </summary>
        /// <param name="wsModels">The ws models.</param>
        /// <returns>the entity models.</returns>
        public static List<RecordStatusModel> ToEntityModels(List<WSInspectorAppRecordStatus> wsModels)
        {
            if (wsModels == null)
            {
                return null;
            }

            var result = wsModels.Select(m => ToEntityModel(m)).ToList();
            return result;
        }

        /// <summary>
        /// From the entity models.
        /// </summary>
        /// <param name="entityModels">The entity models.</param>
        /// <returns>the entity models.</returns>
        public static List<WSInspectorAppRecordStatus> FromEntityModels(List<RecordStatusModel> entityModels)
        {
            if (entityModels == null)
            {
                return null;
            }

            var result = entityModels.Select(m => FromEntityModel(m)).ToList();
            return result;
        }
    }
}
