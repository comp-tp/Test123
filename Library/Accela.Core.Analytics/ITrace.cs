using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Core.Analytics
{
    public interface ITrace
    {
        void Trace(StatsData data);
    }
}
