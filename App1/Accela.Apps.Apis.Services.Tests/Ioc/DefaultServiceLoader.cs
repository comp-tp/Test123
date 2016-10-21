using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Core.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Shared.Contants;
using Accela.Apps.Apis.Repositories.Agency;
using Accela.Apps.Shared.Gateway.Client;
using System.Runtime.Remoting.Messaging;
using Accela.Infrastructure.Caches;

namespace Accela.Apps.Apis.Services.Tests.Ioc
{
    public class RecordRepositoryFactory
    {
        public static IRecordRepository Get()
        {
            var currentAgencyContext = IocContainer.Resolve<IAgencyAppContext>();
            var gatewayClient = IocContainer.Resolve<IGatewayClient>();
            return Get(currentAgencyContext, gatewayClient);
        }

        private static IRecordRepository Get(IAgencyAppContext currentAgencyContext, IGatewayClient gatewayClient)
        {
            if (currentAgencyContext == null)
            {
                throw new ArgumentNullException("Agency Context can not be null.");
            }

            switch (currentAgencyContext.AppType)
            {
                case AppType.Agency:
                    return new RecordRepository(currentAgencyContext);
                case AppType.Citizen:
                    return new Repositories.Citizen.RecordRepository(currentAgencyContext, gatewayClient);
                default:
                    throw new NotImplementedException("Can not find the Repository Type");
            }
        }
    }

    public class DefaultServiceLoader : IServiceLoader
    {
        public int SortOrder
        {
            //should be loaded before everyone else
            get { return 100; }
        }

        public void Load(IServiceLocator container)
        {
            container.Register<IAgencyAppContext>(() => new LocalContextProvider().GetContextEntity(), ServiceLifecycle.PerWebApiRequest);
            //container.RegisterWithRegistration<MemoryCacheStoreProvider>(ServiceLifecycle.Singleton, typeof(CacheStoreProvider), typeof(IMemoryCacheProvider));
            //container.Register<CacheStoreProvider, MemoryCacheStoreProvider>(ServiceLifecycle.Singleton);
            //container.Register<IMemoryCacheProvider, MemoryCacheStoreProvider>(ServiceLifecycle.Singleton);
            container.Register(RecordRepositoryFactory.Get, ServiceLifecycle.PerCall);
        }

    }

    public class LocalContextProvider
    {
        private IAgencyAppContext _contextEntity;
        private object lockObject = new Object();
        public IAgencyAppContext GetContextEntity()
        {

            if (_contextEntity == null)
            {
                lock (lockObject)
                {
                    _contextEntity = (IAgencyAppContext)CallContext.LogicalGetData("ContextEntity");

                    if (_contextEntity == null || _contextEntity.App == null)
                    {
                        _contextEntity = new UnKownAgencyAppContext();
                    }
                    if (_contextEntity.ContextUser == null)
                    {
                        _contextEntity.ContextUser = new UnKownContextUser();
                    }
                }
            }
            return _contextEntity;
        }
    }
}
