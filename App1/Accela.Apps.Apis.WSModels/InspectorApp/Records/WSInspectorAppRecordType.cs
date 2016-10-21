using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp.Records
{
    [DataContract(Name = "recordType")]
    public class WSInspectorAppRecordType : WSDataModel
    {
        /// <summary>
        /// Gets or sets the record Id.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the record display.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        /// <summary>
        /// Gets or sets the module.
        /// </summary>
        /// <value>
        /// The module.
        /// </value>
        [DataMember(Name = "module", EmitDefaultValue = false)]
        public string Module { get; set; }

        /// <summary>
        /// group display value
        /// </summary>
        [DataMember(Name = "group", EmitDefaultValue = false)]
        public string Group { get; set; }

        /// <summary>
        /// sub group display value
        /// </summary>
        [DataMember(Name = "subGroup", EmitDefaultValue = false)]
        public string SubGroup { get; set; }

        /// <summary>
        /// category display value
        /// </summary>
        [DataMember(Name = "category", EmitDefaultValue = false)]
        public string Category { get; set; }

        /// <summary>
        /// type display value
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        [DataMember(Name = "security", EmitDefaultValue = false)]
        public string Security { get; set; }

        [DataMember(Name = "inspectionGroups", EmitDefaultValue = false)]
        public List<string> InspectionGroups { get; set; }

        [DataMember(Name = "standardCommentsGroupIds", EmitDefaultValue = false)]
        public List<string> StandardCommentsGroupIds { get; set; }

        /// <summary>
        /// Toes the entity model.
        /// </summary>
        /// <param name="wsModel">The ws model.</param>
        /// <returns>the entity model.</returns>
        public static RecordTypeModel ToEntityModel(WSInspectorAppRecordType wsModel)
        {
            if (wsModel == null)
            {
                return null;
            }

            var result = new RecordTypeModel()
            {
                Identifier = wsModel.Id,
                Display = wsModel.Display,
                Module = wsModel.Module,
                Group = wsModel.Group,
                SubGroup = wsModel.SubGroup,
                Category = wsModel.Category,
                Type = wsModel.Type,
                Security = wsModel.Security,
                InspectionGroups = wsModel.InspectionGroups,
                StandardCommentsGroupIds = wsModel.StandardCommentsGroupIds
            };

            return result;
        }

        /// <summary>
        /// From the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>the entity model.</returns>
        public static WSInspectorAppRecordType FromEntityModel(RecordTypeModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSInspectorAppRecordType()
            {
                Id = entityModel.Identifier,
                Display = entityModel.Display,
                Module = entityModel.Module,
                Group = entityModel.Group,
                SubGroup = entityModel.SubGroup,
                Category = entityModel.Category,
                Type = entityModel.Type,
                Security = entityModel.Security,
                InspectionGroups = entityModel.InspectionGroups,
                StandardCommentsGroupIds = entityModel.StandardCommentsGroupIds
            };

            return result;
        }

        /// <summary>
        /// Toes the entity models.
        /// </summary>
        /// <param name="wsModels">The ws models.</param>
        /// <returns>the entity models.</returns>
        public static RecordTypeModel[] ToEntityModels(WSInspectorAppRecordType[] wsModels)
        {
            if (wsModels == null)
            {
                return null;
            }

            var result = wsModels.Select(m => ToEntityModel(m)).ToArray();
            return result;
        }

        /// <summary>
        /// From the entity models.
        /// </summary>
        /// <param name="entityModels">The entity models.</param>
        /// <returns>the entity models.</returns>
        public static WSInspectorAppRecordType[] FromEntityModels(RecordTypeModel[] entityModels)
        {
            if (entityModels == null)
            {
                return null;
            }

            var result = entityModels.Select(m => FromEntityModel(m)).ToArray();
            return result;
        }
    }
}
