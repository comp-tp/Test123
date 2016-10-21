using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Accela.Core.Ioc;
using Accela.Core.Configurations;
using Accela.Infrastructure.Configurations;

namespace Accela.Apps.Shared.Web.Utilities
{
    /// <summary>
    /// Config class.
    /// </summary>
    public static class ConfigHelper
    {
        //private readonly static Func<IConfiguration> ConfigurationSettingsProvider;
        private static IConfigurationReader ConfigurationSettings { get { return ConfigurationSettingsManager.Get(); } }

        static ConfigHelper()
        {
            //ConfigurationSettingsProvider = ConfigurationProvider.Get; //IocContainer.Resolve<IConfiguration>();
        }

        /// <summary>
        /// Page size.
        /// </summary>
        const string PAGE_SIZE = "PageSize";

        /// <summary>
        /// Get page size.
        /// </summary>
        /// <returns>Page size.</returns>
        public static int? GetPageSize()
        {
            int? result = null;

            string pageSizeString = ConfigurationSettings.Get(PAGE_SIZE);

            if (!String.IsNullOrWhiteSpace(pageSizeString))
            {
                int parsedPageSize = 0;
                if (int.TryParse(pageSizeString, out parsedPageSize))
                {
                    result = parsedPageSize;
                }
            }

            return result;
        }
    }
}