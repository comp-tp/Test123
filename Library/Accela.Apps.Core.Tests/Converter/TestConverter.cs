using Accela.Core.Converter;
using Accela.Core.Converter.Default;
using Accela.Core.Ioc;
using Moq;
using NUnit.Framework;
using System;
using System.Globalization;

namespace Accela.Apps.Core.Tests.Converter
{
    [TestFixture]
    public class TestConverter
    {
        #region Class Definition
        public class Foo
        {
            public FooEnum FooEnum { get; set; }
        }

        public class FooConverter : IConverter
        {
            public object ConvertTo(Type targetType, object value, object defaultValue = null,
                bool throwException = false, IFormatProvider provider = null, CultureInfo cultureInfo = null)
            {
                var fooEnum = FooEnum.FooEnum1;
                if (value != null &&
                    value is FooEnum)
                {
                    fooEnum = value.ConvertTo<FooEnum>();
                }
                return new Foo { FooEnum = fooEnum };
            }

            public T ConvertTo<T>(object value, T defaultValue = default(T),
                bool throwException = false, IFormatProvider provider = null, CultureInfo cultureInfo = null)
            {
                return (T)this.ConvertTo(typeof(T), value, defaultValue, throwException, provider, cultureInfo);
            }
        }

        public enum FooEnum
        {
            FooEnum1,
            FooEnum2
        }
        #endregion Class Definition

        #region SetUp / TearDown

        [SetUp]
        public void Init()
        {
            var mockServiceLocator = new Mock<IServiceLocator>();
            mockServiceLocator.Setup<IConverterService>(s => s.Resolve<IConverterService>()).Returns(new DefaultConverterService());
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
        public void Test_Converter()
        {
            Assert.AreEqual(123, "123".ConvertTo<int>());
            Assert.AreEqual(123, "abc".ConvertTo<int>(123));
            Assert.AreEqual(123, "123".ConvertTo<int?>());
            Assert.AreEqual(123, "abc".ConvertTo<int?>(123));

            Assert.AreEqual(FooEnum.FooEnum1, "FooEnum1".ConvertTo<FooEnum>());
            Assert.AreEqual(FooEnum.FooEnum2, "1".ConvertTo<FooEnum>());

            //custom converter
            ConverterService.Current.Register(typeof(Foo), new FooConverter());
            var foo = FooEnum.FooEnum2.ConvertTo<Foo>();
            Assert.NotNull(foo);
            Assert.AreEqual(FooEnum.FooEnum2, foo.FooEnum);
        }

        #endregion
    }
}
