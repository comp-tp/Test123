using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Requests.InspectionRequests;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract(Name = "createInspectionRequest")]
    public class WSCreateInspectionRequest
    {
        /// <summary>
        /// Gets or sets the inspection.
        /// </summary>
        /// <value>
        /// The inspection.
        /// </value>
        [DataMember(Name = "createInspection")]
        public WSCreateInspection Inspection
        {
            get;
            set;
        }

        /// <summary>
        /// Toes the entity models.
        /// </summary>
        /// <param name="wsModel">The ws model.</param>
        /// <returns>the entity models.</returns>
        public static CreateInspectionRequest ToEntityModels(WSCreateInspectionRequest wsModel)
        {
            if (wsModel == null)
            {
                return null;
            }

            var result = new CreateInspectionRequest()
            {
                Inspection = WSCreateInspection.ToEntityModel(wsModel.Inspection)
            };

            return result;
        }
    }
}
