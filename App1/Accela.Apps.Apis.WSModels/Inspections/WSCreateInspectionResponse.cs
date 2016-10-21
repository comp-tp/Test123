using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract(Name = "createInspectionResponse")]
    public class WSCreateInspectionResponse : WSResponseBase
    {
        /// <summary>
        /// Gets or sets the inspection.
        /// </summary>
        /// <value>
        /// The inspection.
        /// </value>
        [DataMember(Name = "inspection", EmitDefaultValue = false)]
        public WSInspection Inspection
        {
            get;
            set;
        }

        /// <summary>
        /// From the entity model.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>the WS model.</returns>
        public static WSCreateInspectionResponse FromEntityModel(CreateInspectionResponse response)
        {
            if (response == null)
            {
                return null;
            }

            var result = new WSCreateInspectionResponse()
            {
                Inspection = WSInspection.FromEntityModel(response.Inspection)
            };
           
            return result;
        }
    }
}
