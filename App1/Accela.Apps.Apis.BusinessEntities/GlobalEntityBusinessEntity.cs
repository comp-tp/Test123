using System;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DomainModels.GlobalEntityModels;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared;
using Accela.Apps.Apis.Models.DTOs.Requests.GlobalEntityRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.GlobalEntityResponse;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;
using Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.Portals;

namespace Accela.Apps.Apis.BusinessEntities
{
    public class GlobalEntityBusinessEntity : IGlobalEntityBusinessEntity
    {
        private IGlobalEntityRepository _globalEntityRepository = null;

        //private ICoordinateRepository _coordinateRepository = null;
        private readonly ICoordinateRepository CoordinateRepository;
        //{
        //    get
        //    {
        //        if (_coordinateRepository == null)
        //        {
        //            _coordinateRepository = IocContainer.Resolve<ICoordinateRepository>();
        //        }

        //        return _coordinateRepository;
        //    }
        //}

        public GlobalEntityBusinessEntity(IGlobalEntityRepository globalEntityRepository, ICoordinateRepository coordinateRepository)
        {
            _globalEntityRepository = globalEntityRepository; // IocContainer.Resolve<IGlobalEntityRepository>();
            this.CoordinateRepository = coordinateRepository;
        }

        /// <summary>
        /// Get global entity by id.
        /// </summary>
        /// <param name="id">ID.</param>
        /// <returns>GlobalEntityModel.</returns>
        public GlobalEntityModel GetGlobalEntity(Guid id)
        {
            var globalEntityModel = _globalEntityRepository.GetGlobalEntity(id);
            return globalEntityModel;
        }

        /// <summary>
        /// Get global entity according to specified entity id,entity type, agency name and environment name.
        /// </summary>
        /// <param name="entityID">Entity ID.</param>
        /// <param name="entityType">Entity type.</param>
        /// <param name="agencyName">Agency name.</param>
        /// <param name="environment">Environment.</param>
        /// <returns>GlobalEntityModel.</returns>
        public GlobalEntityModel GetGlobalEntity(string entityID, string entityType, string agencyName, string enviroment)
        {
            var globalEntityModel = _globalEntityRepository.GetGlobalEntity(entityID, entityType, agencyName, enviroment);
            return globalEntityModel;
        }

        /// <summary>
        /// Count record num according to record type.
        /// </summary>
        /// <param name="countRecordNumRequest">Count Record Num Request</param>
        /// <returns>Record type and num count list.</returns>
        public GetRecordCountByRecordTypeResponse CountRecordNumByRecordType(GetRecordCountByRecordTypeRequest countRecordNumRequest)
        {
            var countRecordNumResponse = new GetRecordCountByRecordTypeResponse();
            countRecordNumResponse.RecordNumCounts = _globalEntityRepository.CountRecordNumByRecordType(countRecordNumRequest.AgencyName, countRecordNumRequest.EntityType, countRecordNumRequest.Environment);
            return countRecordNumResponse;
        }

        /// <summary>
        /// Search global entities.
        /// </summary>
        /// <param name="request">Search entities request.</param>
        /// <returns>Search results.</returns>
        public GetGlobalEntitiesResponse SearchGlobalEntities(GetGlobalEntitiesRequest request)
        {
            int entityCount;
            var globalEntities = _globalEntityRepository.SearchGlobalEntities(request.AgencyName,
                                                                             request.Environment,
                                                                             request.EntityType,
                                                                             request.SearchConditions,
                                                                             request.SortExpression,
                                                                             request.Offset,
                                                                             request.Limit,
                                                                             out entityCount);
            var searchRecordsResponse = new GetGlobalEntitiesResponse();
            searchRecordsResponse.Records = globalEntities;
            searchRecordsResponse.PageInfo = new Pagination()
            {
                Offset = request.Offset,
                Limit = request.Limit,
                TotalRows = entityCount
            };
            return searchRecordsResponse;
        }

