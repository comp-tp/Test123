using Accela.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Accela.Apps.Core;

namespace Accela.Infrastructure.Configurations
{
    public class AppConfigurationReader : IConfigurationReader
    {
        public AppConfigurationReader()
        {

        }

        public virtual string Get(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key] ?? string.Empty;
            }
            catch
            {
                //todo:
                //log error?
            }
            return string.Empty;        
        }
    

        public virtual string Get(string key, string defaultValue)
        {
            try
            {
                return ConfigurationManager.AppSettings[key] ?? defaultValue;
            }
            catch (Exception ex)
            {
                //todo:
                //log error?
                throw ex;
            }
        }

        public virtual string Get(string key, bool throwKeyNotFoundException)
        {
            //var returnValue = string.Empty;
            try
            {
                var configValue = ConfigurationManager.AppSettings[key];
                if (string.IsNullOrEmpty(configValue) && throwKeyNotFoundException)
                {
                    throw new ConfigurationKeyNotFoundException(string.Format("{0} not found", key));
                }
                return configValue;
            }
            catch(Exception ex)
            {
                //todo:
                //log error?
                throw ex;
            }
        }

        public virtual T Get<T>(string key) where T : struct, IConvertible
        {
            try
            {
                var configValue = ConfigurationManager.AppSettings[key];
                if (string.IsNullOrEmpty(configValue))
                {
                    throw new ConfigurationKeyNotFoundException(string.Format("{0} not found", key));
                }
                return configValue.ConvertTo<T>();
            }
            catch (Exception ex)
            {
                //todo:
                //log error?
                throw ex;
            }
        }

        public virtual T Get<T>(string key, T defaultValue) where T : struct, IConvertible
        {
            try
            {
                var configValue = ConfigurationManager.AppSettings[key];
                if (string.IsNullOrEmpty(configValue))
                {
                    return defaultValue;
                }
                return configValue.ConvertTo<T>();
            }
            catch (Exception ex)
            {
                //todo:
                //log error?
                throw ex;
            }
        }

        public virtual T Get<T>(string key, bool throwKeyNotFoundException) where T : struct, IConvertible
        {
            var configValue = Get(key, "");
            if (string.IsNullOrEmpty(configValue) && throwKeyNotFoundException)
            {
                throw new ConfigurationKeyNotFoundException(string.Format("{0} not found", key));
            }
            return configValue.ConvertTo<T>();
        }

        //public virtual Task<T> GetAsync<T>(string key) where T : IConvertible
        //{
        //    throw new NotImplementedException();
        //}

        //public virtual Task<T> GetAsync<T>(string key, T defaultValue) where T : IConvertible
        //{
        //    throw new NotImplementedException();
        //}

        //public virtual Task<T> GetAsync<T>(string key, bool throwKeyNotFoundException) where T : IConvertible
        //{
        //    throw new NotImplementedException();
        //}
    }
}
