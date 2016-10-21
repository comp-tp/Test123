using Accela.Core.Ioc;
using Accela.Infrastructure.Azure.DocumentDB;
using Accela.Infrastructure.Azure.Queue;
using Accela.Infrastructure.Azure.Storage;
using Accela.Infrastructure.Azure.Tables;
using Accela.Infrastructure.DocumentDB;
using Accela.Infrastructure.Queue;
using Accela.Infrastructure.Storage;
using Accela.Infrastructure.Tables;

namespace Accela.Infrastructure.Azure.Ioc
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
            container.RegisterSingleOpenGeneric(typeof(ITableStorage<>), typeof(AzureTableStorage<>));
            container.RegisterSingleOpenGeneric(typeof(IQueueStorage<>), typeof(AzureQueueStorage<>));
            container.RegisterSingleOpenGeneric(typeof(IDocumentContext<>), typeof(AzureDocumentDB<>));
            container.Register<IBinaryStorage, AzureBinaryStorage>(ServiceLifecycle.Singleton);
        }
    }
}
