using Accela.Core.Ioc;
using Accela.Infrastructure.Azure.Configurations;
using Accela.Infrastructure.Configuration.Azure.Configurations;
using Accela.Infrastructure.Configurations;

namespace Accela.Infrastructure.Configuration.Azure.Ioc
{
    public class DefaultServiceLoader : IServiceLoader
    {
        public int SortOrder
        {
            //should be loaded before everyone else
            get { return 300; }
        }

        public void Load(IServiceLocator container)
        {
            container.Register<IConfigurationReader, AzureConfigurationReader>(ServiceLifecycle.Singleton);
            container.Register<ISystemConfig, AzureSystemConfig>(ServiceLifecycle.Singleton);
        }
    }
}
