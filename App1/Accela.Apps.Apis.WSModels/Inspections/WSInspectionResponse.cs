using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract]
    public class WSInspectionResponse : WSResponseBase
    {
        [DataMember(Name = "inspection")]
        public WSInspection Inspection { get; set; }

        /// <summary>
        /// Convert InspectionResponse to WSInspectionResponse.
        /// </summary>
        /// <param name="inspectionResponse">InspectionResponse.</param>
        /// <returns>WSInspectionResponse.</returns>
        public static WSInspectionResponse FromEntityModel(InspectionResponse inspectionResponse)
        {
            if (inspectionResponse != null)
            {
                return new WSInspectionResponse()
                {
                    Inspection = WSInspection.FromEntityModel(inspectionResponse.Inspection)
                };
            }
            return null;
        }
    }
}
