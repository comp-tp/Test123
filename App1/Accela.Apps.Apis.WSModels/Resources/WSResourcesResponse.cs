using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ResourceResponses;
using Accela.Apps.Apis.Models.DomainModels.Scope;
using System;

namespace Accela.Apps.Apis.WSModels.Resources
{
    [Serializable]
    [DataContract(Name = "ResourcesResponse")]
    public class WSResourcesResponse : WSResponseBase
    {
        [DataMember(Name = "resources", EmitDefaultValue = false)]
        public List<WSResource> Resources { get; set; }

        public static WSResourcesResponse FromEntityModel(ResourcesResponse resourcesResponse, bool saveResource, List<ScopeModel> scopesList)
        {
            WSResourcesResponse result = new WSResourcesResponse();

            if (resourcesResponse != null
                && resourcesResponse.Resources != null
                && resourcesResponse.Resources.Count > 0)
            {
                result.Resources = new List<WSResource>();

                resourcesResponse.Resources.ForEach(resource =>
                    {
                        if (resource != null)
                        {
                            ScopeModel scope = null;
                            if(!saveResource) 
                            scope = (!String.IsNullOrWhiteSpace(resource.Name)) ? scopesList.Find(x => x.Name == resource.Name) :null;
                            result.Resources.Add(WSResource.FromEntityModel(resource, saveResource, scope));
                        }
                    });
            }

            return result;
        }
    }
}
