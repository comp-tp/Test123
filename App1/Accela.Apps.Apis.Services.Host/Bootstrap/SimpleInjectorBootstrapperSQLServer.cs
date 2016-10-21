using Accela.Core.Ioc.SimpleInjector;
using Accela.Core.Ioc;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using SimpleInjector;
//using Accela.Core.Configurations;
//using Accela.Infrastructure.Azure.Configurations;


namespace Accela.Apps.Apis.Services.Host.Bootstrap
{
    public class SimpleInjectorBootstrapper
    {

        public static void Bootstrap(HttpConfiguration config)
        {
            var configurationReader = new Accela.Apps.Shared.Web.Configurations.WebConfigurationReader();
            IocContainer.Current = new ServiceLocator(configurationReader);
             

            IocContainer.Current.LoadAll();
            var container = IocContainer.Current.IocContainer as Container;
            container.RegisterWebApiControllers(config);
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}