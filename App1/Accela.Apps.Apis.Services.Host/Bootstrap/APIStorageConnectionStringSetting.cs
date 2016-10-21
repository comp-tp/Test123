using Accela.Infrastructure;
using Accela.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accela.Apps.Apis.Ioc
{
    public class APIStorageConnectionStringSetting : IConnectionStringSetting
    {
        IConfigurationReader _reader = null;
        public APIStorageConnectionStringSetting(IConfigurationReader configurationReader)
        {
            _reader = configurationReader;
        }

        public string Get()
        {
            return Get("Api_StorageConnectionString");
        }

        public string Get(string key)
        {
            return _reader.Get(key);
        }
    }
}