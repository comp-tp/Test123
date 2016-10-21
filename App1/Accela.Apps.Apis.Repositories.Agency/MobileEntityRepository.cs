using Accela.Apps.Apis.Common;
using Accela.Apps.Apis.Models.Common;
using Accela.Apps.Apis.Models.DomainModels;
using Accela.Apps.Apis.Persistence;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Toolkits.Encrypt;
using Accela.Infrastructure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Accela.Apps.Apis.Repositories.Agency
{
    /// <summary>
    /// MobileEntity repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MobileEntityRepository<T> : RepositoryBase, IMobileEntityRepository<T>
    {
        IBinaryStorage _storage = null;
        public MobileEntityRepository(IBinaryStorage storage)
            : base() 
        {
            _storage = storage;
        }

        /// <summary>
        /// Insert an IMobileEntity object.
        /// </summary>
        /// <param name="entity">IMobileEntity object.</param>
        public void InsertEntity(IMobileEntity entity)
        {

            PersistedData persistedData = new PersistedData();
            persistedData.Id = Guid.NewGuid();
            persistedData.DataKey = entity.ObjectId;
            // name is blob name(file name)
            persistedData.Name = BuildBlobName(entity, MD5Helper.GetMd5Hash(persistedData.DataKey));
            // Do not know what is the difference between these two columns.
            persistedData.BlobName = persistedData.Name;
            // namespace is container name (folder name)
            persistedData.Namespace = entity.Namespace;
            persistedData.EntityType = entity.EntityType;
            persistedData.ProductName = entity.ProductName;
            persistedData.Agency = entity.Agency;
            persistedData.UserId = entity.UserId;
            //persistedData.Data = entity.ObjectData;
            persistedData.ExpirationDate = entity.ExpiresAfter;
            persistedData.DateCreated = entity.Timestamp;

            using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                apiDataContext.PersistedDatas.Add(persistedData);
                SqlRetryPolicy.ExecuteAction(() =>
                {
                    apiDataContext.SaveChanges();
                });
            }

            var key = new BlobKey(persistedData);
            _storage.CreateNewOrUpdate(key.container, key.blob, entity.ObjectData);
        }

        /// <summary>
        /// Batch insert IMobileEntity object.
        /// </summary>
        /// <param name="entities">an IMobileEntity collection.</param>
        public void InsertEntities(IList<IMobileEntity> entities)
        {
            if (entities == null || entities.Count == 0)
            {
                return;
            }

            var persistedDataList = new List<PersistedData>();

            foreach (IMobileEntity entity in entities)
            {
                PersistedData persistedData = new PersistedData();
                persistedData.Id = Guid.NewGuid();
                persistedData.DataKey = entity.ObjectId;
                // name is blob name(file name)
                persistedData.Name = BuildBlobName(entity, MD5Helper.GetMd5Hash(persistedData.DataKey));
                // namespace is container name (folder name)
                persistedData.Namespace = entity.Namespace;
                persistedData.EntityType = entity.EntityType;
                persistedData.ProductName = entity.ProductName;
                persistedData.Agency = entity.Agency;
                persistedData.UserId = entity.UserId;
                persistedData.Data = entity.ObjectData;
                persistedData.ExpirationDate = entity.ExpiresAfter;
                persistedData.DateCreated = entity.Timestamp;
                persistedDataList.Add(persistedData);
            }

            using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                persistedDataList.ForEach(p =>
                {
                    apiDataContext.PersistedDatas.Add(p);
                });

                SqlRetryPolicy.ExecuteAction(() =>
                {
                    apiDataContext.SaveChanges();
                });
            }

            persistedDataList.ForEach(p => {
                var key = new BlobKey(p);
                _storage.CreateNewOrUpdate(key.container, key.blob, p.Data);
            }
            );
        }

        /// <summary>
        /// Updates an IMobileEntity object.
        /// </summary>
        /// <param name="entity">IMobileEntity object.</param>
        public void UpdateEntity(IMobileEntity entity)
        {
            PersistedData updatedEntity = null;

            using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                SqlRetryPolicy.ExecuteAction(() =>
                {
                    updatedEntity = apiDataContext.PersistedDatas.First(
                                    m => m.EntityType == entity.EntityType
                                        && m.ProductName == entity.ProductName
                                        && m.Agency == entity.Agency
                                        && m.UserId == entity.UserId
                                        && m.Namespace == entity.Namespace
                                        && m.DataKey == entity.ObjectId);
                });
            }

            if (updatedEntity != null)
            {
                var key = new BlobKey(updatedEntity);
                _storage.CreateNewOrUpdate(key.container, key.blob, entity.ObjectData);
            }
        }

        /// <summary>
        /// Delete an IMobileEntity object.
        /// </summary>
        /// <param name="entity">IMobileEntity object.</param>
        public void DeleteEntity(IMobileEntity entity)
        {
            try
            {
                PersistedData deletedEntity = null;

                using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
                {
                    SqlRetryPolicy.ExecuteAction(() =>
                    {
                        deletedEntity = apiDataContext.PersistedDatas.FirstOrDefault(
                                m => m.EntityType == entity.EntityType
                                    && m.ProductName == entity.ProductName
                                    && m.Agency == entity.Agency
                                    && m.UserId == entity.UserId
                                    && m.Namespace == entity.Namespace
                                    && m.DataKey == entity.ObjectId);
                    });

                    if (deletedEntity != null)
                    {
                        apiDataContext.PersistedDatas.Remove(deletedEntity);
                        apiDataContext.SaveChanges();
                    }
                }

                // DO NOT instantly delete blob at runtime for performance; will be done by maintenance
                /*
                if (deletedEntity != null)
                {
                    var container = "apicachedata-" + deletedEntity.ExpirationDate.ToString("yyyy-MM-dd");
                    var blob = deletedEntity.Namespace + "/" + deletedEntity.BlobName;
                    _storage.DeleteIfExists(key.container, key.blob);
                }*/
            }
            catch (Exception ex)
            {
                Log.Error(ex, "DeleteEntity");
                throw;
            }
        }

        /// <summary>
        /// Delete user's cached data.
        /// </summary>
        /// <param name="scope">IEntityScope.</param>
        public void DeleteEntitiesByUser(IEntityScope scope)
        {
            List<PersistedData> deletingItems = null;

            using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                SqlRetryPolicy.ExecuteAction(() =>
                {
                    deletingItems = apiDataContext.PersistedDatas.Where
                        (item => item.Agency == scope.Agency
                                && item.ProductName == scope.ProductName
                                && item.UserId == scope.UserId
                        ).ToList();
                });

                if (deletingItems != null && deletingItems.Count > 0)
                {
                    foreach (var item in deletingItems)
                    {
                        apiDataContext.PersistedDatas.Remove(item);
                    }

                    SqlRetryPolicy.ExecuteAction(() =>
                    {
                        apiDataContext.SaveChanges();
                    });
                }
            }
            // DO NOT instantly delete blob at runtime for performance; will be done by maintenance
            /*
            if (deletingItems != null && deletingItems.Count > 0)
            {
                deletingItems.ForEach(p =>
                {
                    var container = "apicachedata-" + p.ExpirationDate.ToString("yyyy-MM-dd");
                    var blob = p.Namespace + "/" + p.BlobName;
                    _storage.DeleteIfExists(key.container, key.blob);
                });
            }*/
        }

        /// <summary>
        /// Get an instance of T by entity id.
        /// </summary>
        /// <param name="scope">entity scope.</param>
        /// <param name="entityId">entity id.</param>
        /// <param name="isInvariantCulture">is invariant culture for cache, 
        /// ture: cache are different against different culture, 
        /// false: cache are same against different culture</param>
        /// <returns>an instance of T.</returns>
        public K GetObjectById<K>(IEntityScope scope, string entityId, bool isInvariantCulture = false)
        {
            object useStub;

            if (this.CurrentContext.Items != null && this.CurrentContext.Items.TryGetValue("isUsingStub", out useStub))
            {
                bool isUsingStub = false;

                if (useStub != null && bool.TryParse(useStub.ToString(), out isUsingStub))
                {
                    if (isUsingStub)
                    {
                        return default(K);
                    }
                }
            }

            K returnedObject = default(K);
            PersistedData getEntity = null;

            using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                SqlRetryPolicy.ExecuteAction(() =>
                {
                    getEntity = apiDataContext.PersistedDatas.FirstOrDefault(
                            m => m.EntityType == scope.EntityType
                                && m.ProductName == scope.ProductName
                                && m.Agency == scope.Agency
                                && m.UserId == scope.UserId 
                                && (isInvariantCulture ? true : m.Namespace == scope.Namespace)
                                && m.DataKey == entityId
                                && m.ExpirationDate > DateTime.UtcNow);
                });
            }

            if (getEntity != null)
            {
                var key = new BlobKey(getEntity);
                string jsonString = _storage.ReadAsString(key.container, key.blob);

                if (!String.IsNullOrWhiteSpace(jsonString))
                {
                    returnedObject = JsonConverter.FromJsonTo<K>(jsonString);
                }
            }

            return returnedObject;
        }

        /// <summary>
        /// Get All entities.
        /// </summary>
        /// <param name="scope">entity scope.</param>
        /// <returns>a T list.</returns>
        public IList<T> GetEntities(IEntityScope scope)
        {
            IList<T> resultEntities = new List<T>();
            List<PersistedData> persistedDatas = null;

            // TODO:
            // Changes this later.
            //using (PersistenceEngineEntities objectContext = new PersistenceEngineEntities(ConnectiongStrings.PersistenceEngine))
            using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                var query = from p in apiDataContext.PersistedDatas
                            where p.EntityType == scope.EntityType
                                && p.ProductName == scope.ProductName
                                && p.Agency == scope.Agency
                                && p.UserId == scope.UserId
                                && p.Namespace == scope.Namespace
                                && p.ExpirationDate > DateTime.UtcNow
                            select p;

                SqlRetryPolicy.ExecuteAction(() =>
                {
                    persistedDatas = query.ToList<PersistedData>();
                });

            }

            if (persistedDatas != null && persistedDatas.Count > 0)
            {
                var t = Task.Run(async () =>
                {
                    foreach (PersistedData entity in persistedDatas)
                    {
                        var key = new BlobKey(entity);
                        string jsonString = await _storage.ReadAsStringAsync(key.container, key.blob);

                        if (!String.IsNullOrWhiteSpace(jsonString))
                        {
                            var obj = JsonConverter.FromJsonTo<T>(entity.Data);
                            if (obj != null)
                            {
                                resultEntities.Add(obj);
                            }
                        }
                    }
                });

                t.Wait();
            }

            return resultEntities;
        }

        /// <summary>
        /// Query T with an expression.
        /// </summary>
        /// <param name="scope">entity scope.</param>
        /// <param name="expression">filter expression.</param>
        /// <returns>a T list.</returns>
        public IList<T> Query(IEntityScope scope, Expression<Func<T, bool>> expression)
        {
            IList<T> allData = GetEntities(scope);
            IQueryable<T> query = allData.AsQueryable<T>();
            IList<T> result = query.Where<T>(expression).ToList<T>();

            return result;
        }


        /// <summary>
        /// NOTE: this method is not effecient; will use DB SP and Automation to maintain in batch
        /// Removes the expired entities.
        /// </summary>
        public void RemoveExpiredItems()
        {
            try
            {
                List<PersistedData> expiredItems = null;

                using (var apiDataContext = new ApiDataContext(ConnectionStrings.ApiDB))
                {
                    expiredItems = apiDataContext.PersistedDatas.Where(item => item.ExpirationDate < DateTime.UtcNow).ToList();

                    if (expiredItems.Count > 0)
                    {
                        foreach (var item in expiredItems)
                        {
                            apiDataContext.PersistedDatas.Remove(item);
                        }

                        SqlRetryPolicy.ExecuteAction(() =>
                        {
                            apiDataContext.SaveChanges();
                        });
                    }
                }

                if (expiredItems != null && expiredItems.Count > 0)
                {
                    expiredItems.ForEach(p =>
                    {
                        var key = new BlobKey(p);
                        _storage.DeleteIfExistsAsync(key.container, key.blob);
                    });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "RemoveExpiredItems");
                throw;
            }
        }

        /// <summary>
        /// Generates the blob name. 
        /// </summary>
        /// <param name="scope">Entity Scope.</param>
        /// <param name="blobKey">blob key.</param>
        /// <returns>blob name.</returns>
        public string BuildBlobName(IEntityScope scope, string blobKey)
        {
            // {UserID}/{ProductName}/{Agency}/{EntityType}/EntityId
            string blobName = String.Format("{0}/{1}/{2}/{3}",
                scope.ProductName,
                scope.Agency,
                scope.EntityType,
                blobKey);

            return blobName.ToLower();
        }

        /// <summary>
        /// Generates the blob name. 
        /// </summary>
        /// <param name="userId">user id.</param>
        /// <param name="agency">agency.</param>
        /// <param name="entityType">entity type.</param>
        /// <param name="blobKey">blob key.</param>
        /// <returns>blob name.</returns>
        private string BuildBlobName(string app, string userId, string agency, string entityType, string blobKey)
        {
            string tmpUserId = userId;

            if (String.IsNullOrWhiteSpace(tmpUserId))
            {
                tmpUserId = "GLOBAL";
            }

            string tmpAgency = agency;
            if (String.IsNullOrWhiteSpace(agency))
            {
                tmpAgency = "GLOBAL";
            }

            // {UserID}/{ProductName}/{Agency}/{EntityType}/EntityId
            string blobName = String.Format("{0}/{1}/{2}/{3}/{4}",
                tmpUserId,
                app,
                tmpAgency,
                entityType,
                blobKey);

            return blobName.ToLower();
        }


        private class BlobKey
        {
            public string container;
            public string blob;
            public BlobKey(PersistedData persistedData)
            {
                container = CacheConstants.API_TEMPDATA_CONTAINER_PREFIX + persistedData.ExpirationDate.ToString(CacheConstants.API_TEMPDATA_CONTAINER_DATEFORMAT);
                blob = persistedData.Namespace + "/" + persistedData.BlobName;
            }
        }
    }

}
