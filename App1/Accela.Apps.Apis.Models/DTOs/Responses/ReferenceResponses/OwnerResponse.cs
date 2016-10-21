using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses
{
    [DataContract(Name = "getOwnerResponse")]
    public class OwnerResponse : ResponseBase
    {
        /// <summary>
        /// The record owner information.
        /// </summary>
        [DataMember(Name = "owner", EmitDefaultValue = false)]
        public OwnerModel Owner { get; set; }
    }
}
