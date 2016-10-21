using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.Shared.Utils
{
    public static class StringHelper
    {
        /// <summary>
        /// Sub string.
        /// </summary>
        /// <param name="source">source string.</param>
        /// <param name="maxLength">the max length of the string to return.</param>
        /// <returns></returns>
        public static string SubString(string source, int maxLength)
        {
            if (String.IsNullOrEmpty(source))
            {
                return source;
            }

            int length = source.Length;

            if (length <= maxLength)
            {
                return source;
            }
            else
            {
                return source.Substring(0, maxLength);
            }
        }

        public static string TryTrim(string source)
        {
            string result = null;

            if (source != null)
            {
                result = source.Trim();
            }

            return result;
        }
    }
}
