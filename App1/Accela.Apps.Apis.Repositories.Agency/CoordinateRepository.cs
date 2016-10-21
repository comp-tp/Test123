using Accela.Apps.Admin.Agency.Client;
using Accela.Apps.Apis.Common;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Requests.GISSettingsRequests;
using Accela.Apps.Apis.Persistence;
using Accela.Apps.Apis.Repositories.Agency.GeoHelpers;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.GeoServices;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Shared.Toolkits.Encrypt;
using Accela.Apps.Shared.Exceptions;
using Accela.Infrastructure.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Accela.Apps.Apis.Repositories.Agency
{
    /// <summary>
    /// Coordinate Repository
    /// </summary>
    public class CoordinateRepository : RepositoryBase, ICoordinateRepository
    {
        public const string TABLE_NAME = "GeocodeAddress";
        public const string TABLE_PARTITION_KEY = "GeocodeAddress";
        private ITableStorage<CoordinatePersistedModel> _tableStorage = null;

        private bool geoRepositoryInitialized = false;
        private readonly IGeocodeRepository GeocodeRepository;
        private readonly IAgencySettingsService _agencyService;

        public CoordinateRepository(IGeocodeRepository geocodeRepository, ITableStorage<CoordinatePersistedModel> tableStorage, IAgencySettingsService agencyService)
            : base()
        {
            this.GeocodeRepository = geocodeRepository;
			this._tableStorage = tableStorage;
            _agencyService = agencyService;
        }


        /// <summary>
        /// Gets the coordinates.
        /// </summary>
        /// <param name="addresses">The addresses.</param>
        /// <returns>the coordinates.</returns>
        public CoordinateModel[] GetCoordinates(string[] addresses, string outSR = "4326", bool cacheEnabled = true)
        {
            CoordinateModel[] results = null;

            if (addresses == null)
            {
                return null;
            }

            var canUseCache = cacheEnabled && !HasCustomGeoService(this.CurrentContext.Agency);

            if (canUseCache)
            {
                var storageResults = GetCoordinatesFromStorage(addresses);
                var notCachedAddresses = GetNotCachedAddresses(storageResults, addresses);
                var geocodeResults = GetCoordinatesFromGeocodeService(notCachedAddresses, outSR);
                SaveCoordinatesToStorage(geocodeResults);
                results = MergeResults(addresses, storageResults, geocodeResults);
            }
            else
            {
                results = GetCoordinatesFromGeocodeService(addresses, outSR);
            }

            return results;
        }

        public CoordinateModel GetCoordinate(AddressModel address, string outSR = "4326")
        {
            CoordinateModel result = null;

            string geoAddress = ConvertToGeoAddressString(address);
            string[] geoAddresses = new string[] { geoAddress };
            var coordinates = GetCoordinates(geoAddresses, outSR);
            
            if (coordinates != null
                && coordinates.Length > 0)
            {
                result = coordinates[0];
            }

            return result;
        }

        private void InitGeocodeSetting()
        {
            var agencyName = this.CurrentContext.Agency == (new UnKownAgencyAppContext()).Agency ? null : this.CurrentContext.Agency;
            GeocodeHelper.InitGeocodeParameters(this.GeocodeRepository, agencyName);
            geoRepositoryInitialized = true;
        }

        private static string ConvertToGeoAddressString(AddressModel model)
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

        private static string AddToAddress(string orignalString, string newPart, string splitSymbol)
        {
            string result = orignalString;
            if (newPart != null)
            {
                result = orignalString + splitSymbol + newPart.Trim();
            }

            return result.Trim();
        }

        /// <summary>
        /// Gets the not cached addresses.
        /// </summary>
        /// <param name="coordinatesFromStorage">The coordinates from storage.</param>
        /// <param name="wholeAddresses">The whole addresses.</param>
        /// <returns>the not cached addresses.</returns>
        private string[] GetNotCachedAddresses(CoordinateModel[] coordinatesFromStorage, string[] wholeAddresses)
        {
            string[] results = null;

            if (coordinatesFromStorage != null && coordinatesFromStorage.Length > 0 && wholeAddresses != null)
            {
                var addressList = new List<string>();
                for (int i = 0; i < wholeAddresses.Length; i++)
                {
                    var coordinateModel = coordinatesFromStorage[i];

                    if (coordinateModel == null && !String.IsNullOrWhiteSpace(wholeAddresses[i]))
                    {
                        addressList.Add(wholeAddresses[i]);
                    }
                }
                results = addressList.ToArray();
            }

            return results;
        }

        /// <summary>
        /// Gets the coordinates from geocode service.
        /// </summary>
        /// <param name="notFoundAddresses">The addresses.</param>
        /// <returns>
        /// the coordinates from geocode service.
        /// </returns>
        private CoordinateModel[] GetCoordinatesFromGeocodeService(string[] notFoundAddresses, string outSR = "4326")
        {
            CoordinateModel[] results = null;

            if (notFoundAddresses != null && notFoundAddresses.Length > 0)
            {
                //get from geocode service
                if ( !geoRepositoryInitialized )
                {
                    InitGeocodeSetting();
                }
                var geocodeAddressArray = GeocodeRepository.GetCoordinateByAddresses(notFoundAddresses, outSR);
                results = ConvertToCoordinateModels(notFoundAddresses, geocodeAddressArray);
            }

            return results;
        }

        /// <summary>
        /// Gets the coordinates from storage.
        /// </summary>
        /// <param name="wholeAddresses">The addresses.</param>
        /// <returns>the coordinates from storage.</returns>
        private CoordinateModel[] GetCoordinatesFromStorage(string[] wholeAddresses)
        {
            var watch1 = Reflection.Startwatch();
            CoordinateModel[] results = null;

            if (wholeAddresses != null)
            {
                var distinctAddresses = wholeAddresses.Where(a => a != null).Distinct().ToArray();

                var coordinateModelList = new List<CoordinateModel>();
                //var tableDataSource = new TableDataSource<CoordinatePersistedModel>(ConnectionStrings.ApiStorageSettingName, TABLE_NAME);

                foreach (var address in distinctAddresses)
                {
                    CoordinateModel coordinateModel = null;
                    CoordinatePersistedModel persistedModel = null;

                    if (!String.IsNullOrWhiteSpace(address))
                    {
                        var addressForMD5 = address.Trim().ToUpper();
                        var rowKey = MD5Helper.GetMd5Hash(addressForMD5);
                        persistedModel = _tableStorage.Read(TABLE_NAME, TABLE_PARTITION_KEY, rowKey);
                        //persistedModel = tableDataSource.Get(TABLE_PARTITION_KEY, rowKey);
                    }

                    if (persistedModel != null)
                    {
                        coordinateModel = new CoordinateModel();
                        coordinateModel.Address = address;
                        coordinateModel.LocationX = persistedModel.Longitude;
                        coordinateModel.LocationY = persistedModel.Latitude;
                    }

                    coordinateModelList.Add(coordinateModel);
                }

                results = GetMappingCoordinateModels(wholeAddresses, distinctAddresses, coordinateModelList.ToArray());
            }

            // TODO:
            // Use the new DLL
            // Remove the below code later because there is no such thing in the new DLL.
            //Log.Performance(Reflection.CurrentMethodName, Reflection.Stopwatch(watch1), "GetCoordinates - Get storage coordinates", "");

            return results;
        }

        /// <summary>
        /// Converts to coordinate models.
        /// </summary>
        /// <param name="addressArray">The address array.</param>
        /// <param name="geocodeAddressArray">The geocode address array.</param>
        /// <returns>coordinate models.</returns>
        private CoordinateModel[] ConvertToCoordinateModels(string[] addressArray, GeocodeAddress[] geocodeAddressArray)
        {
            CoordinateModel[] result = null;

            if (geocodeAddressArray != null)
            {
                var coordinateModelList = new List<CoordinateModel>();
                for (int i = 0; i < geocodeAddressArray.Length; i++)
                {
                    var address = addressArray[i];
                    var geocode = geocodeAddressArray[i];
                    CoordinateModel coordinateModel = null;

                    if (geocode != null && !String.IsNullOrWhiteSpace(address))
                    {
                        coordinateModel = new CoordinateModel()
                        {
                            Address = address,
                            LocationX = geocode.LocationX,
                            LocationY = geocode.LocationY
                        };
                    }

                    coordinateModelList.Add(coordinateModel);
                }

                result = coordinateModelList.ToArray();
            }

            return result;
        }

        /// <summary>
        /// Gets the mapping coordinate models.
        /// </summary>
        /// <param name="originalAddresses">The original addresses.</param>
        /// <param name="distinctAddresses">The distinct addresses.</param>
        /// <param name="coordinateModels">The coordinate models.</param>
        /// <returns>the mapping coordinate models.</returns>
        private CoordinateModel[] GetMappingCoordinateModels(string[] originalAddresses, string[] distinctAddresses, CoordinateModel[] coordinateModels)
        {
            CoordinateModel[] results = null;

            if (coordinateModels != null && originalAddresses != null && distinctAddresses != null)
            {
                var tempResults = new List<CoordinateModel>();

                foreach (var oa in originalAddresses)
                {
                    if (String.IsNullOrWhiteSpace(oa))
                    {
                        tempResults.Add(null);
                        continue;
                    }

                    int index = Array.FindIndex<string>(distinctAddresses, p => p == oa);
                    var geocodeAddress = index > -1 ? coordinateModels[index] : null;
                    tempResults.Add(geocodeAddress);
                }

                results = tempResults.ToArray();
            }

            return results;
        }

        /// <summary>
        /// Saves the coordinates to storage.
        /// </summary>
        /// <param name="coordinateModels">The coordinate models.</param>
        public void SaveCoordinatesToStorage(CoordinateModel[] coordinateModels)
        {
            if (coordinateModels != null && coordinateModels.Length > 0)
            {
                var coordinatePersistedModelList = new List<CoordinatePersistedModel>();

                for (int i = 0; i < coordinateModels.Length; i++)
                {
                    var coordinateModel = coordinateModels[i];

                    if (coordinateModel == null || String.IsNullOrWhiteSpace(coordinateModel.Address))
                    {
                        continue;
                    }

                    var persistedModel = new CoordinatePersistedModel();
                    persistedModel.PartitionKey = TABLE_PARTITION_KEY;
                    var addressForMD5 = coordinateModel.Address.Trim().ToUpper();
                    persistedModel.RowKey = MD5Helper.GetMd5Hash(addressForMD5);
                    persistedModel.Latitude = coordinateModel.LocationY;
                    persistedModel.Longitude = coordinateModel.LocationX;
                    coordinatePersistedModelList.Add(persistedModel);
                }

                coordinatePersistedModelList = coordinatePersistedModelList.Distinct(new CoordinatePersistedModelComparer()).ToList();
                var coordinatePersistedModelArray = coordinatePersistedModelList.ToArray();

                //Task.Factory.StartNew(() =>
                //{
                    try
                    {
                        //var tableDataSource = new TableDataSource<CoordinatePersistedModel>(ConnectionStrings.ApiStorageSettingName, TABLE_NAME);
                        //tableDataSource.BatchInsertOrUpdate(coordinatePersistedModelArray);
                        _tableStorage.CreateNewOrReplace(coordinatePersistedModelArray, TABLE_NAME);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            Log.Error(ex, "CoordinateRepository.SaveCoordinatesToStorage");
                        }
                        catch { }
                    }
                //});
            }
        }

        /// <summary>
        /// Merges the results.
        /// </summary>
        /// <param name="wholeAddresses">The whole addresses.</param>
        /// <param name="storageResults">The storage results.</param>
        /// <param name="geocodeResults">The geocode results.</param>
        /// <returns>
        /// the results.
        /// </returns>
        private CoordinateModel[] MergeResults(string[] wholeAddresses, CoordinateModel[] storageResults, CoordinateModel[] geocodeResults)
        {
            CoordinateModel[] results = null;

            if (wholeAddresses == null)
            {
                return null;
            }

            var tempResults = new List<CoordinateModel>();

            foreach (var address in wholeAddresses)
            {
                CoordinateModel coordinateModel = null;

                if (!String.IsNullOrWhiteSpace(address))
                {
                    if (storageResults != null)
                    {
                        coordinateModel = storageResults.Where(r => r != null && r.Address == address).FirstOrDefault();
                    }

                    // if address not in cache 
                    if (coordinateModel == null && geocodeResults != null)
                    {
                        coordinateModel = geocodeResults.Where(r => r != null && r.Address == address).FirstOrDefault();
                    }
                }

                tempResults.Add(coordinateModel);
            }

            results = tempResults.ToArray();

            return results;
        }

        public void SaveRecordCoordinate(GeoCoordinateModel recordCoordinate)
        {
            if (recordCoordinate != null)
            {
                GeoCoordinate edmGeoCoordinate = new GeoCoordinate
                {
                    ID = Guid.NewGuid(),
                    GlobalEntityID = recordCoordinate.GlobalEntityId,
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = recordCoordinate.CreatedBy,
                };

                decimal coordinateX = 0.0M;

                Decimal.TryParse(recordCoordinate.CoordinateX, out coordinateX);

                edmGeoCoordinate.CoordinateX = coordinateX;

                decimal coordinateY = 0.0M;

                Decimal.TryParse(recordCoordinate.CoordinateY, out coordinateY);

                edmGeoCoordinate.CoordinateY = coordinateY;

                // TODO:
                // Changes this later.
                //using (var objectContext = new AdministrationDataContext(ConnectiongStrings.Administration))
                using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
                {
                    apiDataContext.GeoCoordinates.Add(edmGeoCoordinate);
                    apiDataContext.SaveChanges();
                }
            }
        }

        public List<GeoCoordinateModel> GetRecordIdsByBBox(BBox bbox)
        {
            if ((bbox == null) || (string.IsNullOrWhiteSpace(bbox.XMin) || string.IsNullOrWhiteSpace(bbox.XMax)
                                  || string.IsNullOrWhiteSpace(bbox.YMin) || string.IsNullOrWhiteSpace(bbox.YMax)))
            { return null; }

            var dblXmin = Convert.ToDecimal(bbox.XMin);
            var dblXmax = Convert.ToDecimal(bbox.XMax);
            var dblYmin = Convert.ToDecimal(bbox.YMin);
            var dblYmax = Convert.ToDecimal(bbox.YMax);

            List<GeoCoordinateModel> results = new List<GeoCoordinateModel>();

            // TODO:
            // Changes this later.
            //using (var objectContext = new AdministrationDataContext(ConnectiongStrings.Administration))
            using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                apiDataContext.GeoCoordinates.Where(o => o.CoordinateX > dblXmin
                                    && o.CoordinateX < dblXmax
                                    && o.CoordinateY > dblYmin
                                    && o.CoordinateY < dblYmax).ToList().ForEach(o => results.Add(ToEntityModel(o)));
            }

            return results;
        }

        public List<GeoCoordinateModel> GlobalEntityIdsWithinRange(GeoSearchRangeModel range)
        {
            List<GeoCoordinateModel> results = new List<GeoCoordinateModel>();

            if (range != null)
            {
                decimal decimalLocationX;
                decimal decimalLocationY;

                decimal delta = GetAreaCoordinate(range, out decimalLocationX, out decimalLocationY);

                // TODO:
                // Changes this later.
                //using (var objectContext = new AdministrationDataContext(ConnectiongStrings.Administration))
                using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
                {
                    var query = apiDataContext.GeoCoordinates.Where(item => (item.CoordinateX.Value - decimalLocationX) * (item.CoordinateX.Value - decimalLocationX) + (item.CoordinateY.Value - decimalLocationY) * (item.CoordinateY.Value - decimalLocationY) < delta * delta);

                    List<GeoCoordinate> coordinates = new List<GeoCoordinate>();

                    SqlRetryPolicy.ExecuteAction(() =>
                    {
                        coordinates = query.ToList();
                    });

                    if (coordinates.Count > 0)
                    {
                        foreach (var coordinate in coordinates)
                        {
                            results.Add(ToEntityModel(coordinate));
                        }
                    }
                }
            }

            return results;
        }

        private decimal GetAreaCoordinate(GeoSearchRangeModel range, out decimal decimalLocationX, out decimal decimalLocationY)
        {
            if (String.IsNullOrWhiteSpace(range.CenterLocationX))
            {
                throw new BadRequestException("CenterLocationX should not be null or empty.");
            }

            double locationX = 0.0;

            if (!Double.TryParse(range.CenterLocationX, out locationX))
            {
                throw new BadRequestException("CenterLocationX should be a decimal number.");
            }

            if (String.IsNullOrWhiteSpace(range.CenterLocationY))
            {
                throw new BadRequestException("CenterLocationY should not be null or empty.");
            }

            double locationY = 0.0;

            if (!Double.TryParse(range.CenterLocationY, out locationY))
            {
                throw new BadRequestException("CenterLocationY should be a decimal number.");
            }

            if (range.Radius < 0)
            {
                throw new BadRequestException("Radius should great than 0.");
            }

            // 1° ≈ 111 km
            // 1′ ≈ 1.85 km
            // 1″ ≈ 30.9 m

            double oneMinutesToDecimalDegrees = 0.016666666667;
            double oneSecondToDecimalDegrees = 0.000277777778;

            int remainder = range.Radius;

            int deltaDegree = 0;

            if (remainder > 111000)
            {
                deltaDegree += remainder / 111000;

                remainder = remainder % 111000;
            }

            int deltaMinute = 0;

            if (remainder > 1850)
            {
                deltaMinute += remainder / 1850;

                remainder = remainder % 1850;
            }

            double deltaSecond = 0.0;

            if (remainder > 30.9)
            {
                deltaSecond += (double)remainder / 30.9;
            }

            double resultDelta = deltaDegree + deltaMinute * oneMinutesToDecimalDegrees + deltaSecond * oneSecondToDecimalDegrees;

            //double resultLocationX = locationX + resultDelta;

            //decimalLocationX = Convert.ToDecimal(resultLocationX);

            decimalLocationX = Convert.ToDecimal(locationX);

            //double resultLocationY = locationY + resultDelta;

            //decimalLocationY = Convert.ToDecimal(resultLocationY);

            decimalLocationY = Convert.ToDecimal(locationY);

            return Convert.ToDecimal(resultDelta);
        }

        public List<RecordGeoModel> GetRecordsByBBox(BBox bbox, Guid civicId, string environment, int offset, int limit)
        {
            List<RecordGeoModel> results = new List<RecordGeoModel>();

            if ((bbox == null) || (string.IsNullOrWhiteSpace(bbox.XMin) || string.IsNullOrWhiteSpace(bbox.XMax)
                      || string.IsNullOrWhiteSpace(bbox.YMin) || string.IsNullOrWhiteSpace(bbox.YMax)))
            { return null; }

            var dblXmin = Convert.ToDecimal(bbox.XMin);
            var dblXmax = Convert.ToDecimal(bbox.XMax);
            var dblYmin = Convert.ToDecimal(bbox.YMin);
            var dblYmax = Convert.ToDecimal(bbox.YMax);

            // TODO:
            // Changes this later.
            //using (var objectContext = new AdministrationDataContext(ConnectiongStrings.Administration))
            using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                var query = MakeRecordsByBBoxQueryExpression(civicId, environment, dblXmin, dblXmax, dblYmin, dblYmax, apiDataContext);

                SqlRetryPolicy.ExecuteAction(() =>
                {
                    results = query.Skip(offset).Take(limit).ToList();
                });
            }

            return results;
        }

        public int GetRecordsCountByBBox(BBox bbox, Guid civicId, string environment)
        {
            int result = 0;

            if ((bbox == null)
                || (string.IsNullOrWhiteSpace(bbox.XMin)
                || string.IsNullOrWhiteSpace(bbox.XMax)
                || string.IsNullOrWhiteSpace(bbox.YMin)
                || string.IsNullOrWhiteSpace(bbox.YMax)))
            {
                return result;
            }

            var dblXmin = Convert.ToDecimal(bbox.XMin);
            var dblXmax = Convert.ToDecimal(bbox.XMax);
            var dblYmin = Convert.ToDecimal(bbox.YMin);
            var dblYmax = Convert.ToDecimal(bbox.YMax);

            // TODO:
            // Changes this later.
            //using (var objectContext = new AdministrationDataContext(ConnectiongStrings.Administration))
            using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                var query = MakeRecordsByBBoxQueryExpression(civicId, environment, dblXmin, dblXmax, dblYmin, dblYmax, apiDataContext);

                SqlRetryPolicy.ExecuteAction(() =>
                {
                    if (civicId == Guid.Empty)
                    {
                        result = (from entity in apiDataContext.GlobalEntities
                                  join item in apiDataContext.GeoCoordinates on entity.ID equals item.GlobalEntityID
                                  where item.CoordinateX > dblXmin
                                          && item.CoordinateX < dblXmax
                                          && item.CoordinateY > dblYmin
                                          && item.CoordinateY < dblYmax
                                          && entity.Environment != null
                                          && entity.Environment.Equals(environment, StringComparison.OrdinalIgnoreCase)
                                  orderby entity.OpenedDate descending
                                  select entity.ID).Count();
                    }
                    else
                    {
                        result = (from entity in apiDataContext.GlobalEntities
                                  join item in apiDataContext.GeoCoordinates on entity.ID equals item.GlobalEntityID
                                  where item.CoordinateX > dblXmin
                                          && item.CoordinateX < dblXmax
                                          && item.CoordinateY > dblYmin
                                          && item.CoordinateY < dblYmax
                                          && entity.Environment != null
                                          && entity.Environment.Equals(environment, StringComparison.OrdinalIgnoreCase)
                                  orderby entity.OpenedDate descending
                                  select entity.ID).Count();
                    }
                });
            }

            return result;
        }

        private IQueryable<RecordGeoModel> MakeRecordsByBBoxQueryExpression(Guid civicId, string environment, decimal dblXmin, decimal dblXmax, decimal dblYmin, decimal dblYmax, ApiDataContext objectContext)
        {
            var query = from entity in objectContext.GlobalEntities
                        join item in objectContext.GeoCoordinates on entity.ID equals item.GlobalEntityID
                        where item.CoordinateX > dblXmin
                                && item.CoordinateX < dblXmax
                                && item.CoordinateY > dblYmin
                                && item.CoordinateY < dblYmax
                                && entity.Environment != null
                                && entity.Environment.Equals(environment, StringComparison.OrdinalIgnoreCase)
                        orderby entity.OpenedDate descending
                        select new RecordGeoModel
                        {
                            CoordinateX = item.CoordinateX,
                            CoordinateY = item.CoordinateY,
                            CreatedDate = entity.CreatedDate,
                            Id = entity.EntityID,
                            GlobalEntityId = entity.ID,
                            Agency = entity.AgencyName,
                            Environment = entity.Environment,
                            Type = entity.UDF1,
                            OneLineAddress = entity.UDF2
                        };

            if (civicId != Guid.Empty)
            {
                query = query.Where(user => user.User.Id == civicId);
            }

            return query;
        }
        
        public List<RecordGeoModel> GetRecordsByCircle(GeoSearchRangeModel circle, Guid civicId, string environment, int offset, int limit)
        {
            List<RecordGeoModel> results = new List<RecordGeoModel>();

            if (circle != null)
            {
                decimal decimalLocationX;
                decimal decimalLocationY;

                decimal delta = GetAreaCoordinate(circle, out decimalLocationX, out decimalLocationY);

                // TODO:
                // Changes this later.
                //using (var objectContext = new AdministrationDataContext(ConnectiongStrings.Administration))
                using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
                {
                    var query = MakeRecordsByCircleQueryExpression(civicId, environment, decimalLocationX, decimalLocationY, delta, apiDataContext);

                    SqlRetryPolicy.ExecuteAction(() =>
                        {
                            results = query.Skip(offset).Take(limit).ToList();
                        });
                }
            }

            return results;
        }
        
        private IQueryable<RecordGeoModel> MakeRecordsByCircleQueryExpression(Guid civicId, string environment, decimal decimalLocationX, decimal decimalLocationY, decimal delta, ApiDataContext objectContext)
        {
            var query = from entity in objectContext.GlobalEntities
                        join item in objectContext.GeoCoordinates on entity.ID equals item.GlobalEntityID
                        where (item.CoordinateX.Value - decimalLocationX) * (item.CoordinateX.Value - decimalLocationX) + (item.CoordinateY.Value - decimalLocationY) * (item.CoordinateY.Value - decimalLocationY) < delta * delta
                        && entity.Environment != null
                        && entity.Environment.Equals(environment, StringComparison.OrdinalIgnoreCase)
                        orderby entity.OpenedDate descending
                        select new RecordGeoModel
                        {
                            CoordinateX = item.CoordinateX,
                            CoordinateY = item.CoordinateY,
                            CreatedDate = entity.CreatedDate,
                            Id = entity.EntityID,
                            GlobalEntityId = entity.ID,
                            Agency = entity.AgencyName,
                            Environment = entity.Environment,
                            Type = entity.UDF1,
                            OneLineAddress = entity.UDF2,
                            Status = entity.UDF4
                        };

            if (civicId != Guid.Empty)
            {
                query = query.Where(user => user.User.Id == civicId);
            }

            return query;
        }

        public int GetRecordsCountByCircle(GeoSearchRangeModel circle, Guid civicId, string environment)
        {
            int recordsCount = 0;
            if (circle != null)
            {
                decimal decimalLocationX;
                decimal decimalLocationY;

                decimal delta = GetAreaCoordinate(circle, out decimalLocationX, out decimalLocationY);

                // TODO:
                // Changes this later.
                //using (var objectContext = new AdministrationDataContext(ConnectiongStrings.Administration))
                using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
                {
                    SqlRetryPolicy.ExecuteAction(() =>
                        {
                            if (civicId != Guid.Empty)
                            {
                                recordsCount = (from entity in apiDataContext.GlobalEntities
                                                join item in apiDataContext.GeoCoordinates on entity.ID equals item.GlobalEntityID
                                                where (item.CoordinateX.Value - decimalLocationX) * (item.CoordinateX.Value - decimalLocationX) + (item.CoordinateY.Value - decimalLocationY) * (item.CoordinateY.Value - decimalLocationY) < delta * delta
                                                && entity.Environment != null
                                                && entity.Environment.Equals(environment, StringComparison.OrdinalIgnoreCase)
                                                orderby entity.OpenedDate descending
                                                select entity.ID).Count();
                            }
                            else
                            {
                                recordsCount = (from entity in apiDataContext.GlobalEntities
                                                join item in apiDataContext.GeoCoordinates on entity.ID equals item.GlobalEntityID
                                                where (item.CoordinateX.Value - decimalLocationX) * (item.CoordinateX.Value - decimalLocationX) + (item.CoordinateY.Value - decimalLocationY) * (item.CoordinateY.Value - decimalLocationY) < delta * delta
                                                && entity.Environment != null
                                                && entity.Environment.Equals(environment, StringComparison.OrdinalIgnoreCase)
                                                orderby entity.OpenedDate descending
                                                select entity.ID).Count();
                            }
                        });
                }
            }
            return recordsCount;
        }

        private GeoCoordinateModel ToEntityModel(GeoCoordinate coordinate)
        {
            var tmpObject = new GeoCoordinateModel();

            tmpObject.GlobalEntityId = coordinate.GlobalEntityID;

            tmpObject.CreatedBy = coordinate.CreatedBy;
            tmpObject.LastUpdatedBy = coordinate.LastUpdatedBy;

            if (coordinate.CoordinateX.HasValue)
            {
                tmpObject.CoordinateX = coordinate.CoordinateX.Value.ToString();
            }

            if (coordinate.CoordinateY.HasValue)
            {
                tmpObject.CoordinateY = coordinate.CoordinateY.Value.ToString();
            }

            if (coordinate.CreatedDate.HasValue)
            {
                tmpObject.CreatedDate = coordinate.CreatedDate.Value;
            }

            if (coordinate.LastUpdatedDate.HasValue)
            {
                tmpObject.LastUpdatedDate = coordinate.LastUpdatedDate.Value;
            }
            return tmpObject;
        }

        private bool HasCustomGeoService(string agencyName)
        {
            bool result = false;

            if (!String.IsNullOrWhiteSpace(agencyName))
            {
                var request = new GetGISSettingsRequest()
                {
                    AgencyName = agencyName
                };

                var response = _agencyService.GetGISSettings(agencyName);

                if (response != null && response.GeocodeRoutingSetting != null && response.GeocodeRoutingSetting.GeocodeService != null)
                {
                    result = !String.IsNullOrWhiteSpace(response.GeocodeRoutingSetting.GeocodeService.GeocodeServiceUrl);
                }
            }

            return result;
        }   

    }
}
