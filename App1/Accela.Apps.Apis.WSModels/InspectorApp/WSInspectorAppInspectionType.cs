using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppInspectionType : WSIdentifierBase
    {
        /// <summary>
        /// Gets or sets the inspection status group keys.
        /// </summary>
        [DataMember(Name = "statusList", EmitDefaultValue = false)]
        public List<WSInspectorAppInspectionStatus> StatusList { get; set; }

        /// <summary>
        /// Gets or sets the standard comments group ids.
        /// </summary>
        /// <value>
        /// The standard comments group ids.
        /// </value>
        [DataMember(Name = "standardCommentsGroupIds", EmitDefaultValue = false)]
        public string[] StandardCommentsGroupIds { get; set; }

        public static InspectionTypeModel ToEntityModel(WSInspectorAppInspectionType model)
        {
            InspectionTypeModel result = null;

            if (model != null)
            {
                result = new InspectionTypeModel()
                {
                    Identifier = model.Id,
                    Display = model.Display,
                    StandardCommentsGroupIds = model.StandardCommentsGroupIds,
                    StatusList = WSInspectorAppInspectionStatus.ToEntityModels(model.StatusList)
                };
            }

            return result;
        }

        public static List<InspectionTypeModel> ToEntityModels(List<WSInspectorAppInspectionType> models)
        {
            List<InspectionTypeModel> result = null;

            if (models != null && models.Count > 0)
            {
                result = new List<InspectionTypeModel>();
                foreach (var m in models)
                {
                    var entityModel = ToEntityModel(m);
                    result.Add(entityModel);
                }
            }

            return result;
        }

        public static WSInspectorAppInspectionType FromEntityModel(InspectionTypeModel model)
        {
            WSInspectorAppInspectionType result = null;

            if (model != null)
            {
                result = new WSInspectorAppInspectionType()
                {
                    Id = model.Identifier,
                    Display = model.Display,
                    StandardCommentsGroupIds = model.StandardCommentsGroupIds,
                    StatusList = WSInspectorAppInspectionStatus.FromEntityModels(model.StatusList)
                };
            }

            return result;
        }

        public static List<WSInspectorAppInspectionType> FromEntityModels(List<InspectionTypeModel> models)
        {
            List<WSInspectorAppInspectionType> result = null;

            if (models != null && models.Count > 0)
            {
                result = new List<WSInspectorAppInspectionType>();
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
