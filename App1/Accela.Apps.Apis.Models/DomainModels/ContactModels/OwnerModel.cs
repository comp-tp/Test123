using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.Models.DomainModels.ContactModels
{
    [DataContract]
    public class OwnerModel : ActionDataModel
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

        [DataMember(Name = "isPrimary", EmitDefaultValue = false)]
        public string IsPrimary { get; set; }

        [DataMember(Name = "address", EmitDefaultValue = false)]
        public AddressModel Address { get; set; }

        [DataMember(Name = "mailingAddress", EmitDefaultValue = false)]
        public AddressModel MailingAddress { get; set; }
    }
}
