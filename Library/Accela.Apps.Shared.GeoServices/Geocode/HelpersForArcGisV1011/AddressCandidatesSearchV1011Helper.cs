using Accela.Apps.GeoServices.Geocode.Helpers;
using Accela.Apps.Shared.Exceptions;
using RestSharp;
using System;
using System.Web;

namespace Accela.Apps.GeoServices.Geocode.HelpersForArcGisV1011
{
    public static class AddressCandidatesSearchV1011Helper
    {
        private const string MULTI_FIELD_GEOCODE_URL_PATTERN = "{0}/findAddressCandidates?Address={1}&Neighborhood={2}&City={3}&Subregion={4}&Region={5}&Postal={6}&PostalExt={7}&CountryCode={8}&searchExtent={9}&location={10}&distance={11}&outFields=*&f=pjson";
        private const string INVALID_RESPONSE_MESSAGE = "Failed to get response from ArcGis server for finding detailed address.";

        public static string BuildRequestUrl(
            string geocodeServerUrl
            , string address = null
            , string neighborhood = null
            , string city = null
            , string subregion = null
            , string region = null
            , string postal = null
            , string postalExt = null
            , string countryCode = null
            , string searchExtent = null
            , string location = null
            , double? distance = null)
        {
            if (String.IsNullOrWhiteSpace(geocodeServerUrl))
            {
                throw new ArgumentException("Invalid geocode server Url.");
            }

            geocodeServerUrl = geocodeServerUrl.Trim().TrimEnd('/');

            var result = string.Format(MULTI_FIELD_GEOCODE_URL_PATTERN
                , geocodeServerUrl
                , HttpUtility.UrlEncode(address), HttpUtility.UrlEncode(neighborhood), HttpUtility.UrlEncode(city)
                , HttpUtility.UrlEncode(subregion), HttpUtility.UrlEncode(region), HttpUtility.UrlEncode(postal)
                , HttpUtility.UrlEncode(postalExt), HttpUtility.UrlEncode(countryCode), HttpUtility.UrlEncode(searchExtent)
                , HttpUtility.UrlEncode(location), distance);
            return result;
        }

        public static ArcGisMultiFieldGeocodingResponse MultiFieldGeocode(string requestUrl)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = requestUrl;
            var restResponse = RestClientHelper.Execute(request);
            var result = RestResponseHelper.ConvertJsonTo<ArcGisMultiFieldGeocodingResponse>(restResponse, INVALID_RESPONSE_MESSAGE);

            if (result != null && result.error != null)
            {
                var details = String.Join(" ", result.error.Details);
                throw new MobileException(result.error.Message, details, ErrorCodes.internal_server_error_500);
            }

            return result;
        }
    }
}
