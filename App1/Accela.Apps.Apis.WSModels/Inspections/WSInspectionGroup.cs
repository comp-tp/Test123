using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract(Name = "inspectionGroup")]
    public class WSInspectionGroup
    {
        /// <summary>
        /// gets or sets the disidentifierplay
        /// </summary> 
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        /// <summary>
        /// gets or sets the display
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        public static InspectionGroupModel ToEntityModel(WSInspectionGroup wsModel)
        {
            if (wsModel != null)
            {
                return new InspectionGroupModel()
                {
                    Identifier = wsModel.Identifier,
                    Display = wsModel.Display 
                };
            }
            return null;
        }

        public static WSInspectionGroup FromEntityModel(InspectionGroupModel inspectionGroupModel)
        {
            if (inspectionGroupModel != null)
            {
                return new WSInspectionGroup()
                {
                    Identifier = inspectionGroupModel.Identifier,
                    Display = inspectionGroupModel.Display
                };
            }
            return null;
        } 
    }
}
