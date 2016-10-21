using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.Apis.Models.DomainModels.ResourceModels
{
    [Serializable]
    public class ResourceModel
    {
        public Guid Id { get; set; }

        public string Api { get; set; }

        public Dictionary<string, string> APIPrameters { get; set; }

        public string ProxyAPI { get; set; }

        public string HttpVerb { get; set; }

        public string UriTemplate { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int AuthenticationType { get; set; }

        public string ProxyRemoteServerName { get; set; }

        public int IsProxy { get; set; }

        public int IsAAGovXMLAPI { get; set; }
        
        public string Scope { get; set; }

        public string ScopeGroup { get; set; }

        public bool canSaveResource { get; set; }

        public bool resourceUpdated { get; set; }

        public bool resourceAdded { get; set; }

        public ResourceModel Clone()
        {
            return new ResourceModel
            {
                Api = this.Api,
                APIPrameters = this.APIPrameters,
                AuthenticationType = this.AuthenticationType,
                Description = this.Description,
                HttpVerb = this.HttpVerb,
                Id = this.Id,
                IsAAGovXMLAPI = this.IsAAGovXMLAPI,
                IsProxy = this.IsProxy,
                Name = this.Name,
                ProxyAPI = this.ProxyAPI,
                UriTemplate = this.UriTemplate,
                ProxyRemoteServerName = this.ProxyRemoteServerName
            };
        }
    }
}
