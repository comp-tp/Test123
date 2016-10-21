using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;
using Accela.Apps.Apis.WSModels.Addresses;
using Accela.Apps.Apis.WSModels.RecordContacts;

namespace Accela.Apps.Apis.WSModels.Contacts
{
    [DataContract(Name="contact")]
    public class WSContact
    {        
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "personId", EmitDefaultValue = false)]
        public string PersonId { get; set; }

        [DataMember(Name = "familyName", EmitDefaultValue = false)]
        public string FamilyName { get; set; }

        [DataMember(Name = "givenName", EmitDefaultValue = false)]
        public string GivenName { get; set; }

        [DataMember(Name = "middleNames", EmitDefaultValue = false)]
        public List<string> MiddleNames { get; set; }

        [DataMember(Name = "fullName", EmitDefaultValue = false)]
        public string FullName { get; set; }

        [DataMember(Name = "tels", EmitDefaultValue = false)]
        public List<string> Tels { get; set; }

        [DataMember(Name = "faxs", EmitDefaultValue = false)]
        public List<string> Faxs { get; set; }

        [DataMember(Name = "emails", EmitDefaultValue = false)]
        public List<string> Emails { get; set; }

        [DataMember(Name = "contactRole", EmitDefaultValue = false)]
        public WSContactRole ContactRole { get; set; }

        [DataMember(Name = "businessName", EmitDefaultValue = false)]
        public string BusinessName { get; set; }

        [DataMember(Name = "isPrimary", EmitDefaultValue = false)]
        public string IsPrimary { get; set; }
        
        [DataMember(Name = "address", EmitDefaultValue = false)]
        public WSCompactAddress Address { get; set; }

        [DataMember(Name = "licenses", EmitDefaultValue = false)]
        public List<WSLicensedProfessional> Licenses { get; set; }

        public static List<WSContact> FromEntityModels(List<ContactModel> contactModels)
        {
            List<WSContact> retu = null;
            if (contactModels != null)
            {
                retu = new List<WSContact>();
                foreach (var item in contactModels)
                {
                    retu.Add(FromEntityModel(item));
                }
            }

            return retu;
        }

        /// <summary>
        /// Convert ContactModel to WSContact.
        /// </summary>
        /// <param name="contactModel">ContactModel.</param>
        /// <returns>WSContact.</returns>
        public static WSContact FromEntityModel(ContactModel contactModel)
        {
            if (contactModel != null)
            {
                return new WSContact()
                {
                    Id = contactModel.Identifier,
                    PersonId = contactModel.PersonIdentifier,
                    FamilyName = contactModel.FamilyName,
                    GivenName = contactModel.GivenName,
                    MiddleNames = contactModel.MiddleNames,
                    FullName = contactModel.FullName,
                    Tels = contactModel.Tels,
                    Faxs = contactModel.Faxs,
                    Emails = contactModel.Emails,
                    ContactRole = WSContactRole.FromEntityModel(contactModel.ContactRole),
                    BusinessName = contactModel.BusinessName,
                    IsPrimary = contactModel.IsPrimary,                    
                    Address = WSCompactAddress.FromEntityModel(contactModel.MailingAddress),
                    Licenses = WSLicensedProfessional.FromEntityModels(contactModel.Licenses)                   
                };
            }
            return null;
        }

        /// <summary>
        /// Convert WSContact to ContactModel.
        /// </summary>
        /// <param name="wsContact">WSContact.</param>
        /// <returns>ContactModel.</returns>
        public static ContactModel ToEnityModel(WSContact wsContact)
        {
            if (wsContact != null)
            {
                return new ContactModel()
                {
                    Identifier = wsContact.Id,
                    PersonIdentifier = wsContact.PersonId,
                    FamilyName = wsContact.FamilyName,
                    GivenName = wsContact.GivenName,
                    MiddleNames = wsContact.MiddleNames,
                    FullName = wsContact.FullName,
                    Tels = wsContact.Tels,
                    Faxs = wsContact.Faxs,
                    Emails = wsContact.Emails,
                    ContactRole = WSContactRole.ToEntityModel(wsContact.ContactRole),
                    BusinessName = wsContact.BusinessName,
                    IsPrimary = wsContact.IsPrimary,                    
                    MailingAddress = WSCompactAddress.ToEntityModel(wsContact.Address),
                    Licenses = WSLicensedProfessional.ToEntityModels(wsContact.Licenses)                    
                };
            }
            return null;
        }
    }
}
