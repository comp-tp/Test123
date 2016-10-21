using Accela.Apps.GeoServices.Geocode.Helpers;
using Accela.Apps.GeoServices.Geocode.HelpersForArcGisV1011;
using System;
using System.Collections.Generic;

namespace Accela.Apps.GeoServices
{
    /// <summary>
    /// Esri Geocode Repository
    /// </summary>
    public class EsriGeocodeRepository : IGeocodeRepository
    {
        #region public

        /// <summary>
        /// geocode server url, with no any query string
        /// e.g. https://geocode.arcgis.com/arcgis/rest/services/World/GeocodeServer
        /// </summary>
        public string GeocodeServerUrl { get; set; }

        /// <summary>
        /// token for geocode services.
        /// if token is not empty, then other token settings (token service url, user name, password, expiration) can be empty, vise verse.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// token service url, with no any query string
        /// e.g. https://www.arcgis.com/sharing/generateToken
        /// </summary>
        public string TokenServiceUrl { get; set; }

        /// <summary>
        /// user name for getting token
        /// </summary>
        public string TokenUsername { get; set; }

        /// <summary>
        /// password for getting token
        /// </summary>
        public string TokenPassword { get; set; }

        /// <summary>
        /// The token expiration time in minutes. 
        /// The default is 60 minutes. The maximum expiration period is 15 days.
        /// help page: http://resources.arcgis.com/en/help/arcgis-rest-api/index.html#//02r3000000m5000000
        /// </summary>
        public int TokenExpiration { get; set; }

        /// <summary>
        /// used for validation required by ArcGis.
        /// used in query string or request http header.
        /// </summary>
        public string Referer { get; set; }

        public bool IsCustomService { get; set; }

        #endregion

        /// <summary>
        /// Use the property to store the first query mode for specific Geo Service Url in order to reduce query times.
        /// </summary>
        private static Dictionary<string, Dictionary<GeocodeQueryMode, int>> FirstQueryModeMappings;

        public EsriGeocodeRepository()
        {
        }

        /// <summary>
        /// Get coordinate by address array.
        /// </summary>
        /// <param name="addresses"></param>
        /// <param name="outSR">The spatial reference of the x/y coordinates returned by a geocode request.</param>
        /// <returns></returns>
        public GeocodeAddress[] GetCoordinateByAddresses(string[] addresses, string outSR = "4326")
        {
            if (addresses == null || addresses.Length == 0)
            {
                return null;
            }

            var addressCount = addresses.Length;
            var tempAddresses = new string[addresses.Length];
            addresses.CopyTo(tempAddresses, 0);

            if (String.IsNullOrWhiteSpace(outSR))
            {
                outSR = "4326";
            }

            GeocodeAddress[] results = null;
            // use service of ArcGis V10.11 version
            var requestToken = TokenV1011Helper.GetToken(this.Token, this.TokenServiceUrl, this.TokenUsername, this.TokenPassword, TokenExpiration, this.Referer);

            // using these query mode is because some custom agencies have different behaviors, we iterate possible mode, if results return successfully, return directly.
            var queryModes = GeocodeAddressesV1011Helper.GetQueryModeSequence(this.IsCustomService, this.GeocodeServerUrl, FirstQueryModeMappings);

            var resultCandidateList = new List<GeocodeAddress[]>();
            var requestUrl = GeocodeAddressesV1011Helper.BuildBatchGeocodeRequestUrl(this.GeocodeServerUrl);
            
            foreach (var queryMode in queryModes)
            {
                tempAddresses = GeocodeAddressesV1011Helper.RebuildAddresses(results, tempAddresses);
                var addressQueryValue = GeocodeAddressesV1011Helper.BuildAddressQueryValue(this.GeocodeServerUrl, tempAddresses, this.IsCustomService, queryMode);
                var resultCandidate = GeocodeAddressesV1011Helper.GeocodeAddresses(requestUrl, this.Referer, addressQueryValue, outSR, requestToken);
                results = GeocodeAddressesV1011Helper.BuildResults(results, resultCandidate);
                var areAllElementsParsed = GeocodeAddressesV1011Helper.AreAllElementsParsed(results);

                if (areAllElementsParsed)
                {
                    break;
                }

                resultCandidateList.Add(resultCandidate);
            }

            // re-fill result for empty addresses.
            results = GeocodeAddressesV1011Helper.FillWithEmptyResults(results, addressCount);

            if (this.IsCustomService)
            {
                // save stats for query modes.
                GeocodeAddressesV1011Helper.SaveQueryModeStats(resultCandidateList, queryModes, this.GeocodeServerUrl, ref FirstQueryModeMappings);
            }

            return results;
        }

