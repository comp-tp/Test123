using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accela.Apps.Core;

namespace Accela.Core.Converter.Default
{
    public class DefaultConverterService : IConverterService
    {
        private IDictionary<Type, IConverter> converters = new ConcurrentDictionary<Type, IConverter>();

        public DefaultConverterService()
        {
            var converter = new DefaultConverter();

            this.Register(typeof(string), converter);
            this.Register(typeof(Int16), converter);
            this.Register(typeof(Int32), converter);
            this.Register(typeof(Int64), converter);
            this.Register(typeof(Decimal), converter);
            this.Register(typeof(Double), converter);
            this.Register(typeof(DateTime), converter);
            this.Register(typeof(bool), converter);
            this.Register(typeof(Char), converter);
            this.Register(typeof(Int16?), converter);
            this.Register(typeof(Int32?), converter);
            this.Register(typeof(Int64?), converter);
            this.Register(typeof(Decimal?), converter);
            this.Register(typeof(Double?), converter);
            this.Register(typeof(DateTime?), converter);
            this.Register(typeof(bool?), converter);
            this.Register(typeof(Char?), converter);
            this.Register(typeof(Enum), converter);
            //this.Register(typeof(SqlGeography), converter);
            //this.Register(typeof(SqlGeometry), converter);
        }

        public virtual object ConvertTo(Type targetType, object value, object defaultValue = null, bool throwException = false, IFormatProvider provider = null, CultureInfo cultureInfo = null)
        {
            var converter = (this.converters.ContainsKey(targetType))
                ? this.converters[targetType]
                : (targetType.IsEnum ||
                   (targetType.IsNullable() && Nullable.GetUnderlyingType(targetType).IsEnum))
                    ? this.converters[typeof(Enum)] : null;

            if (converter == null)
                throw new InvalidOperationException("Unable to find converter for type ({0})".FormatWith(targetType.FullName));

            return converter.ConvertTo(targetType, value, defaultValue, throwException, provider, cultureInfo);
        }

        public T ConvertTo<T>(object value, T defaultValue = default(T), bool throwException = false, IFormatProvider provider = null, CultureInfo cultureInfo = null)
        {
            return (T)this.ConvertTo(typeof(T), value, defaultValue, throwException, provider, cultureInfo);
        }

        public void Register(Type targetType, IConverter converter)
        {
            this.converters[targetType] = converter;
        }
    }
}
