using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Shared.Utils;
using Accela.Automation.GovXmlClient.Model;
using System;
using System.Collections.Generic;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    internal class AddressHelper : GovXmlHelperBase
    {
        public static Addresses ToXmlAddresses(List<AddressModel> clientAddresses)
        {
            Addresses retus = null;
            if (clientAddresses != null)
            {
                List<DetailAddress> xmlDetailAddress = new List<DetailAddress>();
                foreach (var item in clientAddresses)
                {
                    xmlDetailAddress.Add(AddressHelper.ToXmlAddress(item));
                }

                retus = new Addresses();
                retus.detailAddress = xmlDetailAddress.ToArray();
            }

            return retus;
        }

        public static AddressModel ToClientAddress(DetailAddress xmlAddress)
        {
            AddressModel clientAddress = null;
            if (xmlAddress != null)
            {
                clientAddress = new AddressModel
                {
                    Identifier = xmlAddress.keys.ToStringKeys(),
                    Display = GetClientAddressStringBy(xmlAddress),
                    AddressFormat = xmlAddress.addressFormat,
                    HouseNumber = xmlAddress.houseNumber,
                    HouseNumberFraction = xmlAddress.houseNumberFraction,
                    StreetDirection = xmlAddress.streetDirection,
                    StreetName = xmlAddress.streetName,
                    StreetSuffix = xmlAddress.streetSuffix,
                    StreetSuffixDirection = xmlAddress.streetSuffixDirection,
                    Unit = xmlAddress.unit,
                    UnitEnd = xmlAddress.unitEnd,
                    UnitType = xmlAddress.unitType,
                    State = xmlAddress.state,
                    PostalCode = xmlAddress.postalCode,
                    City = xmlAddress.city,
                    County = xmlAddress.county,
                    Country = xmlAddress.country,
                    IsPrimary = BoolHelper.GetBooleanByString(xmlAddress.IsPrimary),
                    XCoordinate = xmlAddress.xCoordinate,
                    YCoordinate = xmlAddress.yCoordinate,
                    AuditStatus = xmlAddress.auditStatus,
                    AddressLine1 = xmlAddress.addressLine1,
                    AddressLine2 = xmlAddress.addressLine2,
                    AddressLine3 = xmlAddress.addressLine3,
                    NeighberhoodPrefix = xmlAddress.neighberhoodPrefix,
                    Neighborhood = xmlAddress.neighborhood,
                    InspectionDistrictPrefix = xmlAddress.inspectionDistrictPrefix,
                    InspectionDistrict = xmlAddress.inspectionDistrict,
                    SecondaryRoadNumber = xmlAddress.secondaryRoadNumber,
                    SecondaryRoad = xmlAddress.secondaryRoad,
                    AddressDescription = xmlAddress.addressDescription,
                    Distance = xmlAddress.distance
                };
            }

            return clientAddress;
        }

        public static AddressModel ToClientAddress(CompactAddress xmlAddress)
        {
            AddressModel clientAddress = null;
            if (xmlAddress != null)
            {
                clientAddress = new AddressModel();
                clientAddress.Identifier = KeysHelper.ToStringKeys(xmlAddress.keys);
                clientAddress.Display = GetClientAddressStringBy(xmlAddress);

                if (xmlAddress.addressLines != null && xmlAddress.addressLines.str != null)
                {
                    if (xmlAddress.addressLines.str.Length > 0)
                    {
                        clientAddress.AddressLine1 = xmlAddress.addressLines.str[0];
                    }

                    if (xmlAddress.addressLines.str.Length > 1)
                    {
                        clientAddress.AddressLine2 = xmlAddress.addressLines.str[1];
                    }

                    if (xmlAddress.addressLines.str.Length > 2)
                    {
                        clientAddress.AddressLine3 = xmlAddress.addressLines.str[2];
                    }
                }

                clientAddress.State = xmlAddress.state;
                clientAddress.PostalCode = xmlAddress.postalCode;
                clientAddress.City = xmlAddress.city;   
            }

            return clientAddress;
        }

        public static AddressModel ToClientAddress(PostalAddress xmlAddress)
        {
            AddressModel clientAddress = null;
            if (xmlAddress != null)
            {
                clientAddress = new AddressModel();
                clientAddress.Identifier = null;
                clientAddress.Display = GetClientAddressStringBy(xmlAddress);
                if (xmlAddress.addressLines != null && xmlAddress.addressLines.str != null)
                {
                    if (xmlAddress.addressLines.str.Length > 0)
                    {
                        clientAddress.AddressLine1 = xmlAddress.addressLines.str[0];
                    }

                    if (xmlAddress.addressLines.str.Length > 1)
                    {
                        clientAddress.AddressLine2 = xmlAddress.addressLines.str[1];
                    }

                    if (xmlAddress.addressLines.str.Length > 2)
                    {
                        clientAddress.AddressLine3 = xmlAddress.addressLines.str[2];
                    }
                }

                clientAddress.State = xmlAddress.region;
                clientAddress.PostalCode = xmlAddress.postalCode;
                clientAddress.City = xmlAddress.town;
            }

            return clientAddress;
        }

        public static AddressModel ToClientAddress(OwnerAddress xmlAddress)
        {
            AddressModel clientAddress = null;
            if (xmlAddress != null)
            {
                clientAddress = new AddressModel();
                clientAddress.Identifier = null;
                clientAddress.Display = GetClientAddressStringBy(xmlAddress);
                if (xmlAddress.addressLines != null && xmlAddress.addressLines.str != null)
                {
                    if (xmlAddress.addressLines.str.Length > 0)
                    {
                        clientAddress.AddressLine1 = xmlAddress.addressLines.str[0];
                    }

                    if (xmlAddress.addressLines.str.Length > 1)
                    {
                        clientAddress.AddressLine2 = xmlAddress.addressLines.str[1];
                    }

                    if (xmlAddress.addressLines.str.Length > 2)
                    {
                        clientAddress.AddressLine3 = xmlAddress.addressLines.str[2];
                    }
                }

                clientAddress.State = xmlAddress.region;
                clientAddress.PostalCode = xmlAddress.postalCode;
                clientAddress.City = xmlAddress.town;
            }

            return clientAddress;
        }

        public static OwnerAddress ToXmlOwnerAddress(AddressModel clientAddress)
        {
            OwnerAddress xmlAddress = null;
            if (clientAddress != null)
            {
                xmlAddress = new OwnerAddress();
                xmlAddress.addressLines = new AddressLinesIFC();
                List<string> addressStr = new List<string>();
                if (!string.IsNullOrWhiteSpace(clientAddress.AddressLine1))
                {
                    addressStr.Add(clientAddress.AddressLine1);
                }

                if (!string.IsNullOrWhiteSpace(clientAddress.AddressLine2))
                {
                    addressStr.Add(clientAddress.AddressLine2);
                }

                if (!string.IsNullOrWhiteSpace(clientAddress.AddressLine3))
                {
                    addressStr.Add(clientAddress.AddressLine3);
                }

                xmlAddress.addressLines.str = addressStr.ToArray();
                xmlAddress.region = clientAddress.State;
                xmlAddress.postalCode = clientAddress.PostalCode;
                xmlAddress.town = clientAddress.City;
            }

            return xmlAddress;
        }

        public static PostalAddress ToXmlPostalAddress(AddressModel clientAddress)
        {
            PostalAddress xmlAddress = null;
            if (clientAddress != null)
            {
                xmlAddress = new PostalAddress();
                xmlAddress.addressLines = new AddressLinesIFC();
                List<string> addressStr = new List<string>();
                if (!string.IsNullOrWhiteSpace(clientAddress.AddressLine1))
                {
                    addressStr.Add(clientAddress.AddressLine1);
                }

                if (!string.IsNullOrWhiteSpace(clientAddress.AddressLine2))
                {
                    addressStr.Add(clientAddress.AddressLine2);
                }

                if (!string.IsNullOrWhiteSpace(clientAddress.AddressLine3))
                {
                    addressStr.Add(clientAddress.AddressLine3);
                }

                xmlAddress.addressLines.str = addressStr.ToArray();
                xmlAddress.region = clientAddress.State;
                xmlAddress.postalCode = clientAddress.PostalCode;
                xmlAddress.town = clientAddress.City;
            }

            return xmlAddress;
        }

        public static DetailAddress ToXmlAddress(AddressModel clientAddress)
        {
            DetailAddress xmlAddress = null;
            
            if (clientAddress != null)
            {
                xmlAddress = new DetailAddress();
                xmlAddress.action = CommonHelper.ToGovXmlAction(clientAddress.Action);

                if (!string.IsNullOrWhiteSpace(clientAddress.Identifier))
                {
                    xmlAddress.keys = KeysHelper.CreateXMLKeys(clientAddress.Identifier);
                }

                xmlAddress.addressFormat = clientAddress.AddressFormat;
                xmlAddress.houseNumber = clientAddress.HouseNumber;
                xmlAddress.houseNumberFraction = clientAddress.HouseNumberFraction;
                xmlAddress.streetDirection = clientAddress.StreetDirection;
                xmlAddress.streetName = clientAddress.StreetName;
                xmlAddress.streetSuffix = clientAddress.StreetSuffix;
                xmlAddress.streetSuffixDirection = clientAddress.StreetSuffixDirection;
                xmlAddress.unit = clientAddress.Unit;
                xmlAddress.unitType = clientAddress.UnitType;
                xmlAddress.unitEnd = clientAddress.UnitEnd;
                xmlAddress.state = clientAddress.State;
                xmlAddress.postalCode = clientAddress.PostalCode;
                xmlAddress.city = clientAddress.City;
                xmlAddress.county = clientAddress.County;
                xmlAddress.country = clientAddress.Country;
                xmlAddress.xCoordinate = clientAddress.XCoordinate;
                xmlAddress.yCoordinate = clientAddress.YCoordinate;

                xmlAddress.IsPrimary = BoolHelper.ToBoolString(clientAddress.IsPrimary, BoolHelper.BoolStringType.TrueOrFalse);

                xmlAddress.addressLine1 = clientAddress.AddressLine1;
                xmlAddress.addressLine2 = clientAddress.AddressLine2;
                xmlAddress.addressLine3 = clientAddress.AddressLine3;
                xmlAddress.neighberhoodPrefix = clientAddress.NeighberhoodPrefix;
                xmlAddress.neighborhood = clientAddress.Neighborhood;
                xmlAddress.inspectionDistrictPrefix = clientAddress.InspectionDistrictPrefix;
                xmlAddress.inspectionDistrict = clientAddress.InspectionDistrict;
                xmlAddress.secondaryRoadNumber = clientAddress.SecondaryRoadNumber;
                xmlAddress.secondaryRoad = clientAddress.SecondaryRoad;
                xmlAddress.addressDescription = clientAddress.AddressDescription;
                xmlAddress.distance = clientAddress.Distance;
            }
  
            return xmlAddress;
        }

        public static string GetClientAddressStringBy(CompactAddress xmlObj)
        {
            string addressString = "";
            if (xmlObj.addressLines != null && xmlObj.addressLines.str != null)
            {
                int count = xmlObj.addressLines.str.Length;

                for (int i = 0; i < count; i++)
                {
                    if (!string.IsNullOrEmpty(xmlObj.addressLines.str[i]) && !string.IsNullOrEmpty(addressString))
                    {
                        addressString = addressString + " " + xmlObj.addressLines.str[i];
                    }
                    else if (!string.IsNullOrEmpty(xmlObj.addressLines.str[i]))
                    {
                        addressString = xmlObj.addressLines.str[i];
                    }
                }

                if (!string.IsNullOrWhiteSpace(xmlObj.city) && addressString != null)
                {
                    if (!addressString.Contains(xmlObj.city.Trim()))
                    {
                        addressString = AddToAddress(addressString, xmlObj.city.Trim(), ", ");
                    }

                    if (!addressString.Contains(xmlObj.state.Trim()))
                    {
                        addressString = AddToAddress(addressString, xmlObj.state.Trim(), ", ");
                    }
                }
            }
            else
            {
                addressString = "";
            }

            return addressString;
        }

        public static string GetClientAddressStringBy(DetailAddress xmlObj)
        {
            string addrString = "";
            addrString = AddToAddress(addrString, xmlObj.houseNumber, " ");
            addrString = AddToAddress(addrString, xmlObj.houseNumberFraction, " ");
            addrString = AddToAddress(addrString, xmlObj.streetDirection, " ");
            addrString = AddToAddress(addrString, xmlObj.streetName, " ");
            addrString = AddToAddress(addrString, xmlObj.streetSuffix, " ");
            addrString = AddToAddress(addrString, xmlObj.streetSuffixDirection, " ");
            addrString = AddToAddress(addrString, xmlObj.unitType, " ");
            addrString = AddToAddress(addrString, xmlObj.unit, " ");
            addrString = AddToAddress(addrString, xmlObj.city, ", ");
            addrString = AddToAddress(addrString, xmlObj.county, ", ");
            addrString = AddToAddress(addrString, xmlObj.state, ", ");
            addrString = AddToAddress(addrString, xmlObj.postalCode, ", ");
            addrString = AddToAddress(addrString, xmlObj.country, ", ");
            return addrString.Trim();
        }

        public static Models.DomainModels.InspectionModels.DetailAddressModel GetDetailAddress(DetailAddress xmlObj)
        {
            Accela.Apps.Apis.Models.DomainModels.InspectionModels.DetailAddressModel detailAddress = null;
            if (xmlObj != null)
            {
                detailAddress = new Accela.Apps.Apis.Models.DomainModels.InspectionModels.DetailAddressModel();
                detailAddress.AddressFormat = xmlObj.addressFormat;
                detailAddress.City = xmlObj.city;
                detailAddress.Country = xmlObj.country;
                detailAddress.County = xmlObj.county;
                detailAddress.HouseNumber = xmlObj.houseNumber;
                detailAddress.HouseNumberFraction = xmlObj.houseNumberFraction;
                detailAddress.Id = KeysHelper.ToStringKeys(xmlObj.keys);
                detailAddress.IsPrimary = BoolHelper.GetBooleanByString(xmlObj.IsPrimary);
                detailAddress.PostalCode = xmlObj.postalCode;
                detailAddress.RefAddressType = xmlObj.RefAddressType;
                detailAddress.State = xmlObj.state;
                detailAddress.StreetDirection = xmlObj.streetDirection;
                detailAddress.StreetName = xmlObj.streetName;
                detailAddress.StreetSuffix = xmlObj.streetSuffix;
                detailAddress.StreetSuffixDirection = xmlObj.streetSuffixDirection;
                detailAddress.Unit = xmlObj.unit;
                detailAddress.UnitEnd = xmlObj.unitEnd;
                detailAddress.UnitType = xmlObj.unitType;
                detailAddress.Urbanization = xmlObj.urbanization;
                detailAddress.XCoordinate = xmlObj.xCoordinate;
                detailAddress.YCoordinate = xmlObj.yCoordinate;
                
            }
            return detailAddress;
        }

        public static Models.DomainModels.InspectionModels.DetailAddressModel GetDetailAddress(AddressModel model)
        {
            Accela.Apps.Apis.Models.DomainModels.InspectionModels.DetailAddressModel detailAddress = null;
            if (model != null)
            {
                detailAddress = new Accela.Apps.Apis.Models.DomainModels.InspectionModels.DetailAddressModel();
                detailAddress.AddressFormat = model.AddressFormat;
                detailAddress.City = model.City;
                detailAddress.Country = model.Country;
                detailAddress.County = model.County;
                detailAddress.HouseNumber = model.HouseNumber;
                detailAddress.HouseNumberFraction = model.HouseNumberFraction;
                detailAddress.Id = model.Identifier;
                detailAddress.IsPrimary = model.IsPrimary;
                detailAddress.PostalCode = model.PostalCode;
                detailAddress.State = model.State;
                detailAddress.StreetDirection = model.StreetDirection;
                detailAddress.StreetName = model.StreetName;
                detailAddress.StreetSuffix = model.StreetSuffix;
                detailAddress.StreetSuffixDirection = model.StreetSuffixDirection;
                detailAddress.Unit = model.Unit;
                detailAddress.UnitEnd = model.UnitEnd;
                detailAddress.UnitType = model.UnitType;
                detailAddress.XCoordinate = model.XCoordinate;
                detailAddress.YCoordinate = model.YCoordinate;
            }
            return detailAddress;
        }

        public static string GetClientAddressStringBy(AddressModel model)
        {
            string addrString = "";
            addrString = AddToAddress(addrString, model.HouseNumber, " ");
            addrString = AddToAddress(addrString, model.HouseNumberFraction, " ");
            addrString = AddToAddress(addrString, model.StreetDirection, " ");
            addrString = AddToAddress(addrString, model.StreetName, " ");
            addrString = AddToAddress(addrString, model.StreetSuffix, " ");
            addrString = AddToAddress(addrString, model.StreetSuffixDirection, " ");
            addrString = AddToAddress(addrString, model.UnitType, " ");
            addrString = AddToAddress(addrString, model.Unit, " ");
            addrString = AddToAddress(addrString, model.City, ", ");
            addrString = AddToAddress(addrString, model.County, ", ");
            addrString = AddToAddress(addrString, model.State, ", ");
            addrString = AddToAddress(addrString, model.PostalCode, ", ");
            addrString = AddToAddress(addrString, model.Country, ", ");
            return addrString.Trim();
        }

        public static string GetClientGeoAddressStringBy(DetailAddress xmlObj)
        {
            string addrString = "";
            addrString = AddToAddress(addrString, xmlObj.houseNumber, " ");
            addrString = AddToAddress(addrString, xmlObj.houseNumberFraction, " ");
            addrString = AddToAddress(addrString, xmlObj.streetDirection, " ");
            addrString = AddToAddress(addrString, xmlObj.streetName, " ");
            addrString = AddToAddress(addrString, xmlObj.streetSuffix, " ");
            addrString = AddToAddress(addrString, xmlObj.streetSuffixDirection, " ");
            addrString = AddToAddress(addrString, xmlObj.city, ", ");
            addrString = AddToAddress(addrString, xmlObj.state, ", ");
            addrString = AddToAddress(addrString, xmlObj.postalCode, ", ");
            addrString = AddToAddress(addrString, xmlObj.country, ", ");
            return addrString.Trim();
        }

        public static string GetClientGeoAddressStringBy(AddressModel model)
        {
            string addrString = "";
            addrString = AddToAddress(addrString, model.HouseNumber, " ");
            addrString = AddToAddress(addrString, model.HouseNumberFraction, " ");
            addrString = AddToAddress(addrString, model.StreetDirection, " ");
            addrString = AddToAddress(addrString, model.StreetName, " ");
            addrString = AddToAddress(addrString, model.StreetSuffix, " ");
            addrString = AddToAddress(addrString, model.StreetSuffixDirection, " ");
            addrString = AddToAddress(addrString, model.City, ", ");
            addrString = AddToAddress(addrString, model.State, ", ");
            addrString = AddToAddress(addrString, model.PostalCode, ", ");
            addrString = AddToAddress(addrString, model.Country, ", ");
            return addrString.Trim();
        }

        public static string GetClientAddressStringBy(PostalAddress xmlObj)
        {
            string addrString = "";
            if (xmlObj.addressLines != null && xmlObj.addressLines.str != null)
            {
                foreach (var item in xmlObj.addressLines.str)
                {
                    addrString = AddToAddress(addrString, item, " ");
                }
            }

            addrString = AddToAddress(addrString, xmlObj.town, ", ");
            addrString = AddToAddress(addrString, xmlObj.region, ", ");
            addrString = AddToAddress(addrString, xmlObj.postalCode, ", ");
 
            return addrString.Trim();
        }

        public static string GetClientAddressStringBy(OwnerAddress xmlObj)
        {
            string addrString = "";
            if (xmlObj.addressLines != null && xmlObj.addressLines.str != null)
            {
                foreach (var item in xmlObj.addressLines.str)
                {
                    addrString = AddToAddress(addrString, item, " ");
                }
            }

            addrString = AddToAddress(addrString, xmlObj.town, ", ");
            addrString = AddToAddress(addrString, xmlObj.region, ", ");
            addrString = AddToAddress(addrString, xmlObj.postalCode, ", ");

            return addrString.Trim();
        }

        private static string AddToAddress(string orignalString, string newPart, string splitSymbol)
        {
            string result = orignalString;
            if (newPart != null)
            {
                result = orignalString + splitSymbol + newPart.Trim();
            }

            return result.Trim();
        }

        public static Models.DTOs.Responses.AddressResponses.AddressesResponse GetClientAddresses(AddressesResponse xmlObj)
        {
            Accela.Apps.Apis.Models.DTOs.Responses.AddressResponses.AddressesResponse results = new Accela.Apps.Apis.Models.DTOs.Responses.AddressResponses.AddressesResponse();

            if (xmlObj.system != null)
            {
                results.Events = CommonHelper.GetClientEventMessage(xmlObj.system.eventMessages);
                results.PageInfo = CommonHelper.GetPaginationFromSystem(xmlObj.system);
            }

            if (xmlObj.addresses != null
                && xmlObj.addresses.detailAddress != null
                && xmlObj.addresses.detailAddress.Length > 0)
            {
                results.Addresses = new List<AddressModel>();

                foreach (var address in xmlObj.addresses.detailAddress)
                {
                    results.Addresses.Add(ToClientAddress(address));
                }
            }

            return results;
        }

        public static DetailAddress ToDetailAddress(AddressCriteria criteria)
        {
            if (criteria == null) return null;

            return new DetailAddress
            {
                keys = KeysHelper.CreateXMLKeys(criteria.Identifier),
                houseNumber = criteria.HouseNumber,
                houseNumberFraction = criteria.HouseNumberFraction,
                streetDirection = criteria.StreetDirection,
                streetName = criteria.StreetName,
                streetSuffix = criteria.StreetSuffix,
                streetSuffixDirection = criteria.StreetSuffixDirection,
                unit = criteria.Unit,
                unitEnd = criteria.UnitEnd,
                unitType = criteria.UnitType,
                city = criteria.City,
                state = criteria.State,
                postalCode = criteria.PostalCode,
                auditStatus = criteria.IncludeDisabled ? null : "A",
                IsPrimary = criteria.IsPrimary
            };
        }
    }
}
