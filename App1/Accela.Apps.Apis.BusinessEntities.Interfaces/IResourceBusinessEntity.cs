using Accela.Apps.Apis.Models.DTOs.Requests.ResourceRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ResourceResponses;
using Accela.Apps.Apis.Models.DomainModels.ResourceModels;
using System.Collections.Generic;
using System;

namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    public interface IResourceBusinessEntity : IBusinessEntity
    {
        /// <summary>
        /// Get resource model by resource id.
        /// </summary>
        /// <param name="resourceId">resource id(guid).</param>
        /// <returns>resource model.</returns>
        ResourceModel GetResourceById(Guid resourceId);

        /// <summary>
        /// Get resource by request url and http method. 
        /// </summary>
        /// <param name="absoluteUrlPath">The request absolute url. e.g /v3/reports</param>
        /// <param name="httpMethod">http method, e.g GET,POST,PUT,DELETE etc.</param>
        /// <returns>return ResourceModel if matched resource is found, otherwise returns null.</returns>
        ResourceModel GetResource(string absoluteUrlPath, string httpMethod);

        ResourcesResponse GetResources(ResourcesFilter request);

        ResourcesResponse SaveResources(List<ResourceModel> request);

        ResourcesResponse UpdateResource(ResourceModel request);

        bool DeleteResource(Guid resourceId);


    }
}
