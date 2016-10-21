using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Shared.Contants;

namespace Accela.Apps.Shared.Utils
{
    public static class EnumHelper
    {
        public static T Parse<T>(string enumString, T defaultValue = default(T), bool ignoreInvalid = true, bool ignoreCase = true) where T : struct, IFormattable, IConvertible, IComparable
        {
            T result = defaultValue;

            if (!typeof(T).IsEnum)
            {
                throw (new ArgumentException("Generic Type [T] must be of type [System.Enum]."));
            }

            if (!String.IsNullOrWhiteSpace(enumString))
            {
                T tempAccelaServerType;

                if (Enum.TryParse<T>(enumString, ignoreCase, out tempAccelaServerType))
                {
                    result = tempAccelaServerType;
                }
                else
                {
                    throw new ArgumentException("Invalid enum string: " + enumString);
                }
            }

            return result;
        }

        public static T[] ParseMultiple<T>(string enumsString, bool ignoreInvalid = true, bool ignoreCase = true) where T : struct, IFormattable, IConvertible, IComparable
        {
            T[] result = null;

            if (!typeof(T).IsEnum)
            {
                throw (new ArgumentException("Generic Type [T] must be of type [System.Enum]."));
            }

            if (!String.IsNullOrWhiteSpace(enumsString))
            {
                var accelaServerTypeStringList = enumsString.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Distinct().ToList();
                var tempAccelaServerTypes = new List<T>();

                foreach (var accelaServerTypeString in accelaServerTypeStringList)
                {
                    T tempAccelaServerType;

                    if (Enum.TryParse<T>(accelaServerTypeString, ignoreCase, out tempAccelaServerType))
                    {
                        tempAccelaServerTypes.Add(tempAccelaServerType);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid enum string: " + accelaServerTypeString);
                    }
                }

                result = tempAccelaServerTypes.ToArray();
            }

            return result;
        }
    }
}
