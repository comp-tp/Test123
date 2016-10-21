

namespace Accela.Infrastructure.Azure.Configurations
{
    using Accela.Infrastructure.Exceptions;
    using Accela.Infrastructure.Configurations;
    using Microsoft.Azure;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Threading.Tasks;

    
    /// <summary>
    /// Reads configuration values from ServiceConfiguration.cscfg
    /// </summary>
    public class AzureConfigurationReader : IConfigurationReader
    {
        public AzureConfigurationReader()
        {
            //CloudConfigurationManager
        }

        public virtual T Get<T>(string key, bool throwKeyNotFoundException) where T : struct, IConvertible
        {
            var configValue = Get(key, "");
            if (string.IsNullOrEmpty(configValue) && throwKeyNotFoundException)
            {
                throw new ConfigurationKeyNotFoundException(string.Format("{0} not found", key));
            }
            return TryParse<T>(configValue);
        }

        public virtual T Get<T>(string key, T defaultValue) where T : struct, IConvertible
        {
            var returnValue = defaultValue;
            try
            {
                var configValue = CloudConfigurationManager.GetSetting(key);
                if (string.IsNullOrEmpty(configValue))
                {
                    return defaultValue;
                }
                returnValue = TryParse<T>(configValue);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError("AzureConfigurationReader failed to get " + key, ex);
            }
            return returnValue;
        }

        public virtual T Get<T>(string key) where T : struct, IConvertible
        {
            var configValue = Get(key, "");
            if (string.IsNullOrEmpty(configValue))
            {
                throw new ConfigurationKeyNotFoundException(string.Format("{0} not found", key));
            }
            return TryParse<T>(configValue);
        }

        public virtual string Get(string key, bool throwKeyNotFoundException)
        {
            var returnValue = string.Empty;
            try
            {
                var configValue = CloudConfigurationManager.GetSetting(key);
                if (string.IsNullOrEmpty(configValue) && throwKeyNotFoundException)
                {
                    throw new ConfigurationKeyNotFoundException(string.Format("{0} not found", key));
                }
                return configValue;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError("AzureConfigurationReader failed to get " + key, ex);
            }
            return returnValue;
        }

        public virtual string Get(string key, string defaultValue)
        {
            try
            {
                return CloudConfigurationManager.GetSetting(key) ?? defaultValue;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError("AzureConfigurationReader failed to get " + key, ex);
            }
            return defaultValue;
        }

        public virtual string Get(string key)
        {
            try
            {
                return CloudConfigurationManager.GetSetting(key);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError("AzureConfigurationReader failed to get " + key, ex);
            }
            return string.Empty;
        }

        //todo: move this base helper class.
        public  static T TryParse<T>(string inValue)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            return (T)converter.ConvertFromString(null, CultureInfo.InvariantCulture, inValue);
        }
    }
}
