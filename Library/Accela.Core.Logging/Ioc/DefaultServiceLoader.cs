using Accela.Core.Ioc;
using Accela.Core.Logging.NLog;
using System;

namespace Accela.Core.Logging
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
            container.Register<ILogFactory, LogFactory>(ServiceLifecycle.Singleton);
            container.Register<ILogger, NLogLogger>(ServiceLifecycle.Singleton);
            container.Register<ILog, LogImpl>(ServiceLifecycle.Singleton);
        }
    }
}
