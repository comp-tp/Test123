using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Accela.Apps.Core;
using System.Globalization;

namespace Accela.Apps.Core
{
    public static class ResourceManagerExtensions
    {
        public static string GetString(this ResourceManager instance, object key, string defaultKey = null)
        {
            var value = string.Empty;
            if (key != null)
            {
                if (key is string)
                {
                    value = instance.GetString(key.ToString());
                }
                else
                {
                    var type = key.GetType();
                    if (type.IsEnum ||
                        (type.IsNullable() && Nullable.GetUnderlyingType(type).IsEnum))
                    {
                        var enumType = type.IsNullable() ? Nullable.GetUnderlyingType(type) : type;
                        value = instance.GetString("{0}_{1}".FormatWith(enumType.Name, key.ToString()));
                    }
                    else
                    {
                        value = instance.GetString(key.ToString());
                    }
                }
            }
            return value.IsNotNullOrEmpty() 
                ? value
                : defaultKey.IsNotNullOrEmpty() ? instance.GetString(defaultKey) : null;
        }

        public static IEnumerable<string> Keys(this ResourceManager instance)
        {
            var resourceSet = instance.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            IDictionaryEnumerator enumerator = resourceSet.GetEnumerator();

            while (enumerator.MoveNext())
            {
                yield return (string)enumerator.Key;
            }
        }
    }
}
