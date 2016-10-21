using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DTOs
{
    [DataContract]
    public class AddressCriteria
    {
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        [DataMember(Name = "addressFormat", EmitDefaultValue = false)]
        public string AddressFormat { get; set; }

        [DataMember(Name = "houseNumber", EmitDefaultValue = false)]
        public string HouseNumber { get; set; }

        [DataMember(Name = "houseNumberFraction", EmitDefaultValue = false)]
        public string HouseNumberFraction { get; set; }

        [DataMember(Name = "streetDirection", EmitDefaultValue = false)]
        public string StreetDirection { get; set; }

        [DataMember(Name = "streetName", EmitDefaultValue = false)]
        public string StreetName { get; set; }

        [DataMember(Name = "streetSuffix", EmitDefaultValue = false)]
        public string StreetSuffix { get; set; }

        [DataMember(Name = "streetSuffixDirection", EmitDefaultValue = false)]
        public string StreetSuffixDirection { get; set; }

        [DataMember(Name = "unit", EmitDefaultValue = false)]
        public string Unit { get; set; }

        [DataMember(Name = "unitEnd", EmitDefaultValue = false)]
        public string UnitEnd { get; set; }

        [DataMember(Name = "unitType", EmitDefaultValue = false)]
        public string UnitType { get; set; }

        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string State { get; set; }

        [DataMember(Name = "postalCode", EmitDefaultValue = false)]
        public string PostalCode { get; set; }

        [DataMember(Name = "city", EmitDefaultValue = false)]
        public string City { get; set; }

        [DataMember(Name = "county", EmitDefaultValue = false)]
        public string County { get; set; }

        [DataMember(Name = "country", EmitDefaultValue = false)]
        public string Country { get; set; }

        [DataMember(Name = "isPrimary", EmitDefaultValue = false)]
        public string IsPrimary { get; set; }

        [DataMember(Name = "xCoordinate", EmitDefaultValue = false)]
        public string XCoordinate { get; set; }

        [DataMember(Name = "yCoordinate", EmitDefaultValue = false)]
        public string YCoordinate { get; set; }

        [DataMember(Name = "includeDisabled", EmitDefaultValue = false)]
        public bool IncludeDisabled { get; set; }
    }
}
