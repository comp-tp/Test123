using Accela.Apps.GeoServices.Geocode.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.GeoServices.Geocode.Helpers
{
    public static class ReverseGeocodeHelper
    {
        public static void UpdateDetailAddress(ReverseGeocodeAddress model)
        {
            if (model != null)
            {
                var addressParts = new string[] { model.Address, model.City, model.State, model.Zip, model.Country };
                addressParts = addressParts.Where(p => !String.IsNullOrWhiteSpace(p)).ToArray();
                var tempFullAddress = addressParts.Length > 0 ? String.Join(", ", addressParts) : null;
                model.DetailAddress = tempFullAddress != null ? tempFullAddress : model.DetailAddress;
            }
        }

        public static void UpdateStreetElements(ReverseGeocodeAddress model)
        {
            if (model != null)
            {
                var streetElements = new string[] { model.AddressBuilding, model.AddressNumber, model.AddressNumberFrom, model.AddressNumberTo, model.Side, model.StreetDirection, model.StreetName, model.StreetPrefixDirection, model.StreetPrefixType, model.StreetType };
                streetElements = streetElements.Where(p => !String.IsNullOrWhiteSpace(p)).ToArray();

                if ((streetElements == null || streetElements.Length == 0) && !String.IsNullOrWhiteSpace(model.Address))
                {

                }
            }
        }

        public static void UpdateAddressElements(string streetLine, ReverseGeocodeAddress target)
        {
            if (String.IsNullOrWhiteSpace(streetLine) || target == null)
            {
                return;
            }
            
            // split street address manually
            var parser = new UsaAddressParser();
            var parseResult = parser.Parse(streetLine);

            if (parseResult != null)
            {
                target.AddressNumber = parseResult.HouseNumber;
                target.StreetAddress = parseResult.StreetLine;
                target.StreetDirection = parseResult.StreetDirection;
                target.StreetName = parseResult.StreetName;
                target.StreetPrefixDirection = parseResult.StreetPrefixDirection;
                target.StreetType = parseResult.StreetType;
            }
        }

        public static void UpdateAddressElements(ArcGisMultiFieldGeocodingResponse source, ReverseGeocodeAddress target)
        {
            var candidate = source != null && source.candidates != null && source.candidates.Length > 0 ? source.candidates[0] : null;
            var attribute = candidate != null && candidate.attributes != null ? candidate.attributes : null;

            if (target != null && attribute != null)
            {
                target.Zip = !String.IsNullOrWhiteSpace(attribute.Postal) ? attribute.Postal : null;
                target.AddressBuilding = !String.IsNullOrWhiteSpace(attribute.AddBldg) ? attribute.AddBldg : null;
                target.AddressNumberFrom = !String.IsNullOrWhiteSpace(attribute.AddNumFrom) ? attribute.AddNumFrom : null;
                target.AddressNumber = !String.IsNullOrWhiteSpace(attribute.AddNum) ? attribute.AddNum : null;
                target.AddressNumberTo = !String.IsNullOrWhiteSpace(attribute.AddNumTo) ? attribute.AddNumTo : null;

                // handle address number
                if (String.IsNullOrWhiteSpace(target.AddressNumber)
                    && !String.IsNullOrWhiteSpace(target.AddressNumberFrom)
                    && !String.IsNullOrWhiteSpace(target.AddressNumberTo)
                    )
                {
                    var streetNumber = !String.IsNullOrWhiteSpace(attribute.Match_addr) ? attribute.Match_addr.Trim().Split(' ')[0] : null;
                    if (!String.IsNullOrWhiteSpace(streetNumber))
                    {
                        target.AddressNumber = !String.IsNullOrWhiteSpace(streetNumber) ? streetNumber : null;
                        target.AddressNumberFrom = null;
                        target.AddressNumberTo = null;
                    }
                }

                target.City = !String.IsNullOrWhiteSpace(attribute.City) ? attribute.City : null;
                target.CountryCode = !String.IsNullOrWhiteSpace(attribute.Country) ? attribute.Country : null;
                target.Country = AddressHelper.GetCountryDisplayName(target.CountryCode);
                target.DetailAddress = !String.IsNullOrWhiteSpace(attribute.Match_addr) ? attribute.Match_addr : null;
                target.Side = !String.IsNullOrWhiteSpace(attribute.Side) ? attribute.Side : null;
                target.State = !String.IsNullOrWhiteSpace(attribute.Region) ? attribute.Region : null;
                target.StreetAddress = !String.IsNullOrWhiteSpace(attribute.StAddr) ? attribute.StAddr : null;
                target.StreetDirection = !String.IsNullOrWhiteSpace(attribute.StDir) ? attribute.StDir : null;
                target.StreetName = !String.IsNullOrWhiteSpace(attribute.StName) ? attribute.StName : null;
                target.StreetPrefixDirection = !String.IsNullOrWhiteSpace(attribute.StPreDir) ? attribute.StPreDir : null;
                target.StreetPrefixType = !String.IsNullOrWhiteSpace(attribute.StPreType) ? attribute.StPreType : null;
                target.StreetType = !String.IsNullOrWhiteSpace(attribute.StType) ? attribute.StType : null;
            }
        }
    }
}
