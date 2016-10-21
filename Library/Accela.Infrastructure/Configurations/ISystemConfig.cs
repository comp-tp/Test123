using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Configurations
{
    /// <summary>
    /// This interface represent OS system configuration
    /// </summary>
    public interface ISystemConfig
    {
        string GetInstanceId();
    }
}
