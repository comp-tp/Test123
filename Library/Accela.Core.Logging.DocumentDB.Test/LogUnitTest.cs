using NLog;
using NUnit.Framework;

namespace Accela.Core.Logging.DocumentDB.Test
{
    [TestFixture]
    public class LogUnitTest
    {
        [Test]
        public void TestNlogger()
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            logger.Info("{\"LogLevel\":\"INFO\",\"Message\":\"UT log message\",\"Agency\":\"ISLANDTON\",\"UserName\":\"teter\",\"AppId\":\"123\",\"RequestFrom\":\"UT\",\"RequestTo\":\"DocumentDB\"}");
            logger.Debug("{\"TraceId\":\"1234567890\",\"Message\":\"UT log message\",\"Agency\":\"ISLANDTON\",\"UserName\":\"teter\",\"AppId\":\"123\",\"RequestFrom\":\"UT\",\"RequestTo\":\"DocumentDB\"}");
        }


    }
}
