using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.InspectionModels
{
    [DataContract]
    public class DetailAddressModel : DataModel
    {        
        [DataMember(Name = "addressFormat")]
        public string AddressFormat;

        [DataMember(Name = "City")]
        public string City;

        [DataMember(Name = "Country")]
        public string Country;

        [DataMember(Name = "County")]
        public string County;

        [DataMember(Name = "houseNumber")]
        public string HouseNumber;

        [DataMember(Name = "houseNumberFraction")]
        public string HouseNumberFraction;

        [DataMember(Name = "id")]
        public string Id;

        [DataMember(Name = "PostalCode")]
        public string PostalCode;

        [DataMember(Name = "State")]
        public string State;

        [DataMember(Name = "streetDirection")]
        public string StreetDirection;

        [DataMember(Name = "streetName")]
        public string StreetName;

        [DataMember(Name = "streetSuffix")]
        public string StreetSuffix;

        [DataMember(Name = "streetSuffixDirection")]
        public string StreetSuffixDirection;

        [DataMember(Name = "unit")]
        public string Unit;

        [DataMember(Name = "unitEnd")]
        public string UnitEnd;

        [DataMember(Name = "unitType")]
        public string UnitType;

        [DataMember(Name = "urbanization")]
        public string Urbanization;

        [DataMember(Name = "XCoordinate")]
        public string XCoordinate;

        [DataMember(Name = "YCoordinate")]
        public string YCoordinate;

        [DataMember(Name = "isPrimary")]
        public bool? IsPrimary { get; set; }

        [DataMember(Name = "ReferenceAddressType")]
        public string RefAddressType { get; set; }
    }
}
