using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Infrastructure.Cache.Redis.Redis
{
    public interface IRedisConfigurationSettings
    {
        string UserName { get; set; }

        string Password { get; set; }

        bool Ssl { get; set; }

        bool AllowAdmin { get; set; }

        int Port { get; set; }

        string ServerEndpoint { get; set; }
    }
}
