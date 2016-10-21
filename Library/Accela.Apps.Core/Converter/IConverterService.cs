using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Core.Converter
{
    public interface IConverterService : IConverter
    {
        void Register(Type targetType, IConverter converter);
    }
}
