using Accela.Infrastructure.Cache.Couchbase;
using Accela.Core.Ioc;
using Accela.Core.Ioc.SimpleInjector;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Core.Tests.Cache
{
    [TestFixture]
    public class CouchbaseManagerTest
    {
        [SetUp]
        public void Init()
        {
            IocContainer.Current = new ServiceLocator();
            IocContainer.Current.LoadAll("Accela.*.dll", "");

        }

        [TearDown]
        public void Dispose()
        {
            IocContainer.Current.Dispose();
            IocContainer.Current = null;
        }

        // Not using Couchbase and not config to test it
        //[Test]
        public void TestCouchbaseManager_Singleton()
        {
            var instance1 = CouchbaseManager.Instance;
            var instance2 = CouchbaseManager.Instance;

            Assert.NotNull(instance1);
            Assert.AreEqual(instance1.GetHashCode(), instance2.GetHashCode());
        }
    }
}
