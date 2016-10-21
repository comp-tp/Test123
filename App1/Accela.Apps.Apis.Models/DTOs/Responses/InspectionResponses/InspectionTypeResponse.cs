using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses
{
    /// <summary>
    /// Inspection type response
    /// </summary>
    [DataContract(Name = "GetInspectionTypeResponse")]
    public class InspectionTypeResponse : PagedResponse
    {
        /// <summary>
        /// Gets or sets the inspection types.
        /// </summary>
        /// <value>
        /// The inspection types.
        /// </value>
        [DataMember(Name = "inspectionTypes")]
        public List<InspectionTypeModel> InspectionTypes 
        { 
            get; 
            set; 
        }
    }
}
