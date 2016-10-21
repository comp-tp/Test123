using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Core.Ioc
{
    /// <summary>
    /// the code is from :
    /// http://simpleinjector.codeplex.com/wikipage?title=InterceptionExtensions&referringTitle=Advanced-scenarios
    /// </summary>
    public interface IInvocation
    {
        object InvocationTarget { get; }

        object ReturnValue { get; set; }

        void Proceed();

        MethodBase GetConcreteMethod();
    }
}
