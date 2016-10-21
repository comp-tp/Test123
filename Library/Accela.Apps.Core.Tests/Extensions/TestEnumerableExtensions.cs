using Accela.Core.Ioc;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Accela.Apps.Core.Tests.Extensions
{
    [TestFixture]
    public class TestEnumerableExtensions
    {
        #region Class Definition
        enum FooEnum
        {
            Value1,
            Value2,
            Value3
        }
        class Foo
        {
            public string A { get; set; }
            public int B { get; set; }
            public int? C { get; set; }
            public bool D { get; set; }
            public FooEnum E { get; set; }
        }
        #endregion Class Deifinition
        
        #region Tests

        [Test]
        public void TestAsEnumerableReturnNull()
        {
            List<Foo> col = null;
            var enumerableFoo = col.AsEnumerable();
            Assert.AreEqual(enumerableFoo, null);
        }

        [Test]
        public void TestAsEnumerableReturnEmpty()
        {
            List<Foo> col = null;
            var enumerableFoo = col.AsEnumerableEmpty();
            Assert.AreEqual(enumerableFoo, Enumerable.Empty<Foo>());
        }

        #endregion Tests
    }
}
