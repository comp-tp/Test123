using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Shared.FormatHelpers;

namespace Accela.Apps.Apis.Models.DomainModels.ReferenceModels
{
    [DataContract]
    public class AddressModel : ActionDataModel
    {
        private readonly Dictionary<string, string> _stateMapping = new Dictionary<string, string>
        {
            {"ALABAMA", "AL"},
            {"ALASKA", "AK"},
            {"AMERICAN SAMOA", "AS"},
            {"ARIZONA", "AZ"},
            {"ARKANSAS", "AR"},
            {"CALIFORNIA", "CA"},
            {"COLORADO", "CO"},
            {"CONNECTICUT", "CT"},
            {"DELAWARE", "DE"},
            {"DISTRICT OF COLUMBIA", "DC"},
            {"FEDERATED STATES OF MICRONESIA", "FM"},
            {"FLORIDA", "FL"},
            {"GEORGIA", "GA"},
            {"GUAM", "GU"},
            {"HAWAII", "HI"},
            {"IDAHO", "ID"},
            {"ILLINOIS", "IL"},
            {"INDIANA", "IN"},
            {"IOWA", "IA"},
            {"KANSAS", "KS"},
            {"KENTUCKY", "KY"},
            {"LOUISIANA", "LA"},
            {"MAINE", "ME"},
            {"MARSHALL ISLANDS", "MH"},
            {"MARYLAND", "MD"},
            {"MASSACHUSETTS", "MA"},
            {"MICHIGAN", "MI"},
            {"MINNESOTA", "MN"},
            {"MISSISSIPPI", "MS"},
            {"MISSOURI", "MO"},
            {"MONTANA", "MT"},
            {"NEBRASKA", "NE"},
            {"NEVADA", "NV"},
            {"NEW HAMPSHIRE", "NH"},
            {"NEW JERSEY", "NJ"},
            {"NEW MEXICO", "NM"},
            {"NEW YORK", "NY"},
            {"NORTH CAROLINA", "NC"},
            {"NORTH DAKOTA", "ND"},
            {"NORTHERN MARIANA ISLANDS", "MP"},
            {"OHIO", "OH"},
            {"OKLAHOMA", "OK"},
            {"OREGON", "OR"},
            {"PALAU", "PW"},
            {"PENNSYLVANIA", "PA"},
            {"PUERTO RICO", "PR"},
            {"RHODE ISLAND", "RI"},
            {"SOUTH CAROLINA", "SC"},
            {"SOUTH DAKOTA", "SD"},
            {"TENNESSEE", "TN"},
            {"TEXAS", "TX"},
            {"UTAH", "UT"},
            {"VERMONT", "VT"},
            {"VIRGIN ISLANDS", "VI"},
            {"VIRGINIA", "VA"},
            {"WASHINGTON", "WA"},
            {"WEST VIRGINIA", "WV"},
            {"WISCONSIN", "WI"},
            {"WYOMING", "WY"}
        };

        /// <summary>
        ///     Gets or sets the address Id.
        /// </summary>
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        /// <summary>
        ///     Gets or sets the address display.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        /// <summary>
        ///     This is address format
        /// </summary>
        [DataMember(Name = "addressFormat", EmitDefaultValue = false)]
        public string AddressFormat { get; set; }

        [DataMember(Name = "addressLine1", EmitDefaultValue = false)]
        public string AddressLine1 { get; set; }

        [DataMember(Name = "addressLine2", EmitDefaultValue = false)]
        public string AddressLine2 { get; set; }

        [DataMember(Name = "addressLine3", EmitDefaultValue = false)]
        public string AddressLine3 { get; set; }

        [DataMember(Name = "houseNumber", EmitDefaultValue = false)]
        public string HouseNumber { get; set; }

        [DataMember(Name = "houseNumberFraction", EmitDefaultValue = false)]
        public string HouseNumberFraction { get; set; }

        [DataMember(Name = "streetDirection", EmitDefaultValue = false)]
        public string StreetDirection { get; set; }

        /// <summary>
        ///     added date: 2013-07-16
        /// </summary>
        [DataMember(Name = "streetPrefix", EmitDefaultValue = false)]
        public string StreetPrefix { get; set; }

        /// <summary>
        ///     added date: 2013-07-18
        /// </summary>
        [DataMember(Name = "streetAddress", EmitDefaultValue = false)]
        public string StreetAddress { get; set; }

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

        /// <summary>
        ///     added date: 2013-07-16
        /// </summary>
        [DataMember(Name = "countryCode", EmitDefaultValue = false)]
        public string CountryCode { get; set; }

        [DataMember(Name = "isPrimary", EmitDefaultValue = false)]
        public bool? IsPrimary { get; set; }

        [DataMember(Name = "xCoordinate", EmitDefaultValue = false)]
        public string XCoordinate { get; set; }

        [DataMember(Name = "yCoordinate", EmitDefaultValue = false)]
        public string YCoordinate { get; set; }

        [DataMember(Name = "auditStatus", EmitDefaultValue = false)]
        public string AuditStatus { get; set; }

        [DataMember(Name = "stateAbbreviation", EmitDefaultValue = false)]
        public string StateAbbreviation
        {
            get
            {
                if (String.IsNullOrEmpty(State))
                {
                    return null;
                }

                var stateInUpper = State.ToUpper();

                // The value of state field is already in abbreviation form for some customize geocoding services.
                return _stateMapping.ContainsKey(stateInUpper) ? _stateMapping[stateInUpper] : (_stateMapping.ContainsValue(stateInUpper) ? stateInUpper : null);
            }
        }

        [DataMember(Name = "neighborhoodPrefix", EmitDefaultValue = false)]
        public string NeighberhoodPrefix;

        [DataMember(Name = "neighborhood", EmitDefaultValue = false)]
        public string Neighborhood;

        [DataMember(Name = "inspectionDistrictPrefix", EmitDefaultValue = false)]
        public string InspectionDistrictPrefix;

        [DataMember(Name = "inspectionDistrict", EmitDefaultValue = false)]
        public string InspectionDistrict;

        [DataMember(Name = "secondaryRoad", EmitDefaultValue = false)]
        public string SecondaryRoad;

        [DataMember(Name = "secondaryRoadNumber", EmitDefaultValue = false)]
        public string SecondaryRoadNumber;

        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string AddressDescription;

        [DataMember(Name = "distance", EmitDefaultValue = false)]
        public string Distance;

        public static string GetOneLineString(List<AddressModel> addressList)
        {
            string result = String.Empty;

            if (addressList != null && addressList.Count() > 0)
            {
                AddressModel address = addressList.Find(item => item.IsPrimary.HasValue && item.IsPrimary.Value);

                if (address == null)
                {
                    address = addressList.First();
                }

                result = ConvertToOneLineString(address);
            }

            return result;
        }

        public static string ConvertToOneLineString(AddressModel model)
        {
            string result = String.Empty;

            if (model != null)
            {
                result = AddressFormatter.ToOneLineString(
                    model.Display
                    , model.HouseNumber
                    , model.HouseNumberFraction
                    , null
                    , model.StreetName
                    , model.StreetSuffix
                    , model.StreetSuffixDirection
                    , model.UnitType
                    , model.Unit
                    , null
                    , model.City
                    , model.County
                    , model.State
                    , model.PostalCode
                    , model.Country);
            }

            return result;
        }
    }
}