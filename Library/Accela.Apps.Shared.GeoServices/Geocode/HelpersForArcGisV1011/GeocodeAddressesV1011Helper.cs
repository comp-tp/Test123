using Accela.Apps.GeoServices.Geocode.Helpers;
using Accela.Apps.GeoServices.Geocode.Parser;
using Accela.Core.Logging;
using Accela.Apps.Shared.Toolkits.Encrypt;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Accela.Apps.Shared.Exceptions;

namespace Accela.Apps.GeoServices.Geocode.HelpersForArcGisV1011
{
    public static class GeocodeAddressesV1011Helper
    {
        private const string BATCH_GEOCODE_URL_PATTERN = "{0}/geocodeAddresses";
        private const string queryNameInGlobalVersion = "SingleLine";
        private const string INVALID_RESPONSE_MESSAGE = "Failed to get Geocode response from ArcGis server.";

        public static string BuildBatchGeocodeRequestUrl(string geocodeServerUrl)
        {
            if (String.IsNullOrWhiteSpace(geocodeServerUrl))
            {
                throw new ArgumentException("Invalid geocode server Url.");
            }

            geocodeServerUrl = geocodeServerUrl.Trim().TrimEnd('/');

            var result = string.Format(BATCH_GEOCODE_URL_PATTERN, geocodeServerUrl);

            return result;
        }

        public static GeocodeAddress[] GeocodeAddresses(
            string requestUrl
            , string referer
            , string addressQueryValue
            , string outSR
            , string token)
        {

            if (String.IsNullOrWhiteSpace(requestUrl))
            {
                throw new ArgumentException("Invalid geocode address Url.");
            }
            var request = new RestRequest(Method.POST);

            if (!String.IsNullOrWhiteSpace(referer))
            {
                request.AddHeader("referer", referer);
            }

            request.Resource = requestUrl;
            request.AddParameter("addresses", addressQueryValue, ParameterType.GetOrPost);
            request.AddParameter("outSR", outSR, ParameterType.GetOrPost);
            request.AddParameter("f", "pjson", ParameterType.GetOrPost);
            token = String.IsNullOrWhiteSpace(token) ? String.Empty : token.Trim();
            request.AddParameter("token", token, ParameterType.GetOrPost);
            var restResponse = RestClientHelper.Execute(request);

            var tempResult = RestResponseHelper.ConvertJsonTo<GeocodingResponse>(restResponse, INVALID_RESPONSE_MESSAGE);

            if (tempResult != null && tempResult.Error != null)
            {
                var details = String.Join(" ", tempResult.Error.Details);
                throw new MobileException(tempResult.Error.Message, details, ErrorCodes.internal_server_error_500);
            }

            var result = ConvertResponse(tempResult);
            return result;
        }

        public static string[] RebuildAddresses(GeocodeAddress[] results, string[] addresses)
        {
            if (results == null)
            {
                return addresses;
            }

            foreach (var result in results)
            {
                if (result == null)
                {
                    continue;
                }

                if (!Double.IsNaN(result.LocationX) && !Double.IsNaN(result.LocationY))
                {
                    addresses[result.No] = null;
                }
            }

            return addresses;
        }

        public static string BuildAddressQueryValue(
            string geocodeServerUrl
            , string[] addresses
            , bool isCustomService
            , GeocodeQueryMode queryMode)
        {
            if (String.IsNullOrWhiteSpace(geocodeServerUrl))
            {
                throw new ArgumentException("Invalid geocode server Url.");
            }

            geocodeServerUrl = geocodeServerUrl.Trim().TrimEnd('/');
            var queryName = isCustomService ? GetQueryName(geocodeServerUrl, queryMode) : queryNameInGlobalVersion;
            var newAddresses = isCustomService ? ConvertToAddressLines(addresses, queryMode) : addresses;
            var addressJson = BuildSingleLineRecordSet(newAddresses, queryName);

            return addressJson;
        }

