using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Accela.Apps.Shared.Contexts;
using Accela.Core.Logging;

namespace Accela.Apps.Shared.Test.Utils
{
    [TestFixture]
    public class JsonConverterTest
    {
        // NOTE: not ignore null
        private static string JSON_TEST_STRING = "{\"Agency\":\"ISLANDTON\",\"AppId\":null,\"DateCreated\":\"\\/Date(-62135568000000-0800)\\/\",\"Detail\":null,\"DetailBlobUri\":null,\"EnvName\":\"TEST\",\"Message\":null,\"MethodExecuteTime\":0,\"MethodInSize\":0,\"MethodName\":null,\"MethodOutSize\":0,\"Order\":0,\"RequestFrom\":null,\"RequestTo\":null,\"TraceId\":null,\"UserName\":null}";

        [Test]
        public void ToJson()
        {
            var obj = new LogEntity()
            {
                Agency = "ISLANDTON",
                EnvName = "TEST"
            };
            var jsonString = JsonConverter.ToJson(obj);
            Assert.IsNotNullOrEmpty(jsonString);
            Assert.AreEqual(JSON_TEST_STRING, jsonString);
        }

        [Test]
        public void FromJsonTo()
        {
            var obj = JsonConverter.FromJsonTo<LogEntity>(JSON_TEST_STRING);
            Assert.IsNotNull(obj);
            Assert.AreEqual("ISLANDTON", obj.Agency);
            Assert.AreEqual("TEST", obj.EnvName);
        }
    }
}
