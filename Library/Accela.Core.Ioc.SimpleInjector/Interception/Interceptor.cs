using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;

namespace Accela.Core.Ioc.SimpleInjector.Interception
{
    /// <summary>
    /// the code is from :
    /// http://simpleinjector.codeplex.com/wikipage?title=InterceptionExtensions&referringTitle=Advanced-scenarios
    /// </summary>
    public static class Interceptor
    {
        public static T CreateProxy<T>(IInterceptor interceptor, T realInstance)
        {
            return (T)CreateProxy(typeof(T), interceptor, realInstance);
        }

        [DebuggerStepThrough]
        public static object CreateProxy(Type serviceType, IInterceptor interceptor,
            object realInstance)
        {
            var proxy = new InterceptorProxy(serviceType, realInstance, interceptor);

            return proxy.GetTransparentProxy();
        }

        private sealed class InterceptorProxy : RealProxy
        {
            private object realInstance;
            private IInterceptor interceptor;

            [DebuggerStepThrough]
            public InterceptorProxy(Type classToProxy, object realInstance,
                IInterceptor interceptor)
                : base(classToProxy)
            {
                this.realInstance = realInstance;
                this.interceptor = interceptor;
            }

            public override IMessage Invoke(IMessage msg)
            {
                if (msg is IMethodCallMessage)
                {
                    return this.InvokeMethodCall((IMethodCallMessage)msg);
                }

                return msg;
            }

            private IMessage InvokeMethodCall(IMethodCallMessage message)
            {
                var invocation = new Invocation { Proxy = this, Message = message };

                invocation.Proceeding += (s, e) =>
                {
                    try
                    {
                        invocation.ReturnValue = message.MethodBase.Invoke(
                        this.realInstance, message.Args);
                    }
                    catch (TargetInvocationException ex)
                    {
                        if (ex.InnerException != null)
                        {
                            throw ex.InnerException;
                        }
                        else
                        {
                            throw;
                        }
                    }
                };

                this.interceptor.Intercept(invocation);

                return new ReturnMessage(invocation.ReturnValue, null, 0, null, message);
            }

            private class Invocation : IInvocation
            {
                public event EventHandler Proceeding;

                public InterceptorProxy Proxy { get; set; }

                public IMethodCallMessage Message { get; set; }

                public object ReturnValue { get; set; }

                public object InvocationTarget
                {
                    get { return this.Proxy.realInstance; }
                }

                public void Proceed()
                {
                    if (this.Proceeding != null)
                    {
                        this.Proceeding(this, EventArgs.Empty);
                    }
                }

                public MethodBase GetConcreteMethod()
                {
                    return this.Message.MethodBase;
                }
            }
        }
    }

}
