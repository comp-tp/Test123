using Accela.Core.Ioc;
using Accela.Core.Logging;
using System;
using System.Diagnostics;

namespace Accela.Apps.Shared.Ioc
{
    public class MonitoringInterceptor : IInterceptor
    {
        private readonly ILogFactory _logFactory;

        public MonitoringInterceptor(ILogFactory logFactory)
        {
            this._logFactory = logFactory;
        }

        public void Intercept(IInvocation invocation)
        {
            var watch = Stopwatch.StartNew();

            // Calls the decorated instance.
            invocation.Proceed();

            try
            {
                var method = invocation.GetConcreteMethod();
                var decoratedType = invocation.InvocationTarget.GetType();
                var logger = this._logFactory.GetLog();

                if (logger.IsDebugEnabled)
                {
                    this._logFactory.GetLog().Debug("Interception", null, decoratedType.Name + "." + method.Name, (int)watch.ElapsedMilliseconds);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }

}