        /// <summary>
        /// get address by coordinates.
        /// geocode service help page
        /// http://resources.arcgis.com/en/help/arcgis-online-geocoding-rest-api/#/Reverse_geocoding/02q00000000m000000/
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <param name="distance"></param>
        /// <param name="inSR">the spatial reference of the reverse geocode location</param>
        /// <param name="outSR">The spatial reference of the x/y coordinates returned by a geocode request.</param>
        /// <returns></returns>
        public ReverseGeocodeAddress GetAddressesByCoordinate(double longitude, double latitude, double distance = 100, string inSR = "4326", string outSR = "4326")
        {
            if (String.IsNullOrWhiteSpace(inSR))
            {
                inSR = "4326";
            }

            if (String.IsNullOrWhiteSpace(outSR))
            {
                outSR = "4326";
            }

            var location = string.Format("{{\"x\":{0:R},\"y\":{1:R},\"spatialReference\":{{\"wkid\":{2}}}}}", longitude, latitude, inSR);
            var requestUrl = ReverseGeocodeV1011Helper.BuildRequestUrl(this.GeocodeServerUrl, location, distance, outSR);
            var tempResult = ReverseGeocodeV1011Helper.ReverseGeocode(requestUrl);

            if (tempResult == null || tempResult.Address == null)
            {
                return null;
            }

            var tempAddress = tempResult.Address;

            // get results from global service response, or custom service response
            var result = new ReverseGeocodeAddress()
            {
                Address = IsCustomService ? tempAddress.Street ?? tempAddress.Address : tempAddress.Address ?? tempAddress.Street,
                City = tempAddress.City,
                State = IsCustomService ? tempAddress.State ?? tempAddress.Region : tempAddress.Region ?? tempAddress.State,
                Country = AddressHelper.GetCountryDisplayName(tempAddress.CountryCode),
                Zip = IsCustomService ? tempAddress.ZIP ?? tempAddress.Postal : tempAddress.Postal ?? tempAddress.ZIP
            };

            if (!String.IsNullOrWhiteSpace(result.Address))
            {
                if (IsCustomService)
                {
                    // update result with street element split manually
                    ReverseGeocodeHelper.UpdateAddressElements(result.Address, result);
                }
                else
                {
                    // use another ArcGis V10.11 service to update address elements. 
                    var searchRequestUrl = AddressCandidatesSearchV1011Helper.BuildRequestUrl(this.GeocodeServerUrl, tempAddress.Address, city: tempAddress.City, region: tempAddress.Region, postal: tempAddress.Postal, countryCode: tempAddress.CountryCode, location: location, distance: distance);
                    var tempResult1 = AddressCandidatesSearchV1011Helper.MultiFieldGeocode(searchRequestUrl);
                    ReverseGeocodeHelper.UpdateAddressElements(tempResult1, result);
                }
            }

            // update DetailAddress property based on new address elements
            ReverseGeocodeHelper.UpdateDetailAddress(result);

            return result;
        }

        //public void ClearTokenCache()
        //{
        //    TokenCacheV1011Helper.ClearCache();
        //}
    }

    /// <summary>
    /// used for custom geocode address API.
    /// </summary>
    public enum GeocodeQueryMode
    {
        /// <summary>
        /// use single line parameter in geocode address request.
        /// for example: 
        /// {geocode server}/geocodeAddresses?addresses={"records":[{"attributes":{"OBJECTID":0,"Single Line Input":"1414 21st St, Sacramento, California, 95811"}}]}&outSR=&f=pjson
        /// </summary>
        SingleLineParameter,

        /// <summary>
        /// use single line parameter with street value in geocode address request.
        /// for example:
        /// {geocode server}/geocodeAddresses?addresses={"records":[{"attributes":{"OBJECTID":0,"Single Line Input":"1414 21st St"}}]}&outSR=&f=pjson
        /// </summary>
        SingleLineWithStreetValue,

        /// <summary>
        /// use street parameter in geocode address request.
        /// for example:
        /// {geocode server}/geocodeAddresses?addresses={"records":[{"attributes":{"OBJECTID":1,"street":"1414 21st St, Sacramento, California, 95811"}}]}&outSR=&f=pjson
        /// </summary>
        StreetParameter,

        /// <summary>
        /// only pass street address (without city, state and zip, etc.) in geocode address request.
        /// for example:
        /// {geocode server}/geocodeAddresses?addresses={"records":[{"attributes":{"OBJECTID":1,"street":"1414 21st St"}}]}&outSR=&f=pjson
        /// </summary>
        StreetValue
    }
}
