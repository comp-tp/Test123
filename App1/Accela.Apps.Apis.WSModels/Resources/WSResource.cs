
using System;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ResourceModels;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.Scope;

namespace Accela.Apps.Apis.WSModels.Resources
{
    [DataContract(Name = "resources")]
    [Serializable]
    public class WSResource
    {
        [DataMember(Name = "status")]
        public int Status { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "api")]
        public string Api { get; set; }

        [DataMember(Name = "httpMethod")]
        public string HttpVerb { get; set; }

        [DataMember(Name = "templateUri")]
        public string UriTemplate { get; set; }

        [DataMember(Name = "scope")]
        public string Name { get; set; }

        [DataMember(Name = "scopeGroup")]
        public string ScopeGroup { get; set; }

        public string Description { get; set; }

        [DataMember(Name = "authenticationType")]
        public string AuthenticationType { get; set; }

        public bool canSaveResource { get; set; } 

        public bool IsProxy { get; set; }
        
        [DataMember(Name = "proxyUri", EmitDefaultValue = false)]
        public string ProxyAPI { get; set; }
                
        public bool isAAGovXMLAPI { get; set; }

        [DataMember(Name = "proxyServerName", EmitDefaultValue = false)]
        public string ProxyRemoteServerName { get; set; }

        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string Message { get; set; }

        //Conditionally serialize fields in JSON
        public bool ShouldSerializeStatus() { return SaveResource; }
        public bool ShouldSerializeUriTemplate() { return !SaveResource; }
        public bool ShouldSerializeName() { return !SaveResource; }
        public bool ShouldSerializeScopeGroup() { return !SaveResource; }
        public bool ShouldSerializeAuthenticationType() { return !SaveResource; }
        public bool ShouldSerializeProxyAPI() { return !SaveResource; }
        public bool ShouldSerializeProxyRemoteServerName() { return !SaveResource; }
        
        //SERIALIZE when SaveResource is false
        public bool SaveResource { get; set; }


        public static WSResource FromEntityModel(ResourceModel entityModel, bool saveResource, ScopeModel scope)
        {
            if (entityModel == null)
            {
                return null;
            }
            
            var result = new WSResource
            {
                Id = entityModel.Id ==new Guid() ? "" :entityModel.Id.ToString(),
                Status = (int)System.Net.HttpStatusCode.OK,
                Api = entityModel.Api,
                HttpVerb = entityModel.HttpVerb,
                UriTemplate = entityModel.UriTemplate,
                Name = entityModel.Name,
                ScopeGroup = scope==null ? null : (scope.ScopeGroups!=null&& scope.ScopeGroups.Count>0)? scope.ScopeGroups[0].Name:null,
                Description = entityModel.Description,
                AuthenticationType = Enum.GetName(typeof(APIAuthentication), entityModel.AuthenticationType),
                IsProxy = entityModel.IsProxy == 1 ? true : false,
                ProxyAPI = entityModel.ProxyAPI,
                isAAGovXMLAPI = entityModel.IsAAGovXMLAPI == 1 ? true : false,
                ProxyRemoteServerName = entityModel.ProxyRemoteServerName,
                SaveResource = saveResource,
                canSaveResource = entityModel.canSaveResource
            };
            if (saveResource)
                result.Message = entityModel.resourceAdded ? "API successfully added." : entityModel.resourceUpdated ? "Existing API successfully updated." : "";
            return result;
        }

       
    }

    public enum APIAuthentication
    {
        None = 0,
        UserCredential = 1,
        AppCredential = 2,
        AccessKey = 3,
        UserIdentityACAAnonymous = 4,
        UserIdentityAA = 5
    }


}
