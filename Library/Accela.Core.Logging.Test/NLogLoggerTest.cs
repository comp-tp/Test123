using Accela.Core.Logging.NLog;
using Accela.Core.Logging.Util;
using NUnit.Framework;
using System;
using System.Threading;

namespace Accela.Core.Logging.Test
{
    public class NLogLoggerTest
    {
        [SetUp]
        public void Init()
        {

        }

        [TearDown]
        public void Dispose()
        {
        }

        [Test]
        public void Wirte_logs_Test()
        {
            NLogLogger logger = new NLogLogger();

            //logger.WriteLog("Debug", null);

            var logEntity = new LogEntity
            {
                Agency = "UTTestAgency",
                AppId ="UTAppId123",
                Message = "Hello",
                Detail = String.Format(@"The \\~!@#$%^&*()_+=-\// <> \detail' "" data here"),
                EnvName = "TEST",
                MethodExecuteTime = 100,
                MethodName = "get v4/recodes",
                RequestFrom = "apps-apis",
                RequestTo = "apps-admin",
                TraceId = Guid.NewGuid().ToString(),
                UserName = "UTJUserName"
            };

            logger.WriteLog("Debug", logEntity);
            logger.WriteLog("Info", logEntity);
            logger.WriteLog("Warn", logEntity);
            logger.WriteLog("Error", logEntity);
            logger.WriteLog("Critical", logEntity);

            DateTime startTime = DateTime.UtcNow;

            var totalMilliSeconds = (DateTime.UtcNow - startTime).TotalMilliseconds;

            //Assert.That(totalMilliSeconds, Is.LessThan(TimeSpan.FromMilliseconds(1000)));

            // give time for writing to logentries
            Thread.Sleep(2000);
        }

        [Test]
        public void SholdLessThan_5Sec_Serialize_1000000_logs_ToJson_Test()
        {
            var logEntity = new LogEntity
            {
                Agency = "UTTestAgency",
                AppId = "UTAppId123",
                Message = "Hello",
                Detail = String.Format(@"The <> \detail' "" data here"),
                EnvName = "TEST",
                MethodExecuteTime = 100,
                MethodName = "get v4/recodes",
                RequestFrom = "apps-apis",
                RequestTo = "apps-admin",
                TraceId = Guid.NewGuid().ToString(),
                UserName = "UTJUserName"
            };

            DateTime startTime = DateTime.UtcNow;

            for (int i = 0; i < 1000 * 1000; i++ )
                LogJsonHelper.ToJson(logEntity, "DEBUG");

            DateTime endTime = DateTime.UtcNow;
            Assert.That(endTime - startTime, Is.LessThan(TimeSpan.FromSeconds(5)));
        }

    }
}
