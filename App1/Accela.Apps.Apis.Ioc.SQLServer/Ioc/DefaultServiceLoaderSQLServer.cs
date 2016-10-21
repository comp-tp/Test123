using Accela.Apps.Apis.Repositories.Agency;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Apis.Repositories.Interfaces.Admin;
using Accela.Apps.Apis.Services.Host.Contexts;
using Accela.Apps.Shared.Contants;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Shared.Gateway.Client;
using Accela.Core.Configurations;
using Accela.Core.Ioc;
using Accela.Infrastructure.Caches;
using Accela.Infrastructure.SQLServer.Queue;
using Accela.Infrastructure.SQLServer.Tables;
using Accela.Infrastructure.Storage.SQLServer.Binary;
using System;

namespace Accela.Apps.Apis.Ioc
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

    public class ReferenceDataRepositoryFactory
    {
        public static IReferenceDataRepository Get()
        {
            var currentAgencyContext = IocContainer.Resolve<IAgencyAppContext>();
            var gatewayClient = IocContainer.Resolve<IGatewayClient>();
            return Get(currentAgencyContext, gatewayClient);
        }

        private static IReferenceDataRepository Get(IAgencyAppContext currentAgencyContext, IGatewayClient gatewayClient)
        {
            if (currentAgencyContext == null)
            {
                throw new ArgumentNullException("Agency Context can not be null.");
            }

            switch (currentAgencyContext.AppType)
            {
                case AppType.Agency:
                    return new ReferenceDataRepository(currentAgencyContext);
                case AppType.Citizen:
                    return new Repositories.Citizen.ReferenceDataRepository(currentAgencyContext, gatewayClient);
                default:
                    throw new NotImplementedException("Can not find the Repository Type");
            }
        }
    }

    public class AttachmentRepositoryFactory
    {
        public static IAttachmentRepository Get()
        {
            var currentAgencyContext = IocContainer.Resolve<IAgencyAppContext>();

            var gatewayClient = IocContainer.Resolve<IGatewayClient>();
            return Get(currentAgencyContext, gatewayClient);
        }

        private static IAttachmentRepository Get(IAgencyAppContext currentAgencyContext, IGatewayClient gatewayClient)
        {
            if (currentAgencyContext == null)
            {
                throw new ArgumentNullException("Agency Context can not be null.");
            }

            switch (currentAgencyContext.AppType)
            {
                case AppType.Agency:
                    return new AttachmentRepository(currentAgencyContext, gatewayClient);
                case AppType.Citizen:
                    return new Repositories.Citizen.AttachmentRepository(currentAgencyContext,gatewayClient);
                default:
                    throw new NotImplementedException("Can not find the Repository Type");
            }
        }
    }

    public class UserRepositoryFactory
    {
        public static IUserRepository Get()
        {
            var currentAgencyContext = IocContainer.Resolve<IAgencyAppContext>();
            var gatewayClient = IocContainer.Resolve<IGatewayClient>();

            return Get(currentAgencyContext, gatewayClient);
        }

        private static IUserRepository Get(IAgencyAppContext currentAgencyContext, IGatewayClient gatewayClient)
        {
            if (currentAgencyContext == null)
            {
                throw new ArgumentNullException("Agency Context can not be null.");
            }

            switch (currentAgencyContext.AppType)
            {
                case AppType.Agency:
                    return new UserRepository(currentAgencyContext,gatewayClient);
                case AppType.Citizen:
                    return new Repositories.Citizen.UserRepository(ConfigurationSettingsManager.Get());
                default:
                    throw new NotImplementedException("Can not find the Repository Type");
            }
        }
    }


    

    public class DefaultServiceLoader : IServiceLoader
    {
        public int SortOrder
        {
            //should be loaded at the end
            get { return 100; }
        }

        public void Load(IServiceLocator container)
        {
            container.Register(AgencyContextProvider.Get, ServiceLifecycle.PerWebApiRequest);

            //var connectionString = container.ConfigurationReader.Get(ConnectionStrings.ApiStorageSettingName);

            //container.Register<IBinaryStorage>(() => {
            //    return new Accela.Infrastructure.Azure.Storage.AzureBinaryStorage(connectionString, new Accela.Infrastructure.CustomRetryPolicyConfiguration()); }, 
            //        ServiceLifecycle.Singleton);


            //Register Right Cache Provider for the application (API Service)
            container.Register<CacheStoreProvider, MemoryCacheStoreProvider>(ServiceLifecycle.Singleton);
            //container.Register<CacheStoreProvider, CouchbaseCacheProvider>(ServiceLifecycle.Singleton);
            //container.Register<CacheStoreProvider, RedisCacheProvider>(ServiceLifecycle.Singleton);
            
            container.Register(RecordRepositoryFactory.Get, ServiceLifecycle.PerCall);
            container.Register(ReferenceDataRepositoryFactory.Get, ServiceLifecycle.PerCall);
            container.Register(AttachmentRepositoryFactory.Get, ServiceLifecycle.PerCall);
            container.Register(UserRepositoryFactory.Get, ServiceLifecycle.PerCall);

            //container.RegisterSingleOpenGeneric(typeof(IAnalyticReader<,>), typeof(CouchbaseAnalyticReader<>));
            //container.RegisterSingleOpenGeneric(typeof(IAnalyticWriter<,>), typeof(CouchbaseAnalyticWriter<>));

            //container.RegisterSingleOpenGeneric(typeof(IAnalyticReaderService<,>), typeof(AnalyticsReaderService<,>));
            //container.RegisterSingleOpenGeneric(typeof(IAnalyticWriterService<,>), typeof(AnalyticsWriterService<,>));

            

            container.Register<ISQLServerTableStorageRepository>(() =>
            {
                var storageConnectionString = container.ConfigurationReader.Get("Api_StorageConnectionString");
                return new SQLServerTableStorageRepository(storageConnectionString);              
            }, ServiceLifecycle.Singleton);
            container.Register<ISQLServerQueueStorageRepository>(() =>
            {
                var storageConnectionString = container.ConfigurationReader.Get("Api_StorageConnectionString");
                return new SQLServerQueueStorageRepository(storageConnectionString);
            }, ServiceLifecycle.Singleton);
            container.Register<ISQLServerBinaryStorageRepository>(() =>
            {
                var storageConnectionString = container.ConfigurationReader.Get("Api_StorageConnectionString");
                return new SQLServerBinaryStorageRepository(storageConnectionString);
            }, ServiceLifecycle.Singleton);

           

        }
    }
}