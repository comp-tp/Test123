using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DomainModels.ResourceModels;
using Accela.Apps.Apis.Models.DTOs.Requests.ResourceRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ResourceResponses;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Apis.Resources;
using Accela.Core.Ioc;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Cache;
using Accela.Apps.Shared.Exceptions;
using Accela.Apps.Shared.Contexts;
using Accela.Core.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Caching;
using Accela.Infrastructure.Configurations;
using Accela.Infrastructure.Caches;

namespace Accela.Apps.Apis.BusinessEntities
{
    public class ResourceBusinessEntity : BusinessEntityBase, IResourceBusinessEntity
    {
        class ResourceUrlSegmentComparer : IEqualityComparer<String>
        {
            public bool Equals(String x, String y)
            {
                //Check whether the compared objects reference the same data. 
                if (Object.ReferenceEquals(x, y)) return true;

                //Check whether any of the compared objects is null. 
                if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                    return false;

                //Check whether the products' properties are equal. 
                return x.Equals(y, StringComparison.OrdinalIgnoreCase);
            }

            public int GetHashCode(String name)
            {
                //Check whether the object is null 
                return Object.ReferenceEquals(name, null) ? 0 : name.GetHashCode();
            }
        }

        private const string RESOURCE_CACHE_EXPIRATION_MINUTES = "ResourceCacheExpirationMinutes";
        private readonly IMemoryCacheProvider cacheStoreProvider;
        private readonly IResourceRepository ResourceRepository;
        private readonly IConfigurationReader _configurationReader;
        //private readonly IAgencyAppContext _context;

        public ResourceBusinessEntity(IResourceRepository resourceRepository, IMemoryCacheProvider cacheStoreProvider, IConfigurationReader configurationReader)
        {
            this.ResourceRepository = resourceRepository;
            this.cacheStoreProvider = cacheStoreProvider;
            this._configurationReader = configurationReader;
        }

        /// <summary>
        /// Get resource model by resource id.
        /// </summary>
        /// <param name="resourceId">resource id(guid).</param>
        /// <returns>resource model.</returns>
        public ResourceModel GetResourceById(Guid resourceId)
        {
            return ResourceRepository.GetResourceById(resourceId);
        }

        /// <summary>
        /// Get resource by request url and http method. 
        /// </summary>
        /// <param name="absoluteUrlPath">The request absolute url. e.g /v3/reports</param>
        /// <param name="httpMethod">http method, e.g GET,POST,PUT,DELETE etc.</param>
        /// <returns>return ResourceModel if matched resource is found, otherwise returns null.</returns>
        public ResourceModel GetResource(string absoluteUrlPath, string httpMethod)
        {
            if (String.IsNullOrWhiteSpace(absoluteUrlPath) || String.IsNullOrWhiteSpace(httpMethod))
            {
                throw new MobileException(MobileResources.GetString("getresource_parameter_incorrect"), "", ErrorCodes.internal_server_error_500);
            }

            char[] separator = new char[] { '/' };

            absoluteUrlPath = RemoveSlashFromEnd(absoluteUrlPath);
            string[] urlSegments = absoluteUrlPath.Split(separator);

            // same pattern for api doc
            var samePattern = CachedResources.FirstOrDefault(r => r.Api.Equals(absoluteUrlPath, StringComparison.OrdinalIgnoreCase) && r.HttpVerb.Equals(httpMethod, StringComparison.OrdinalIgnoreCase));
            if(samePattern != null)
            {
                return samePattern;
            }

            var theSameHttpVerbResources = CachedResources.FindAll(resource => resource.HttpVerb.Equals(httpMethod, StringComparison.OrdinalIgnoreCase));
            //theSameHttpVerbResources.ForEach(resource => resource.Api = RemoveSlashFromEnd(resource.Api));

            var theSameLengthResources = theSameHttpVerbResources.FindAll(resource => resource.Api.Split(separator).Length == urlSegments.Length);
            var resourcesWithoutCurlyBraces = theSameLengthResources.FindAll(resource => !resource.Api.Contains("{"));
            var resourceExactMatch = resourcesWithoutCurlyBraces.Find(resource =>
            {
                string[] tmpUrlSegments = resource.Api.Split(separator);
                return tmpUrlSegments.SequenceEqual(urlSegments, new ResourceUrlSegmentComparer());
            });

            if (resourceExactMatch != null)
            {
                return resourceExactMatch;
            }

            var resourcesWithCurlyBraces = theSameLengthResources.FindAll(resource => resource.Api.Contains("{"));

            Dictionary<string, string> key_values = new Dictionary<string, string>();

            var resourceMatch = resourcesWithCurlyBraces.Find(resource =>
            {
                string[] tmpUrlSegments = resource.Api.Split(separator);
                
                for (int i = 0; i < urlSegments.Length; i++)
                {
                    if (tmpUrlSegments[i].StartsWith("{"))
                    {
                        key_values[tmpUrlSegments[i]] = urlSegments[i];
                        continue;
                    }

                    if (!tmpUrlSegments[i].Equals(urlSegments[i], StringComparison.OrdinalIgnoreCase))
                    {
                        return false;
                    }
                }

                // in memory cache, the API Paramter raises concurrent issue
                //resource.APIPrameters = key_values;
                return true;
            });

            ResourceModel result = null;
            if(resourceMatch != null)
            {
                result = resourceMatch.Clone();
                result.APIPrameters = key_values;
            }

            return result;
        }

