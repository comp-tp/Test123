using Accela.Infrastructure.Azure.Queue;
using Accela.Infrastructure.Queue;
using Microsoft.WindowsAzure.Storage.Queue;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Azure.Test
{
    [TestFixture]
    public class AzureQueueStorageTest : BaseAzureTest
    {
        AzureQueueStorage<LogEntity> _queueStorage = null;
        private const string UT_QUEUE_NAME = "utqueuename";
        [SetUp]
        public void Init()
        {
            _queueStorage = new AzureQueueStorage<LogEntity>(new StorageConnectionStringSetting(), null);
            CloudQueue queue = base.StorageAccount.CreateCloudQueueClient().GetQueueReference(UT_QUEUE_NAME);
            queue.CreateIfNotExists();
        }

        [TearDown]
        public void Dispose()
        {
            var c = base.StorageAccount.CreateCloudQueueClient();
            var queue = c.GetQueueReference(UT_QUEUE_NAME);
            queue.DeleteIfExists();
        }

        [Test]
        public void AzureQueueStorage_Construct()
        {
            Assert.Throws(typeof(ArgumentNullException), delegate { new AzureQueueStorage<LogEntity>(null, null); });

            var storage = new AzureQueueStorage<LogEntity>(new StorageConnectionStringSetting(), null);

            // init thru diffrent Retry policy.
            storage = new AzureQueueStorage<LogEntity>(new StorageConnectionStringSetting(), new NoRetryPolicyConfiguration() { });

            storage = new AzureQueueStorage<LogEntity>(new StorageConnectionStringSetting(), new CustomRetryPolicyConfiguration() { RetryMethod = RetryMethod.Exponential, DeltaBackoff = TimeSpan.FromMilliseconds(200), MaxAttempts = 3 });

            storage = new AzureQueueStorage<LogEntity>(new StorageConnectionStringSetting(), new CustomRetryPolicyConfiguration() { RetryMethod = RetryMethod.Linear, DeltaBackoff = TimeSpan.FromMilliseconds(500), MaxAttempts = 3 });

            Assert.Throws(typeof(NotSupportedException), delegate
            {
                new AzureQueueStorage<LogEntity>(new StorageConnectionStringSetting(), new CustomRetryPolicyConfiguration()
                {
                    RetryMethod = RetryMethod.Discrete,
                    RetrySpans = new List<TimeSpan>{ 
                                    TimeSpan.FromMilliseconds(100), 
                                    TimeSpan.FromMilliseconds(200),
                                    TimeSpan.FromMilliseconds(500)
                        }
                });
            });
        }

        [Test]
        public void InvalidQueueName_ShouldThrowException()
        {
            //Queue names must be 3-63 characters in length and may contain lower-case alphanumeric characters and dashes. Dashes must be preceded and followed by an alphanumeric character.
            Assert.Throws(typeof(ArgumentNullException), async delegate { await _queueStorage.CreateIfNotExistsAsync(null); });
            Assert.Throws(typeof(ArgumentException), async delegate { await _queueStorage.CreateIfNotExistsAsync("UPPER-CASE"); });
            Assert.Throws(typeof(ArgumentException), async delegate { await _queueStorage.CreateIfNotExistsAsync("-dashtest"); });

            string str64 = null;
            for (int i = 0; i < 64; i++) str64 += i.ToString();
            Assert.Throws(typeof(ArgumentException), async delegate { await _queueStorage.CreateIfNotExistsAsync(str64); });

            // 2 chars
            Assert.Throws(typeof(ArgumentException), async delegate { await _queueStorage.CreateIfNotExistsAsync("12"); });
        }

        [Test]
        public async void CreateIfNotExistsAsync_ShouldSuccess()
        {
            var result = await _queueStorage.CreateIfNotExistsAsync(UT_QUEUE_NAME);
        }

        [Test]
        public async void DeleteIfExistsAsync_ShouldSuccess()
        {
            // queue name doesn't exist
            string queueName = "not-exist-queue";
            var result = await _queueStorage.DeleteIfExistsAsync(queueName);

            Assert.IsFalse(result);
            queueName = "utqueue-checkexist";

            result = await _queueStorage.CreateIfNotExistsAsync(queueName);

            Assert.IsTrue(result);
            result = await _queueStorage.DeleteIfExistsAsync(queueName);
            Assert.IsTrue(result);
        }

        [Test]
        public async void ExistsAsync_ShouldReturnTrue()
        {
            await _queueStorage.CreateIfNotExistsAsync(UT_QUEUE_NAME);

            var result = await _queueStorage.ExistsAsync(UT_QUEUE_NAME);
            Assert.IsTrue(result);
        }


        [Test]
        public async void ExistsAsync_ShouldReturnFalse_ForNonExisQueue()
        {
            var result = await _queueStorage.ExistsAsync("not-exist-queue-1212121");
            Assert.IsFalse(result);
        }

        [Test]
        public async void CreateNewMessageAsync_ShouldSuccess()
        {
            QueueMessage<LogEntity> message = new QueueMessage<LogEntity>("this is new message.");
            DateTimeOffset expirationTime = DateTime.UtcNow.AddHours(1);
            message.ExpirationTime = expirationTime;
            await _queueStorage.CreateNewMessageAsync(UT_QUEUE_NAME, message);
        }

        [Test]
        public async void CreateNewMessagesAsync_ShouldSuccess()
        {
            List<QueueMessage<LogEntity>> messages = new List<QueueMessage<LogEntity>>();
            for (int i = 0; i < 5; i++)
            {
                QueueMessage<LogEntity> message = new QueueMessage<LogEntity>("this is new message for test" + i);
                DateTimeOffset expirationTime = DateTime.UtcNow.AddHours(1);
                message.ExpirationTime = expirationTime;
                messages.Add(message);
            }

            await _queueStorage.CreateNewMessagesAsync(UT_QUEUE_NAME, messages);
        }

        [Test]
        public async void GetMessageAsync_ShouldSuccess()
        {
            QueueMessage<LogEntity> message = new QueueMessage<LogEntity>("this is new message for get test.");
            DateTimeOffset expirationTime = DateTime.UtcNow.AddHours(1);
            message.ExpirationTime = expirationTime;
            await _queueStorage.CreateNewMessageAsync(UT_QUEUE_NAME, message);

            QueueMessage<LogEntity> result = await _queueStorage.GetMessageAsync(UT_QUEUE_NAME);

            Assert.IsNotNull(result);
            Assert.That(result.AsString, Is.Null.Or.Empty);
            Assert.That(result.Id, Is.Null.Or.Empty);
            Assert.GreaterOrEqual(DateTime.UtcNow, result.InsertionTime.Value.UtcDateTime);
            Assert.IsNotNull(result.ExpirationTime);
        }

        [Test]
        public async void GeneralTypeObject_ShouldSuccess()
        {
            var entity = new LogEntity
            {
                TraceId = "12345678",
                Message = "this is new message for general type test"
            };
            QueueMessage<LogEntity> message = new QueueMessage<LogEntity>(entity);
            DateTimeOffset expirationTime = DateTime.UtcNow.AddHours(1);
            message.ExpirationTime = expirationTime;
            await _queueStorage.CreateNewMessageAsync(UT_QUEUE_NAME, message);

            QueueMessage<LogEntity> result = await _queueStorage.GetMessageAsync(UT_QUEUE_NAME);

            Assert.IsNotNull(result);
            Assert.That(result.AsString, Is.Null.Or.Empty);
            Assert.That(result.Id, Is.Null.Or.Empty);
            Assert.GreaterOrEqual(DateTime.UtcNow, result.InsertionTime.Value.UtcDateTime);
            Assert.IsNotNull(result.ExpirationTime);

            LogEntity t = result.AsT as LogEntity;
            Assert.IsNotNull(t);
            Assert.AreEqual(entity.TraceId, t.TraceId);

        }

        [Test]
        public async void GetMessagesAsync_ShouldSuccess()
        {
            for (int i = 0; i < 40; i++)
            {
                QueueMessage<LogEntity> message = new QueueMessage<LogEntity>("this is new message for get test" + i);
                DateTimeOffset expirationTime = DateTime.UtcNow.AddHours(1);
                message.ExpirationTime = expirationTime;
                await _queueStorage.CreateNewMessageAsync(UT_QUEUE_NAME, message);
            }

            //Azure queue have 32 items limitation each retrive
            var result = await _queueStorage.GetMessagesAsync(UT_QUEUE_NAME, 40);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);

            foreach(var item in result)
            {
                Assert.That(item.AsString, Is.Null.Or.Empty);
                Assert.That(item.Id, Is.Null.Or.Empty);
                Assert.GreaterOrEqual(DateTime.UtcNow, item.InsertionTime.Value.UtcDateTime);
                Assert.IsNotNull(item.ExpirationTime);
            }

        }

        [Test]
        public void GetMessagesAsync_ShouldThrowException()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), async delegate { await _queueStorage.GetMessagesAsync(UT_QUEUE_NAME, 0); });
            Assert.Throws(typeof(ArgumentOutOfRangeException), async delegate { await _queueStorage.GetMessagesAsync(UT_QUEUE_NAME, 1001); });
        }

        [Test]
        public async void ClearAsync_ShouldSuccess()
        {
            await _queueStorage.ClearAsync(UT_QUEUE_NAME);
            var result = await _queueStorage.PeekMessageAsync(UT_QUEUE_NAME);

            Assert.IsNull(result);
        }

        [Test]
        public async void PeekMessageAsync_ShouldReturnMessage()
        {
            QueueMessage<LogEntity> message = new QueueMessage<LogEntity>("this is message for peek test.");
            DateTimeOffset expirationTime = DateTime.UtcNow.AddHours(1);
            message.ExpirationTime = expirationTime;
            await _queueStorage.CreateNewMessageAsync(UT_QUEUE_NAME, message);

            string id = null;
            for (int i = 0; i < 5; i++)
            {
                QueueMessage<LogEntity> result = await _queueStorage.PeekMessageAsync(UT_QUEUE_NAME);

                Assert.IsNotNull(result);
                Assert.That(result.AsString, Is.Null.Or.Empty);
                Assert.That(result.Id, Is.Null.Or.Empty);

                if (id != null)
                {
                    Assert.AreEqual(id, result.Id);
                    id = result.Id;
                }

                Assert.GreaterOrEqual(DateTime.UtcNow, result.InsertionTime.Value.UtcDateTime);
                Assert.IsNotNull(result.ExpirationTime);
            }
        }

        [Test]
        public async void PeekMessagesAsync_ShouldReturnMessageList()
        {
            int totalInsert = 15;
            for (int i = 0; i < totalInsert; i++)
            {
                QueueMessage<LogEntity> message = new QueueMessage<LogEntity>("this is new message for peek list test" + i);
                DateTimeOffset expirationTime = DateTime.UtcNow.AddHours(1);
                message.ExpirationTime = expirationTime;
                await _queueStorage.CreateNewMessageAsync(UT_QUEUE_NAME, message);
            }
            var result = await _queueStorage.PeekMessagesAsync(UT_QUEUE_NAME, totalInsert);
            Assert.IsNotNull(result);
            Assert.AreEqual(totalInsert, result.Count());
            foreach(var item in result)
            {
                Assert.IsNotNull(item);
                Assert.That(item.AsString, Is.Null.Or.Empty);
                Assert.That(item.Id, Is.Null.Or.Empty);
                Assert.GreaterOrEqual(DateTime.UtcNow, item.InsertionTime.Value.UtcDateTime);
                Assert.IsNotNull(item.ExpirationTime);
            }
        }


        // for sync extesion tests

        [Test]
        public void CreateIfNotExists_ShouldSuccess()
        {
            var result = _queueStorage.CreateIfNotExists(UT_QUEUE_NAME);
        }

        [Test]
        public void DeleteIfExists_ShouldSuccess()
        {
            // queue name doesn't exist
            string queueName = "not-exist-queue";
            var result = _queueStorage.DeleteIfExists(queueName);

            Assert.IsFalse(result);
            queueName = "utqueue-checkexist";

            result =  _queueStorage.CreateIfNotExists(queueName);

            Assert.IsTrue(result);
            result =  _queueStorage.DeleteIfExists(queueName);
            Assert.IsTrue(result);
        }

        [Test]
        public void Exists_ShouldReturnTrue()
        {
             _queueStorage.CreateIfNotExists(UT_QUEUE_NAME);

            var result =  _queueStorage.Exists(UT_QUEUE_NAME);
            Assert.IsTrue(result);
        }


        [Test]
        public void Exists_ShouldReturnFalse_ForNonExisQueue()
        {
            var result = _queueStorage.Exists("not-exist-queue-1212121");
            Assert.IsFalse(result);
        }

        [Test]
        public void CreateNewMessage_ShouldSuccess()
        {
            QueueMessage<LogEntity> message = new QueueMessage<LogEntity>("this is new message.");
            DateTimeOffset expirationTime = DateTime.UtcNow.AddHours(1);
            message.ExpirationTime = expirationTime;
            _queueStorage.CreateNewMessage(UT_QUEUE_NAME, message);
        }

        [Test]
        public void CreateNewMessages_ShouldSuccess()
        {
            List<QueueMessage<LogEntity>> messages = new List<QueueMessage<LogEntity>>();
            for (int i = 0; i < 5; i++)
            {
                QueueMessage<LogEntity> message = new QueueMessage<LogEntity>("this is new message for sync test" + i);
                DateTimeOffset expirationTime = DateTime.UtcNow.AddHours(1);
                message.ExpirationTime = expirationTime;
                messages.Add(message);
            }

            _queueStorage.CreateNewMessages(UT_QUEUE_NAME, messages);
        }

        [Test]
        public void GetMessage_ShouldSuccess()
        {
            QueueMessage<LogEntity> message = new QueueMessage<LogEntity>("this is new message for get test.");
            DateTimeOffset expirationTime = DateTime.UtcNow.AddHours(1);
            message.ExpirationTime = expirationTime;
             _queueStorage.CreateNewMessage(UT_QUEUE_NAME, message);

            QueueMessage<LogEntity> result = _queueStorage.GetMessage(UT_QUEUE_NAME);

            Assert.IsNotNull(result);
            Assert.That(result.AsString, Is.Null.Or.Empty);
            Assert.That(result.Id, Is.Null.Or.Empty);
            Assert.GreaterOrEqual(DateTime.UtcNow, result.InsertionTime.Value.UtcDateTime);
            Assert.IsNotNull(result.ExpirationTime);
        }

        [Test]
        public void GetMessages_ShouldSuccess()
        {
            for (int i = 0; i < 5; i++)
            {
                QueueMessage<LogEntity> message = new QueueMessage<LogEntity>("this is new message for get test" + i);
                DateTimeOffset expirationTime = DateTime.UtcNow.AddHours(1);
                message.ExpirationTime = expirationTime;
                _queueStorage.CreateNewMessage(UT_QUEUE_NAME, message);
            }


            var result = _queueStorage.GetMessages(UT_QUEUE_NAME, 5);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);

            foreach (var item in result)
            {
                Assert.That(item.AsString, Is.Null.Or.Empty);
                Assert.That(item.Id, Is.Null.Or.Empty);
                Assert.GreaterOrEqual(DateTime.UtcNow, item.InsertionTime.Value.UtcDateTime);
                Assert.IsNotNull(item.ExpirationTime);
            }

        }


        [Test]
        public void Clear_ShouldSuccess()
        {
            _queueStorage.Clear(UT_QUEUE_NAME);
            var result = _queueStorage.PeekMessages(UT_QUEUE_NAME, 1);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() == 0);
        }

        [Test]
        public void PeekMessage_ShouldReturnMessage()
        {
            QueueMessage<LogEntity> message = new QueueMessage<LogEntity>("this is message for peek test.");
            DateTimeOffset expirationTime = DateTime.UtcNow.AddHours(1);
            message.ExpirationTime = expirationTime;
            _queueStorage.CreateNewMessage(UT_QUEUE_NAME, message);

            string id = null;
            for (int i = 0; i < 5; i++)
            {
                QueueMessage<LogEntity> result = _queueStorage.PeekMessage(UT_QUEUE_NAME);

                Assert.IsNotNull(result);
                Assert.That(result.AsString, Is.Null.Or.Empty);
                Assert.That(result.Id, Is.Null.Or.Empty);

                if (id != null)
                {
                    Assert.AreEqual(id, result.Id);
                    id = result.Id;
                }

                Assert.GreaterOrEqual(DateTime.UtcNow, result.InsertionTime.Value.UtcDateTime);
                Assert.IsNotNull(result.ExpirationTime);
            }
        }

        [Test]
        public void PeekMessages_ShouldReturnMessageList()
        {
            int totalInsert = 15;
            for (int i = 0; i < totalInsert; i++)
            {
                QueueMessage<LogEntity> message = new QueueMessage<LogEntity>("this is new message for peek list test" + i);
                DateTimeOffset expirationTime = DateTime.UtcNow.AddHours(1);
                message.ExpirationTime = expirationTime;
                _queueStorage.CreateNewMessage(UT_QUEUE_NAME, message);
            }
            var result = _queueStorage.PeekMessages(UT_QUEUE_NAME, totalInsert);
            Assert.IsNotNull(result);
            Assert.AreEqual(totalInsert, result.Count());
            foreach (var item in result)
            {
                Assert.IsNotNull(item);
                Assert.That(item.AsString, Is.Null.Or.Empty);
                Assert.That(item.Id, Is.Null.Or.Empty);
                Assert.GreaterOrEqual(DateTime.UtcNow, item.InsertionTime.Value.UtcDateTime);
                Assert.IsNotNull(item.ExpirationTime);
            }
        }
    }
}
