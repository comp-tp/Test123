using Accela.Core.Ioc;
using Accela.Core.Serialization;
using Accela.Core.Serialization.DataContract;
using Accela.Core.Serialization.JsonNet;
using Moq;
using NUnit.Framework;
using System;

namespace Accela.Apps.Core.Tests.Serialization
{
    [TestFixture]
    public class TestSerialization
    {
        #region Class Definition
        public enum FooEnum
        {
            A1,
            A2
        }

        public class Foo
        {
            public string A { get; set; }
            public int B { get; set; }
            public bool C { get; set; }
            public DateTime D { get; set; }
            public FooEnum E { get; set; }
            public int? B_Nullable { get; set; }
            public bool? C_Nullable { get; set; }
            public DateTime? D_Nullable { get; set; }
            public FooEnum? E_Nullable { get; set; }
        }
        #endregion Class Definition

        #region SetUp / TearDown

        [SetUp]
        public void Init()
        {
            var mockServiceLocator = new Mock<IServiceLocator>();
            mockServiceLocator.Setup<IJsonSerializer>(s => s.Resolve<IJsonSerializer>()).Returns(new JsonNetSerializer());
            mockServiceLocator.Setup<IBinarySerializer>(s => s.Resolve<IBinarySerializer>()).Returns(new BsonNetSerializer());
            mockServiceLocator.Setup<IXmlSerializer>(s => s.Resolve<IXmlSerializer>()).Returns(new XmlDataContractSerializer());

            IocContainer.Current = mockServiceLocator.Object;
        }

        [TearDown]
        public void Dispose()
        {
            IocContainer.Current.Dispose();
            IocContainer.Current = null;
        }

        #endregion

        #region Tests

        [Test]
        public void TestSerialization_JSON()
        {
            var foo = new Foo
            {
                A = "ABC",
                B = 123,
                C = true,
                D = DateTime.Parse("2013-06-18T19:35:25.7464649-07:00")
            };
            var json = JsonSerializerService.Current.Serialize(foo);
            Assert.AreEqual(@"{""A"":""ABC"",""B"":123,""C"":true,""D"":""2013-06-18T19:35:25.7464649-07:00"",""E"":0,""B_Nullable"":null,""C_Nullable"":null,""D_Nullable"":null,""E_Nullable"":null}", json);
        }

        [Test]
        public void TestSerialization_XML()
        {
            var foo = new Foo
            {
                A = "ABC",
                B = 123,
                C = true,
                D = DateTime.Parse("2013-06-18T19:35:25.7464649-07:00")
            };
            var xml = XmlSerializerService.Current.Serialize(foo);
            Console.Write(xml);
            Assert.AreEqual(@"<?xml version=""1.0"" encoding=""utf-8""?><TestSerialization.Foo xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://schemas.datacontract.org/2004/07/Accela.Apps.Core.Tests.Serialization""><A>ABC</A><B>123</B><B_Nullable i:nil=""true"" /><C>true</C><C_Nullable i:nil=""true"" /><D>2013-06-18T19:35:25.7464649-07:00</D><D_Nullable i:nil=""true"" /><E>A1</E><E_Nullable i:nil=""true"" /></TestSerialization.Foo>", xml);
        }

        [Test]
        public void TestSerialization_Binary()
        {
            var foo = new Foo
            {
                A = "ABC",
                B = 123,
                C = true,
                D = DateTime.Parse("2013-06-18T19:35:25.7464649-07:00")
            };
            var base64 = BinarySerializerService.Current.Serialize(foo);
            Assert.AreEqual(@"XQAAAAJBAAQAAABBQkMAEEIAewAAAAhDAAEJRACyYElaPwEAABBFAAAAAAAKQl9OdWxsYWJsZQAKQ19OdWxsYWJsZQAKRF9OdWxsYWJsZQAKRV9OdWxsYWJsZQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==", base64);
        }

        #endregion
    }
}