        /// <summary>
        /// Get global entity according to specified entity id, agency name and environment name.
        /// </summary>
        /// <param name="entityID">Entity ID.</param>   
        /// <param name="agencyName">Agency name.</param>
        /// <param name="environment">Environment.</param>
        /// <returns>GlobalEntityModel.</returns>
        public GlobalEntityModel GetGlobalEntity(string entityID, string agencyName, string enviroment)
        {
            var globalEntityModel = _globalEntityRepository.GetGlobalEntity(entityID, agencyName, enviroment);
            return globalEntityModel;
        }

        /// <summary>
        /// Add a new global entity model.
        /// </summary>
        /// <param name="globalEntityModel">Global entity model.</param>
        /// <returns>Global entity model.</returns>
        public GlobalEntityModel AddIfNotExist(GlobalEntityModel globalEntityModel)
        {
            var globalEntity = _globalEntityRepository.AddIfNotExist(globalEntityModel);
            return globalEntity;
        }

        public GetGlobalEntityResponse GlobalEntity(GetGlobalEntityRequest request)
        {
            GetGlobalEntityResponse result = new GetGlobalEntityResponse();

            if (request != null)
            {
                result.Record = _globalEntityRepository.GetGlobalEntity(request.EntityId, request.EntityType, request.AgencyName, request.Environment);
            }

            return result;
        }


        public GetGlobalEntitiesCountResponse GetGlobalEntitiesCount(GetGlobalEntitiesCountRequest request)
        {
            GetGlobalEntitiesCountResponse result = _globalEntityRepository.GetGlobalEntitiesCount(request);
            return result;
        }

        public GlobalEntityModel Update(GlobalEntityModel globalEntityModel)
        {
            var globalEntity = _globalEntityRepository.Update(globalEntityModel);
            return globalEntityModel;
        }

        public RecordsGeoResponse GetRecordsViaGeo(RecordsGeoRequest request)
        {
            RecordsGeoResponse response = new RecordsGeoResponse();

            if (request == null)
            {
                return response;
            }

            response.Records = new List<RecordGeoModel>();

            GetRecordsWithGeoCriteria(request, response);

            return response;
        }

        private void GetRecordsWithGeoCriteria(RecordsGeoRequest request, RecordsGeoResponse response)
        {
            if (response.Records == null)
            {
                return;
            }

            int recordCount = 0;
            List<RecordGeoModel> results = new List<RecordGeoModel>();
            int passByOne = request.Limit + 1;
            if (request.BBoxValue != null)
            {
                recordCount = CoordinateRepository.GetRecordsCountByBBox(request.BBoxValue, request.CivicId, request.Environment);

                if (recordCount > 0)
                {
                    results = CoordinateRepository.GetRecordsByBBox(request.BBoxValue, request.CivicId, request.Environment, request.Offset, passByOne);
                }
            }
            else
            {
                if (request.GeoCircle != null)
                {
                    var criterion = new GeoSearchRangeModel
                    {
                        CenterLocationX = request.GeoCircle.CenterX,
                        CenterLocationY = request.GeoCircle.CenterY,
                        Type = "RECORD"
                    };

                    int tmpRadius = 0;

                    Int32.TryParse(request.GeoCircle.Radius, out tmpRadius);

                    criterion.Radius = tmpRadius;

                    recordCount = CoordinateRepository.GetRecordsCountByCircle(criterion, request.CivicId, request.Environment);

                    if (recordCount > 0)
                    {
                        results = CoordinateRepository.GetRecordsByCircle(criterion, request.CivicId, request.Environment, request.Offset, passByOne);
                    }
                }
            }


            if (results != null && results.Count > 0)
            {
                response.Records = results;
                response.PageInfo = new Pagination()
                {
                    Offset = request.Offset,
                    Limit = request.Limit
                };

                if (passByOne == results.Count)
                {
                    results.RemoveAt(passByOne - 1);
                }

                response.PageInfo.TotalRows = recordCount;

            }
        }
    }
}
