using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Core.Ioc
{
    public static class IocContainer
    {
        public static IServiceLocator Current { get; set; }

        public static T Resolve<T>() where T : class
        {
            return Current.Resolve<T>();
        }

        public static object Resolve(Type serviceType)
        {
            return Current.Resolve(serviceType);
        }
    }
}
