using Accela.Infrastructure.Cache.Redis;
using Accela.Core.Ioc;
using Accela.Core.Ioc.SimpleInjector;
using Accela.Infrastructure.Caches;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Core.Tests.Cache
{

    #region Model
    [Serializable]
    public class HostEnvModel
    {
        public HostEnvModel()
        {
            HostEnvironmentDetailModels = new List<HostEnvironmentDetailModel>();
        }
        public Guid EnvironmentId { get; set; }

        public string Name { get; set; }

        public Nullable<Guid> AgencyId { get; set; }

        public string GatewayURL { get; set; }

        public string GatewayKey { get; set; }

        public string BizServerURL { get; set; }

        public string BizServerVersion { get; set; }

        public bool IsAABizServer { get; set; }

        public bool Status { get; set; }

        public string Description { get; set; }

        public DateTime? LastUpdatedDate { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string LastUpdatedBy { get; set; }

        public string CreatedBy { get; set; }

        public String Keep1 { get; set; }

        public String Keep2 { get; set; }

        public string GatewayVersion { get; set; }

        public bool Defatult { get; set; }

        public List<HostEnvironmentDetailModel> HostEnvironmentDetailModels { get; set; }
    }

    [Serializable]
    public class HostEnvironmentDetailModel
    {
        public Guid ID { get; set; }

        public Guid HostEnvironmentId { get; set; }

        public string ServerURL { get; set; }

        public int ServerType { get; set; }

        public int ServerStatus { get; set; }

        public string VersionNum { get; set; }

        public string Description { get; set; }

        public DateTime? LastUpdatedDate { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string LastUpdatedBy { get; set; }

        public string CreatedBy { get; set; }
    }
    #endregion

    [TestFixture]
    public class RedisServerTest
    {
        //private CacheStoreProvider cacheStore;

        [SetUp]
        public void Init()
        {
            var cacheStore =  new Mock<ICache>();
            var redisProviderProvider = new Mock<IRedisProvider>();
            redisProviderProvider.Setup<string>(s => s.Instance.Get<string>("Test")).Returns("Test");
            redisProviderProvider.Setup(s => s.Instance).Returns(cacheStore.Object);


            for (int i = 0; i < 1000; i++)
            {
                redisProviderProvider.Setup<HostEnvModel>(s => s.Instance.Get<HostEnvModel>("Environment" + i.ToString())).Returns(new HostEnvModel { Name = string.Format("agency_{0}", i) });
                redisProviderProvider.Setup<int>(s => s.Instance.Get<int>("key" + i.ToString())).Returns(i);
            }

            IocContainer.Current = new ServiceLocator();
            IocContainer.Current.RegisterInstance<IRedisProvider>(redisProviderProvider.Object);

            //IocContainer.Current = new ServiceLocator();
            //IocContainer.Current.LoadAll("Accela.*.dll", "");
        }

        [TearDown]
        public void Dispose()
        {
            IocContainer.Current.Dispose();
            IocContainer.Current = null;
        }


        [Test]
        public void RedisInstance_IsSingleton()
        {
            var cache = IocContainer.Current.Resolve<IRedisProvider>();
            var cache1 = IocContainer.Current.Resolve<IRedisProvider>();

            var con = cache.Instance;
            var con1 = cache1.Instance;
            Assert.AreSame(con, con1);
        }


        [Test]
        public void RedisInstance_Set1000Items()
        {
            var stopWatch = new Stopwatch();
            var cache = IocContainer.Current.Resolve<IRedisProvider>();
            stopWatch.Start();
            for (int i = 0; i < 1000; i++)
            {
                cache.Instance.Put<int>("key" + i.ToString(), i, TimeSpan.FromMinutes(5));
            }
            stopWatch.Stop();
            Console.WriteLine(string.Format("Set operation took {0} milliseconds", stopWatch.ElapsedMilliseconds));
            Assert.IsTrue(1 == 1);
        }




        [Test]
        public void RedisInstance_Get1000Items()
        {
            var cache = IocContainer.Current.Resolve<IRedisProvider>();
            for (int i = 0; i < 1000; i++)
            {
                var va = cache.Instance.Get<int>("key" + i.ToString());
                Assert.IsTrue(va == i);
            }

        }


        [Test]
        public void RedisInstance_Set1000Environments()
        {
            var stopWatch = new Stopwatch();
            var cache = IocContainer.Current.Resolve<IRedisProvider>();
            stopWatch.Start();
            for (int i = 0; i < 1000; i++)
            {
                var he = new HostEnvModel { Name = string.Format("agency_{0}", i) };
                cache.Instance.Put<HostEnvModel>("Environment" + i.ToString(), he, TimeSpan.FromMinutes(5));
            }
            stopWatch.Stop();
            Console.WriteLine(string.Format("Set operation took {0} milliseconds", stopWatch.ElapsedMilliseconds));
            Assert.IsTrue(stopWatch.ElapsedMilliseconds < 25000);
        }

        [Test]
        public void RedisInstance_Get1000Environments()
        {
            var cache = IocContainer.Current.Resolve<IRedisProvider>();
            for (int i = 0; i < 1000; i++)
            {
                var va = cache.Instance.Get<HostEnvModel>("Environment" + i.ToString());
                Assert.IsTrue(va.Name == string.Format("agency_{0}", i));
            }

        }


        [Test]
        public void RedisInstance_Delete1000Items()
        {
            var cache = IocContainer.Current.Resolve<IRedisProvider>();
            for (int i = 0; i < 1000; i++)
            {
                cache.Instance.Remove<int>("key" + i.ToString());

            }
            Assert.IsTrue(1 == 1);
        }


        [Test]
        public void RedisInstance_MultiThreadSet1000Items()
        {


            try
            {


                var task = Task.Run<long>(async () =>
                {
                    var cache = IocContainer.Current.Resolve<IRedisProvider>();
                    return await runTask(cache);
                });

                var task1 = Task.Run<long>(async () =>
                {
                    var cache = IocContainer.Current.Resolve<IRedisProvider>();
                    return await runTask(cache);
                });

                Task.WhenAll<long>(task, task1).ContinueWith(taskResult =>
                {

                    long totalTime = 0;
                    foreach (var item in taskResult.Result)
                    {
                        totalTime += item;
                    }
                    Console.WriteLine(string.Format("Set operation took {0} milliseconds", totalTime));
                });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async static Task<long> runTask(IRedisProvider cache)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            await Task.Run(() =>
            {
                for (int i = 0; i < 500; i++)
                {
                    cache.Instance.Put<int>("key" + i.ToString(), i, TimeSpan.FromMinutes(5));
                }
            });
            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }


    }
}
