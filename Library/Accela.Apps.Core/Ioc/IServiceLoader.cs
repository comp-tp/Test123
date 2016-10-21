using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Core.Ioc
{
    public interface IServiceLoader
    {
        int SortOrder { get; }
        void Load(IServiceLocator container);
    }
}
