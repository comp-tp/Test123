using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Accela.Apps.GeoServices.Geocode.Helpers
{
    public static class AddressHelper
    {
        /// <summary>
        /// Get Country by countrycode.
        /// </summary>
        /// <param name="countryCode">country code. Example: USA</param>
        /// <returns></returns>
        public static string GetCountryDisplayName(string countryCode)
        {
            string country = string.Empty;

            if (RegionInfo.CurrentRegion.ThreeLetterISORegionName.Equals(countryCode, StringComparison.OrdinalIgnoreCase))
            {
                country = RegionInfo.CurrentRegion.DisplayName;
            }
            else
            {
                foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
                {
                    if (ci.IsNeutralCulture)
                    {
                        continue;
                    }

                    try
                    {
                        RegionInfo regionInfo = new RegionInfo(ci.LCID);
                        if (string.Equals(regionInfo.ThreeLetterISORegionName, countryCode, StringComparison.InvariantCultureIgnoreCase))
                        {
                            country = regionInfo.DisplayName;
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

            return country;
        }
    }
}
