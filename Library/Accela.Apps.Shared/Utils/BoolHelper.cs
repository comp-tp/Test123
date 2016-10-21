using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.Shared.Utils
{
    public static class BoolHelper
    {
        /// <summary>
        /// bool string type
        /// </summary>
        public enum BoolStringType
        {
            TrueOrFalse,
            YesOrNo,
            YOrN,
            OnOrOff,
            OneOrZero
        }

        /// <summary>
        /// Determines whether the specified bool string is true/yes/y/on/1 string.
        /// </summary>
        /// <param name="source">if set to <c>true</c> [source].</param>
        /// <returns>
        /// <c>true</c> if the specified bool string is true/yes/y/on/1 string; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsTrueString(string source)
        {
            bool result = false;
            string[] trueStringArray = { "true", "yes", "y", "on", "1" };

            if (!String.IsNullOrEmpty(source) && trueStringArray.Contains(source, StringComparer.OrdinalIgnoreCase))
            {
                result = true;
            }

            return result;
        }

        public static bool? GetBooleanByString(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return null;
            }
            else
            {
                return IsTrueString(source);
            }
        }



        /// <summary>
        /// Toes the bool string.
        /// </summary>
        /// <param name="source">if set to <c>true</c> [source].</param>
        /// <param name="targetType">Type of the target.</param>
        /// <returns>
        /// the bool string.
        /// </returns>
        public static string ToBoolString(bool? source, BoolStringType targetType)
        {
            string result = String.Empty;

            if (source != null)
            {
                switch (targetType)
                {
                    case BoolStringType.OneOrZero:
                        result = source.Value == true ? "1" : "0";
                        break;
                    case BoolStringType.OnOrOff:
                        result = source.Value == true ? "on" : "off";
                        break;
                    case BoolStringType.YOrN:
                        result = source.Value == true ? "y" : "n";
                        break;
                    case BoolStringType.YesOrNo:
                        result = source.Value == true ? "yes" : "no";
                        break;
                    case BoolStringType.TrueOrFalse:
                    default:
                        result = source.Value == true ? "true" : "false";
                        break;
                }
            }

            return result;
        }
    }
}
