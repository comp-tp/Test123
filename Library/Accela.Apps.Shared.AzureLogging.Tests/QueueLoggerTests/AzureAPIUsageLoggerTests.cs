using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.WindowsAzure.Storage;
using Accela.Apps.Shared.AzureLogging.Logger;
using Accela.Apps.Core.Log;
using Accela.Core.Logging;
using System.Threading;

namespace Accela.Apps.Shared.AzureLogging.Tests.QueueLoggerTests
{
    [TestFixture]
    public class AzureAPIUsageLoggerTests : BaseAzureTest
    {
        private IQueueLogger<IApiUsage> logger;
        
        protected override void InitializeSetup()
        {
            logger = new AzureAPIUsageLogger("Local_Storage", "apiusage");
            logger.Start();
            StorageAccount = CloudStorageAccount.DevelopmentStorageAccount;
            //base.InitializeSetup();

            var queue = GetQueue(StorageAccount, "apiusage");
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

        }


        [Test]
        public void Should_Add_ApiUsage_To_Queue()
        {
            var createdDate = DateTime.Now;
            logger.Enqueue(new ApiUsage { Agency = "Test", AppId = "Test", ClientIP = "1.2.3.4", CreatedDate = createdDate, ResourceName = "apis/test", UserId = "Unit Test" });
            Thread.Sleep(1000);

            var queue = GetQueue(StorageAccount, "apiusage");
            var mesg = queue.GetMessage();
            Assert.IsNotNull(mesg);
            var result = Deserialize<IApiUsage>(mesg.AsBytes);
            Assert.AreEqual(result.CreatedDate, createdDate);
            queue.DeleteMessage(mesg);
        }



        [Test]
        public void Should_Add_100_ApiUsage_Messages_In_LessThan_1_Sec()
        {
            // Arrange
            // Act
            DateTime startTime = DateTime.UtcNow;
            100.Times(i => logger.Enqueue(new ApiUsage { Agency = "Test", AppId = "Test",  ClientIP = "1.2.3.4", CreatedDate = startTime, ResourceName = "apis/test", UserId = "Unit Test" }));
            DateTime endTime = DateTime.UtcNow;
            // Give background thread time to finish
            Thread.Sleep(500);
            // Assert
            Assert.That(endTime - startTime, Is.LessThan(TimeSpan.FromMilliseconds(100)));
        }

        [TearDown]
        public override void TearDown()
        {
            logger.Cancel();
        }

        protected override CloudStorageAccount StorageAccount
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ApiUsage : IApiUsage
    {
        public string ResourceName
        {
            get;
            set;
        }

        public string HttpVerb
        {
            get;
            set;
        }

        public string Agency
        {
            get;
            set;
        }

        public string UserId
        {
            get;
            set;
        }

        public string AppId
        {
            get;
            set;
        }

        public string AppVersion
        {
            get;
            set;
        }

        public string Environment
        {
            get;
            set;
        }

        public string ClientOS
        {
            get;
            set;
        }

        public string ClientOSVersion
        {
            get;
            set;
        }

        public string ClientDevice
        {
            get;
            set;
        }

        public string ClientIP
        {
            get;
            set;
        }

        public DateTime CreatedDate
        {
            get;
            set;
        }
    }
}
