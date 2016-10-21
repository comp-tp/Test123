using Accela.Core.Ioc;
using Accela.Infrastructure.PubSub;
using System;

namespace Accela.Infrastructure.PubSub.Enterprise.Ioc
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
            container.RegisterSingleOpenGeneric(typeof(IPublisher<>), typeof(Publisher<>));
            container.RegisterSingleOpenGeneric(typeof(ISubscriber<>), typeof(Subscriber<>));
        }
    }
}