        public static bool AreAllElementsParsed(GeocodeAddress[] geocodeAddressArray)
        {
            bool result = false;

            if (geocodeAddressArray != null && geocodeAddressArray.Length > 0)
            {
                var allSucceededCount = (from r in geocodeAddressArray
                                         where r != null
                                         && !Double.IsNaN(r.LocationX) 
                                         && !Double.IsNaN(r.LocationY)
                                         select r
                                        ).Count();
                if (allSucceededCount == geocodeAddressArray.Length)
                {
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Build results by extracted parsed result for each element based on cnadidates
        /// </summary>
        /// <param name="results"></param>
        /// <param name="candidates"></param>
        /// <returns></returns>
        public static GeocodeAddress[] BuildResults(GeocodeAddress[] results, GeocodeAddress[] candidates)
        {
            if (candidates == null)
            {
                return results;
            }

            if (results == null)
            {
                results = candidates;
                return results;
            }

            foreach (var candidate in candidates)
            {
                // get matched element and that element has not parsed result.
                var matchedElement = results.Where(r => r.No == candidate.No && (Double.IsNaN(r.LocationX) || !Double.IsNaN(r.LocationY))).FirstOrDefault();

                if (matchedElement == null)
                {
                    continue;
                }

                // fill the parsed result.
                matchedElement.LocationX = candidate.LocationX;
                matchedElement.LocationY = candidate.LocationY;
            }

            return results;
        }

        public static GeocodeAddress[] FillWithEmptyResults(GeocodeAddress[] candidates, int addressCount)
        {
            if (candidates == null)
            {
                return candidates;
            }

            var addressIndexes = new int[addressCount];

            for (int i = 0; i < addressCount; i++)
            {
                addressIndexes[i] = i;
            }

            var resultIndexes = candidates.Where(p => p != null).Select(p => p.No).ToArray();
            var missedIdnexes = addressIndexes.Where(p => !resultIndexes.Contains(p)).ToArray();

            var newResults = new List<GeocodeAddress>(candidates);

            if (missedIdnexes != null && missedIdnexes.Length > 0)
            {
                foreach (var index in missedIdnexes)
                {
                    var tempResult = new GeocodeAddress()
                    {
                        No = index,
                        LocationX = Double.NaN,
                        LocationY = double.NaN
                    };

                    newResults.Add(tempResult);
                }
            }

            var results = newResults.Where(p => p != null).OrderBy(p => p.No).ToArray();
            return results;
        }

        public static GeocodeQueryMode[] GetQueryModeSequence(bool isCustomService, string geocodeServiceUrl, Dictionary<string, Dictionary<GeocodeQueryMode, int>> queryModeStatList)
        {
            GeocodeQueryMode[] result = null;

            if (isCustomService)
            {
                var tempResult = new List<GeocodeQueryMode>(new GeocodeQueryMode[] { GeocodeQueryMode.SingleLineParameter, GeocodeQueryMode.StreetParameter, GeocodeQueryMode.SingleLineWithStreetValue, GeocodeQueryMode.StreetValue });

                if (queryModeStatList != null && queryModeStatList.Count > 0 && !String.IsNullOrWhiteSpace(geocodeServiceUrl))
                {
                    var hashCode = MD5Helper.GetMd5Hash(geocodeServiceUrl.ToUpperInvariant());

                    if (queryModeStatList.ContainsKey(hashCode) && queryModeStatList[hashCode] != null)
                    {
                        var queryModeStats = queryModeStatList[hashCode];
                        var firstQueryMode = queryModeStats.OrderByDescending(p => p.Value).Select(p => p.Key).FirstOrDefault();
                        tempResult.Remove(firstQueryMode);
                        tempResult.Insert(0, firstQueryMode);
                        result = tempResult.ToArray();
                    }
                }

                if (result == null)
                {
                    result = tempResult.ToArray();
                }
            }
            else
            {
                result = new GeocodeQueryMode[] { GeocodeQueryMode.SingleLineParameter };
            }

            return result;
        }

        public static void SaveQueryModeStats(List<GeocodeAddress[]> resultList, GeocodeQueryMode[] queryModes, string geocodeServiceUrl, ref Dictionary<string, Dictionary<GeocodeQueryMode, int>> queryModeStatList)
        {
            if (resultList == null || resultList.Count == 1 || queryModes == null || String.IsNullOrWhiteSpace(geocodeServiceUrl))
            {
                return;
            }

            var resultArray = resultList.ToArray();
            var hashCode = MD5Helper.GetMd5Hash(geocodeServiceUrl.ToUpperInvariant());
            Dictionary<GeocodeQueryMode, int> stats = null;

            if (queryModeStatList == null)
            {
                queryModeStatList = new Dictionary<string, Dictionary<GeocodeQueryMode, int>>();
            }

            if (queryModeStatList.ContainsKey(hashCode))
            {
                stats = queryModeStatList[hashCode];
            }
            else
            {
                stats = new Dictionary<GeocodeQueryMode, int>();
                queryModeStatList[hashCode] = stats;
            }

            for (int i = 0; i < resultArray.Length; i++)
            {
                var tempResults = resultArray[i];

                if (tempResults == null || tempResults.Length == 0)
                {
                    continue;
                }

                var currentQueryMode = queryModes[i];
                var validResultCount = tempResults.Count(p => p != null && !Double.IsNaN(p.LocationX) && !Double.IsNaN(p.LocationY));
                var oldCount = stats.ContainsKey(currentQueryMode) ? stats[currentQueryMode] : 0;
                stats[currentQueryMode] = oldCount + validResultCount;
            }
        }

        private static string GetQueryName(string geocodeServerUrl, GeocodeQueryMode queryMode)
        {
            var queryName = "SingleLine";

            if (queryMode == GeocodeQueryMode.SingleLineParameter
                    || queryMode == GeocodeQueryMode.SingleLineWithStreetValue
                    )
            {
                queryName = GetSingleLinePropertyName(geocodeServerUrl);

                if (String.IsNullOrWhiteSpace(queryName))
                {
                    queryName = "Single Line Input";
                }
            }
            else if (queryMode == GeocodeQueryMode.StreetParameter || queryMode == GeocodeQueryMode.StreetParameter)
            {
                // for some agencies, they expose "single line input" parameter, but actully does not support it, so we have to try using hard-coded street parameter to get result.
                queryName = "Street";
            }

            return queryName;
        }

        private static string[] ConvertToAddressLines(string[] addresses, GeocodeQueryMode queryMode)
        {
            if (addresses == null
                || addresses.Length == 0
                || queryMode == GeocodeQueryMode.SingleLineParameter
                || queryMode == GeocodeQueryMode.SingleLineWithStreetValue)
            {
                return addresses;
            }

            var parser = new UsaAddressParser();
            var list = new List<string>();

            for (int i = 0; i < addresses.Length; i++)
            {
                var address = addresses[i];

                if (String.IsNullOrWhiteSpace(address))
                {
                    list.Add(address);
                    continue;
                }

                var addressParts = parser.Parse(address);

                if (addressParts == null)
                {
                    LogFactory.GetLog().Info("Not supported address occurred.", String.Format("The address: {0}", address), "ConvertToAddressLines()");
                }

                var newAddress = addressParts == null ? address : addressParts.StreetLine;
                list.Add(newAddress);
            }

            var result = list.ToArray();

            return result;
        }

        private static string GetSingleLinePropertyName(string geocodeServerUrl)
        {
            var request = new RestRequest(Method.GET);
            var requestUrl = String.Format("{0}?f=json", (geocodeServerUrl ?? String.Empty).Trim());
            request.Resource = requestUrl;
            var restResponse = RestClientHelper.Execute(request);
            var isJson = restResponse != null && restResponse.Content != null && restResponse.Content.Trim().StartsWith("{");
            var serviceDescription = isJson ? JObject.Parse(restResponse.Content) : null;
            var propertyName = serviceDescription != null && serviceDescription.SelectToken("singleLineAddressField.name") != null ? serviceDescription.SelectToken("singleLineAddressField.name").ToString() : null;
            return propertyName;
        }

        private static string BuildSingleLineRecordSet(string[] addresses, string singleLinePropertyName)
        {
            if (addresses == null)
            {
                return null;
            }

            var recordPattern = "{{\"attributes\":{{\"OBJECTID\":{0},\"{1}\":\"{2}\"}}}}";
            var recordsPattern = "{{\"records\":[{0}]}}";

            var resultBuilder = new List<string>();

            for (int i = 0; i < addresses.Length; i++)
            {
                if (String.IsNullOrWhiteSpace(addresses[i]))
                {
                    continue;
                }

                var singleLine = String.Format(recordPattern, i, singleLinePropertyName, addresses[i]);
                resultBuilder.Add(singleLine);
            }

            var tempResult = String.Join(",", resultBuilder.ToArray());
            var result = String.Format(recordsPattern, tempResult);

            return result;
        }

        private static GeocodeAddress[] ConvertResponse(GeocodingResponse geocodingResponse)
        {
            GeocodeAddress[] result = null;

            if (geocodingResponse != null && geocodingResponse.Locations != null && geocodingResponse.Locations.Count > 0)
            {
                result = new GeocodeAddress[geocodingResponse.Locations.Count];
                int index = 0;

                foreach (var location in geocodingResponse.Locations)
                {
                    if (location == null || location.Attributes == null || location.Location == null)
                    {
                        continue;
                    }

                    result[index++] = new GeocodeAddress
                    {
                        No = location.Attributes.ResultID,
                        LocationX = location.Location.X,
                        LocationY = location.Location.Y
                    };
                }
            }

            return result;
        }
    }
}
