using System.Collections.Generic;

namespace Accela.Apps.GeoServices
{
    /// <summary>
    /// interface IGeocodeRepository
    /// </summary>
    public interface IGeocodeRepository
    {
        string GeocodeServerUrl { get; set; }

        string Token { get; set; }

        string TokenServiceUrl { get; set; }

        string TokenUsername { get; set; }

        string TokenPassword { get; set; }

        int TokenExpiration { get; set; }

        string Referer { get; set; }

        bool IsCustomService { get; set; }

        /// <summary>
        /// Get coordinate by address array.
        /// </summary>
        /// <param name="addresses"></param>
        /// <param name="outSR">The spatial reference of the x/y coordinates returned by a geocode request.</param>
        /// <returns></returns>
        GeocodeAddress[] GetCoordinateByAddresses(string[] addresses, string outSR = "4326");

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
        ReverseGeocodeAddress GetAddressesByCoordinate(double longitude, double latitude, double distance = 100, string inSR = "4326", string outSR = "4326");

        //void ClearTokenCache();
    }
}
