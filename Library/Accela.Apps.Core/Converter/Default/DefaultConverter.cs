using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accela.Apps.Core;

namespace Accela.Core.Converter.Default
{
    internal class DefaultConverter : IConverter
    {
        public object ConvertTo(Type type, object value, object defaultValue = null, bool throwException = false,
            IFormatProvider provider = null, CultureInfo cultureInfo = null)
        {
            object retValue = (defaultValue == null)
                ? type.DefaultValue() : defaultValue;
            try
            {
                if (value != null &&
                    value != DBNull.Value)
                {
                    if (value.GetType() == type)
                    {
                        retValue = value;
                    }
                    else
                    {
                        switch (type.FullName)
                        {
                            case "System.String":
                                retValue = System.Convert.ToString(value, provider);
                                break;
                            case "System.Int16":
                                retValue = System.Convert.ToInt16(value, provider);
                                break;
                            case "System.Int32":
                                retValue = System.Convert.ToInt32(value, provider);
                                break;
                            case "System.Int64":
                                retValue = System.Convert.ToInt64(value, provider);
                                break;
                            case "System.Decimal":
                                retValue = System.Convert.ToDecimal(value, provider);
                                break;
                            case "System.Double":
                                retValue = System.Convert.ToDouble(value, provider);
                                break;
                            case "System.DateTime":
                                retValue = System.Convert.ToDateTime(value, provider);
                                break;
                            case "System.Boolean":
                                string stringValue = value.ToString();

                                if (stringValue.Equals("false", StringComparison.OrdinalIgnoreCase) ||
                                    stringValue.Equals("0") ||
                                    stringValue.Equals("off", StringComparison.OrdinalIgnoreCase) ||
                                    stringValue.Equals("n", StringComparison.OrdinalIgnoreCase) ||
                                    stringValue.Equals("no", StringComparison.OrdinalIgnoreCase))
                                {
                                    retValue = false;
                                }
                                else if (stringValue.Equals("true", StringComparison.OrdinalIgnoreCase) ||
                                    stringValue.Equals("1") ||
                                    stringValue.Equals("on", StringComparison.OrdinalIgnoreCase) ||
                                    stringValue.Equals("y", StringComparison.OrdinalIgnoreCase) ||
                                    stringValue.Equals("yes", StringComparison.OrdinalIgnoreCase))
                                {
                                    retValue = true;
                                }
                                else
                                {
                                    retValue = System.Convert.ToBoolean(value, provider);
                                }
                                break;
                            case "System.Char":
                                retValue = System.Convert.ToChar(value, provider);
                                break;
                            default:
                                if (type.IsEnum)
                                {
                                    retValue = Enum.Parse(type, value.ToString(), true);
                                }
                                else if (type.IsNullable())
                                {
                                    var nullableConverter = new NullableConverter(type);
                                    retValue = nullableConverter.ConvertFromString(value.ToString());
                                }
                                else
                                {
                                    //just cast it, it should throw exception if unable to cast
                                    retValue = value;

                                    //throw (new InvalidOperationException("Unable to convert object to {0}"
                                    //    .FormatWith(type)));
                                }
                                break;
                        }
                    }
                }
            }
            catch
            {
                if (throwException)
                    throw;
            }
            return retValue;
        }

        public T ConvertTo<T>(object value, T defaultValue = default(T), bool throwException = false,
            IFormatProvider formatProvider = null, CultureInfo cultureInfo = null)
        {
            return (T)this.ConvertTo(typeof(T), value, defaultValue, throwException, formatProvider, cultureInfo);
        }
    }
}
