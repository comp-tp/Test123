using Accela.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Accela.Infrastructure.Configuration.App.Configurations
{
    public class SystemConfig : ISystemConfig
    {
        public string GetInstanceId()
        {
            return Dns.GetHostName();
        }
    }
}
