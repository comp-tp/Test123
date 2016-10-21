using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.Addresses
{
    [DataContract]
    public class WSAddressByCoordinates
    {
        [DataMember(Name = "addressFormat", EmitDefaultValue = false)]
        public string AddressFormat { get; set; }

        [DataMember(Name = "houseNumber", EmitDefaultValue = false)]
        public string HouseNumber { get; set; }

        [DataMember(Name = "houseNumberFraction", EmitDefaultValue = false)]
        public string HouseNumberFraction { get; set; }

        [DataMember(Name = "streetDirection", EmitDefaultValue = false)]
        public string StreetDirection { get; set; }

        [DataMember(Name = "streetPrefix", EmitDefaultValue = false)]
        public string StreetPrefix { get; set; }

        /// <summary>
        /// the value is the one of street address element, not inclue street number and other street element info.
        /// e.g. the vlaue is Crow Canyon in "11594 Crow Canyon Rd"
        /// </summary>
        [DataMember(Name = "street", EmitDefaultValue = false)]
        public string Street { get; set; }

        /// <summary>
        /// the field will be deprecated.
        /// current vlaue include street number, prefixDirection, prefixType, street name, street suffix type, and street suffix direction
        /// </summary>
        [DataMember(Name = "streetName", EmitDefaultValue = false)]
        public string StreetName { get; set; }

        [DataMember(Name = "streetSuffix", EmitDefaultValue = false)]
        public string StreetSuffix { get; set; }

        [DataMember(Name = "streetSuffixDirection", EmitDefaultValue = false)]
        public string StreetSuffixDirection { get; set; }

        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string State { get; set; }

        [DataMember(Name = "postalCode", EmitDefaultValue = false)]
        public string PostalCode { get; set; }

        [DataMember(Name = "city", EmitDefaultValue = false)]
        public string City { get; set; }

        [DataMember(Name = "country", EmitDefaultValue = false)]
        public string Country { get; set; }

        [DataMember(Name = "countryCode", EmitDefaultValue = false)]
        public string CountryCode { get; set; }

        [DataMember(Name = "stateAbbreviation", EmitDefaultValue = false)]
        public string StateAbbreviation { get; set; }
    }
}
