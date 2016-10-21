using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Core.Logging
{
    public interface ILogFactory
    {
        ILog GetLog();
    }
}
