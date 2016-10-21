using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.ResourceModels;
using System;
using Accela.Apps.Apis.Models.DTOs.Requests.ResourceRequests;

namespace Accela.Apps.Apis.Repositories.Interfaces
{
    public interface IResourceRepository : IRepository
    {
        List<ResourceModel> GetResources();

        /// <summary>
        /// Get resource model by resource id.
        /// </summary>
        /// <param name="resourceId">resource id(guid).</param>
        /// <returns>resource model.</returns>
        ResourceModel GetResourceById(Guid resourceId);

        List<ResourceModel> SaveResources(List<ResourceModel> resourcesRequest, bool addResources);

        Boolean DeleteResource(Guid resourceId);
    }
}
