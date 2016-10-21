using Accela.Apps.GeoServices.Geocode.Helpers;
using Accela.Apps.GeoServices.Response;
using Accela.Apps.Shared.Exceptions;
using RestSharp;
using System;
using System.Web;

namespace Accela.Apps.GeoServices.Geocode.HelpersForArcGisV1011
{
    public static class TokenV1011Helper
    {
        private const string TOKEN_SERVICE_URL_WITH_QUERY_PATTERN = "{0}?username={1}&password={2}&expiration={3}&referer={4}&f=json";
        private const string INVALID_RESPONSE_MESSAGE = "Failed to get response from ArcGis server for getting token.";

        public static string GetToken(string token, string tokenServiceUrl, string userName, string password, int expiration, string referer)
        {
            string result = token;

            if (String.IsNullOrWhiteSpace(result))
            {
                if (!String.IsNullOrWhiteSpace(tokenServiceUrl))
                {
                    var requestTokenUrl = BuildRequestUrl(tokenServiceUrl, userName, password, expiration, referer);
                    result = GetToken(requestTokenUrl);
                }
            }

            return result;
        }

        private static string BuildRequestUrl(
            string tokenServiceUrl
            , string userName
            , string password
            , int expiration
            , string referer)
        {
            if (String.IsNullOrWhiteSpace(tokenServiceUrl))
            {
                throw new ArgumentException("Invalid geocode token Url.");
            }

            expiration = expiration > 0 ? expiration : 60;

            var result = string.Format(TOKEN_SERVICE_URL_WITH_QUERY_PATTERN, tokenServiceUrl, HttpUtility.UrlEncode(userName), HttpUtility.UrlEncode(password), expiration, HttpUtility.UrlEncode(referer));
            return result;
        }

        private static string GetToken(string requestUrl)
        {
            if (String.IsNullOrWhiteSpace(requestUrl))
            {
                throw new ArgumentException("Invalid geocode token Url.");
            }

            // temporarily disable cache.
            //var cacheKey = TokenCacheV1011Helper.BuildTokenCacheKey(requestUrl);
            //var tokenModel = TokenCacheV1011Helper.GetTokenModelFromCache(cacheKey);
            TokenResponse tokenModel = null;

            //if (tokenModel == null || tokenModel.ExpireTime < DateTime.UtcNow.AddMinutes(2))
            {
                tokenModel = GetTokenModelFromServer(requestUrl);
                //TokenCacheV1011Helper.SaveTokenModelToCache(cacheKey, tokenModel);
            }

            var token = tokenModel != null && !String.IsNullOrWhiteSpace(tokenModel.Token) ? tokenModel.Token : String.Empty;

            return token;
        }

        /// <summary>
        /// Get Token from ESRI rest Server
        /// http://resources.arcgis.com/en/help/arcgis-online-geocoding-rest-api/#/Batch_geocode_authentication/02q00000000p000000/
        /// </summary>
        /// <param name="referer"></param>
        private static TokenResponse GetTokenModelFromServer(string requestUrl)
        {
            if (String.IsNullOrWhiteSpace(requestUrl))
            {
                throw new ArgumentException("Invalid geocode token Url.");
            }

            var request = new RestRequest();
            request.Resource = requestUrl;
            var restResponse = RestClientHelper.Execute(request);
            var result = RestResponseHelper.ConvertJsonTo<TokenResponse>(restResponse, INVALID_RESPONSE_MESSAGE);

            if (result != null && result.Error != null)
            {
                var details = String.Join(" ", result.Error.Details);
                throw new MobileException(result.Error.Message, details, ErrorCodes.internal_server_error_500);
            }

            if (result != null && !String.IsNullOrWhiteSpace(result.Token))
            {
                var qureys = HttpUtility.ParseQueryString(requestUrl);
                int minutes = 0;
                int tempMinutes;
                if (int.TryParse(qureys["expiration"], out tempMinutes))
                {
                    minutes = tempMinutes;
                }

                result.ExpireTime = DateTime.UtcNow.AddMinutes((minutes - 2) >= 0 ? (minutes - 2) : minutes);
            }

            return result;
        }
    }
}
