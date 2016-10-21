using Accela.Core.Ioc;
using Accela.Infrastructure.Configuration.App.Configurations;
using Accela.Infrastructure.Configurations;


namespace Accela.Infrastructure.Configuration.App.Ioc
{
    public class DefaultServiceLoader : IServiceLoader
    {
        public int SortOrder
        {
            //should be loaded before everyone else
            get { return 200; }
        }

        public void Load(IServiceLocator container)
        {
            container.Register<IConfigurationReader, AppConfigurationReader>(ServiceLifecycle.Singleton);
            container.Register<ISystemConfig, SystemConfig>(ServiceLifecycle.Singleton);
        }
    }
}
