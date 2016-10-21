
using System;
using System.Collections.Generic;
using System.Linq;
using Accela.Apps.Apis.Models.DomainModels.GlobalEntityModels;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.Persistence;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Apis.Common;
using Accela.Apps.Apis.Models.DTOs.Responses.GlobalEntityResponse;
using Accela.Apps.Apis.Models.DTOs.Requests.GlobalEntityRequests;
using System.Web;
using Accela.Apps.Shared.FormatHelpers;
namespace Accela.Apps.Apis.Repositories.Citizen
{
    /// <summary>
    /// Global entity repository class.
    /// </summary>
    public class GlobalEntityRepository : RepositoryBase, IGlobalEntityRepository
    {
        const string ENABLE_STATUS = "1";

        /// <summary>
        /// Get global entity by id.
        /// </summary>
        /// <param name="id">ID.</param>
        /// <returns>GlobalEntityModel.</returns>
        public GlobalEntityModel GetGlobalEntity(Guid id)
        {
            GlobalEntityModel globalEntityModel = null;
            var globalEntity = new GlobalEntity();

            using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                SqlRetryPolicy.ExecuteAction(() =>
                {
                    globalEntity = apiDataContext.GlobalEntities.FirstOrDefault(g => g.ID == id && g.Status == GlobalEntityModel.ENABLED);
                });
            }
            if (globalEntity != null)
            {
                globalEntityModel = ConvertDBEntityToModel(globalEntity);
            }
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
            GlobalEntityModel globalEntityModel = null;
            var globalEntity = new GlobalEntity();

