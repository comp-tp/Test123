using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.ResourceModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ResourceResponses
{
    public class ResourcesResponse : ResponseBase
    {
        public List<ResourceModel> Resources { get; set; }

        public ResourcesResponse()
        {
            Resources = new List<ResourceModel>();
        }
    }
}
