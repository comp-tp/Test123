using Accela.Apps.GeoServices.Geocode.Helpers;
using Accela.Apps.GeoServices.Response;
using Accela.Apps.Shared.Exceptions;
using RestSharp;
using System;
using System.Web;

namespace Accela.Apps.GeoServices.Geocode.HelpersForArcGisV1011
{
    public class ReverseGeocodeV1011Helper
    {
        private const string REVERSE_GEOCODE_URL_PATTERN = "{0}/reverseGeocode?location={1}&distance={2}&outSR={3}&f=pjson";
        private const string INVALID_RESPONSE_MESSAGE = "Failed to get ReverseGeocode response from ArcGis server.";

        public static string BuildRequestUrl(
            string geocodeServerUrl
            , string location
            , double distance
            , string outSR)
        {
            if (String.IsNullOrWhiteSpace(geocodeServerUrl))
            {
                throw new ArgumentException("Invalid geocode server Url.");
            }

            geocodeServerUrl = geocodeServerUrl.Trim().TrimEnd('/');
            var result = string.Format(REVERSE_GEOCODE_URL_PATTERN, geocodeServerUrl, HttpUtility.UrlEncode(location), distance, outSR);
            return result;
        }

        public static ReverseGeocodeResponse ReverseGeocode(string requestUrl)
        {
            if (String.IsNullOrWhiteSpace(requestUrl))
            {
                throw new ArgumentException("Invalid reverse geocode Url.");
            }

            var request = new RestRequest(Method.GET);
            request.Resource = requestUrl;
            var restResponse = RestClientHelper.Execute(request);

            var result = RestResponseHelper.ConvertJsonTo<ReverseGeocodeResponse>(restResponse, INVALID_RESPONSE_MESSAGE);

            if (result != null && result.Error != null)
            {
                var details = String.Join(" ", result.Error.Details);
                throw new MobileException(result.Error.Message, details, ErrorCodes.internal_server_error_500);
            }

            return result;
        }
    }
}
