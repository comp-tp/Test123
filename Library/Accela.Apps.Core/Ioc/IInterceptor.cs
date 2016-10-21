using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Core.Ioc
{
    /// <summary>
    /// the code is from :
    /// http://simpleinjector.codeplex.com/wikipage?title=InterceptionExtensions&referringTitle=Advanced-scenarios
    /// </summary>
    public interface IInterceptor
    {
        void Intercept(IInvocation invocation);
    }
}