            using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                SqlRetryPolicy.ExecuteAction(() =>
                {
                    globalEntity = apiDataContext.GlobalEntities.FirstOrDefault(g => g.EntityID == entityID &&
                                                                                    g.EntityType == entityType &&
                                                                                    g.AgencyName == agencyName &&
                                                                                    g.Environment == enviroment &&
                                                                                    g.Status == GlobalEntityModel.ENABLED);
                });
            }
            if (globalEntity != null)
            {
                globalEntityModel = ConvertDBEntityToModel(globalEntity);
            }
            return globalEntityModel;
        }

        /// <summary>
        /// Get global entities by civic id.
        /// </summary>
        /// <param name="civicId">CivicId.</param> 
        /// <param name="type">Type.</param>
        /// <param name="enviroment">Environment.</param>
        /// <param name="offSet">Offset.</param>
        /// <param name="limit">Limit.</param>
        /// <returns>GlobalEntityModel list.</returns>
        public List<RecordGeoModel> GetGlobalEntitiesByCivicId(Guid civicId, string type, string enviroment, int offSet, int limit)
        {
            List<RecordGeoModel> results = new List<RecordGeoModel>();
            
            using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                SqlRetryPolicy.ExecuteAction(() =>
                {
                    var query = MakeRecordsByCircleQueryExpression(civicId, type, enviroment, apiDataContext);
                    var tempResult = from q in query
                                     select new
                                     {
                                         Record = q,
                                         ImageUrls = (
                                                     from i in apiDataContext.Images
                                                     where i != null
                                                     && i.GlobalEntityID == q.GlobalEntityId
                                                     select i.ImageURL
                                                     )
                                     };
                    var matches = tempResult.Skip(offSet).Take(limit).ToList();

                    if (matches != null && matches.Count > 0)
                    {
                        matches.ForEach(m =>
                        {
                            var imageUrls = m.ImageUrls.ToList();

                            if (m.Record != null)
                            {
                                m.Record.ImageUrls = FixedImageUrls(imageUrls);
                            }

                            results.Add(m.Record);
                        });
                    }
                });
            }

            return results;
        }

        private IQueryable<RecordGeoModel> MakeRecordsByCircleQueryExpression(Guid civicId, string type, string enviroment, ApiDataContext objectContext)
        {
            var query = from entity in objectContext.GlobalEntities
                        join item in objectContext.GeoCoordinates on entity.ID equals item.GlobalEntityID
                        where entity.CloudUserID == civicId &&
                              entity.EntityType == type &&
                              entity.Environment == enviroment &&
                              entity.Status == GlobalEntityModel.ENABLED
                        orderby entity.CreatedDate descending
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
                            //User = new Accela.Azure.DataModels.Portals.CloudUserModel
                            //{
                            //    Id = user.CloudUserId,
                            //    Email = user.Email,
                            //    FirstName = user.FirstName,
                            //    LastName = user.LastName
                            //},
                            Description = entity.UDF3,
                            Status = entity.UDF4,
                            OpenedDate = entity.OpenedDate,
                            AssignTo = entity.AssignTo,
                            LastUpdatedDate = entity.LastUpdatedDate
                        };

            return query;
        }

        /// <summary>
        /// Get global entities by civic id.
        /// </summary>
        /// <param name="civicId">CivicId.</param>
        /// <param name="type">Type.</param>
        /// <param name="environment">Environment.</param>
        /// <returns>Record count.</returns>
        public int GetGlobalEntitiesCountByCivicId(Guid civicId, string type, string environment)
        {
            int recordCount = 0;

            using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                SqlRetryPolicy.ExecuteAction(() =>
                {
                    recordCount = apiDataContext.GlobalEntities.Where(g => g.CloudUserID == civicId &&
                                                                            g.EntityType == type &&
                                                                            g.Environment == environment &&
                                                                            g.Status == GlobalEntityModel.ENABLED).Count();
                });
            }

            return recordCount;
        }

        /// <summary>
        /// Get global entity according to specified entity id, agency name and environment name.
        /// </summary>
        /// <param name="entityID">Entity ID.</param>
        /// <param name="agencyName">Agency name.</param>
        /// <param name="enviroment">Environment.</param>
        /// <returns>GlobalEntityModel.</returns>
        public GlobalEntityModel GetGlobalEntity(string entityID, string agencyName, string enviroment)
        {
            GlobalEntityModel globalEntityModel = null;
            var globalEntity = new GlobalEntity();

            using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                SqlRetryPolicy.ExecuteAction(() =>
                {
                    globalEntity = apiDataContext.GlobalEntities.FirstOrDefault(g => g.EntityID == entityID &&
                                                                                    g.AgencyName == agencyName &&
                                                                                    g.Environment == enviroment &&
                                                                                    g.Status == GlobalEntityModel.ENABLED);
                });
            }
            if (globalEntity != null)
            {
                globalEntityModel = ConvertDBEntityToModel(globalEntity);
                AttachImages(globalEntityModel);
            }
            return globalEntityModel;
        }

        private void AttachImages(GlobalEntityModel globalEntityModel)
        {
            if (globalEntityModel != null)
            {
                List<Image> images = null;
                using (var objectContext = new ApiDataContext(ConnectionStrings.ApiDB))
                {
                    SqlRetryPolicy.ExecuteAction(() =>
                    {
                        images = objectContext.Images.Where(image => globalEntityModel.ID == image.GlobalEntityID).ToList();
                    });
                }

                if (images != null && images.Count > 0)
                {
                    images.ForEach(item => { item.ImageURL = FixedImageUrl(item.ImageURL); });

                    globalEntityModel.ImageUrls = images.Select(image => image.ImageURL).ToList();
                }
            }
        }

        private List<string> FixedImageUrls(List<string> imageUrls)
        {
            List<string> result = null;

            if (imageUrls != null)
            {
                result = new List<string>();

                foreach (var imageUrl in imageUrls)
                {
                    var newImageUrl = FixedImageUrl(imageUrl);
                    result.Add(newImageUrl);
                }
            }

            return result;
        }

        private string FixedImageUrl(string originalUrl)
        {
            var result = originalUrl;
            string port = HttpContext.Current.Request.Url.Port == 80 ? "" : HttpContext.Current.Request.Url.Port.ToString();
            var currUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + (string.IsNullOrEmpty(port) ? "" : ":" + port);

            if (!String.IsNullOrWhiteSpace(originalUrl) && !(originalUrl.Contains("http") || originalUrl.Contains("https")))
            {
                result = currUrl + originalUrl;
            }

            return result;
        }

        /// <summary>
        /// Add a new global entity model if not exist.
        /// </summary>
        /// <param name="globalEntityModel">Global entity model.</param>
        /// <returns>Global entity model.</returns>
        public GlobalEntityModel AddIfNotExist(GlobalEntityModel globalEntityModel)
        {
            GlobalEntityModel result = null;

            using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                var query = from item in apiDataContext.GlobalEntities
                            where item.EntityID == globalEntityModel.EntityID
                                  && item.EntityType == globalEntityModel.EntityType
                                  && item.AgencyName == globalEntityModel.AgencyName
                                  && item.Environment == globalEntityModel.Environment
                            select item;

                List<GlobalEntity> items = null;
                SqlRetryPolicy.ExecuteAction(() =>
                {
                    items = query.ToList();
                });

                // if not exist then add it
                if (items.Count == 0)
                {
                    var globalEntity = ConvertModelToDBEntity(globalEntityModel);
                    apiDataContext.GlobalEntities.Add(globalEntity);

                    SqlRetryPolicy.ExecuteAction(() =>
                    {
                        apiDataContext.SaveChanges();
                    });

                    globalEntityModel.ID = globalEntity.ID;
                    result = globalEntityModel;
                }
                else
                {
                    result = ConvertDBEntityToModel(items[0]);
                }
            }
            return result;
        }
        

        /// <summary>
        /// Convert model to db entity.
        /// </summary>
        /// <param name="globalEntityModel">Global entity model.</param>
        /// <returns>Global entity.</returns>
        private GlobalEntity ConvertModelToDBEntity(GlobalEntityModel globalEntityModel)
        {
            var globalEntity = new GlobalEntity();
            globalEntity.ID = Guid.NewGuid();
            globalEntity.EntityID = globalEntityModel.EntityID;
            globalEntity.EntityType = globalEntityModel.EntityType;
            globalEntity.AgencyName = globalEntityModel.AgencyName;
            globalEntity.Environment = globalEntityModel.Environment;
            globalEntity.Status = GlobalEntityModel.ENABLED;
            globalEntity.CreatedBy = globalEntityModel.CreatedBy;
            globalEntity.CreatedDate = globalEntityModel.CreatedDate;
            globalEntity.OpenedDate = globalEntityModel.OpenDate;
            globalEntity.CloudUserID = globalEntityModel.CloudUserID;
            globalEntity.UDF1 = globalEntityModel.Keep1;
            globalEntity.UDF2 = globalEntityModel.Keep2;
            globalEntity.UDF3 = globalEntityModel.Keep3;
            globalEntity.UDF4 = globalEntityModel.Keep4;

            return globalEntity;
        }

        private GlobalEntity ConvertModelToDBEntity(GlobalEntity globalEntity, GlobalEntityModel globalEntityModel)
        {
            globalEntity.AgencyName = globalEntityModel.AgencyName;
            globalEntity.EntityID = globalEntityModel.EntityID;
            globalEntity.EntityType = globalEntityModel.EntityType;
            globalEntity.Environment = globalEntityModel.Environment;
            globalEntity.AssignTo = globalEntityModel.AssignTo;
            globalEntity.Status = globalEntityModel.Status;
            globalEntity.CloudUserID = globalEntityModel.CloudUserID;
            globalEntity.UDF1 = globalEntityModel.Keep1;
            globalEntity.UDF2 = globalEntityModel.Keep2;
            globalEntity.UDF3 = globalEntityModel.Keep3;
            globalEntity.UDF4 = globalEntityModel.Keep4;
            globalEntity.LastUpdatedBy = globalEntityModel.LastUpdatedBy;
            globalEntity.LastUpdatedDate = globalEntityModel.LastUpdatedDate;

            return globalEntity;
        }

        private List<GlobalEntityModel> ConvertDBEntityToModels(List<GlobalEntity> globalEntities)
        {
            List<GlobalEntityModel> globalEntityModels = new List<GlobalEntityModel>();
            if (globalEntities != null && globalEntities.Count > 0)
            {
                foreach (var globalEntity in globalEntities)
                {
                    globalEntityModels.Add(ConvertDBEntityToModel(globalEntity));
                }
            }
            return globalEntityModels;
        }

        /// <summary>
        /// Convert db entity to model.
        /// </summary>
        /// <param name="globalEntityModel">Global entity model.</param>
        /// <param name="globalEntity">Global entity.</param>
        private GlobalEntityModel ConvertDBEntityToModel(GlobalEntity globalEntity)
        {
            var globalEntityModel = new GlobalEntityModel();
            globalEntityModel.ID = globalEntity.ID;
            globalEntityModel.EntityID = globalEntity.EntityID;
            globalEntityModel.EntityType = globalEntity.EntityType;
            globalEntityModel.AgencyName = globalEntity.AgencyName;
            globalEntityModel.Environment = globalEntity.Environment;
            globalEntityModel.CreatedBy = globalEntity.CreatedBy;
            globalEntityModel.Status = globalEntity.Status;
            if (globalEntity.CloudUserID.HasValue)
            {
                globalEntityModel.CloudUserID = globalEntity.CloudUserID.Value;
            }

            globalEntityModel.Keep1 = globalEntity.UDF1;
            globalEntityModel.Keep2 = globalEntity.UDF2;
            globalEntityModel.Keep3 = globalEntity.UDF3;
            globalEntityModel.Keep4 = globalEntity.UDF4;

            if (globalEntity.CreatedDate.HasValue)
            {
                globalEntityModel.CreatedDate = globalEntity.CreatedDate.Value;
            }
            globalEntityModel.LastUpdatedBy = globalEntity.LastUpdatedBy;
            if (globalEntity.LastUpdatedDate.HasValue)
            {
                globalEntityModel.LastUpdatedDate = globalEntity.LastUpdatedDate.Value;
            }
            return globalEntityModel;
        }

        public GlobalEntityModel Update(GlobalEntityModel globalEntityModel)
        {
            using (var objectContext =new ApiDataContext(ConnectionStrings.ApiDB))
            {
                var globalEntity = objectContext.GlobalEntities.Single(entity => entity.ID == globalEntityModel.ID);
                globalEntity = ConvertModelToDBEntity(globalEntity, globalEntityModel);
                objectContext.SaveChanges();
            }

            return globalEntityModel;
        }

        /// <summary>
        /// Get globalentities count(including total count,posted count and closed count).
        /// </summary>
        /// <param name="request">GetGlobalEntitiesCount Request</param>
        /// <returns>GetGlobalEntitiesCount Response</returns>
        public GetGlobalEntitiesCountResponse GetGlobalEntitiesCount(GetGlobalEntitiesCountRequest request)
        {
            GetGlobalEntitiesCountResponse result = new GetGlobalEntitiesCountResponse();

            using (var objectContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                SqlRetryPolicy.ExecuteAction(() =>
                {

                    var query = objectContext.GlobalEntities.Where(g => g.AgencyName == request.Agency
                                                                            && g.EntityType == request.EntityType
                                                                            && g.Environment == request.Enviromment
                                                                            && g.Status == ENABLE_STATUS);

                    if (!DateTime.Equals(DateTime.MinValue, request.OpenedDateFrom) && !DateTime.Equals(DateTime.MinValue, request.OpenedDateTo))
                    {
                        DateTime comparedDateTo = request.OpenedDateTo.AddDays(1);
                        query = query.Where(g => DateTime.Compare(g.OpenedDate.Value, request.OpenedDateFrom) >= 0
                                    && DateTime.Compare(g.OpenedDate.Value, comparedDateTo) < 0);

                    }

                    if (!DateTime.Equals(DateTime.MinValue, request.UpdatedDateFrom) && !DateTime.Equals(DateTime.MinValue, request.UpdatedDateTo))
                    {
                        DateTime comparedDateTo = request.UpdatedDateTo.AddDays(1);
                        query = query.Where(g => DateTime.Compare(g.OpenedDate.Value, request.UpdatedDateFrom) >= 0
                                    && DateTime.Compare(g.OpenedDate.Value, comparedDateTo) < 0);
                    }

                    if (!string.IsNullOrEmpty(request.Statuses))
                    {
                        query = query.Where(g => request.Statuses.Contains(g.UDF4));
                    }

                    result.Count = query.Count();
                });
            }

            return result;
        }

        /// <summary>
        /// Count record num according to record type.
        /// </summary>
        /// <param name="angecyName">Agency name.</param>
        /// <param name="entityType">Entity type.</param>
        /// <param name="environment">Environment.</param>
        /// <returns>Record type and num count list.</returns>
        public Dictionary<string, int> CountRecordNumByRecordType(string angecyName, string entityType, string environment)
        {
            var recordNumCounts = new Dictionary<string, int>();
            using (var objectContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                SqlRetryPolicy.ExecuteAction(() =>
                {
                    var groupResults = objectContext.GlobalEntities.Where(g => g.AgencyName == angecyName && g.Environment == environment && g.EntityType == entityType && g.Status == GlobalEntityModel.ENABLED)
                                                                    .GroupBy(r => r.UDF1)
                                                                    .Select(r => new { RecordType = r.Key, Count = r.Count() }).ToList();

                    if (groupResults != null && groupResults.Count > 0)
                    {
                        groupResults.ForEach(g => recordNumCounts.Add(g.RecordType, g.Count));
                    };

                });
            }
            return recordNumCounts;
        }

        /// <summary>
        /// Search global entities.
        /// </summary>
        /// <param name="agencyName">Agency Name.</param>
        /// <param name="environment">Environment.</param>
        /// <param name="entityType">Entity Type.</param>
        /// <param name="searchConditions">Search Conditions.</param>
        /// <param name="sortExpression">Sort Expression.</param>
        /// <param name="offSet">Offset.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="count">Record Count.</param>
        /// <returns>Global entities.</returns>
        public List<GlobalEntityModel> SearchGlobalEntities(string agencyName,
                                                            string enviroment,
                                                            string entityType,
                                                            IDictionary<string, string> searchConditions,
                                                            string sortExpression,
                                                            int offSet,
                                                            int limit,
                                                            out int count)
        {
            List<GlobalEntityModel> globalEntityModels = new List<GlobalEntityModel>();
            var recordCount = 0;
            using (var objectContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                IQueryable<GlobalEntity> query = from global_entity in objectContext.GlobalEntities
                                                 join geoCoordinate in objectContext.GeoCoordinates on global_entity.ID equals geoCoordinate.GlobalEntityID into globalentityGeos
                                                 from geoCoordinate in globalentityGeos.DefaultIfEmpty()
                                                 where global_entity.Status == ENABLE_STATUS &&
                                                        global_entity.EntityType == entityType &
                                                        global_entity.AgencyName == agencyName &&
                                                        global_entity.Environment == enviroment
                                                 select global_entity;

                query = GetGlobalEntitySearchQuery(query, searchConditions);

                // Sort
                string orderby = string.Empty;
                if (!string.IsNullOrEmpty(sortExpression))
                {
                    orderby = sortExpression;
                }
                else
                {
                    orderby = "CreatedDate DESC";
                }

                // Query
                List<GlobalEntity> globalEntities = null;

                SqlRetryPolicy.ExecuteAction(() =>
                {
                    recordCount = query.Count();
                    globalEntities = query.OrderBySql(orderby).Skip<GlobalEntity>(offSet).Take<GlobalEntity>(limit).ToList<GlobalEntity>();
                });

                if (globalEntities != null && globalEntities.Count() > 0)
                {
                    globalEntityModels = ConvertDBEntityToModels(globalEntities: globalEntities, isContainGeoInfo: true);
                    AttachImages(globalEntityModels);
                }
            }
            count = recordCount;
            return globalEntityModels;
        }

        private void AttachImages(List<GlobalEntityModel> globalEntityModels)
        {
            if (globalEntityModels != null && globalEntityModels.Count > 0)
            {
                var globalEntityIds = globalEntityModels.Select(g => g.ID).ToList();

                List<Image> images = null;
                using (var objectContext = new ApiDataContext(ConnectionStrings.ApiDB))
                {
                    SqlRetryPolicy.ExecuteAction(() =>
                    {
                        images = objectContext.Images.Where(image => globalEntityIds.Contains(image.GlobalEntityID)).ToList();
                    });
                }

                if (images != null && images.Count > 0)
                {
                    string port = HttpContext.Current.Request.Url.Port == 80 ? "" : HttpContext.Current.Request.Url.Port.ToString();
                    var currUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + (string.IsNullOrEmpty(port) ? "" : ":" + port);
                    images.ForEach(item => { if (!(item.ImageURL.Contains("http") || item.ImageURL.Contains("https"))) { item.ImageURL = currUrl + item.ImageURL; } });

                    foreach (var image in images)
                    {
                        var globalEntityModel = globalEntityModels.Find(r => r.ID == image.GlobalEntityID);
                        if (globalEntityModel != null)
                        {
                            if (globalEntityModel.ImageUrls == null)
                            {
                                globalEntityModel.ImageUrls = new List<string>();
                            }
                            globalEntityModel.ImageUrls.Add(image.ImageURL);
                        }
                    }
                }
            }
        }

        private List<GlobalEntityModel> ConvertDBEntityToModels(List<GlobalEntity> globalEntities, bool isContainGeoInfo = false)
        {
            List<GlobalEntityModel> globalEntityModels = new List<GlobalEntityModel>();
            if (globalEntities != null && globalEntities.Count > 0)
            {
                foreach (var globalEntity in globalEntities)
                {
                    globalEntityModels.Add(ConvertDBEntityToModel(globalEntity, isContainGeoInfo));
                }
            }
            return globalEntityModels;
        }

        /// <summary>
        /// Convert db entity to model.
        /// </summary>
        /// <param name="globalEntityModel">Global entity model.</param>
        /// <param name="globalEntity">Global entity.</param>
        private GlobalEntityModel ConvertDBEntityToModel(GlobalEntity globalEntity, bool isContainGeoInfo = false)
        {
            var globalEntityModel = new GlobalEntityModel();
            globalEntityModel.ID = globalEntity.ID;
            globalEntityModel.EntityID = globalEntity.EntityID;
            globalEntityModel.EntityType = globalEntity.EntityType;
            globalEntityModel.AgencyName = globalEntity.AgencyName;
            globalEntityModel.Environment = globalEntity.Environment;
            globalEntityModel.CreatedBy = globalEntity.CreatedBy;
            globalEntityModel.Status = globalEntity.Status;

            if (globalEntity.CloudUserID.HasValue)
            {
                globalEntityModel.CloudUserID = globalEntity.CloudUserID.Value;
            }

            globalEntityModel.Keep1 = globalEntity.UDF1;
            globalEntityModel.Keep2 = globalEntity.UDF2;
            globalEntityModel.Keep3 = globalEntity.UDF3;
            globalEntityModel.Keep4 = globalEntity.UDF4;
            globalEntityModel.AssignTo = globalEntity.AssignTo;

            if (globalEntity.OpenedDate.HasValue)
            {
                globalEntityModel.OpenDate = globalEntity.OpenedDate.Value;
            }
            //globalEntityModel.ImageUrls = globalEntity.ImageUrl;

            if (globalEntity.CreatedDate.HasValue)
            {
                globalEntityModel.CreatedDate = globalEntity.CreatedDate.Value;
            }
            globalEntityModel.LastUpdatedBy = globalEntity.LastUpdatedBy;
            if (globalEntity.LastUpdatedDate.HasValue)
            {
                globalEntityModel.LastUpdatedDate = globalEntity.LastUpdatedDate.Value;
            }

            if (isContainGeoInfo && globalEntity.GeoCoordinates != null && globalEntity.GeoCoordinates.Count > 0)
            {
                var geoCoordinate = globalEntity.GeoCoordinates.First();
                if (geoCoordinate != null && geoCoordinate.CoordinateX.HasValue)
                {
                    globalEntityModel.Longitude = geoCoordinate.CoordinateX.ToString();
                }

                if (geoCoordinate != null && geoCoordinate.CoordinateY.HasValue)
                {
                    globalEntityModel.Latitude = geoCoordinate.CoordinateY.ToString();
                }
            }

            return globalEntityModel;
        }

        public IQueryable<GlobalEntity> GetGlobalEntitySearchQuery(IQueryable<GlobalEntity> query, IDictionary<string, string> searchConditions)
        {
            var status = searchConditions.Keys.Contains("Statuses") ? searchConditions["Statuses"] : string.Empty;
            var assignTo = searchConditions.Keys.Contains("AssignTo") ? searchConditions["AssignTo"] : string.Empty;
            var beginOpenedDate = searchConditions.Keys.Contains("BeginOpenedDate") ? searchConditions["BeginOpenedDate"] : string.Empty;
            var endOpenedDate = searchConditions.Keys.Contains("EndOpenedDate") ? searchConditions["EndOpenedDate"] : string.Empty;

            // Search
            if (!string.IsNullOrEmpty(status))
            {
                string[] findingStatuses = status.Split(',');
                for (int i = 0; i < findingStatuses.Length; i++)
                {
                    findingStatuses[i] = findingStatuses[i].Trim();
                }
                query = query.Where(entity => findingStatuses.Contains(entity.UDF4));
            }

            if (!string.IsNullOrEmpty(assignTo))
            {
                query = query.Where(entity => entity.AssignTo == assignTo);
            }

            if (!string.IsNullOrEmpty(beginOpenedDate) && !string.IsNullOrEmpty(endOpenedDate))
            {
                var beginDate = DateTimeFormat.ToDateTimeFromMetaDateTimeString(beginOpenedDate);
                var endDate = DateTimeFormat.ToDateTimeFromMetaDateTimeString(endOpenedDate);
                query = query.Where(entity => entity.OpenedDate.Value >= beginDate && entity.OpenedDate.Value <= endDate);
            }

            return query;
        }
    }
}
