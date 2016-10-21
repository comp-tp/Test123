using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses
{
    [DataContract(Name = "getRecordContactsResponse")]
    public class RecordContactsResponse : ResponseBase
    {
        /// <summary>
        /// The record owner information.
        /// </summary>
        [DataMember(Name = "contacts", EmitDefaultValue = false)]
        public List<ContactModel> Contacts { get; set; }
    }
}
