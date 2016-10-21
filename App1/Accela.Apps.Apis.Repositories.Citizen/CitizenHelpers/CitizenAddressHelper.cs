using System.Collections.Generic;
using Accela.ACA.WSProxy;
using Accela.Apps.Apis.Models.DTOs.Responses.AddressResponses;
using Accela.Apps.Shared.Utils;
using Accela.Automation.CitizenServices.Client.Models.Response.Record;

namespace Accela.Apps.Apis.Repositories.CitizenHelpers
{
    public class CitizenAddressHelper
    {
        private string _serviceProvCode;
        public CitizenAddressHelper(string serviceProvCode)
        {
            _serviceProvCode = serviceProvCode;
        }

        public static AddressesResponse ToEntityAddressesResponse(CitizenRecordAddressesResponse citizenResponse)
        {
            AddressesResponse response = null;

            if (citizenResponse != null)
            {
                response = new AddressesResponse();
                response.Addresses = ToEntityAddresses(citizenResponse.result);
            }

            return response;
        }

        public static List<Accela.Apps.Apis.Models.DomainModels.ReferenceModels.AddressModel> ToEntityAddresses(List<Accela.ACA.WSProxy.AddressModel> citizenObjs)
        {
            List<Accela.Apps.Apis.Models.DomainModels.ReferenceModels.AddressModel> entityContacts = null;

            if (citizenObjs != null)
            {
                entityContacts = new List<Accela.Apps.Apis.Models.DomainModels.ReferenceModels.AddressModel>();
                foreach (var citizenContact in citizenObjs)
                {
                    Accela.Apps.Apis.Models.DomainModels.ReferenceModels.AddressModel clientAddress = ToEnityAddress(citizenContact);
                    if (clientAddress != null)
                    {
                        entityContacts.Add(clientAddress);
                    }
                }
            }

            return entityContacts;
        }

        public Accela.ACA.WSProxy.AddressModel ToCitizenAddress(Accela.Apps.Apis.Models.DomainModels.ReferenceModels.AddressModel entityAddress)
        {
            Accela.ACA.WSProxy.AddressModel result = new Accela.ACA.WSProxy.AddressModel();

            if (entityAddress != null)
            {
                result.serviceProviderCode = _serviceProvCode;

                result.primaryFlag = entityAddress.IsPrimary.ToString();

                result.houseFractionStart = entityAddress.HouseNumberFraction;

                result.unitStart = entityAddress.Unit;
                result.unitEnd = entityAddress.UnitEnd;
                result.unitType = entityAddress.UnitType;

                result.streetDirection = entityAddress.StreetDirection;
                result.streetName = entityAddress.StreetName;
                result.streetSuffix = entityAddress.StreetSuffix;
                result.streetSuffixdirection = entityAddress.StreetSuffixDirection;

                result.city = entityAddress.City;
                result.state = entityAddress.State;
                result.zip = entityAddress.PostalCode;
                result.country = entityAddress.Country;
                result.county = entityAddress.County;

                result.unitStart = entityAddress.Unit;
                result.unitEnd = entityAddress.UnitEnd;
                result.unitType = entityAddress.UnitType;

                try
                {
                    result.xcoordinator = double.Parse(entityAddress.XCoordinate);
                }
                catch
                {
                    result.xcoordinator = null;
                }

                try
                {
                    result.ycoordinator = double.Parse(entityAddress.YCoordinate);
                }
                catch
                {
                    result.ycoordinator = null;
                }

                try
                {
                    result.houseNumberStart = int.Parse(entityAddress.HouseNumber);
                }
                catch
                {
                    //don't need throw exception in here. 
                }
            }

            return result;
        }

        public static List<Accela.Apps.Apis.Models.DomainModels.ReferenceModels.AddressModel> ToEnityAddresses(List<Accela.ACA.WSProxy.AddressModel> citizenAddresses)
        {
            List<Accela.Apps.Apis.Models.DomainModels.ReferenceModels.AddressModel> addresses = new List<Accela.Apps.Apis.Models.DomainModels.ReferenceModels.AddressModel>();
            if (citizenAddresses != null && citizenAddresses.Count > 0)
            {
                citizenAddresses.ForEach(addr => addresses.Add(ToEnityAddress(addr)));
            }
            return addresses;
        }

