using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.Shared.FormatHelpers
{
    public static class AddressFormatter
    {
        private const string ONE_SPACE = " ";
        private const string ONE_COMMA_AND_SPACE = ", ";

        /// <summary>
        /// Converts to one line string.
        /// </summary>
        /// <param name="houseNumber">The house number.</param>
        /// <param name="houseNumberFraction">The house number fraction.</param>
        /// <param name="streetDirection">The street direction.</param>
        /// <param name="streetName">Name of the street.</param>
        /// <param name="streetSuffix">The street suffix.</param>
        /// <param name="streetSuffixDirection">The street suffix direction.</param>
        /// <param name="unitType">Type of the unit.</param>
        /// <param name="unit">The unit.</param>
        /// <param name="unitEnd">The unit end.</param>
        /// <param name="city">The city.</param>
        /// <param name="county">The county.</param>
        /// <param name="state">The state.</param>
        /// <param name="postalCode">The postal code.</param>
        /// <param name="country">The country.</param>
        /// <returns>one line string.</returns>
        public static string ToOneLineString(
              string displayValue
            , string houseNumber = null
            , string houseNumberFraction = null
            , string streetDirection = null
            , string streetName = null
            , string streetSuffix = null
            , string streetSuffixDirection = null
            , string unitType = null
            , string unit = null
            , string unitEnd = null
            , string city = null
            , string county = null
            , string state = null
            , string postalCode = null
            , string country = null
            )
        {
            string result = String.Empty;

            if (!string.IsNullOrWhiteSpace(displayValue))
            {
                result = displayValue;
            }
            else
            {
                result = ToOneLineString(
                                  houseNumber, ONE_SPACE
                                , houseNumberFraction, ONE_SPACE
                                , streetDirection, ONE_SPACE
                                , streetName, ONE_SPACE
                                , streetSuffix, ONE_SPACE
                                , streetSuffixDirection, ONE_SPACE
                                , unitType, ONE_SPACE
                                , unit, ONE_COMMA_AND_SPACE
                                , unitEnd, ONE_COMMA_AND_SPACE
                                , city, ONE_COMMA_AND_SPACE
                                , county, ONE_COMMA_AND_SPACE
                                , state, ONE_COMMA_AND_SPACE
                                , postalCode, ONE_COMMA_AND_SPACE
                                , country);
            }

            return result;
        }

        /// <summary>
        /// Formats to one line string.
        /// </summary>
        /// <param name="addressPartArray">
        /// The address part array.
        /// the pattern should be part1,separator1,part2,separator2,...
        /// </param>
        /// <returns>one line string.</returns>
        public static string ToOneLineString(params string[] addressPartArray)
        {
            String result = String.Empty;

            if (addressPartArray != null && addressPartArray.Length > 0 && addressPartArray.Length % 2 == 1)
            {
                var arrayLength = addressPartArray.Length;
                var tempResult = new StringBuilder();
                var separatorCandidate = String.Empty;

                for (int i = 0; i < arrayLength; i = i + 2)
                {
                    var part = addressPartArray[i];

                    if (!String.IsNullOrWhiteSpace(part))
                    {
                        if (tempResult.Length > 0)
                        {
                            tempResult.Append(separatorCandidate);
                        }

                        tempResult.Append(part);
                    }

                    separatorCandidate = (i + 1) < arrayLength ? addressPartArray[i + 1] : String.Empty;
                }

                result = tempResult.ToString();
            }

            return result;
        }
    }
}
