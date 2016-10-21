using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Requests.InspectionRequests;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract(Name = "scheduleInspectionRequest")]
    public class WSScheduleInspectionRequest
    {
        /// <summary>
        /// Gets or sets the inspection.
        /// </summary>
        /// <value>
        /// The inspection.
        /// </value>
        [DataMember(Name = "scheduleInspection", EmitDefaultValue = false)]
        public WSScheduleInspection Inspection
        {
            get;
            set;
        }

        /// <summary>
        /// Toes the entity models.
        /// </summary>
        /// <param name="wsModel">The ws model.</param>
        /// <returns>the entity models.</returns>
        public static CreateInspectionRequest ToEntityModels(WSScheduleInspectionRequest wsModel)
        {
            if (wsModel == null)
            {
                return null;
            }

            var result = new CreateInspectionRequest()
            {
                Inspection = WSScheduleInspection.ToEntityModel(wsModel.Inspection)
            };

            return result;
        }
    }
}
