using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Core.Converter
{
    public interface IConverter
    {
        object ConvertTo(Type targetType, object value, object defaultValue = null, bool throwException = false, IFormatProvider provider = null, CultureInfo cultureInfo = null);
        T ConvertTo<T>(object value, T defaultValue = default(T), bool throwException = false, IFormatProvider provider = null, CultureInfo cultureInfo = null);
    }
}
