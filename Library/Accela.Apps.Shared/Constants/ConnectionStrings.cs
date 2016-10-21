using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;
using Accela.Core.Ioc;
using Accela.Infrastructure.Configurations;

namespace Accela.Apps.Shared
{
    public static class ConnectiongStrings
    {
        private static IConfigurationReader ConfigurationSettings;

        static ConnectiongStrings()
        {
            ConfigurationSettings = IocContainer.Resolve<IConfigurationReader>();
        }

        public static void SetTestConfig(IConfigurationReader config)
        {
            ConfigurationSettings = config;
        }


        public static string GetEntityConnectionString(string connectionStringsKey, string entityResourcePath, Type entityContainer)
        {
            var csBuilder = new EntityConnectionStringBuilder();

            csBuilder.Provider = "System.Data.SqlClient";
            csBuilder.ProviderConnectionString = ConfigurationSettings.Get(connectionStringsKey);
            csBuilder.Metadata = string.Format("res://{0}/{1}.csdl|res://{0}/{1}.ssdl|res://{0}/{1}.msl",
                entityContainer.Assembly.FullName, entityResourcePath);

            return csBuilder.ToString();
        }

        /// <summary>
        /// get default connection string based on setting "DefaultSqlConnectionString" 
        /// under appSettings section in Web.config or Cloud Service Configuration file 
        /// for SQL Server.
        /// </summary>
        public static string Default4SQLServer
        {
            get
            {
                var connectionString = ConfigurationSettings.Get("DefaultSqlConnectionString");
                return connectionString;
            }
        }

        /// <summary>
        /// get default connection string based on setting "DefaultDataContextConnectionStringName" 
        /// and "DefaultDataContextConnectionStringPattern" under appSettings section in Web.config 
        /// or Cloud Service Configuration file for Entity Framework.
        /// </summary>
        public static string Default4EntityFramework
        {
            get
            {
                var entityConnectionString = GetEntityConnectionString("DefaultDataContextConnectionStringName", "DefaultDataContextConnectionStringPattern");
                return entityConnectionString;
            }
        }

        public static string AzureStorageSettingKey
        {
            get
            {
                return "StorageConnectionString";
            }
        }

        public static string InternalAPIAccessKey
        {
            get
            {
                return ConfigurationSettings.Get("InternalAPI_AccessKey",  true);
            }
        }
        /// <summary>
        /// Gets connection string by key of connection string name.
        /// </summary>
        /// <param name="keyOfConnectionStringName">Name of the key of connection string.</param>
        /// <returns>connection string</returns>
        public static string GetConnectionStringByKeyOfName(string keyOfConnectionStringName)
        {
            var connectionStringName = ConfigurationSettings.Get(keyOfConnectionStringName);
            var connectionString = ConfigurationSettings.Get(connectionStringName);
            return connectionString;
        }

        /// <summary>
        /// Gets the connection provider by key of connection string name.
        /// </summary>
        /// <param name="keyOfConnectionStringName">Name of the key of connection string.</param>
        /// <returns>connection provider</returns>
        public static string GetConnectionProviderByKeyOfName(string keyOfConnectionStringName)
        {
            var connectionStringName = ConfigurationSettings.Get(keyOfConnectionStringName);
            var keyOfProviderName = connectionStringName + "ProviderName";
            var providerName = ConfigurationSettings.Get(keyOfProviderName);
            return providerName;
        }

        /// <summary>
        /// Gets the entity connection string.
        /// </summary>
        /// <param name="keyOfConnectionStringName">Name of the key of connection string.</param>
        /// <param name="keyOfEntityConnectionStringPattern">The key of entity connection string pattern.</param>
        /// <returns>the entity connection string.</returns>
        public static string GetEntityConnectionString(string keyOfConnectionStringName, string keyOfEntityConnectionStringPattern)
        {
            var connectionString = GetConnectionStringByKeyOfName(keyOfConnectionStringName);
            var providerName = GetConnectionProviderByKeyOfName(keyOfConnectionStringName);

            var entityConnectionStringPattern = ConfigurationSettings.Get(keyOfEntityConnectionStringPattern);
            var entityConnectionString = String.Format(entityConnectionStringPattern, providerName, connectionString);
            return entityConnectionString;
        }
    }
}