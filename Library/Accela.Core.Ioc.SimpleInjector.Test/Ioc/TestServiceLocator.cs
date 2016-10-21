using Accela.Core.Ioc;
using Accela.Core.Ioc.SimpleInjector;
using NUnit.Framework;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accela.Apps.Core.Tests.Ioc
{

    public interface IEntityScope
    {
        String ProductName
        {
            get;
            set;
        }

        String Agency
        {
            get;
            set;
        }

        String EntityType
        {
            get;
            set;
        }

        Guid UserId
        {
            get;
            set;
        }

        String Namespace
        {
            get;
            set;
        }
    }

    public interface IMobileEntity : IEntityScope
    {
        String ObjectId
        {
            get;
            set;
        }

        String ObjectData
        {
            get;
            set;
        }

        DateTime ExpiresAfter
        {
            get;
            set;
        }

        DateTime Timestamp
        {
            get;
            set;
        }
    }


    public class SimpleMobileEntity : IMobileEntity
    {

        public string ObjectId
        {
            get;
            set;
        }

        public string ObjectData
        {
             get;
            set;
        }

        public DateTime ExpiresAfter
        {
             get;
            set;
        }

        public DateTime Timestamp
        {
            get;
            set;
        }

        public string ProductName
        {
            get;
            set;
        }

        public string Agency
        {
            get;
            set;
        }

        public string EntityType
        {
            get;
            set;
        }

        public Guid UserId
        {
            get;
            set;
        }

        public string Namespace
        {
            get;
            set;
        }
    }

    public interface IRepository<T> where T : IMobileEntity
    {

        void Insert(T entity);
        T Get(string key);
    }

    public class Repository<T> : IRepository<T> where T : IMobileEntity
    {
        private Dictionary<string, T> _dummyCache = new Dictionary<string,T>();
        public void Insert(T entity)
        {
            _dummyCache.Add(entity.ObjectId, entity);
            //throw new NotImplementedException();
        }

        public T Get(string key)
        {
            if (_dummyCache.ContainsKey(key))
            {
                return _dummyCache[key];
            }
            return default(T);
        }
    }

    [TestFixture]
    public class TestServiceLocator
    {

        public interface IBaseRepository { }

        public interface IUserRepository : IBaseRepository
        {

            string UserName { get; set; }
        }


        public class UserRepository : IUserRepository
        {
            public string UserName { get; set; }
        }


        public interface IDepartmentRespository : IBaseRepository { }
        public class DepartmentRespository : IDepartmentRespository
        {

        }

        public interface IStoreRespository : IBaseRepository { }
        public class StoreRespository : IStoreRespository
        {

        }


        public interface IService { }

        public class UserService : IService { }

        public class StoreService : IService { }

        public class DepartmentService : IService { }


        #region Class Definition
        public interface IFoo
        {
            string A { get; set; }
        }

        public class Foo : IFoo
        {
            public Foo()
            {
            }

            public int Id { get; set; }
            public string A { get; set; }
        }

        public class FooServiceLoader : IServiceLoader
        {
            public int SortOrder { get; private set; }

            public void Load(IServiceLocator container)
            {
                container.Register<IFoo, Foo>();
            }
        }

        public class Foo2 : IFoo
        {
            public Foo2(IFooConstructorParam fooParam)
            {
                this.FooParam = fooParam;
            }

            public string A { get; set; }
            public IFooConstructorParam FooParam { get; set; }
        }

        public interface IFooConstructorParam
        {
            string A { get; set; }
        }

        public class FooConstructorParam : IFooConstructorParam
        {
            public string A { get; set; }
        }

        #endregion Class Definition

        #region SetUp / TearDown

        [SetUp]
        public void Init()
        {
        }

        [TearDown]
        public void Dispose()
        {
        }

        #endregion SetUp / TearDown

        #region Tests


        [Test]
        public void TestServiceLocator_OpenGeneric()
        {
            using (var container = new ServiceLocator())
            {
                //container.RegisterManyForOpenGeneric(typeof(IRepository<>), typeof(IRepository<>));
                container.RegisterSingleOpenGeneric(typeof(IRepository<>), typeof(Repository<>));

                var myContainer = container.IocContainer as  Container;
                myContainer.Verify();
                var repo = container.Resolve<IRepository<SimpleMobileEntity>>();
                //resolve
                Assert.IsNotNull(repo);
                repo.Insert(new SimpleMobileEntity { ObjectId = "SimpleOne", ObjectData = "{data}", ProductName = "Accela" });
                var fromCache = repo.Get("SimpleOne");
                Assert.IsNotNull(fromCache);
                Assert.AreEqual("{data}", fromCache.ObjectData);
            }
        }

        [Test]
        public void TestServiceLocator_PerCall()
        {
            using (var container = new ServiceLocator())
            {
                container.Register<IFoo, Foo>();

                //resolve
                var foo1 = container.Resolve<IFoo>();
                var foo2 = container.Resolve<IFoo>();

                Assert.IsNotNull(foo1);
                Assert.IsNotNull(foo2);
                Assert.AreNotEqual(foo1.GetHashCode(), foo2.GetHashCode());
            }
        }

        [Test]
        public void TestServiceLocator_Singleton()
        {
            using (var container = new ServiceLocator())
            {
                container.Register<IFoo, Foo>(ServiceLifecycle.Singleton);

                //resolve
                var foo1 = container.Resolve<IFoo>();
                var foo2 = container.Resolve<IFoo>();

                Assert.IsNotNull(foo1);
                Assert.IsNotNull(foo2);
                Assert.AreEqual(foo1.GetHashCode(), foo2.GetHashCode());
            }
        }

        [Test]
        public void TestServiceLocator_Singleton_MultipleTasks()
        {
            using (var container = new ServiceLocator())
            {
                var hash = new List<int>();
                container.Register<IFoo, Foo>(ServiceLifecycle.Singleton);

                var thread1 = new Thread(IocTestAction);
                var thread2 = new Thread(IocTestAction);

                thread1.Start(new { Container = container, Hash = hash });
                thread2.Start(new { Container = container, Hash = hash });

                thread1.Join();
                thread2.Join();

                Assert.AreEqual(2, hash.Count);
                Assert.AreEqual(hash[0], hash[1]);
            }
        }

        [Test]
        public void TestServiceLocator_Auto_Wiring()
        {
            using (var container = new ServiceLocator())
            {
                container.Register<IFoo, Foo2>();
                container.Register<IFooConstructorParam, FooConstructorParam>();

                var fooParam = container.Resolve<IFooConstructorParam>();
                Assert.NotNull(fooParam);

                var foo = container.Resolve<IFoo>();
                Assert.NotNull(foo);

                var foo2 = foo as Foo2;
                Assert.NotNull(foo2);
                Assert.NotNull(foo2.FooParam);
            }
        }


        [Test]
        public void TestServiceLocator_AutoRegistration()
        {
            using (var container = new ServiceLocator())
            {

                var repositoryAssembly = typeof(IBaseRepository).Assembly;

                var registrations = repositoryAssembly.GetExportedTypes().Where(t => t.IsClass).Where(t => t.GetInterfaces().Any(i => i.IsAssignableFrom(typeof(IBaseRepository))))
                  .Select(t => new
                  {
                      Service = t.GetInterfaces().First(),
                      Implementation = t
                  });

                foreach (var reg in registrations)
                {
                    container.Register(reg.Service, reg.Implementation, ServiceLifecycle.PerCall);
                }


                var userRepository = container.Resolve<IUserRepository>();
                Assert.NotNull(userRepository);

                var userRepository2 = container.Resolve<IUserRepository>();
                Assert.AreNotEqual(userRepository.GetHashCode(), userRepository2.GetHashCode());
            }
        }

        [Test]
        public void TestServiceLocator_RegisterAll()
        {
            using (var container = new ServiceLocator())
            {
                var type = typeof(IService);
                var types = typeof(TestServiceLocator).Assembly.GetTypes().Where(p => p.IsClass && !p.IsAbstract && type.IsAssignableFrom(p));
                container.RegisterAll<IService>(types);

                var allInstances = container.ResolveAll<IService>();
                Assert.AreEqual(3, allInstances.Count());
            }

        }

        [Test]
        public void TestServiceLocator_Load_All()
        {
            using (var container = new ServiceLocator())
            {
                container.LoadAll("Accela.*.dll", "");

                var foo = container.Resolve<IFoo>();

                Assert.NotNull(foo);
                Assert.IsInstanceOf<Foo>(foo);
            }
        }

        private void IocTestAction(object obj)
        {
            dynamic dynObj = (dynamic)obj;
            IocTestAction(dynObj.Container, dynObj.Hash);
        }

        private void IocTestAction(IServiceLocator container, List<int> hash)
        {
            //resolve
            lock (hash)
            {
                var foo1 = container.Resolve<IFoo>();
                var foo2 = container.Resolve<IFoo>();

                Assert.IsNotNull(foo1);
                Assert.IsNotNull(foo2);
                Assert.AreEqual(foo1.GetHashCode(), foo2.GetHashCode());

                hash.Add(foo1.GetHashCode());
            }
        }

        #endregion Tests
    }
}
