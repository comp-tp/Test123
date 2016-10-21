using Accela.Apps.Apis.Ioc;
using Accela.Core.Ioc;
using Accela.Infrastructure;
using Accela.Infrastructure.Configurations;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;
using System;

namespace Accela.Apps.Apis.Services.Host.Bootstrap
{
    public class SimpleInjectorBootstrapper
    {
        public static void Bootstrap(HttpConfiguration config)
        {
            IocInitializer.Initialize();

            IocContainer.Current.LoadAll();
            var container = IocContainer.Current.IocContainer as Container;
            container.Register(typeof(IRetryPolicyConfiguration), typeof(RetryPolicyConfigurationLoader),Lifestyle.Singleton);
            container.Register(typeof(IConnectionStringSetting), typeof(APIStorageConnectionStringSetting),Lifestyle.Singleton);
            container.RegisterWebApiControllers(config);
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

    }
}