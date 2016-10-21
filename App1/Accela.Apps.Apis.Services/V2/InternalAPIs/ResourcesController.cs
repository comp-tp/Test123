using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DomainModels.ResourceModels;
using Accela.Apps.Apis.Models.DomainModels.Scope;
using Accela.Apps.Apis.Models.DTOs.Requests.ResourceRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ResourceResponses;
using Accela.Apps.Apis.WSModels.Resources;
using Accela.Core.Ioc;
using Accela.Apps.Shared;
using Accela.Infrastructure.Caches;

using System.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using Accela.Apps.Shared.Exceptions;
using Accela.Apps.Shared.WSModels;
using System.Net;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("apis/v3/resources")]
    public class ResourcesController : ControllerBase
    {

        private readonly IResourceBusinessEntity resourceBusinessEntity;
        private readonly IScopeBusinessEntity scopeBusinessEntity;

        public ResourcesController(IResourceBusinessEntity resourceBusinessEntity, IScopeBusinessEntity scopeBusinessEntity)
        {
            this.resourceBusinessEntity = resourceBusinessEntity;
            this.scopeBusinessEntity = scopeBusinessEntity;
        }

        [Route("")]
        //v3/resources?api=agencies 
        //v3/resources?api=v4&httpmethod=GET
        //v3/resources?Id=B6385F30-4DA0-11E2-A346-005056C10006,B6385F30-4DA0-11E2-A346-005056C10009,B6385F30-4DA0-11E2-A346-005056C10010,B6385F30-4DA0-11E2-A346-005056C10011,B6385F30-4DA0-11E2-A346-005056C10900   - comma separeated id

        public WSResourcesResponse GetResources( [FromUri]string api = null, [FromUri]string httpmethod = null, [FromUri]string id = null)
        {
            ResourcesFilter request = new ResourcesFilter();

            if (!string.IsNullOrWhiteSpace(api))
                    request.Api = api.ToLower();

            if(!string.IsNullOrWhiteSpace(httpmethod))
                    request.HttpMethod = httpmethod.ToUpper();

            if (!string.IsNullOrWhiteSpace(id))
                request.Ids = id.TrimEnd(',').ToUpper();
            

            var resourcesResponse = ExcuteV1_2(r => { return resourceBusinessEntity.GetResources(r); }, request);
            var scopes = scopeBusinessEntity.GetScopes();
            return WSResourcesResponse.FromEntityModel(resourcesResponse,false,scopes);
        }


        [Route("{id}")]
        //v3/resources/{id}
        public WSResourcesResponse GetResourceById(string id)
        {
            ResourcesFilter request = new ResourcesFilter();

            Guid agencyId;
            if (Guid.TryParse(id, out agencyId))
                request.ResourceId = agencyId;
            else
                throw new BadRequestException("Invalid Api Id provided in Uri.", "", "invalid_request");

            var resourcesResponse = ExcuteV1_2(r => {  return resourceBusinessEntity.GetResources(r);}, request);
            var scopes = scopeBusinessEntity.GetScopes();
            return WSResourcesResponse.FromEntityModel(resourcesResponse,false, scopes);
        }


        [Route("")]
        public WSResourcesResponse AddResources([FromBody]WSResourceInfoRequest[] resourceInfoRequests)
        {
           
            List<ResourceModel> resourcesRequest = new List<ResourceModel>();

            foreach (WSResourceInfoRequest resourceInfo in resourceInfoRequests)
            {
                ResourceModel resourceRequest = new ResourceModel();
                resourceRequest.canSaveResource = String.IsNullOrWhiteSpace(validateSaveResource(resourceInfo)) ? true : false;
                resourceRequest.Api = resourceInfo.Api;
                resourceRequest.HttpVerb = resourceInfo.HttpMethod.ToUpper();

                if (resourceRequest.canSaveResource)
                {
                    resourceRequest.UriTemplate = resourceInfo.TemplateUri;
                    resourceRequest.Name = resourceInfo.Scope;
                    resourceRequest.Scope = resourceInfo.Scope;
                    resourceRequest.ScopeGroup = resourceInfo.ScopeGroup;
                    resourceRequest.AuthenticationType = (int)((APIAuthentication)Enum.Parse(typeof(APIAuthentication), resourceInfo.AuthenticationType,true));
                    resourceRequest.ProxyAPI = resourceInfo.ProxyUri;
                    resourceRequest.ProxyRemoteServerName = resourceInfo.ProxyServerName;
                }
                resourcesRequest.Add(resourceRequest);
            }
            WSResourcesResponse response = new WSResourcesResponse();
            var resourcesResponse = resourceBusinessEntity.SaveResources(resourcesRequest);
            response = WSResourcesResponse.FromEntityModel(resourcesResponse,true,null);
            response.Resources.Where(resource => (!resource.canSaveResource)).Select(s => { s.Message = validateSaveResource(resourceInfoRequests.Where(r => ((r.Api.ToLower() == s.Api.ToLower()) && (r.HttpMethod.ToUpper() == s.HttpVerb))).FirstOrDefault()); return s; }).ToList();
            response.Resources.Where(resource => (!resource.canSaveResource)).Select(s => { s.Status = (int)System.Net.HttpStatusCode.BadRequest; return s; }).ToList();
            return response;
        }

        [Route("{id}")]
        [HttpPut]
        public GenericResultResponse<string> UpdateResource([FromUri] string id ,[FromBody]WSResourceInfoRequest resourceInfoRequest)
        {

            Guid resourceId;
            if (Guid.TryParse(id, out resourceId))
                resourceInfoRequest.AgencyId = resourceId;
            else
                throw new BadRequestException("Invalid Api Id provided in Uri.", "", "invalid_request");

            string validationError = validateSaveResource(resourceInfoRequest);
            if (!String.IsNullOrWhiteSpace(validationError))
                throw new BadRequestException(validationError, "", "invalid_request");

            WSResourcesResponse response = new WSResourcesResponse();

            ResourceModel request = new ResourceModel()
            {
                Id = resourceInfoRequest.AgencyId,
                Api =  resourceInfoRequest.Api,
                canSaveResource = true,
                HttpVerb = resourceInfoRequest.HttpMethod.ToUpper(),                
                UriTemplate = resourceInfoRequest.TemplateUri,
                Name = resourceInfoRequest.Scope,
                Scope = resourceInfoRequest.Scope,
                ScopeGroup =  resourceInfoRequest.ScopeGroup,
                AuthenticationType = resourceInfoRequest.AuthenticationType == null ? -1 : (int)((APIAuthentication)Enum.Parse(typeof(APIAuthentication), resourceInfoRequest.AuthenticationType,true)),
                ProxyAPI = resourceInfoRequest.ProxyUri,
                ProxyRemoteServerName = resourceInfoRequest.ProxyServerName
            };
            

            GenericResultResponse<string> result = new GenericResultResponse<string>();
            var resourcesResponse = resourceBusinessEntity.UpdateResource(request);
            bool isSuccess = false;
            foreach(ResourceModel resouceModel in resourcesResponse.Resources)
            {
                isSuccess = resouceModel.resourceUpdated;
            }
            result.Status= isSuccess ? (int) HttpStatusCode.OK : (int)HttpStatusCode.NotFound;
            result.Result = isSuccess ? "API successfully updated." : "API with Id : " + resourceId.ToString() + " not found in database.";
            return result;
        }

        [Route("{id}")]
        [HttpDelete]
        public GenericResultResponse<string> DeleteResource([FromUri] string id)
        {
            
            Guid agencyId;
            if (!Guid.TryParse(id, out agencyId))
                throw new BadRequestException("Invalid Api Id provided in Uri.", "", "invalid_request");

            GenericResultResponse<string> result = new GenericResultResponse<string>();
            var isSuccess = resourceBusinessEntity.DeleteResource(agencyId);
            result.Status = isSuccess ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound;
            result.Result = isSuccess ? "API successfully deleted." : "API with Id : " + agencyId.ToString() + " not found in database.";
            return result;
        }





        private string validateSaveResource(WSResourceInfoRequest resourceRequest)
        {
            string validationResponse = "";

            if (String.IsNullOrWhiteSpace(resourceRequest.Api))
                validationResponse = "Empty or null value for api.";

            if (String.IsNullOrWhiteSpace(resourceRequest.HttpMethod))
                validationResponse += "Empty or null  value for httpMethod.";
            else
                if (!(new[] { "POST", "PUT", "GET", "DELETE" }).Contains(resourceRequest.HttpMethod.ToUpper()))
                    validationResponse += resourceRequest.HttpMethod + " is not a valid value for httpMethod. Allowed values - 'GET', 'PUT', 'POST', 'DELETE'.";

            if (String.IsNullOrWhiteSpace(resourceRequest.TemplateUri))
                validationResponse += "Empty or null value for templateUri.";

            if (String.IsNullOrWhiteSpace(resourceRequest.Scope))
                validationResponse += "Empty or null value for scope.";

            if (String.IsNullOrWhiteSpace(resourceRequest.ScopeGroup))
                validationResponse += "Empty or null value for scopeGroup.";


            if (String.IsNullOrWhiteSpace(resourceRequest.AuthenticationType))
                validationResponse += "Empty or null  value for authenticationType.";
            else
            {
                APIAuthentication authType;
                if (!Enum.TryParse(resourceRequest.AuthenticationType, true, out authType))
                    validationResponse += resourceRequest.AuthenticationType + " is not a valid value for authenticationType. Allowed values - 'None', 'UserCredential', 'AppCredential', 'AccessKey', 'UserIdentityACAAnonymous', 'UserIdentityAA'.";
            }

            if (String.IsNullOrWhiteSpace(resourceRequest.ProxyUri))
                validationResponse += "Empty or null value for proxyUri.";

            return validationResponse;
        }

        

        [HttpDelete]
        [Route("cache")]
        public string[] ClearCache(string lang = null)
        {
            string[] result = null;

            var tempResult = new List<string>();

            var message = RemoveCache<ResourceModel>("ALL_API_RESOURCES", "All API resource cache");
            tempResult.Add(message);
            message = RemoveCache<ResourceModel>("V4_Public_APIS", "V4 public API resource cache");
            tempResult.Add(message);
            message = RemoveCache<ResourceModel>("V4_Private_APIS", "V4 private API resource cache");
            tempResult.Add(message);
            message = RemoveCache<ScopeModel>("CachedScopes", "scope cache");
            tempResult.Add(message);
            message = RemoveCache<ScopeModel>("CachedScopeGroups", "scope group cache");
            tempResult.Add(message);

            result = tempResult.ToArray();

            return result;
        }

        private string RemoveCache<T>(string cacheKey, string cacheName) where T : new()
        {
            string resultPattern = "{0} {1} items removed.";
            var cache = IocContainer.Resolve<CacheStoreProvider>().Instance;

            var cacheValue = cache.Get(cacheKey) as List<T>;
            var cacheCount = cacheValue != null ? cacheValue.Count : 0;

            if (cacheCount > 0)
            {
                cache.Remove(cacheKey);
            }

            var message = String.Format(resultPattern, cacheCount, cacheName);
            return message;
        }

    }
}
