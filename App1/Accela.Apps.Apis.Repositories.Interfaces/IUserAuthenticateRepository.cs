using Accela.Apps.Apis.Models.DTOs.Responses.CommonResponses;

namespace Accela.Apps.Apis.Repositories.Interfaces
{
    public interface IUserAuthenticateRepository
    {
        /// <summary>
        /// Authenticates the user and returns the token.
        /// </summary>
        /// <param name="agency">agency name.</param>
        /// <param name="loginName">login name.</param>
        /// <param name="password">password.</param>
        /// <returns>token to access Automation service.</returns>
        BizLoginResponse Authenticate(string agency, string loginName, string password);

        /// <summary>
        /// Get Agency/Citizen user seq
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        string GetUserIDByToken(string token);
    }
}
