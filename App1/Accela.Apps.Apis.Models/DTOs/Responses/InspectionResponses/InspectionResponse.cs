using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses
{
    /// <summary>
    /// Inspection response
    /// </summary>
    [DataContract(Name = "GetInspectionResponse")]
    public class InspectionResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the inspection.
        /// </summary>
        /// <value>
        /// The inspection.
        /// </value>
        [DataMember(Name = "inspection")]
        public InspectionModel Inspection
        {
            get;
            set;
        }
    }
}
