using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.Models.DomainModels.ContactModels
{
    [DataContract]
    public class ContactModel : ActionDataModel
    {
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        [DataMember(Name = "personIdentifier", EmitDefaultValue = false)]
        public string PersonIdentifier { get; set; }

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

        [DataMember(Name = "telCountryCodes", EmitDefaultValue = false)]
        public List<string> TelCountryCodes { get; set; }

        [DataMember(Name = "countryCode", EmitDefaultValue = false)]
        public string CountryCode { get; set; }
        
        [DataMember(Name = "faxs", EmitDefaultValue = false)]
        public List<string> Faxs { get; set; }

        [DataMember(Name = "faxCountryCodes", EmitDefaultValue = false)]
        public List<string> FaxCountryCodes { get; set; }

        [DataMember(Name = "emails", EmitDefaultValue = false)]
        public List<string> Emails { get; set; }

        [DataMember(Name = "contactRole", EmitDefaultValue = false)]
        public ContactRoleModel ContactRole { get; set; }

        [DataMember(Name = "businessName", EmitDefaultValue = false)]
        public string BusinessName { get; set; }

        [DataMember(Name = "isPrimary", EmitDefaultValue = false)]
        public string IsPrimary { get; set; }

        /// <summary>
        /// added for owner's address, 2013-11-26
        /// </summary>
        [DataMember(Name = "address", EmitDefaultValue = false)]
        public AddressModel Address { get; set; }
      
        [DataMember(Name = "mailingAddress", EmitDefaultValue = false)]
        public AddressModel MailingAddress { get; set; }

        [DataMember(Name = "licenses", EmitDefaultValue = false)]
        public List<LicensedProfessional> Licenses { get; set; }
    }
}