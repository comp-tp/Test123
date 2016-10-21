using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Core.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Apis.BusinessEntities.Ioc
{
    public class DefaultServiceLoader : IServiceLoader
    {
        public int SortOrder
        {
            //should be loaded before everyone else
            get { return Int32.MinValue; }
        }

        public void Load(IServiceLocator container)
        {
            //load All Repositories
            //var types = typeof(DefaultServiceLoader).Assembly.GetTypes().Where(p => p.IsClass && typeof(IBusinessEntity).IsAssignableFrom(p));
            //container.RegisterAll<IBusinessEntity>(types);

            var registrations = typeof(DefaultServiceLoader).Assembly.GetExportedTypes().Where(t => t.IsClass).Where(t => t.GetInterfaces().Any(i => i.IsAssignableFrom(typeof(IBusinessEntity))))
                  .Select(t => new
                  {
                      Service = t.GetInterfaces().First(),
                      Implementation = t
                  });

            foreach (var reg in registrations)
            {
                container.Register(reg.Service, reg.Implementation, ServiceLifecycle.PerCall);
            }

        }
    }
}
