using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Models.DTOs.Requests.ReferenceRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using Accela.Apps.GeoServices;
using Accela.Apps.Shared;
using Accela.Apps.Apis.Repositories.Interfaces.Admin;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Shared.Exceptions;
using Accela.Apps.Apis.BusinessEntities.GeoHelpers;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.GeoRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.GeoResponses;
using Accela.Core.Ioc;
using Accela.Apps.Shared.Contexts;

namespace Accela.Apps.Apis.BusinessEntities
{
    public class MapBusinessEntity : IMapBusinessEntity
    {
        public MapBusinessEntity()
        {
        }

        /// <summary>
        /// Get address by coordinate
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public GetAddressByCoordinateResponse GetAddressByCoordinate(GetAddressByCoordinateRequest request, IAgencyAppContext agencyContext)
        {
            var getAddressByCoordinateResponse = new GetAddressByCoordinateResponse();

            var geocodeRepository = IocContainer.Resolve<IGeocodeRepository>();
            var agencyName = agencyContext.Agency == (new UnKownAgencyAppContext()).Agency ? null : agencyContext.Agency;
            GeocodeHelper.InitGeocodeParameters(geocodeRepository, agencyName);

            var distance = request.Distance.HasValue ? request.Distance.Value : 100;
            var reverseGeocodeAddress = geocodeRepository.GetAddressesByCoordinate(request.Longitude, request.Latitude, distance, request.InSR);

            if (reverseGeocodeAddress != null)
            {
                getAddressByCoordinateResponse.Address = new AddressModel();
                getAddressByCoordinateResponse.Address.AddressFormat = reverseGeocodeAddress.DetailAddress;

                // set parsed address elements
                if (!String.IsNullOrWhiteSpace(reverseGeocodeAddress.AddressNumber))
                {
                    getAddressByCoordinateResponse.Address.HouseNumber = reverseGeocodeAddress.AddressNumber;
                }
                else if (!String.IsNullOrWhiteSpace(reverseGeocodeAddress.AddressNumberFrom)
                    && !String.IsNullOrWhiteSpace(reverseGeocodeAddress.AddressNumberTo)
                    )
                {
                    getAddressByCoordinateResponse.Address.HouseNumber = reverseGeocodeAddress.AddressNumberFrom;
                    getAddressByCoordinateResponse.Address.HouseNumberFraction = reverseGeocodeAddress.AddressNumberTo;
                }
                getAddressByCoordinateResponse.Address.StreetDirection = reverseGeocodeAddress.StreetPrefixDirection;
                getAddressByCoordinateResponse.Address.StreetPrefix = reverseGeocodeAddress.StreetPrefixType;
                getAddressByCoordinateResponse.Address.StreetName = reverseGeocodeAddress.StreetName;
                getAddressByCoordinateResponse.Address.StreetAddress = reverseGeocodeAddress.Address;
                getAddressByCoordinateResponse.Address.StreetSuffix = reverseGeocodeAddress.StreetType;
                getAddressByCoordinateResponse.Address.StreetSuffixDirection = reverseGeocodeAddress.StreetDirection;
                
                getAddressByCoordinateResponse.Address.City = reverseGeocodeAddress.City;
                getAddressByCoordinateResponse.Address.State = reverseGeocodeAddress.State;
                getAddressByCoordinateResponse.Address.PostalCode = reverseGeocodeAddress.Zip;
                getAddressByCoordinateResponse.Address.Country = reverseGeocodeAddress.Country;
                getAddressByCoordinateResponse.Address.CountryCode = reverseGeocodeAddress.CountryCode;
            }

            return getAddressByCoordinateResponse;
        }

        public GeoGetCoordinatesByAddressesResponse GetCoordinates(GeoGetCoordinatesByAddressesRequest request)
        {
            if (request == null)
            {
                return null;
            }

            var coordinateRepository = IocContainer.Resolve<ICoordinateRepository>();
            var tempResult = coordinateRepository.GetCoordinates(request.Addresses, request.OutSR, request.CacheEnabled);
            GeoGetCoordinatesByAddressesResponse result = null;

            if (tempResult != null)
            {
                var items = (from r in tempResult
                             select r != null ? new GeoLocationListItem()
                             {
                                 Address = r.Address,
                                 Location = new GeoLocation()
                                 {
                                     X = r.LocationX,
                                     Y = r.LocationY
                                 }
                             } : null).ToArray();
                result = new GeoGetCoordinatesByAddressesResponse()
                {
                    Locations = items
                };
            }

            return result;
        }
    }
}
