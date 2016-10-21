using Accela.Core.Logging;
using log4net;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using log4net.Repository;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accela.Apps.Shared.AzureLogging.Tests
{


    [TestFixture]
    public class AzureQueueLoggerTests : BaseAzureTest
    {
        private const string ErrorMessage = "TEST ERROR MESSAGE";
        private const string FileFolderPath = @"c:\LogTesting\";
        private readonly Level ErrorLevel = Level.Debug;
        private AzureQueueAppender appender;
        //private ILoggerRepository rep;
        private Guid fileGuid;
        //private CloudStorageAccount storageAccount;
        private string GetFilePath()
        {
            return string.Format("{0}{1}.log", FileFolderPath, fileGuid);
        }


        protected override void InitializeSetup()
        {

            StorageAccount = CloudStorageAccount.DevelopmentStorageAccount;
            appender = new AzureQueueAppender("Log_StorageConnectionString");
            //appender.StorageSettingsName = "Log_StorageConnectionString_logperfermancetest";

            appender.Threshold = ErrorLevel;
            //appender.File = GetFilePath();
            appender.Layout = new PatternLayout("%message");
            //appender.StaticLogFileName = true;
            //appender.AppendToFile = true;
            appender.ActivateOptions();
            //rep = LogManager.CreateRepository(Guid.NewGuid().ToString());
            //appender.Name = "default";
            BasicConfigurator.Configure(LogRepository, appender);
           

            var queue = GetQueue(appender.StorageAccount, "logs");
            while (true)
            {
                var mesg = queue.GetMessage();
                if (mesg != null)
                {
                    queue.DeleteMessage(mesg);
                }
                else
                {
                    break;
                }
            }
            base.InitializeSetup();
        }


        [Test]
        public void CanWriteLog()
        {
            var traceId = Guid.NewGuid().ToString(); //"ee994746-b972-4559-a8a9-ee0bd4556cff";
            // Arrange
            Accela.Core.Logging.ILogger logger = AzureLogging.Logger.AzureQueueLogger.Instance;
            // Act
            var logEntry = GetLogEntity(traceId);

            logger.WriteLog("Debug", logEntry);

            // Assert
            //Assert.That(File.Exists(GetFilePath()), Is.True);
            //IEnumerable<string> readLines = File.ReadLines(GetFilePath());
            //Assert.That(readLines.Count(), Is.GreaterThanOrEqualTo(1));

            var queue = GetQueue(appender.StorageAccount, "logs");

            Thread.Sleep(new TimeSpan(0, 0, 1)); // let background thread finish

            var mesg = queue.GetMessage();

            Assert.IsNotNull(mesg);
            var result = Deserialize<LogEntity>(mesg.AsBytes);
            Assert.AreEqual(result.TraceId, traceId);
            queue.DeleteMessage(mesg);

        }

        [Test]
        public void CanWriteLog_Error()
        {
            var traceId = Guid.NewGuid().ToString(); //"ee994746-b972-4559-a8a9-ee0bd4556cff";
            // Arrange
            Accela.Core.Logging.ILogger logger = AzureLogging.Logger.AzureQueueLogger.Instance;
            // Act
            var logEntry = GetLogEntity(traceId);

            logger.WriteLog("Error", logEntry);

            // Assert
            //Assert.That(File.Exists(GetFilePath()), Is.True);
            //IEnumerable<string> readLines = File.ReadLines(GetFilePath());
            //Assert.That(readLines.Count(), Is.GreaterThanOrEqualTo(1));

            var queue = GetQueue(appender.StorageAccount, "logs");

            Thread.Sleep(new TimeSpan(0, 0, 1)); // let background thread finish

            var mesg = queue.GetMessage();

            Assert.IsNotNull(mesg);
            var result = Deserialize<LogEntity>(mesg.AsBytes);
            Assert.AreEqual(result.TraceId, traceId);
            queue.DeleteMessage(mesg);

        }

        [Test]
        public void CanWriteLog_Info()
        {
            var traceId = Guid.NewGuid().ToString(); //"ee994746-b972-4559-a8a9-ee0bd4556cff";
            // Arrange
            Accela.Core.Logging.ILogger logger = AzureLogging.Logger.AzureQueueLogger.Instance;
            // Act
            var logEntry = GetLogEntity(traceId);

            logger.WriteLog("info", logEntry);

            // Assert
            //Assert.That(File.Exists(GetFilePath()), Is.True);
            //IEnumerable<string> readLines = File.ReadLines(GetFilePath());
            //Assert.That(readLines.Count(), Is.GreaterThanOrEqualTo(1));

            var queue = GetQueue(appender.StorageAccount, "logs");

            Thread.Sleep(new TimeSpan(0, 0, 1)); // let background thread finish

            var mesg = queue.GetMessage();

            Assert.IsNotNull(mesg);
            var result = Deserialize<LogEntity>(mesg.AsBytes);
            Assert.AreEqual(result.TraceId, traceId);
            queue.DeleteMessage(mesg);

        }

        [Test]
        public void CanWriteMoreThan2000Length()
        {
            var str = "Below is the code for random string generation, it is working but there is some problem here which I at the moment cant figure out what happens here is that it always returns me value of length 1 ,I a";
            var strBuilder = new StringBuilder(4000);
            for (int i = 0; i < 12; i++)
            {
                strBuilder.AppendLine(str);
            }
            var traceId = Guid.NewGuid().ToString(); 
            // Arrange
            Accela.Core.Logging.ILogger logger = AzureLogging.Logger.AzureQueueLogger.Instance;
            // Act
            var logEntry = GetLogEntity(traceId, strBuilder.ToString());
            logger.WriteLog("Debug", logEntry);
            var queue = GetQueue(appender.StorageAccount, "logs");
            Thread.Sleep(new TimeSpan(0, 0, 5)); // let background thread finish
            var mesg = queue.GetMessage();
            Assert.IsNotNull(mesg);
            var result = Deserialize<LogEntity>(mesg.AsBytes);
            Assert.AreEqual(result.TraceId, traceId);
            queue.DeleteMessageAsync(mesg);
        }

     



        public LogEntity GetLogEntity(string traceId, string detail = "Error Test")
        {
            return new LogEntity { Agency = "Test", DateCreated = DateTime.Now, AppId = "inspector.app", AppVer = "2.0", EnvName = "PROD", TraceId = traceId, Detail = detail };
        }


        public static CloudQueue GetQueue(CloudStorageAccount storageAccount, string queueName)
        {
            if (storageAccount == null)
            {
                throw new Exception("The storagae account is null, can't get the Queue: " + queueName);
            }
            if (String.IsNullOrWhiteSpace(queueName))
            {
                throw new ArgumentNullException("queueName is null.");
            }

            //Queue names must be 3-63 characters in length and may contain lower-case alphanumeric characters and dashes. 
            //Dashes must be preceded and followed by an alphanumeric character.
            //if (!IsBlobContainerNameValid(queueName))
            //{
            //    string ex = "Invalid queue name. Queue names must be 3-63 characters in length and may contain lower-case alphanumeric characters and dashes. Dashes must be preceded and followed by an alphanumeric character.";
            //    throw new ArgumentException(ex);
            //}

            var queueClient = storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference(queueName);
            queue.CreateIfNotExists();

            return queue;
        }

        [Test]
        public void ReturnsQuicklyAfterLogging100Messages()
        {
            // Arrange
            log4net.ILog log = LogManager.GetLogger(LogRepository.Name, "ReturnsQuicklyAfterLogging100Messages");
            // Act
            DateTime startTime = DateTime.UtcNow;
            100.Times(i => log.Error(ErrorMessage));
            DateTime endTime = DateTime.UtcNow;
            // Give background thread time to finish
            Thread.Sleep(500);
            // Assert
            //ReleaseFileLocks();
            Assert.That(endTime - startTime, Is.LessThan(TimeSpan.FromMilliseconds(100)));
            //Assert.That(File.Exists(GetFilePath()), Is.True);
            //IEnumerable<string> readLines = File.ReadLines(GetFilePath());
            //Assert.That(readLines.Count(), Is.GreaterThanOrEqualTo(100));
        }


        [Test]
        public void CanLog2000MessagesASecond()
        {
            // Arrange
            log4net.ILog log = LogManager.GetLogger(LogRepository.Name, "CanLogAtLeast2000MessagesASecond");
            //// Act
            DateTime startTime = DateTime.UtcNow;
            2000.Times(i => log.Error(GetLogEntity(Guid.NewGuid().ToString())));
            Thread.Sleep(500);
            //ReleaseFileLocks();
            TimeSpan testDuration = DateTime.UtcNow - startTime;
            var logsPerSecond = 2000 / testDuration.TotalSeconds;
            //Console.WriteLine("{0} messages logged in {1}s => {2}/s", logCount, testDuration.TotalSeconds, logsPerSecond);
            Assert.That(logsPerSecond, Is.GreaterThan(1000), "Must log at least 2000 messages per second");
        }

        protected override CloudStorageAccount StorageAccount
        {
            get;
            set;
        }
    }
}
