using Accela.Infrastructure;
using Accela.Infrastructure.Configurations;
using Accela.Infrastructure.PubSub;
using Accela.Infrastructure.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accela.Apps.Apis.Ioc
{
    public class ServiceBusConnectionStringSetting : ConnectionStringSettingBase , IServiceBusConnectionStringSetting
    {
        public ServiceBusConnectionStringSetting(IConfigurationReader configurationReader) : base(configurationReader)
        {
        }

        public override string Get()
        {
            return base.ConfigurationReader.Get("Microsoft.ServiceBus.ConnectionString");
        }
    }
}