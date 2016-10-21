using System;

namespace Accela.Apps.Core
{
    public static class EnumExtensions
    {
        public static bool HasValue<T>(this T instance, T value)
            where T : struct
        {
            if (typeof(T).IsEnum == false)
                throw (new InvalidOperationException("Type ({0}) is not an enum".FormatWith(typeof(T).GetType().FullName)));

            if (instance.GetType() != value.GetType())
                throw (new InvalidOperationException("Unable to perform enum operation on a different type"));

            return ((instance.ConvertTo<int>() & value.ConvertTo<int>()) == value.ConvertTo<int>());
        }
    }
}
