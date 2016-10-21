using Accela.Apps.Shared.Contants;
using Accela.Apps.Shared.Exceptions;
using System;
using System.Collections.Generic;

namespace Accela.Apps.Shared.OAuth.Token.RelyingParty
{
    public static class RelyingPartyTokenHelper
    {
        public static AccelaAccessTokenModel ParseAndValidateToken(string token, string signingKey, string encryptionKey)
        {
            AccelaAccessTokenModel result = null;
            SimpleWebTokenModel tempResult = null;
            try
            {
                tempResult = SimpleWebTokenFactory.ParseAndValidateToken(token, signingKey, encryptionKey);
            }
            catch (Exception ex)
            {
                if (ex is TokenException)
                {
                    throw ex;
                }

                throw new TokenException("Invalid token.", ex, ErrorCodes.invalid_token_401);
            }

            if (tempResult != null)
            {
                var keyValuePairs = tempResult.GetAllKeyValuePairs();
                var scopeArrayString = keyValuePairs[AccelaAccessToken.SCOPE];
                var scopeArray = !String.IsNullOrWhiteSpace(scopeArrayString) ? scopeArrayString.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries) : null;
                var scope = scopeArray != null && scopeArray.Length > 0 ? new HashSet<string>(scopeArray) : null;
                var clientTypeInteger = 0;
                int.TryParse(keyValuePairs[AccelaAccessToken.CLIENT_TYPE], out clientTypeInteger);
                var clientType = (AppType)clientTypeInteger;
                result = new AccelaAccessTokenModel()
                {
                    AgencyName = keyValuePairs[AccelaAccessToken.AGENCY_NAME],
                    AAToken = keyValuePairs[AccelaAccessToken.AA_TOKEN],
                    LoginName = keyValuePairs[AccelaAccessToken.LOGIN_NAME],
                    ClientId = keyValuePairs[AccelaAccessToken.CLIENT_ID],
                    ClientType = clientType,
                    CloudUserId = keyValuePairs[AccelaAccessToken.CLOUD_USER_ID],
                    AccountUid = keyValuePairs[AccelaAccessToken.ACCOUNT_UID],
                    EnvironmentName = keyValuePairs[AccelaAccessToken.ENVIRONMENT_NAME],
                    Scope = scope,
                    ExpiresIn = tempResult.GetExpiresIn()
                };
            }

            return result;
        }

        public static bool ValidateScopes(AccelaAccessTokenModel tokenModel, string currentRequestedScope)
        {
            bool result = false;

            if (tokenModel != null)
            {
                result = tokenModel != null && tokenModel.Scope != null && tokenModel.Scope.Contains(currentRequestedScope);
            }

            return result;
        }
    }
}
