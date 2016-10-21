using Accela.Apps.GeoServices.Geocode.Helpers;
using Accela.Apps.Shared.Exceptions;
using RestSharp;
using System;
using System.Web;

namespace Accela.Apps.GeoServices.Geocode.HelpersForArcGisV1011
{
    public static class SingleFieldGeocodeV1011Helper
    {
        private const string SINGLE_FIELD_GEOCODE_URL_PATTERN = "{0}/find?text={1}&sourceCountry={2}&bbox={3}&location={4}&distance={5}&outFields=*&maxLocations={6}&f=pjson";
        private const string INVALID_RESPONSE_MESSAGE = "Failed to get response from ArcGis server for getting detailed address.";

        public static string BuildRequestUrl(
            string geocodeServerUrl
            , string text
            , string sourceCountry = null
            , string bbox = null
            , string location = null
            , double? distance = null
            , string maxLocations = null)
        {
            if (String.IsNullOrWhiteSpace(geocodeServerUrl))
            {
                throw new ArgumentException("Invalid geocode server Url.");
            }

            geocodeServerUrl = geocodeServerUrl.Trim().TrimEnd('/');

            var result = string.Format(SINGLE_FIELD_GEOCODE_URL_PATTERN
                , geocodeServerUrl, HttpUtility.UrlEncode(text), HttpUtility.UrlEncode(sourceCountry)
                , HttpUtility.UrlEncode(bbox), HttpUtility.UrlEncode(location), distance, HttpUtility.UrlEncode(maxLocations));
            return result;
        }

        public static ArcGisSingleFieldGeocodingResponse SingleFieldGeocode(string requestUrl)
        {
            if (String.IsNullOrWhiteSpace(requestUrl))
            {
                throw new ArgumentException("Invalid geocode Url.");
            }

            var request = new RestRequest(Method.GET);
            request.Resource = requestUrl;
            var restResponse = RestClientHelper.Execute(request);
            var result = RestResponseHelper.ConvertJsonTo<ArcGisSingleFieldGeocodingResponse>(restResponse, INVALID_RESPONSE_MESSAGE);

            if (result != null && result.error != null)
            {
                var details = String.Join(" ", result.error.Details);
                throw new MobileException(result.error.Message, details, ErrorCodes.internal_server_error_500);
            }

            return result;
        }
    }
}
