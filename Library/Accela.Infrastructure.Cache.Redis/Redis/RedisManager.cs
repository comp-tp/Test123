using System;
using System.Diagnostics;
using StackExchange.Redis;
using Accela.Core.Configurations;
using Accela.Infrastructure.Cache.Redis.Redis;
using Accela.Infrastructure.Configurations;

namespace Accela.Infrastructure.Cache.Redis
{
    public class RedisManager
    {
        private static ConnectionMultiplexer _cacheService;
        private static volatile IDatabase instance;
        private static object syncRoot = new Object();

        private readonly IRedisConfigurationSettings redisConfigurationSettings;
        //private readonly static Func<IConfiguration> ConfigurationSettingsProvider;
        private static IConfigurationReader ConfigurationSettings { get { return ConfigurationSettingsManager.Get(); } }


        static RedisManager()
        {
            //ConfigurationSettingsProvider = ConfigurationProvider.Instance.Get; //IocContainer.Resolve<IConfiguration>();
            //_instance = new CouchbaseClient();
        }

        public RedisManager()
        {

        }

        public RedisManager(IRedisConfigurationSettings redisConfigurationSettings)
        {
            this.redisConfigurationSettings = redisConfigurationSettings;
        }

       
        //private static Lazy<ConnectionMultiplexer> redisConnection = new Lazy<ConnectionMultiplexer>(() =>
        //{
        //    return ConnectionMultiplexer.Connect(GetConnectionSettings(true));
        //});

        //private static ConnectionMultiplexer RedisConnection
        //{
        //    get
        //    {
        //        return redisConnection.Value;
        //    }
        //}


        public static IDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            try
                            {
                                _cacheService = GetConnectionMultiplexer();
                                instance = _cacheService.GetDatabase();
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine(ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    if (_cacheService == null || !_cacheService.IsConnected)
                    {
                        lock (syncRoot)
                        {
                            try
                            {
                                _cacheService = GetConnectionMultiplexer();
                                instance = _cacheService.GetDatabase();
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine(ex.Message);
                            }
                        }
                    }
                }
                return instance;
            }
        }

        public static ConnectionMultiplexer GetConnectionMultiplexer(bool allowAdmin = false)
        {
            return ConnectionMultiplexer.Connect(GetConnectionSettings(allowAdmin));
        }

        private static string GetConnectionSettings(bool allowAdmin = false)
        {
            //if (redisConfigurationSettings != null)
            //{ 
            
            //}

            var allowAdminSettingString = allowAdmin ? ",allowAdmin=true" : String.Empty;
            var connString = string.Format("{0}:{1},ssl={2},password={3}{4}",
                ConfigurationSettings.Get("redis.server",  true),
                ConfigurationSettings.Get("redis.port",  true),
                ConfigurationSettings.Get("redis.ssl",  true),
                ConfigurationSettings.Get("redis.password", true),
                allowAdminSettingString);
            //var redisConnectionstring = ConfigurationManager.ConnectionStrings["RedisConnection"].ConnectionString;
            return connString;
        }
    }
}
