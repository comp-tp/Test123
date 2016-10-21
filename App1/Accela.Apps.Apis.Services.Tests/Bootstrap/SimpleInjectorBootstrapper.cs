using Accela.Core.Ioc.SimpleInjector;
using Accela.Core.Ioc;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using SimpleInjector;

namespace Accela.Apps.Apis.Services.Tests.Bootstrap
{
    public class SimpleInjectorBootstrapper
    {

        public static Container Bootstrap()
        {
            IocContainer.Current = new ServiceLocator();
            IocContainer.Current.LoadAll("Accela.*.dll", "");
            var container = IocContainer.Current.IocContainer as Container;
            //container.RegisterWebApiControllers(config);
            container.Verify();
            //GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            return container;
        }
    }
}