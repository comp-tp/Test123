
using System;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.Resources
{
    [DataContract(Name = "wsResourceInfoRequest")]
    public class WSResourceInfoRequest : WSRequestBase
    {
        public Guid AgencyId { get; set; }

        [DataMember(Name = "api")]
        public string Api { get; set; }

        [DataMember(Name = "httpMethod")]
        public string HttpMethod { get; set; }

        [DataMember(Name = "templateUri")]
        public string TemplateUri { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "scope")]
        public string Scope { get; set; }

        [DataMember(Name = "scopeGroup")]
        public string ScopeGroup { get; set; }

        [DataMember(Name = "authenticationType")]
        public string AuthenticationType { get; set; }

        [DataMember(Name = "proxyUri")]
        public string ProxyUri { get; set; }

        [DataMember(Name = "proxyServerName")]
        public string ProxyServerName { get; set; }


    }
}
