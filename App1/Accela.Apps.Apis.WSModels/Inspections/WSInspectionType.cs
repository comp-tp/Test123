using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract]
    public class WSInspectionType : WSIdentifierBase
    {
        /// <summary>
        /// Gets or sets the inspection status group keys.
        /// </summary>
        //[DataMember(Name = "statusList", EmitDefaultValue = false)]
        //public List<WSInspectionStatus> StatusList { get; set; }

        /// <summary>
        /// Gets or sets the standard comments group ids.
        /// </summary>
        /// <value>
        /// The standard comments group ids.
        /// </value>
        //[DataMember(Name = "standardCommentsGroupIds", EmitDefaultValue = false)]
        //public string[] StandardCommentsGroupIds { get; set; }

        public static InspectionTypeModel ToEntityModel(WSInspectionType wsModel)
        {
            if (wsModel != null)
            {
                return new InspectionTypeModel()
                {
                    Identifier = wsModel.Id,
                    Display = wsModel.Display,
                    //StatusList = WSInspectionStatus.ToEntityModels(wsModel.StatusList),
                    //StandardCommentsGroupIds = wsModel.StandardCommentsGroupIds
                };
            }
            return null;
        }

        public static WSInspectionType FromEntityModel(InspectionTypeModel inspectionTypeModel)
        {
            if (inspectionTypeModel != null)
            {
                return new WSInspectionType()
                {
                    Id = inspectionTypeModel.Identifier,
                    Display = inspectionTypeModel.Display,
                    //StatusList = WSInspectionStatus.FromEntityModels(inspectionTypeModel.StatusList),
                    //StandardCommentsGroupIds = inspectionTypeModel.StandardCommentsGroupIds
                };
            }
            return null;
        }
    }
}