        public static Accela.Apps.Apis.Models.DomainModels.ReferenceModels.AddressModel ToEnityAddress(Accela.ACA.WSProxy.AddressModel citizenAddress)
        {
            Accela.Apps.Apis.Models.DomainModels.ReferenceModels.AddressModel result = new Accela.Apps.Apis.Models.DomainModels.ReferenceModels.AddressModel();

            if (citizenAddress != null)
            {
                result.IsPrimary = BoolHelper.IsTrueString(citizenAddress.primaryFlag);

                result.HouseNumberFraction = citizenAddress.houseFractionStart;

                result.Unit = citizenAddress.unitStart;
                result.UnitEnd = citizenAddress.unitEnd;
                result.UnitType = citizenAddress.unitType;

                result.StreetDirection = citizenAddress.streetDirection;
                result.StreetName = citizenAddress.streetName;
                result.StreetSuffix = citizenAddress.streetSuffix;
                result.StreetSuffixDirection = citizenAddress.streetSuffixdirection;

                result.City = citizenAddress.city;
                result.State = citizenAddress.state;
                result.PostalCode = citizenAddress.zip;
                result.Country = citizenAddress.country;
                result.County = citizenAddress.county;

                result.Unit = citizenAddress.unitStart;
                result.UnitEnd = citizenAddress.unitEnd;
                result.UnitType = citizenAddress.unitType;

                if (citizenAddress.xcoordinator != null)
                {
                    result.XCoordinate = citizenAddress.xcoordinator.ToString();
                }

                if (citizenAddress.ycoordinator != null)
                {
                    result.YCoordinate = citizenAddress.ycoordinator.ToString();
                }

                if (citizenAddress.houseNumberStart != null)
                {
                    result.HouseNumber = citizenAddress.houseNumberStart.ToString();
                }

                result.Display = GetClientAddressStringBy(result);
            }

            return result;
        }

        public static Accela.Apps.Apis.Models.DomainModels.ReferenceModels.AddressModel ToEnityAddress(CompactAddressModel citizenObj)
        {
            Accela.Apps.Apis.Models.DomainModels.ReferenceModels.AddressModel entityObj = null;

            if (citizenObj != null)
            {
                entityObj = new Accela.Apps.Apis.Models.DomainModels.ReferenceModels.AddressModel();
                entityObj.State = citizenObj.state;
                entityObj.City = citizenObj.city;
                entityObj.AddressLine1 = citizenObj.addressLine1;
                entityObj.AddressLine2 = citizenObj.addressLine2;
                entityObj.AddressLine3 = citizenObj.addressLine3;
                entityObj.Country = citizenObj.countryCode;
                entityObj.PostalCode = citizenObj.countryZip;
                if (string.IsNullOrWhiteSpace(entityObj.PostalCode))
                {
                    entityObj.PostalCode = citizenObj.zip;
                }

                entityObj.Display = GetClientAddressStringBy(entityObj);
            }

            return entityObj;
        }

        public static CompactAddressModel4WS ToCitizenCompactAddress(Accela.Apps.Apis.Models.DomainModels.ReferenceModels.AddressModel entityAddress)
        {
            CompactAddressModel4WS result = new CompactAddressModel4WS();

            if (entityAddress != null)
            {
                result.city = entityAddress.City;
                result.state = entityAddress.State;
                result.zip = entityAddress.PostalCode;
                result.countryZip = entityAddress.Country;
                result.countryCode = entityAddress.Country;

                result.addressLine1 = entityAddress.AddressLine1;
                result.addressLine2 = entityAddress.AddressLine2;
                result.addressLine3 = entityAddress.AddressLine3;
            }

            return result;
        }

        public static string GetClientAddressStringBy(Accela.Apps.Apis.Models.DomainModels.ReferenceModels.AddressModel model)
        {
            string addrString = "";
            addrString = AddToAddress(addrString, model.AddressLine1, " ");
            addrString = AddToAddress(addrString, model.AddressLine2, " ");
            addrString = AddToAddress(addrString, model.AddressLine3, " ");
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

        private static string AddToAddress(string orignalString, string newPart, string splitSymbol)
        {
            string result = orignalString;
            if (newPart != null)
            {
                result = orignalString + splitSymbol + newPart.Trim();
            }

            return result.Trim();
        }
    }
}
