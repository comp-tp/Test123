using Accela.Apps.Shared;
using Accela.Apps.Shared.Exceptions;
using RestSharp;
using System;
using System.Text;

namespace Accela.Apps.GeoServices.Geocode.Helpers
{
    public static class RestResponseHelper
    {
        public static T ConvertJsonTo<T>(IRestResponse restResponse, string invalidResponseMessage) where T : class
        {
            T result = default(T);
            if (restResponse == null || string.IsNullOrEmpty(restResponse.Content))
            {
                throw new MobileException(invalidResponseMessage, "No response.", ErrorCodes.internal_server_error_500);
            }

            if (restResponse.ContentType != null
                && (restResponse.ContentType.IndexOf("application/json", StringComparison.OrdinalIgnoreCase) != -1
                    || restResponse.ContentType.IndexOf("text/plain", StringComparison.OrdinalIgnoreCase) != -1
                    )
                )
            {
                result = JsonConverter.FromJsonTo<T>(restResponse.Content);
            }
            else
            {
                throw new MobileException(invalidResponseMessage, restResponse.ErrorMessage, ErrorCodes.internal_server_error_500);
            }

            return result;
        }
    }

    public static class StringExtensions
    {
        public static string Replace(this string str, string oldValue, string newValue, StringComparison comparison)
        {
            StringBuilder sb = new StringBuilder();

            int previousIndex = 0;
            int index = str.IndexOf(oldValue, comparison);
            while (index != -1)
            {
                sb.Append(str.Substring(previousIndex, index - previousIndex));
                sb.Append(newValue);
                index += oldValue.Length;

                previousIndex = index;
                index = str.IndexOf(oldValue, index, comparison);
            }
            sb.Append(str.Substring(previousIndex));

            return sb.ToString();
        }
    }
}
