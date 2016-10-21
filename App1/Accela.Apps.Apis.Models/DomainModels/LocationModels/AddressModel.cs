using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.LocationModels
{
    [DataContract]
    public class AddressModel : LocationBaseModel
    {
        /// <summary>
        /// Gets or sets the record Id.
        /// </summary>
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the record Id.
        /// </summary>
        [DataMember(Name = "unit", EmitDefaultValue = false)]
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets the record Id.
        /// </summary>
        [DataMember(Name = "houseNumber", EmitDefaultValue = false)]
        public string HouseNumber { get; set; }

        /// <summary>
        /// Gets or sets the record Id.
        /// </summary>
        [DataMember(Name = "unitType", EmitDefaultValue = false)]
        public string UnitType { get; set; }

        /// <summary>
        /// Gets or sets the record Id.
        /// </summary>
        [DataMember(Name = "city", EmitDefaultValue = false)]   
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the record Id.
        /// </summary>
        [DataMember(Name = "houseNumberFraction", EmitDefaultValue = false)]
        public string HouseNumberFraction { get; set; }

        /// <summary>
        /// Gets or sets the record Id.
        /// </summary>
        [DataMember(Name = "streetName", EmitDefaultValue = false)]
        public string StreetName { get; set; }

        /// <summary>
        /// Gets or sets the record Id.
        /// </summary>
        [DataMember(Name = "streetSuffix", EmitDefaultValue = false)]
        public string StreetSuffix { get; set; }

        /// <summary>
        /// Gets or sets the record Id.
        /// </summary>
        [DataMember(Name = "streetSuffixDirection", EmitDefaultValue = false)]
        public string StreetSuffixDirection { get; set; }

        /// <summary>
        /// Gets or sets the record Id.
        /// </summary>
        [DataMember(Name = "postalCode", EmitDefaultValue = false)]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the record Id.
        /// </summary>
        [DataMember(Name = "directions", EmitDefaultValue = false)]
        public string Directions { get; set; }

        /// <summary>
        /// Gets or sets the record Id.
        /// </summary>
        [DataMember(Name = "streetDirection", EmitDefaultValue = false)]
        public string StreetDirection { get; set; }

        /// <summary>
        /// Gets or sets the record Id.
        /// </summary>
        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the record Id.
        /// </summary>
        [DataMember(Name = "isPrimary", EmitDefaultValue = false)]
        public string IsPrimary { get; set; }

        /// <summary>
        /// Gets or sets the record Id.
        /// </summary>
        [DataMember(Name = "county", EmitDefaultValue = false)]
        public string County { get; set; }

        /// <summary>
        /// Gets or sets the record Id.
        /// </summary>
        [DataMember(Name = "country", EmitDefaultValue = false)]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the record Id.
        /// </summary>
        [DataMember(Name = "addressFormat", EmitDefaultValue = false)]
        public string AddressFormat { get; set; }
    }
}
