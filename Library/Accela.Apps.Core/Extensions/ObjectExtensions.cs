using System;
using System.Globalization;

using Accela.Core.Converter;

namespace Accela.Apps.Core
{
    public static class ObjectExtensions
    {
        public static bool IsEquals(this object instance, object compare)
        {
            if (instance == null && compare == null)
                return true;

            return (instance != null)
                ? instance.Equals(compare)
                : compare.Equals(instance);
        }

        public static object ConvertTo(this object instance, Type targetType, object defaultValue, bool throwException = false,
            IFormatProvider provider = null, CultureInfo cultureInfo = null)
        {
            return ConverterService.Current.ConvertTo(targetType, instance, defaultValue,
                throwException, provider, cultureInfo);
        }

        public static T ConvertTo<T>(this object instance, T defaultValue = default(T), bool throwException = false,
            IFormatProvider provider = null, CultureInfo cultureInfo = null)
        {
            return ConverterService.Current.ConvertTo<T>(instance, defaultValue,
                throwException, provider, cultureInfo);
        }
    }
}
