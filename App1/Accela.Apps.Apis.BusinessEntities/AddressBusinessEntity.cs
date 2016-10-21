using System;
using System.Collections.Generic;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Models.DTOs.Requests.AddressRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AddressResponses;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.GeoServices;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Exceptions;
using Accela.Apps.Apis.Models.DTOs.Requests.GISSettingsRequests;
using Accela.Apps.Apis.Repositories.Interfaces.Admin;
using Accela.Apps.Shared.Contants;
using Accela.Apps.Apis.BusinessEntities.GeoHelpers;
using Accela.Core.Ioc;

namespace Accela.Apps.Apis.BusinessEntities
{
    public class AddressBusinessEntity : IAddressBusinessEntity
    {
        #region Private Variables

        #endregion


        public AddressBusinessEntity(IAddressRepository addressRepository, ICoordinateRepository coordinateRepository)
        {
            //this.agencyRepository = agencyRepository;
            this.addressRepository = addressRepository;
            this.coordinateRepository = coordinateRepository;
        }

        #region Private Properties

        private readonly IAddressRepository addressRepository;
        private readonly ICoordinateRepository coordinateRepository;

        #endregion

        public AddressesResponse GetAddresses(AddressesRequest request)
        {
            return addressRepository.GetAddresses(request);
        }

        public AddressResponse GetAddress(AddressRequest request)
        {
            var addressResponse = addressRepository.GetAddress(request);
            if (addressResponse.Error == null && addressResponse.Address == null)
            {
                throw new NotFoundException("The address didn't exist.");
            }
            return addressResponse;
        }

        /// <summary>
        /// Retrieve Coodinate by address, then set X,Y to address.
        /// </summary>
        /// <param name="addresses">The addresses.</param>
        /// <param name="forceSetCoordinatesByAddress">if set to <c>true</c> [force set coordinates by address].</param>
        public void RetrieveAndSetCoodinateXY(List<AddressModel> addresses, bool forceSetCoordinatesByAddress = true)
        {
            if (addresses == null || addresses.Count == 0)
            {
                return;
            }

            string[] arrAddresses = new string[addresses.Count];
            AddressModel[] refAddress = new AddressModel[addresses.Count];
            int index = -1;

            foreach (var address in addresses)
            {
                index++;
                refAddress[index] = address;

                #region data check

                if (address == null)
                {
                    continue;
                }

                if (!forceSetCoordinatesByAddress && !String.IsNullOrWhiteSpace(address.XCoordinate) && !String.IsNullOrWhiteSpace(address.YCoordinate))
                {
                    continue;
                }

                #endregion

                #region Build address if no X,Y

                arrAddresses[index] = BuildAddressString(address);

                #endregion
            }

            if (arrAddresses == null || arrAddresses.Length == 0)
            {
                return;
            }

            #region get coodinate X,Y by address and set x,y to address
            List<CoordinateModel> cachedToStorageList = new List<CoordinateModel>();

            //Code Refactor: removed dependency to GeocodeRepository
            //var coordinates = GeocodeRepository.GetCoordinateByAddresses(arrAddresses);
            var coordinates = coordinateRepository.GetCoordinates(arrAddresses);
            if (coordinates != null && coordinates.Length > 0)
            {
                for (int i = 0; i < addresses.Count; i++)
                {
                    if (coordinates[i] != null)
                    {
                        // repository always returns same array count as input
                        refAddress[i].XCoordinate = coordinates[i].LocationX.Equals(double.NaN) ? refAddress[i].XCoordinate : coordinates[i].LocationX.ToString();
                        refAddress[i].YCoordinate = coordinates[i].LocationY.Equals(double.NaN) ? refAddress[i].YCoordinate : coordinates[i].LocationY.ToString();
                        CoordinateModel cachedToStorage = new CoordinateModel
                        {
                            Address = arrAddresses[i],
                            LocationX = coordinates[i].LocationX,
                            LocationY = coordinates[i].LocationY
                        };
                        cachedToStorageList.Add(cachedToStorage);
                    }
                }

                coordinateRepository.SaveCoordinatesToStorage(cachedToStorageList.ToArray());
            }

            #endregion
        }

        /// <summary>
        /// Convert AddressModel to address string.
        /// </summary>
        /// <param name="address">AddressModel</param>
        /// <returns>full address string.</returns>
        public static string BuildAddressString(AddressModel address)
        {
            string addressInfo = String.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}, {10} {11}",
                                    address.HouseNumber,
                                    address.HouseNumberFraction,
                                    address.StreetDirection,
                                    address.StreetName,
                                    address.StreetSuffix,
                                    address.StreetSuffixDirection,
                                    address.Unit,
                                    address.UnitEnd,
                                    address.UnitType,
                                    address.City,
                                    address.State,
                                    address.PostalCode);
            return addressInfo;
        }
    }
}
