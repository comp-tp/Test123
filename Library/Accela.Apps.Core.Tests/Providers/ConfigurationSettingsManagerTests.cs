using Accela.Core.Configurations;
using Accela.Core.Ioc;
using Accela.Infrastructure.Configurations;
using Moq;
using NUnit.Framework;
using System;

namespace Accela.Apps.Core.Tests.Providers
{

    class RedisConfig
    {
        public RedisConfig(string userName, string password, string endpoint)
        {
            UserName = userName;
            Password = password;
            Endpoint = endpoint;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Endpoint { get; set; }

    }

    [TestFixture]
    public class ConfigurationSettingsManagerTests
    {

        [SetUp]
        public virtual void Init()
        {
            var configProvider = new Mock<IConfigurationReader>();
            configProvider.Setup<string>(s => s.Get("Test", "")).Returns("Test");
            var mockServiceLocator = new Mock<IServiceLocator>();
            mockServiceLocator.Setup<IConfigurationReader>(s => s.Resolve<IConfigurationReader>()).Returns(configProvider.Object);
            IocContainer.Current = mockServiceLocator.Object;
        }

        [TearDown]
        public virtual void Dispose()
        {
            IocContainer.Current.Dispose();
            IocContainer.Current = null;
        }

        [Test]
        public void ShouldAddProvider()
        {
            var configProvider = new Mock<IConfigurationReader>();
            ConfigurationSettingsManager.Add("MockProvider", configProvider.Object);
            Assert.That(ConfigurationSettingsManager.Get("MockProvider") != null);
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionForNullProviderName()
        {
            var configProvider = new Mock<IConfigurationReader>();
            Assert.That(() => ConfigurationSettingsManager.Add("", configProvider.Object), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionForNullProvider()
        {
            var configProvider = new Mock<IConfigurationReader>();
            Assert.That(() => ConfigurationSettingsManager.Add("MockProvider1", null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionForGet()
        {
            var configProvider = new Mock<IConfigurationReader>();
            ConfigurationSettingsManager.Add("MockProvider2", configProvider.Object);
            Assert.That(() => ConfigurationSettingsManager.Get(""), Throws.TypeOf<ArgumentNullException>());
        }
        
        [Test]
        public void ShouldReturnProviderFromIoC()
        {
            Assert.That(ConfigurationSettingsManager.Get() != null);
        }



        [Test]
        public void ShouldAddConfigSettings()
        {
            ConfigurationSettingsManager.AddSettings(new RedisConfig("Test","TestPassword", "http://localhost/redis"));
            Assert.That(ConfigurationSettingsManager.GetSettings<RedisConfig>() != null);

        }
    }
}
