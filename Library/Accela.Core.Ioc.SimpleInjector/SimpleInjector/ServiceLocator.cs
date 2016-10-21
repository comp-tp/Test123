using Accela.Apps.Core;
using Accela.Core.Ioc.SimpleInjector.Interception;
using Accela.Core.Utilities;
using Accela.Infrastructure.Configurations;
using SimpleInjector;
using SimpleInjector.Extensions;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Accela.Core.Ioc.SimpleInjector
{
    public class ServiceLocator : IServiceLocator
    {
        private Container container = new Container();
        
        public IConfigurationReader ConfigurationReader { get;  set; }

        public ServiceLocator()
        {
            this.container.Options.AllowOverridingRegistrations = true;
            ConfigurationReader = null;
        }

        public ServiceLocator(IConfigurationReader configurationReader)
        {
            this.container.Options.AllowOverridingRegistrations = true;
            ConfigurationReader = configurationReader;
        }

        public void LoadAll(string dllSearchPattern, string folderPath, Func<IEnumerable<Assembly>, IEnumerable<Assembly>> assemblyFilter)
        {
            Guard.Requires<ArgumentNullException>(!string.IsNullOrEmpty(dllSearchPattern), "dllSearchPattern");
            Guard.Requires<ArgumentNullException>(!string.IsNullOrEmpty(folderPath), "folderPath");
            Guard.Requires<ArgumentNullException>(assemblyFilter != null, "assemblyFilter");

            LoadDlls(dllSearchPattern, folderPath, assemblyFilter);
        }

        public void LoadAll(string dllSearchPattern, string folderPath)
        {
            Guard.Requires<ArgumentNullException>(!string.IsNullOrEmpty(dllSearchPattern), "dllSearchPattern");
            //Guard.Requires<ArgumentNullException>(!string.IsNullOrEmpty(folderPath), "folderPath");
            LoadDlls(dllSearchPattern, folderPath, null);
        }

        public void LoadAll(string dllSearchPattern)
        {
            Guard.Requires<ArgumentNullException>(!string.IsNullOrEmpty(dllSearchPattern), "dllSearchPattern");
            LoadDlls(dllSearchPattern, "bin", null);
        }


        public void LoadAll(Func<IEnumerable<Assembly>, IEnumerable<Assembly>> assemblyFilter)
        {
            Guard.Requires<ArgumentNullException>(assemblyFilter != null, "assemblyFilter");
            LoadDlls("Accela.*.dll", "bin", assemblyFilter);
        }

        /// <summary>
        /// Loads all Dlls which starts with "Accela.*" in bin folder
        /// </summary>
        public void LoadAll()
        {
            LoadDlls("Accela.*.dll", "bin", null);
        }

        private void LoadDlls(string dllSearchPattern, string folderPath, Func<IEnumerable<Assembly>, IEnumerable<Assembly>> assemblyFilter = null)
        {
            try
            {
                var assembiles = LoadAssemblies(dllSearchPattern, folderPath);

                if (assemblyFilter != null)
                {
                    assembiles = assemblyFilter(assembiles);
                }

                var serviceLoaders = assembiles
                    .SelectMany(x => x.GetTypes())
                    .Where(x => x.IsClass && x.IsAssignableTo(typeof(IServiceLoader)))
                    .Select(x => (IServiceLoader)Activator.CreateInstance(x))
                    .OrderBy(x => x.SortOrder)
                    .ToArray();

                if (serviceLoaders != null && serviceLoaders.Any())
                {
                    foreach (var serviceLoader in serviceLoaders)
                    {
                        serviceLoader.Load(this);
                    }
                }
            }
            catch(ReflectionTypeLoadException typeLoadExcepiton)
            {
                var exceptions = new StringBuilder();
                foreach(var loadException in typeLoadExcepiton.LoaderExceptions)
                {
                    exceptions.AppendLine(loadException.ToString());
                }

                throw new Exception(exceptions.ToString());
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private IEnumerable<Assembly> LoadAssemblies(string dllSearchPattern, string folderPath)
        {
            var binPath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, folderPath);
            var directory = new DirectoryInfo(binPath);
            var files = directory.GetFiles(dllSearchPattern, SearchOption.TopDirectoryOnly);
            foreach (FileInfo file in files)
            {
                // Load the file into the application domain.
                var assemblyName = AssemblyName.GetAssemblyName(file.FullName);
                var assembly = AppDomain.CurrentDomain.Load(assemblyName);
                yield return assembly;
            }
            yield break;
        }

        public object IocContainer
        {
            get { return this.container; }
        }

        public void Register(Type serviceType, Type concreteType, ServiceLifecycle lifecycle = ServiceLifecycle.PerCall)
        {
            this.container.Register(serviceType, concreteType, this.GetLifestyle(lifecycle));
        }

        public void RegisterSingle<ServiceType>() where ServiceType : class
        {
            this.container.RegisterSingleton<ServiceType>();
        }

        public void Register<ServiceType, ConcreteType>(ServiceLifecycle lifecycle = ServiceLifecycle.PerCall)
            where ServiceType : class
            where ConcreteType : class, ServiceType
        {
            this.container.Register<ServiceType, ConcreteType>(this.GetLifestyle(lifecycle));
        }

        public void RegisterInstance(Type serviceType, object instance)
        {
            this.container.RegisterSingleton(serviceType, instance);
        }

        public void RegisterInstance<ServiceType>(ServiceType instance) where ServiceType : class
        {
            this.container.RegisterSingleton<ServiceType>(instance);
        }


        

        public object Resolve(Type serviceType)
        {
            return this.container.GetInstance(serviceType);
        }

        public ServiceType Resolve<ServiceType>() where ServiceType : class
        {
            return this.container.GetInstance<ServiceType>();
        }

        public IEnumerable<T> ResolveAll<T>() where T : class
        {
            return this.container.GetAllInstances<T>();
        }

        public void InterceptWith<T>(Func<Type, bool> predicate) where T : class, IInterceptor
        {
            this.container.InterceptWith<T>(predicate);
        }

        public void InterceptWith(Func<IInterceptor> interceptorCreator, Func<Type, bool> predicate)
        {
            this.container.InterceptWith(interceptorCreator, predicate);
        }

        public void InterceptWith(IInterceptor interceptor, Func<Type, bool> predicate)
        {
            this.container.InterceptWith(interceptor, predicate);
        }

        public void Dispose()
        {
            this.container = null;
        }

        private Lifestyle GetLifestyle(ServiceLifecycle lifecycle)
        {
            switch (lifecycle)
            {
                case ServiceLifecycle.PerCall:
                    return Lifestyle.Transient;
                case ServiceLifecycle.Singleton:
                    return Lifestyle.Singleton;
                case ServiceLifecycle.PerWebRequest:
                case ServiceLifecycle.PerWebApiRequest:
                    return new WebApiRequestLifestyle();
                default:
                    throw new NotImplementedException("Lifecycle ({0}) not implemented".FormatWith(lifecycle));
            }
        }


        public void RegisterSingleOpenGeneric(Type serviceType, Type instance)
        {
            this.container.RegisterSingleton(serviceType, instance);
        }


        public void RegisterManyForOpenGeneric(Type serviceType, Type instance, ServiceLifecycle lifecycle = ServiceLifecycle.PerCall)
        {
            //this.container.RegisterManyForOpenGeneric(serviceType, this.GetLifestyle(lifecycle), instance.Assembly);

            //this.container.RegisterCollection(serviceType, AccessibilityOption.PublicTypesOnly, (sType, implTypes) => container.RegisterAll(sType, implTypes), instance.Assembly);
            container.RegisterCollection(serviceType, container.GetTypesToRegister(serviceType, new List<Assembly> {instance.Assembly}).Where(t => t.IsPublic));

        }


        public void Register<ServiceType>(Func<ServiceType> instanceCreater, ServiceLifecycle lifecycle) where ServiceType : class
        {
            this.container.Register<ServiceType>(instanceCreater, this.GetLifestyle(lifecycle));
        }


        public void RegisterAll<T>(IEnumerable<T> services) where T : class
        {
            this.container.RegisterCollection<T>(services);
        }

        public void RegisterAll<T>(IEnumerable<Type> services) where T : class
        {
            this.container.RegisterCollection<T>(services);
        }

        public void RegisterWithRegistration<T>(ServiceLifecycle lifecycle, params Type[] interfaces) where T : class
        {
            var registration = this.GetLifestyle(lifecycle).CreateRegistration<T>(this.container);
            AddRegistration(registration, interfaces);
        }

        private void AddRegistration(Registration registration, params Type[] interfaces)
        {
            foreach (Type obj in interfaces)
            {
                this.container.AddRegistration(obj, registration);
            }
        }
    }
}
