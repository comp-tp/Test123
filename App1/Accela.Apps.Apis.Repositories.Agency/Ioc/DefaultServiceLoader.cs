using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Core.Ioc;
using Accela.Apps.Shared.Contants;
using Accela.Apps.Shared.Contexts;
using Accela.Infrastructure.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Apis.Repositories.Agency.Ioc
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
            //var types = typeof(DefaultServiceLoader).Assembly.GetTypes().Where(p => p.IsClass && typeof(IRepository).IsAssignableFrom(p));
            //container.RegisterAll<IRepository>(types);

            var registrations = typeof(DefaultServiceLoader).Assembly.GetExportedTypes().Where(t => t.IsClass).Where(t => t.GetInterfaces().Any(i => i.IsAssignableFrom(typeof(IRepository))))
               .Select(t => new
               {
                   Service = t.GetInterfaces().First(),
                   Implementation = t
               });

            foreach (var reg in registrations)
            {
                container.Register(reg.Service, reg.Implementation, ServiceLifecycle.PerCall);
            }

            container.RegisterSingleOpenGeneric(typeof(IMobileEntityRepository<>), typeof(MobileEntityRepository<>));
        }
    }
}
