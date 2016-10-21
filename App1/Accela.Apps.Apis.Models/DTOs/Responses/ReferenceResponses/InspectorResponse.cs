using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses
{
    /// <summary>
    /// Inspector response
    /// </summary>
    [DataContract(Name = "getInspectorResponse")]
    public class InspectorResponse : PagedResponse
    {
        /// <summary>
        /// Gets or sets the inspectors.
        /// </summary>
        /// <value>
        /// The inspectors.
        /// </value>
        [DataMember(Name = "inspectors")]
        public List<InspectorModel> Inspectors
        {
            get;
            set;
        }
    }
}
