using Accela.Infrastructure.SQLServer.Queue;
using Accela.Infrastructure.Storage;
using Accela.Infrastructure.Tables;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.SQLServer.Test
{
    [TestFixture]
    public class SQLServerQueueStorageRepositoryTest
    {
        private const string CONNECTION_STRING = "Persist Security Info=False;User Id=sqlazuredevadmin;Password=@ccela123;Initial Catalog=CP_APPS_QUEUE_STORAGES;Server=kszdcyoqxe.database.windows.net";
        private const string QUEUE_NAME = "queuestorage-ut";
        public SQLServerQueueStorageRepositoryTest()
        {

        }

        [SetUp]
        public void Setup()
        {

        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public async void QueueStorageRepository_QueueCRUDTest()
        {
            await QueueStorageRepository.CreateIfNotExistsAsync(QUEUE_NAME);

            // if exists already, not create again
            await QueueStorageRepository.CreateIfNotExistsAsync(QUEUE_NAME);

            // exists
            bool exists = await QueueStorageRepository.ExistsAsync(QUEUE_NAME);
            Assert.IsTrue(exists);

            await QueueStorageRepository.DeleteIfExistsAsync(QUEUE_NAME);
            await QueueStorageRepository.DeleteIfExistsAsync(QUEUE_NAME);

            exists = await QueueStorageRepository.ExistsAsync(QUEUE_NAME);
            Assert.IsFalse(exists);
        }

        [Test]
        public async void QueueStorageRepository_QueueEntityCRUDAsyncTest()
        {
            // clear queue
            await QueueStorageRepository.ClearAsync(QUEUE_NAME);

            var entity = new SQLServerQueueEntity
            {
                InsertionTime = new DateTimeOffset(DateTime.UtcNow),
                ExpirationTime = new DateTimeOffset(DateTime.UtcNow.AddHours(1)),
                Content = "Queue UT Data - " + Guid.NewGuid().ToString()
            };
            await QueueStorageRepository.InsertQueueEntityAsync(QUEUE_NAME,entity);

            // peek queue
            bool deleteQueueMessage = false;
            var result = await QueueStorageRepository.GetQueueEntityAsync(QUEUE_NAME, deleteQueueMessage);

            Assert.IsNotNull(result);
            Assert.AreEqual(entity.Content, result.Content);
            Assert.AreEqual(entity.InsertionTime, result.InsertionTime);
            // get queue (pop)
            deleteQueueMessage = true;
            result = await QueueStorageRepository.GetQueueEntityAsync(QUEUE_NAME, deleteQueueMessage);
            Assert.IsNotNull(result);
            Assert.AreEqual(entity.Content, result.Content);

            // no message in queue
            result = await QueueStorageRepository.GetQueueEntityAsync(QUEUE_NAME, false);
            Assert.IsNull(result);

            string lastContent = null;
            for (int i = 1; i <= 5; i++)
            {
                entity = new SQLServerQueueEntity
                {
                    InsertionTime = new DateTimeOffset(DateTime.UtcNow),
                    ExpirationTime = new DateTimeOffset(DateTime.UtcNow.AddHours(1)),
                    Content = "Queue UT Data - " + Guid.NewGuid().ToString() + "-" + i.ToString()
                };

                if (i == 5) lastContent = entity.Content;

                await QueueStorageRepository.InsertQueueEntityAsync(QUEUE_NAME, entity);
            }

            // pop 3 messages
            var messages = await QueueStorageRepository.GetQueueEntitiesAsync(QUEUE_NAME, 4, true);
            Assert.AreEqual(4, messages.Count());

            result = await QueueStorageRepository.GetQueueEntityAsync(QUEUE_NAME, false);
            Assert.AreEqual(lastContent, result.Content);
        }


        private ISQLServerQueueStorageRepository QueueStorageRepository
        {
            get
            {
                return new SQLServerQueueStorageRepository(CONNECTION_STRING);
            }
        }

    }
}
