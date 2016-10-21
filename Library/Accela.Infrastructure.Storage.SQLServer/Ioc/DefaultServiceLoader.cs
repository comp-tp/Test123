using Accela.Core.Ioc;
using Accela.Infrastructure.Queue;
using Accela.Infrastructure.SQLServer.Queue;
using Accela.Infrastructure.SQLServer.Tables;
using Accela.Infrastructure.Storage;
using Accela.Infrastructure.Storage.SQLServer.Binary;
using Accela.Infrastructure.Tables;
using System;

namespace Accela.Infrastructure.SQLServer.Ioc
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
            container.RegisterSingleOpenGeneric(typeof(ITableStorage<>), typeof(SQLServerTableStorage<>));
            container.RegisterSingleOpenGeneric(typeof(IQueueStorage<>), typeof(SQLServerQueueStorage<>));
            container.Register<IBinaryStorage, SQLServerBinaryStorage>(ServiceLifecycle.Singleton);
        }
    }
}
