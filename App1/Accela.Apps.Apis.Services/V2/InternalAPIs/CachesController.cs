using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.WSModels.Caches;
using Accela.Core.Ioc;
using Accela.Core.Utilities;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Cache;
using Accela.Apps.Shared.Exceptions;
using Accela.Apps.Shared.WSModels;

using System.Web.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Accela.Infrastructure.Caches;

namespace Accela.Apps.Apis.Services.V2.InternalAPIs
{
    [RoutePrefix("apis/v3/caches")]
    public class CachesController : ControllerBase
    {

        private readonly IPersistedDataBusinessEntity _persistedDataBusinessEntity;
        private readonly CacheStoreProvider cacheStoreProvider;
        private readonly IMemoryCacheProvider memoryCacheProvider;

        public CachesController(CacheStoreProvider cacheProvider, IPersistedDataBusinessEntity persistedDataBusinessEntity, IMemoryCacheProvider memoryCacheProvider)
        {
            this.cacheStoreProvider = cacheProvider;
            _persistedDataBusinessEntity = persistedDataBusinessEntity;
            this.memoryCacheProvider = memoryCacheProvider;
        }


        /// <summary>
        /// Deletes Cache Key from Cache Provider
        /// </summary>
        /// <param name="cacheType"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{cacheType}/{key}")]
        public HttpResponseMessage RemoveCacheKey(string cacheType, string key)
        {
            if (String.IsNullOrWhiteSpace(cacheType))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid cacheType - Provide one of cacheTypes: Redis, InMemory, all");
            }
            if (String.IsNullOrWhiteSpace(key))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid cache key.");
            }
            
            //todo: use enum for cacheTypes.
            switch (cacheType.ToLower())
            {
                case "redis":
                    cacheStoreProvider.Instance.Remove(key);
                    break;
                case "inmemory":
                    memoryCacheProvider.Instance.Remove(key);
                    break;
                case "all":
                    cacheStoreProvider.Instance.Remove(key);
                    memoryCacheProvider.Instance.Remove(key);
                    break;
                default:
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Cache type is not supported.");
            }
            //return HttpCode 204 - for successful delete
            return Request.CreateResponse(HttpStatusCode.NoContent, string.Format("Successfully removed cache key {0}.", key));
        }


        [Route("{key}")]
        public GenericResultResponse<string> GetCacheContentByCacheKey(string key)
        {
            if (String.IsNullOrWhiteSpace(key))
            {
                throw new BadRequestException("Cache key is required.", "", ErrorCodes.data_validation_error_400);
            }

            var result = new GenericResultResponse<string>();
            var obj = cacheStoreProvider.Instance.Get(key.ToLower());
            if (obj == null)
            {
                result.Result = "null";
            }
            else
            {
                result.Result = JsonConvert.SerializeObject(obj);
            }

            return result;
        }

        [Route("remove")]
        [HttpPut]
        public GenericResultResponse<string> Clear([FromBody] WSClearCacheRequest request, bool returnCachedObjectOnly = false)
        {
            try
            {
                if (request == null)
                {
                    throw new BadRequestException("request is null, please check request body.", "", ErrorCodes.data_validation_error_400);
                }

                if (request.CacheKeys == null || request.CacheKeys.Length == 0)
                {
                    throw new BadRequestException("cacheKey is required.", "", ErrorCodes.data_validation_error_400);
                }

                if (Log.IsDebugEnabled)
                {
                    Log.Debug("CacheKey are " + request.CacheKeys == null ? "null" : request.CacheKeys.ToStringWithComma(), null, "/apis/v3/caches");
                }

                if (returnCachedObjectOnly)
                {
                    if (request.CacheKeys.Length > 1)
                    {
                        throw new BadRequestException("only support one cache key for getting cache object.", "", ErrorCodes.data_validation_error_400);
                    }

                    return GetCacheContentByCacheKey(request.CacheKeys[0]);
                }


                foreach (var k in request.CacheKeys)
                {
                    var key = k.ToLower();
                    switch (key)
                    {
                        case CacheKeys.AGENCIES:
                        case CacheKeys.ENVIRONMENTS:
                        case CacheKeys.HOSTS:
                            key = CacheKeys.HOSTS; // all host/agency/environment related are put into global cache GLOBAL_CACHES_HOSTS
                            break;
                    }

                    ClearCacheByKey(key);
                }

                var result = new GenericResultResponse<string>
                {
                    Result = String.Concat("Clear Cache by cache key - '", request.CacheKeys.ToStringWithComma(), "' successfully.")
                };

                if (Log.IsDebugEnabled)
                {
                    Log.Debug("CacheKeys are " + request.CacheKeys.ToStringWithComma(), result.Result, "/apis/v3/caches");
                }

                return result;
            }
            catch (BadRequestException be)
            {
                throw be;
            }
            catch (Exception ex)
            {
                throw new MobileException(ex.Message, ex);
            }
        }

        private void ClearCacheByKey(string cacheKey)
        {
            if (cacheStoreProvider == null || cacheStoreProvider.Instance == null)
            {
                Log.Critical("Can't get cache instance.", null, "ClearCacheByKey in /apis/v3/caches");
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(cacheKey))
                {
                    cacheKey = cacheKey.ToLowerInvariant();
                    bool successToRemove = false;
                    for (int i = 0; i < 3 && !successToRemove; i++)
                    {
                        try
                        {
                            cacheStoreProvider.Instance.Remove(cacheKey);
                            memoryCacheProvider.Instance.Remove(cacheKey);
                            successToRemove = true;
                        }
                        catch (Exception ex)
                        {
                            Log.Error(String.Format("Remove cache: {0} failed - {1} times.", cacheKey, i + 1), ex.ToString(), "ClearCacheByKey in /apis/v3/caches");
                            successToRemove = false;
                        }
                    }
                }
            }
        }


        [Route("")]
        public WSGetCacheResponse GetCaches(string agency = null)
        {
            var persistedDataModels = _persistedDataBusinessEntity.GetPersistedDatas(agency);
            return WSGetCacheResponse.FromEntityModel(persistedDataModels);
        }

        [HttpDelete]
        [Route("clear")]
        public GenericResultResponse<Boolean> ClearCaches(string agency = null, string cachetype = null)
        {
            // below clear all memory caches only, and won't be used "clear cache" in admin portal.
            if ("all".Equals(agency, StringComparison.OrdinalIgnoreCase)
                && "all".Equals(cachetype, StringComparison.OrdinalIgnoreCase)
                )
            {
                var isSuccess = ClearAllMemoryCaches();
                return new GenericResultResponse<Boolean>
                {
                    Result = isSuccess
                };
            }
            else {
                var isSuccess = _persistedDataBusinessEntity.DeletePersistedDatas(agency, cachetype);
                return new GenericResultResponse<Boolean>
                {
                    Result = isSuccess
                };
            }
        }

        private bool ClearAllMemoryCaches()
        {
            bool result = false;

            try
            {
                this.cacheStoreProvider.Instance.Clear();
                memoryCacheProvider.Instance.Clear();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }
    }
}
