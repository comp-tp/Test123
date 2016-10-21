using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure
{
    public interface IConnectionStringSetting
    {
        string Get();
        string Get(string key);
    }
}