        public ResourcesResponse GetResources(ResourcesFilter request)
        {
            ResourcesResponse result = new ResourcesResponse();

            if (request.ResourceId != null && request.ResourceId != Guid.Empty)
            {
                result.Resources.Add(ResourceRepository.GetResourceById(request.ResourceId));
                return result;
            }

            IEnumerable<ResourceModel> resources;

            resources = CachedResources;

            if(!String.IsNullOrWhiteSpace(request.Api))
                resources = resources.Where(item => (item.Api.Contains(request.Api)));
            if (!String.IsNullOrWhiteSpace(request.HttpMethod))
                resources = resources.Where(item => item.HttpVerb == request.HttpMethod);

            if (!String.IsNullOrWhiteSpace(request.Ids))
                resources = resources.Where(item => request.Ids.Contains(item.Id.ToString().ToUpper())); 


            
            result.Resources = resources.ToList();
            return result;
        }


        public ResourcesResponse SaveResources(List<ResourceModel> resourcesRequest)
        {
            ResourcesResponse result = new ResourcesResponse();
            result.Resources= ResourceRepository.SaveResources(resourcesRequest,false);
            ClearResourcesCache(result.Resources);
            return result;
        }


        public ResourcesResponse UpdateResource(ResourceModel request)
        {
            ResourcesResponse result = new ResourcesResponse();
            result.Resources = ResourceRepository.SaveResources(new List<ResourceModel> { request }, true);
            ClearResourcesCache(result.Resources);
            return result;
        }


        public bool DeleteResource(Guid resourceId)
        {
            var result = ResourceRepository.DeleteResource(resourceId);
            if (result)
                ClearResourcesCache();
            return result;
            
        }
    /// <summary>
    /// Get cached resources.
    /// </summary>
    private List<ResourceModel> CachedResources
        {
            get
            {
                List<ResourceModel> cachedResources = null;
                try
                {
                    cachedResources = cacheStoreProvider.Instance.Get(CacheKeys.RESOURCES) as List<ResourceModel>;
                }
                catch(Exception ex)
                {
                    LogEntity logData = new LogEntity {
                        Message = ex.Message,
                        Detail = ex.ToString(),
                        MethodName = "CachedResources"
                    };
                    Log.Critical(logData);
                }
                

                if (cachedResources == null || cachedResources.Count == 0)
                {
                    // read resources from db
                    List<ResourceModel> resources = ResourceRepository.GetResources();
                 
                    try
                    {
                        /*
                         * And the code to fix the routing issue for APIs which are in the following format:
                         * 
                         * GET /v4/inspections/{inspectionId}/conditions/{id}
                         * GET /v4/inspections/{inspectionId}/conditions/permission
                         * 
                         * We need to match the URL which has the least curly braces first.
                         * Put this kind of code in here to let then execute once.
                        //*/
                        resources.Sort((x, y) =>
                        {
                            var amountOfCurlyBracesX = x.Api.Count(c => c == '{');
                            var amountOfCurlyBracesY = y.Api.Count(c => c == '{');
                            return amountOfCurlyBracesX - amountOfCurlyBracesY;
                        });

                        // CF-1272 Configure API resource in-memory time out
                        // Get Recource Cache Expiration Minutes From Congiguration 
                        var cacheExpirationMinutes = double.Parse(_configurationReader.Get(RESOURCE_CACHE_EXPIRATION_MINUTES, "15"));
                        cacheStoreProvider.Instance.Put(CacheKeys.RESOURCES, resources, System.DateTime.UtcNow.AddMinutes(cacheExpirationMinutes));
                    }
                    catch (Exception ex)
                    {
                        Log.Critical(ex.Message, ex.ToString(), "CachedResources-Get");
                    }

                    if (resources != null)
                    {
                        resources.ForEach(resource => resource.Api = RemoveSlashFromEnd(resource.Api));
                    }

                    cachedResources = resources;
                }

                return cachedResources;
            }
        }

        /// <summary>
        /// remove '/' if end with char is '/'
        /// </summary>
        /// <param name="value">Original string.</param>
        /// <returns>result string.</returns>
        private string RemoveSlashFromEnd(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return String.Empty;
            }

            if (value.EndsWith("/"))
            {
                value = value.Remove(value.Length - 1, 1);
            }

            return value;
        }

        private void ClearResourcesCache(List<ResourceModel> resources)
        {
            var updatedResource = resources.Where(c => c.resourceUpdated || c.resourceAdded).FirstOrDefault();
            if (updatedResource != null)
                ClearResourcesCache();
        }


        private void ClearResourcesCache()
        {
            try
            {
                cacheStoreProvider.Instance.Remove(CacheKeys.RESOURCES);
                cacheStoreProvider.Instance.Remove(CacheKeys.SCOPES);
            }
            catch (Exception ex)
            {
                LogEntity logData = new LogEntity
                {
                    Message = ex.Message,
                    Detail = ex.ToString(),
                    MethodName = "ClearResourcesCache()"
                };
                Log.Critical(logData);
            }

        }
    }

    
}
