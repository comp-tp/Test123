using Accela.Core.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Core.Converter
{
    public static class ConverterService
    {
        public static IConverterService Current { get; private set; }

        static ConverterService()
        {
            ConverterService.Current = IocContainer.Resolve<IConverterService>();
        }
    }
}
