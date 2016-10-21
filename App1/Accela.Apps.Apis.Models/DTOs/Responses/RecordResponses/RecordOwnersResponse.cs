using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses
{
    [DataContract(Name = "getRecordOwnersResponse")]
    public class RecordOwnersResponse : ResponseBase
    {
        /// <summary>
        /// The record owner information.
        /// </summary>
        [DataMember(Name = "owners", EmitDefaultValue = false)]
        public List<OwnerModel> Owners { get; set; }
    }
}
