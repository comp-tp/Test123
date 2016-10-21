using Accela.Core.Ioc;
using Accela.Core.Utilities;
using Accela.Infrastructure.Configurations;
using System;
using System.Collections.Concurrent;

namespace Accela.Core.Configurations
{
    /// <summary>
    /// Workaround for static helper classes where Constructor injection is not option for "IConfiguration"
    /// </summary>
    public sealed class ConfigurationSettingsManager
    {
        private static volatile IConfigurationReader _configurationSettingsReader;

        private static object syncRoot = new Object();

        private static ConcurrentDictionary<string, IConfigurationReader> _configurationSettingReaders;
        private static ConcurrentDictionary<string, object> _configurationSettings;

        /// <summary>
        /// Can not create instance of ConfigurationSettingsManager
        /// </summary>
        private ConfigurationSettingsManager()
        {
        }

        static ConfigurationSettingsManager()
        {
            _configurationSettingReaders = new ConcurrentDictionary<string, IConfigurationReader>();
            _configurationSettings = new ConcurrentDictionary<string, object>();
        }

        public static bool Add(string name, IConfigurationReader configurationSettingsReader)
        {
            Guard.Requires<ArgumentNullException>(!string.IsNullOrEmpty(name), "name", "name is required");
            Guard.Requires<ArgumentNullException>(configurationSettingsReader != null, "configurationSettingsReader", "configurationSettingsReader is required");

            if (_configurationSettingReaders.ContainsKey(name))
            {
                throw new Exception("configuration name is already exists.");
            }
            return _configurationSettingReaders.TryAdd(name, configurationSettingsReader);
        }

        public static IConfigurationReader Get()
        {
            if (_configurationSettingsReader == null)
            {
                lock (syncRoot)
                {
                    if (_configurationSettingsReader == null)
                    {
                        _configurationSettingsReader = IocContainer.Resolve<IConfigurationReader>();
                    }
                }
            }
            return _configurationSettingsReader;
        }

        public static IConfigurationReader Get(string name)
        {
            Guard.Requires<ArgumentNullException>(!string.IsNullOrEmpty(name), "name", "ConfigurationSettings name is required");
            IConfigurationReader configuration;
            if (_configurationSettingReaders.TryGetValue(name, out configuration))
            {
                return configuration;
            }
            return null;
        }

        public static T GetSettings<T>()
        {
            var key = typeof(T).FullName;
            object configuration;
            if (_configurationSettings.TryGetValue(key, out configuration))
            {
                return (T)configuration;
            }
            throw new Exception("Configuration does not exists.");
        }

        public static bool AddSettings<T>(T value)
        {
            var key = value.GetType().FullName;
            if (_configurationSettings.ContainsKey(key))
            {
                throw new Exception("Configuration is already exists.");
            }
            return _configurationSettings.TryAdd(key, value);
        }



    }
}
