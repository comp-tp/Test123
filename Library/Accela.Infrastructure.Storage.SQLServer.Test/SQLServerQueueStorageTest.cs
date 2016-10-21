using Accela.Infrastructure.Queue;
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
    public class SQLServerQueueStorageTest
    {
        private const string QUEUE_NAME = "queuestorage-ut";

        public SQLServerQueueStorageTest()
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
        public async void SqlServerQueueStorage_CreateIfNotExistsAsync()
        {
            var mockRepository = new Mock<ISQLServerQueueStorageRepository>();
            mockRepository
                .Setup(m => m.CreateIfNotExistsAsync(It.Is<string>(p => p == QUEUE_NAME)))
                .Returns(Task.FromResult(true));
            var queueStorage = new SQLServerQueueStorage<CustomEntity>(mockRepository.Object, null);

            bool result = await queueStorage.CreateIfNotExistsAsync(QUEUE_NAME);

            Assert.IsTrue(result);
        }

        [Test]
        public async void SqlServerQueueStorage_DeleteIfExistsAsync()
        {
            var mockRepository = new Mock<ISQLServerQueueStorageRepository>();
            mockRepository
                .Setup(m => m.DeleteIfExistsAsync(It.Is<string>(p => p == QUEUE_NAME)))
                .Returns(Task.FromResult(true));
            var queueStorage = new SQLServerQueueStorage<CustomEntity>(mockRepository.Object, null);

            bool result = await queueStorage.DeleteIfExistsAsync(QUEUE_NAME);

            Assert.IsTrue(result);
        }

        [Test]
        public async void SqlServerQueueStorage_ExistsAsync()
        {
            var mockRepository = new Mock<ISQLServerQueueStorageRepository>();
            mockRepository
                .Setup(m => m.ExistsAsync(It.Is<string>(p => p == QUEUE_NAME)))
                .Returns(Task.FromResult(false));
            var queueStorage = new SQLServerQueueStorage<CustomEntity>(mockRepository.Object, null);

            bool result = await queueStorage.ExistsAsync(QUEUE_NAME);

            Assert.IsFalse(result);

            mockRepository
                .Verify(m => m.ExistsAsync(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public async void SqlServerQueueStorage_CreateNewMessageAsync()
        {
            var mockRepository = new Mock<ISQLServerQueueStorageRepository>();
            var queueMessage = new QueueMessage<CustomEntity>(new CustomEntity { Name = "your name", WorkYears = 2 });
            queueMessage.ExpirationTime = new DateTimeOffset(DateTime.UtcNow);
            mockRepository.Setup(m => m.InsertQueueEntityAsync(QUEUE_NAME, new SQLServerQueueEntity()));

            var queueStorage = new SQLServerQueueStorage<CustomEntity>(mockRepository.Object, null);

            await queueStorage.CreateNewMessageAsync(QUEUE_NAME, queueMessage);

            mockRepository
                .Verify(m => m.InsertQueueEntityAsync(It.IsAny<string>(), It.IsAny<SQLServerQueueEntity>()), Times.Once());
        }

        [Test]
        public async void SqlServerQueueStorage_CreateNewMessagesAsync()
        {
            var mockRepository = new Mock<ISQLServerQueueStorageRepository>();
            var mocData = new List<SQLServerQueueEntity>();

            var messages = new List<QueueMessage<CustomEntity>>();

            for (int i=0; i<5;i++)
            {
                var entity = new SQLServerQueueEntity 
                {
                    Id = i,
                    ExpirationTime = new DateTimeOffset(DateTime.UtcNow),
                    InsertionTime = new DateTimeOffset(DateTime.UtcNow),
                    Content = "test"
                };

                mocData.Add(entity);

                var m = new QueueMessage<CustomEntity>(new CustomEntity { Name = "your name", WorkYears = 2 });
                m.ExpirationTime = new DateTimeOffset(DateTime.UtcNow);
                messages.Add(m);
            }

            mockRepository.Setup(m => m.InsertQueueEntitiesAsync(QUEUE_NAME, mocData));

            var queueStorage = new SQLServerQueueStorage<CustomEntity>(mockRepository.Object, null);

            await queueStorage.CreateNewMessagesAsync(QUEUE_NAME, messages);

            mockRepository
                .Verify(m => m.InsertQueueEntitiesAsync(It.IsAny<string>(), It.IsAny <IEnumerable<SQLServerQueueEntity>>()), Times.Once());
        }


        [Test]
        public async void SqlServerQueueStorage_GetMessageAsync()
        {
            var mockRepository = new Mock<ISQLServerQueueStorageRepository>();
            var queueMessage = new QueueMessage<CustomEntity>(new CustomEntity { Name = "your name", WorkYears = 2 });
            queueMessage.ExpirationTime = new DateTimeOffset(DateTime.UtcNow);

            var entity = new SQLServerQueueEntity
            {
                ExpirationTime = new DateTimeOffset(DateTime.UtcNow),
                InsertionTime = new DateTimeOffset(DateTime.UtcNow),
                Content = "test"
            };

            mockRepository
                .Setup(m => m.GetQueueEntityAsync(QUEUE_NAME, true))
                .Returns(Task.FromResult<SQLServerQueueEntity>(entity));

            var queueStorage = new SQLServerQueueStorage<CustomEntity>(mockRepository.Object, null);

            var result = await queueStorage.GetMessageAsync(QUEUE_NAME);

            Assert.IsNotNull(result);
            Assert.AreEqual(entity.InsertionTime, result.InsertionTime);

            mockRepository
                .Verify(m => m.GetQueueEntityAsync(It.IsAny<string>(), true), Times.Once());
        }

        [Test]
        public async void SqlServerQueueStorage_GetMessagesAsync()
        {
            var mockRepository = new Mock<ISQLServerQueueStorageRepository>();
            var mocData = new List<SQLServerQueueEntity>();

            var messages = new List<QueueMessage<CustomEntity>>();

            for (int i = 0; i < 5; i++)
            {
                var entity = new SQLServerQueueEntity
                {
                    ExpirationTime = new DateTimeOffset(DateTime.UtcNow),
                    InsertionTime = new DateTimeOffset(DateTime.UtcNow),
                    Content = "test"
                };

                mocData.Add(entity);

                var m = new QueueMessage<CustomEntity>(new CustomEntity { Name = "your name", WorkYears = 2 });
                m.ExpirationTime = new DateTimeOffset(DateTime.UtcNow);
                messages.Add(m);
            }

            mockRepository
                .Setup(m => m.GetQueueEntitiesAsync(QUEUE_NAME, 5, true))
                .Returns(Task.FromResult <IEnumerable<SQLServerQueueEntity>>(mocData));

            var queueStorage = new SQLServerQueueStorage<CustomEntity>(mockRepository.Object, null);

            await queueStorage.GetMessagesAsync(QUEUE_NAME, 5);

            mockRepository
                .Verify(m => m.GetQueueEntitiesAsync(It.IsAny<string>(), 5, true), Times.Once());
        }

        [Test]
        public async void SqlServerQueueStorage_PeekMessageAsync()
        {
            var mockRepository = new Mock<ISQLServerQueueStorageRepository>();
            var queueMessage = new QueueMessage<CustomEntity>(new CustomEntity { Name = "your name", WorkYears = 2 });
            queueMessage.ExpirationTime = new DateTimeOffset(DateTime.UtcNow);

            var entity = new SQLServerQueueEntity
            {
                ExpirationTime = new DateTimeOffset(DateTime.UtcNow),
                InsertionTime = new DateTimeOffset(DateTime.UtcNow),
                Content = "test"
            };

            mockRepository
                .Setup(m => m.GetQueueEntityAsync(QUEUE_NAME, false))
                .Returns(Task.FromResult<SQLServerQueueEntity>(entity));

            var queueStorage = new SQLServerQueueStorage<CustomEntity>(mockRepository.Object, null);

            var result = await queueStorage.PeekMessageAsync(QUEUE_NAME);

            Assert.IsNotNull(result);
            Assert.AreEqual(entity.InsertionTime, result.InsertionTime);

            mockRepository
                .Verify(m => m.GetQueueEntityAsync(It.IsAny<string>(), false), Times.Once());
        }

        [Test]
        public async void SqlServerQueueStorage_PeekMessagesAsync()
        {
            var mockRepository = new Mock<ISQLServerQueueStorageRepository>();
            var mocData = new List<SQLServerQueueEntity>();

            var messages = new List<QueueMessage<CustomEntity>>();

            for (int i = 0; i < 5; i++)
            {
                var entity = new SQLServerQueueEntity
                {
                    ExpirationTime = new DateTimeOffset(DateTime.UtcNow),
                    InsertionTime = new DateTimeOffset(DateTime.UtcNow),
                    Content = "test"
                };

                mocData.Add(entity);

                var m = new QueueMessage<CustomEntity>(new CustomEntity { Name = "your name", WorkYears = 2 });
                m.ExpirationTime = new DateTimeOffset(DateTime.UtcNow);
                messages.Add(m);
            }

            mockRepository
                .Setup(m => m.GetQueueEntitiesAsync(QUEUE_NAME, 5, false))
                .Returns(Task.FromResult<IEnumerable<SQLServerQueueEntity>>(mocData));

            var queueStorage = new SQLServerQueueStorage<CustomEntity>(mockRepository.Object, null);

            await queueStorage.PeekMessagesAsync(QUEUE_NAME, 5);

            mockRepository
                .Verify(m => m.GetQueueEntitiesAsync(It.IsAny<string>(), 5, false), Times.Once());
        }

        [Test]
        public async void SqlServerQueueStorage_ClearAsync()
        {
            var mockRepository = new Mock<ISQLServerQueueStorageRepository>();
            mockRepository
                .Setup(m => m.ClearAsync(It.Is<string>(p => p == QUEUE_NAME)))
                .Returns(Task.FromResult(false));
            var queueStorage = new SQLServerQueueStorage<CustomEntity>(mockRepository.Object, null);

            await queueStorage.ClearAsync(QUEUE_NAME);

            mockRepository
                .Verify(m => m.ClearAsync(It.IsAny<string>()), Times.Once());
        }

        [Serializable]
        public class CustomEntity
        {
            public string Name { get; set; }
            public int WorkYears { get; set; }
        }
    }
}
