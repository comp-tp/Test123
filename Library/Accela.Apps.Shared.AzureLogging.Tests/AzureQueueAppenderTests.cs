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

    public static class IntExtensions
    {
        public static void Times(this int n, Action<int> action)
        {
            for (int i = 0; i < n; i++)
            {
                action(i);
            }
        }
    }

    [TestFixture]
    public class AzureQueueAppenderTests : BaseAzureTest
    {
        private const string ErrorMessage = "TEST ERROR MESSAGE";
        //private const string FileFolderPath = @"c:\LogTesting\";
        private readonly Level ErrorLevel = Level.Error;
        private AzureQueueAppender appender;
        //private ILoggerRepository rep;
        //private Guid fileGuid;
        //private CloudStorageAccount storageAccount;
        //private string GetFilePath()
        //{
        //    return string.Format("{0}{1}.log", FileFolderPath, fileGuid);
        //}


        protected override void InitializeSetup()
        {

            StorageAccount = CloudStorageAccount.DevelopmentStorageAccount;
            appender = new AzureQueueAppender(StorageAccount);
            appender.Threshold = ErrorLevel;
            //appender.File = GetFilePath();
            appender.Layout = new PatternLayout("%message");
            //appender.StaticLogFileName = true;
            //appender.AppendToFile = true;
            appender.ActivateOptions();
            //rep = LogManager.CreateRepository(Guid.NewGuid().ToString());

            BasicConfigurator.Configure(LogRepository, appender);

            var queue = GetQueue(StorageAccount, "logs");
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
        public void CanWriteToQueue()
        {
            var traceId = Guid.NewGuid().ToString(); //"ee994746-b972-4559-a8a9-ee0bd4556cff";
            // Arrange
            log4net.ILog log = LogManager.GetLogger(LogRepository.Name, "CanWriteToQueue");
            // Act
            var logEntry = GetLogEntity(traceId);
            log.Error(logEntry);
            var queue = GetQueue(StorageAccount, "logs");

            Thread.Sleep(new TimeSpan(0, 0, 8)); // let background thread finish

            var mesg = queue.GetMessage();

            Assert.IsNotNull(mesg);
            var result = Deserialize<LogEntity>(mesg.AsBytes);
            Assert.AreEqual(result.TraceId, traceId);
            queue.DeleteMessage(mesg);

        }


        public static T Deserialize<T>(byte[] byteArray)
        {
            using (var ms = new MemoryStream(byteArray))
            {
                return (T)new BinaryFormatter().Deserialize(ms);
            }
        }



        public LogEntity GetLogEntity(string traceId)
        {
            return new LogEntity { Agency = "Test", DateCreated = DateTime.Now, AppId = "inspector.app", AppVer = "2.0", EnvName = "PROD", TraceId = traceId, Detail = "Error Test" };
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
