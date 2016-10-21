using Accela.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure
{
    public class ConnectionStringSettingBase : IConnectionStringSetting
    {
        protected IConfigurationReader ConfigurationReader = null;
        public ConnectionStringSettingBase(IConfigurationReader configurationReader)
        {
            ConfigurationReader = configurationReader;
        }

        public virtual string Get()
        {
            // child class should implement it
            throw new NotImplementedException();
        }

        public virtual string Get(string key)
        {
            return ConfigurationReader.Get(key);
        }
    }
}
