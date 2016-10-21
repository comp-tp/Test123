using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Requests.InspectionRequests;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract(Name = "reassignInspectionRequest")]
    public class WSReassignInspectionRequest
    {
        /// <summary>
        /// Gets or sets the inspection.
        /// </summary>
        /// <value>
        /// The inspection.
        /// </value>
        [DataMember(Name = "reassignInspection", EmitDefaultValue = false)]
        public WSReassignInspection Inspection { get; set; }

        /// <summary>
        /// Toes the entity models.
        /// </summary>
        /// <param name="wsModel">The ws model.</param>
        /// <returns>the entity models.</returns>
        public static ReassignInspectionRequest ToEntityModels(WSReassignInspectionRequest wsModel)
        {
            if (wsModel == null)
            {
                return null;
            }

            var result = new ReassignInspectionRequest()
                             {
                                 Inspection = WSReassignInspection.ToEntityModel(wsModel.Inspection)
                             };

            return result;
        }
    }
}
