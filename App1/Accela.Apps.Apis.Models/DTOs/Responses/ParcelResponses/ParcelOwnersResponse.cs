using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ParcelResponses
{
    /// <summary>
    /// Parcel Owners Response
    /// </summary>
    public class ParcelOwnersResponse : PagedResponse
    {
        /// <summary>
        /// The record owner information.
        /// </summary>
        [DataMember(Name = "owners", EmitDefaultValue = false)]
        public List<OwnerModel> Owners { get; set; }
    }
}
