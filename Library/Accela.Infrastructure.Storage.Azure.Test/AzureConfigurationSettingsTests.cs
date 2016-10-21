using Accela.Infrastructure.Exceptions;
using Accela.Infrastructure.Azure.Configurations;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Azure.Test
{

    public enum ApiTypes
    {
        InternalApi = 0,
        ExternalApi = 1,
        RestApi = 2,
    }

    [TestFixture]
    class AzureConfigurationSettingsTests
    {
        private AzureConfigurationReader configurationReader; 

        [SetUp]
        public void Init()
        {

            var configurationReaderMock = new Mock<AzureConfigurationReader>();
            
            configurationReaderMock.Setup<string>(s => s.Get("InternalAPI_AccessKey", "")).Returns("Test");

            configurationReaderMock.Setup<ApiTypes>(s => s.Get<ApiTypes>("EnumValue", false)).Returns(ApiTypes.InternalApi);
            configurationReaderMock.Setup<bool>(s => s.Get<bool>("IsValid", false)).Returns(true);
            configurationReaderMock.Setup<DateTime>(s => s.Get<DateTime>("StartDate", false)).Returns(new DateTime(2015, 12, 31));

            configurationReaderMock.Setup<double>(s => s.Get<double>("MinValue", false)).Returns(12.5);
            configurationReaderMock.Setup<int>(s => s.Get<int>("MaxValue", false)).Returns(12);

            configurationReaderMock.Setup<int>(s => s.Get<int>("RandomKeyNameWhichDoesnotExist", 41)).Returns(41);
            configurationReaderMock.Setup<int>(s => s.Get<int>("KeyNameDoesnotExist", true)).Throws(new ConfigurationKeyNotFoundException("Key Not found"));

            configurationReader = configurationReaderMock.Object;

        }

        [TearDown]
        public void Dispose()
        {
            configurationReader = null;
        }

        [Test]
        public void ShouldReadSettingsByKeyName()
        {
            var accessKey = configurationReader.Get("InternalAPI_AccessKey", "Test");
            Assert.That(accessKey, Is.Null.Or.Empty);

        }

        [Test]
        public void ShouldReadEnumValue()
        {
            var accessKey = configurationReader.Get<ApiTypes>("EnumValue", false);
            Assert.That(accessKey == ApiTypes.InternalApi);

        }

        [Test]
        public void ShouldReadBooleanValue()
        {
            var isValid = configurationReader.Get<bool>("IsValid", false);
            Assert.That(isValid == true);

        }

        [Test]
        public void ShouldReadDateValue()
        {
            var startDate = configurationReader.Get<DateTime>("StartDate", false);
            Assert.That(startDate == new DateTime(2015, 12, 31));

        }

        [Test]
        public void ShouldReadDoubleValue()
        {
            var minValue = configurationReader.Get<double>("MinValue", false);
            Assert.That(minValue == 12.5);

        }

        [Test]
        public void ShouldReadIntValue()
        {
            var maxValue = configurationReader.Get<int>("MaxValue", false);
            Assert.That(maxValue == 12);

        }

        [Test]
        public void ShouldReturndefaultValue()
        {
            var configValue = configurationReader.Get<int>("RandomKeyNameWhichDoesnotExist", 41);
            Assert.IsTrue(41 == configValue);

        }

        [Test]
        public void ShouldThrowKeyNotFound()
        {
            Assert.That(() => configurationReader.Get<int>("KeyNameDoesnotExist", true), Throws.TypeOf<ConfigurationKeyNotFoundException>());
        }
    }
}
