using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Exceptions
{
    public class ConfigurationKeyNotFoundException : AccelaBaseException
    {
        public ConfigurationKeyNotFoundException(string message)
            : base(message)
        {
        }
    }
}
