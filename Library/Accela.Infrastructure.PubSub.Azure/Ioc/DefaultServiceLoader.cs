using Accela.Core.Ioc;
using Accela.Infrastructure.PubSub;
using System;

namespace Accela.Infrastructure.PubSub.Azure.Ioc
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
            container.Register(typeof(IPublisher<>), typeof(Publisher<>), ServiceLifecycle.Singleton);
            container.Register(typeof(ISubscriber<>), typeof(Subscriber<>), ServiceLifecycle.Singleton);
        }
    }
}
