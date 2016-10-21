using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Infrastructure.Configurations;
using Accela.Core.Configurations;

namespace Accela.Apps.Apis.Common
{
    public static class ConnectionStrings
    {
        private static IConfigurationReader ConfigurationSettings { get { return ConfigurationSettingsManager.Get(); } }
        public const string ApiStorageSettingName = "Api_StorageConnectionString";

        public static string ApiDB
        {
            get
            {
                return ConfigurationSettings.Get("Api_DBConnectionString");
            }
        }
    }
}
