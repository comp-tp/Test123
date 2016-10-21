using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.Models.DTOs.Requests.UserRequest;
using Accela.Apps.Apis.Models.DTOs.Responses.UserReponses;
using Accela.Apps.Apis.Repositories.Agency.AARESTModels;
using Accela.Apps.Apis.Repositories.Interfaces.Admin;
//using RestSharp;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Shared.Gateway.Client;
using Accela.Apps.Shared.Contants;
using System.Net.Http;

namespace Accela.Apps.Apis.Repositories.Agency
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        //public UserRepository(string appId, 
        //                      string agencyName, 
        //                      string serviceProvCode, 
        //                      string agencyUserId, 
        //                      string agencyUsername, 
        //                      string token, 
        //                      string environmentName, 
        //                      string language)
        //    : base(appId, agencyName, serviceProvCode, agencyUserId, agencyUsername, token, environmentName, language)
        //{
        //}
        private IGatewayClient _gatewayClient;

        public UserRepository(IAgencyAppContext contextEntity, IGatewayClient gatewayClient)
            : base(contextEntity)
        {
            _gatewayClient = gatewayClient;
        }

        //private AARestClient _restClient;
        //private AARestClient RestClient
        //{
        //    get
        //    {
        //        if (_restClient == null)
        //        {
        //            _restClient = new AARestClient(this.currentAgencyContext.Agency, this.currentAgencyContext.EnvName);
        //        }

        //        return _restClient;
        //    }
        //}

        public CloudUserModel GetCloudUser(Guid cloudUserId)
        {
            throw new NotImplementedException();
        }

        public UserProfileResponse GetUserProfile(UserProfileRequest request)
        {
            string requestUrlTemplate = "apis/v4/users/me?token={0}";
            string requestUrl = String.Format(requestUrlTemplate, this.CurrentContext.SocialToken);

            //var aaResult = RestClient.Execute(requestUrl, true);
            //HttpRequestMessage requestMessage = new HttpRequestMessage
            //{
            //    RequestUri = new Uri(requestUrl)
            //};

            UserProfileResponse result = new UserProfileResponse();

            var response = _gatewayClient.Send(ApiTypes.NormalApi, requestUrl,HttpMethod.Get);
            if (response != null && response.Content != null)
            {
                result.Data = response.Content.ReadAsStringAsync().Result;
            }

            return result;
        }
    }
}
