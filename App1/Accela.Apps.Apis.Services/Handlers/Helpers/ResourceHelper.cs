using Accela.Apps.Apis.APIHandlers;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DomainModels.ResourceModels;
using Accela.Core.Ioc;
using Accela.Apps.Shared.APIHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Apis.Services.Handlers.Helpers
{
    internal static class ResourceHelper
    {
        /// <summary>
        /// Get resource model from Request or Cache.
        /// If resourceModel is in request, get it from request
        /// otherwise get it from cache and set it to current request properties.
        /// </summary>
        /// <param name="request">HttpRequestMessage instance.</param>
        /// <returns>an instance of ResourceModel.</returns>
        public static ResourceModel GetResourceModelFromRequestOrCache(HttpRequestMessage request)
        {

            ResourceModel resourceModel = null;

            if (request.Properties.ContainsKey(Constants.PROPERTIES_KEY_RESOURCE_MODEL))
            {
                resourceModel = request.Properties[Constants.PROPERTIES_KEY_RESOURCE_MODEL] as ResourceModel; 
            }
            
            if(resourceModel == null)
            {
                HttpMessage message = new HttpMessage(request);
                string httpMethod = message.GetHttpMethod();
                string requestAbsoluteUrl = message.GetAPIRelativePathWithoutQueryString();

                if(string.IsNullOrWhiteSpace(requestAbsoluteUrl))
                {
                    return null;
                }
                //request.GetDependencyScope();
                var _resourceBusinessEntity = IocContainer.Resolve<IResourceBusinessEntity>();
                resourceModel = _resourceBusinessEntity.GetResource(requestAbsoluteUrl, httpMethod);
                if (resourceModel != null)
                {
                    request.Properties[Constants.PROPERTIES_KEY_RESOURCE_MODEL] = resourceModel;
                }
            }

            return resourceModel;
        }
    }
}
