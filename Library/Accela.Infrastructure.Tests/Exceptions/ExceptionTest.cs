using System;
using NUnit.Framework;
using Accela.Infrastructure.Exceptions;
using Newtonsoft.Json;

namespace Accela.Infrastructure.Tests.Exceptions
{
    [TestFixture]
    public class ExceptionTest
    {
        [Test]
        public void TestMobileExceptionMessage()
        {
            // http://www.asp.net/web-api/overview/formats-and-model-binding/json-and-xml-serialization
            var exception = new AccelaBaseException(null, (string)null, "1005");
            string json = JsonConvert.SerializeObject(exception, Formatting.None);
            Assert.AreEqual("Exception of type 'Accela.Infrastructure.Exceptions.MobileException' was thrown.", exception.Message);
        }
    }
}

