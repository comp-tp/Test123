using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.Contacts
{
    [DataContract(Name = "searchContactsRequest")]
    public class WSSearchContactsRequest
    {
        [DataMember(Name = "filter")]
        public WSSearchContactFilter Filter { get; set; }
    }

    [DataContract(Name = "filter")]
    public class WSSearchContactFilter
    {
        [DataMember(Name = "givenName", Order = 1)]
        public string GivenName { get; set; }

        [DataMember(Name = "middleNames", Order = 2)]
        public List<string> MiddleNames { get; set; }

        [DataMember(Name = "familyName", Order = 3)]
        public string FamilyName { get; set; }

        [DataMember(Name = "fullName", Order = 4)]
        public string FullName { get; set; }

        [DataMember(Name = "role", Order = 5)]
        public string Role { get; set; }

        [DataMember(Name = "businessName", Order = 6)]
        public string ContactBusinessName { get; set; }

        [DataMember(Name = "addressLines", Order = 7)]
        public List<string> AddressLines { get; set; }

        [DataMember(Name = "zip", Order = 8)]
        public string PostalCode { get; set; }

        [DataMember(Name = "city", Order = 9)]
        public string Town { get; set; }

        [DataMember(Name = "state", Order = 10)]
        public string Region { get; set; }

        [DataMember(Name = "telephoneNumbers", Order = 11)]
        public List<string> TelephoneNumbers { get; set; }

        [DataMember(Name = "faxNumber", Order = 12)]
        public List<string> FacsimileNumbers { get; set; }

        [DataMember(Name = "email", Order = 13)]
        public string ElectronicMailAddresses { get; set; }
    }
}
