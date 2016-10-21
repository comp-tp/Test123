using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;


namespace Accela.Apps.Apis.WSModels.RecordContacts
{
    [DataContract(Name = "getRecordContactsResponse")]
    public class WSRecordContactsResponse : WSResponseBase
    {
        /// <summary>
        /// The record owner information.
        /// </summary>
        [DataMember(Name = "contacts", EmitDefaultValue = false)]
        public List<WSContact> Contacts { get; set; }

        /// <summary>
        /// Converts from the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>WSRecordContactsResponse.</returns>
        public static WSRecordContactsResponse FromEntityModel(RecordContactsResponse entityModel)
        {
            if (entityModel == null)
            {
                return new WSRecordContactsResponse()
                {
                };
            }

            var result = new WSRecordContactsResponse()
            {
                // filter licensed professionals.if contact.licenses is empty, it is contact ,not licensed professional.
                Contacts = entityModel.Contacts == null ? null : WSContact.FromEntityModels(entityModel.Contacts.Where(item => item.Licenses == null).ToList())
            };

            return result;
        }
    }
}
