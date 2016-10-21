using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses
{
    /// <summary>
    /// inspection status response.
    /// </summary>
    [DataContract(Name = "getInspectionStatusResponse")]
    public class InspectionStatusResponse : PagedResponse
    {
        /// <summary>
        /// Gets or sets the inspection statuses.
        /// </summary>
        /// <value>
        /// The inspection statuses.
        /// </value>
        [DataMember(Name = "inspectionStatuses")]
        public List<InspectionStatusModel> InspectionStatuses 
        { 
            get; 
            set; 
        }
    }
}
