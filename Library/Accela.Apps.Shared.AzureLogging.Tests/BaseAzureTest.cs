using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using log4net.Repository;
using Microsoft.WindowsAzure.Storage;
using System.Diagnostics;
using log4net;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Accela.Apps.Shared.AzureLogging.Tests
{

    [TestFixture]
    public abstract class BaseAzureTest
    {


        protected virtual ILoggerRepository LogRepository { get; set; }

        protected abstract CloudStorageAccount StorageAccount { get; set; }

        protected virtual void InitializeSetup()
        {
            LogRepository = LogManager.CreateRepository("default");
        }

        [SetUp]
        public virtual void SetUp()
        {

            CloudStorageEmulatorShepherd shepherd = new CloudStorageEmulatorShepherd();
            shepherd.Start();
            InitializeSetup();
        }

        [TearDown]
        public virtual void TearDown()
        {
            if (LogRepository != null)
            {
                LogRepository.Shutdown();
            }

        }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
        }

        public static T Deserialize<T>(byte[] byteArray)
        {
            using (var ms = new MemoryStream(byteArray))
            {
                return (T)new BinaryFormatter().Deserialize(ms);
            }
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

    }

    public class CloudStorageEmulatorShepherd
    {
        public void Start()
        {
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.DevelopmentStorageAccount;
                var queueClient = storageAccount.CreateCloudQueueClient();
                var queue = queueClient.GetQueueReference("logs");
                queue.CreateIfNotExists(new QueueRequestOptions { LocationMode = LocationMode.PrimaryThenSecondary, RetryPolicy = new Microsoft.WindowsAzure.Storage.RetryPolicies.NoRetry(), ServerTimeout = new TimeSpan(0, 0, 0, 1) });
            }
            catch (Exception ex)
            {
                var processStartInfo = new ProcessStartInfo()
                {
                    FileName = Path.Combine(@"C:\Program Files\Microsoft SDKs\Azure\Emulator", "csrun.exe"),
                    Arguments = @"/devstore",
                };

                using (var process = Process.Start(processStartInfo))
                {
                    process.WaitForExit();
                }
            }
        }
    }

}
