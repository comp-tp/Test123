
using System;
using Accela.Apps.Apis.Models.DTOs.Responses.CommonResponses;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared.Exceptions;
using Accela.Automation.CitizenServices.Client.Models.Request;
using Accela.Automation.CitizenServices.Client.Models.Response;
namespace Accela.Apps.Apis.Repositories.Citizen
{
    public class AuthenticateRepository : RepositoryBase, IUserAuthenticateRepository
    {
        private RestClient _restClient { get; set; }

        public AuthenticateRepository(string agencyName, string environmentName)
            : base(agencyName, environmentName, null, null)
        {
            _restClient = new RestClient(agencyName, environmentName);
        }

        /// <summary>
        /// Authenticates the user and returns the token.
        /// </summary>
        /// <param name="agency">agency name.</param>
        /// <param name="loginName">login name.</param>
        /// <param name="password">password.</param>
        /// <returns>token to access Automation service.</returns>
        public BizLoginResponse Authenticate(string agency, string loginName, string password)
        {
            string servProvCode = CommonHelper.GetServProvCode(agency);
            CitizenUserAuthenticateRequest authRequest = new CitizenUserAuthenticateRequest
            {
                agency = servProvCode,
                userId = loginName,
                password = password
            };

            var response = _restClient.Execute<CitizenUserAuthenticateResponse>("auth/public", authRequest);
            string token = response.result;

            if (String.IsNullOrEmpty(token))
            {
                throw new MobileException(response.responseStatus.detail.message);
            }

            BizLoginResponse loginResponse = new BizLoginResponse();
            loginResponse.ApplicationState = token;
            return loginResponse;
        }

        public string GetUserIDByToken(string token)
        {
            string resource = String.Format("citizen/?token={0}", token);
            var response = _restClient.Execute<CitizenUserResponse>(resource);
            return response.userID;
        }
    }
}
