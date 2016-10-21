using Accela.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Core.Ioc
{
    public interface IServiceLocator : IDisposable
    {
        IConfigurationReader ConfigurationReader { get; set; }

        void LoadAll(string dllSearchPattern, string folderPath, Func<IEnumerable<Assembly>, IEnumerable<Assembly>> assemblyFilter);
        void LoadAll(string dllSearchPattern, string folderPath);
        void LoadAll(string dllSearchPattern);
        void LoadAll(Func<IEnumerable<Assembly>, IEnumerable<Assembly>> assemblyFilter);
        void LoadAll();


        void Register(Type serviceType, Type concreteType, ServiceLifecycle lifecycle = ServiceLifecycle.PerCall);

        void RegisterWithRegistration<T>(ServiceLifecycle lifecycle, params Type[] interfaces) where T: class;



        void RegisterSingle<ServiceType>() where ServiceType : class;

        void Register<ServiceType, ConcreteType>(ServiceLifecycle lifecycle = ServiceLifecycle.PerCall)
            where ServiceType : class
            where ConcreteType : class, ServiceType;

        void RegisterInstance(Type serviceType, object instance);

        void RegisterInstance<ServiceType>(ServiceType instance) where ServiceType : class;

        object Resolve(Type serviceType);

        ServiceType Resolve<ServiceType>() where ServiceType : class;

        IEnumerable<T> ResolveAll<T>() where T : class;

        object IocContainer { get; }

        void RegisterSingleOpenGeneric(Type serviceType, Type instance);

        //void RegisterWithContext<T>(Func<T> dependencyContext);
        void RegisterManyForOpenGeneric(Type serviceType, Type instance, ServiceLifecycle lifecycle);

        void Register<ServiceType>(Func<ServiceType> instanceCreater, ServiceLifecycle lifecycle) where ServiceType : class;

        void RegisterAll<T>(IEnumerable<T> services) where T : class;
        void RegisterAll<T>(IEnumerable<Type> services) where T : class;

        void InterceptWith<TInterceptor>(Func<Type, bool> predicate) where TInterceptor : class, IInterceptor;

        void InterceptWith(Func<IInterceptor> interceptorCreator, Func<Type, bool> predicate);

        void InterceptWith(IInterceptor interceptor, Func<Type, bool> predicate);
    }

    #region ServiceLifecycle
    public enum ServiceLifecycle
    {
        PerCall,
        Singleton,
        PerWebRequest,
        PerWebApiRequest
    }
    #endregion ServiceLifecycle
}
