using Accela.Core.Serialization;
using Accela.Infrastructure.SQLServer.Tables;
using Accela.Infrastructure.Storage;
using Accela.Infrastructure.Storage.SQLServer;
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
    public class SQLServerTableStorageTest
    {
        private const string SAMPLE_TABLE_NAME1 = "T1";
        private IQueryable<SQLServerTableStorageEntity> _sampleItemList = null;

        public SQLServerTableStorageTest()
        {

        }

        public class XSQLServerTableStorageEntity : ITableEntity
        {
            public string XName1 { get; set; }

            public string RowKey { get; set; }

            public string PartitionKey { get; set; }

            public DateTimeOffset Timestamp { get; set; }
        }

        [SetUp]
        public void Setup()
        {
            _sampleItemList = InitItemList();
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public async void CreateNewOrReplaceAsyncTest()
        {
            var mockRepository = new Mock<ISQLServerTableStorageRepository>();
            var xEntity = new XSQLServerTableStorageEntity()
            {
                PartitionKey = Guid.NewGuid().ToString(),
                RowKey = Guid.NewGuid().ToString(),
                Timestamp = new DateTimeOffset(DateTime.Now),
                XName1 = "xname1"
            };

            var tableStorage = new SQLServerTableStorage<XSQLServerTableStorageEntity>(mockRepository.Object, new CustomRetryPolicyConfiguration());
            await tableStorage.CreateNewOrReplaceAsync(xEntity, SAMPLE_TABLE_NAME1);

            mockRepository
                .Verify(m => m.CreateNewOrReplaceAsync(It.IsAny<SQLServerTableStorageEntity>(), It.IsAny<string>()), Times.Once());
        }

        [Test]
        public async void CreateNewOrReplaceArrayAsyncTest()
        {
            var mockRepository = new Mock<ISQLServerTableStorageRepository>();
            var xEntityList = new List<XSQLServerTableStorageEntity>();

            var xEntity1 = new XSQLServerTableStorageEntity()
            {
                PartitionKey = Guid.NewGuid().ToString(),
                RowKey = Guid.NewGuid().ToString(),
                Timestamp = new DateTimeOffset(DateTime.Now),
                XName1 = "xname1"
            };

            var xEntity2 = new XSQLServerTableStorageEntity()
            {
                PartitionKey = Guid.NewGuid().ToString(),
                RowKey = Guid.NewGuid().ToString(),
                Timestamp = new DateTimeOffset(DateTime.Now),
                XName1 = "xname2"
            };
            xEntityList.Add(xEntity1);
            xEntityList.Add(xEntity2);

            var tableStorage = new SQLServerTableStorage<XSQLServerTableStorageEntity>(mockRepository.Object, new CustomRetryPolicyConfiguration());
            await tableStorage.CreateNewOrReplaceAsync(xEntityList.ToArray(), SAMPLE_TABLE_NAME1);

            mockRepository
                .Verify(m => m.CreateNewOrReplaceAsync(It.IsAny<SQLServerTableStorageEntity[]>(), It.IsAny<string>()), Times.Once());
        }

        [Test]
        public async void DeleteIfExistsAsyncTest()
        {
            var mockRepository = new Mock<ISQLServerTableStorageRepository>();
            var xSQLServerTableStorageEntity = new XSQLServerTableStorageEntity()
            {
                PartitionKey = Guid.NewGuid().ToString(),
                RowKey = Guid.NewGuid().ToString(),
                Timestamp = new DateTimeOffset(DateTime.Now),
                XName1 = "xname1"
            };

            var tableStorage = new SQLServerTableStorage<XSQLServerTableStorageEntity>(mockRepository.Object, new CustomRetryPolicyConfiguration());
            await tableStorage.DeleteIfExistsAsync(xSQLServerTableStorageEntity, SAMPLE_TABLE_NAME1);

            mockRepository
                .Verify(m => m.DeleteIfExistsAsync(It.IsAny<SQLServerTableStorageEntity>(), It.IsAny<string>()), Times.Once());
        }

        [Test]
        public async void ReadAsyncTest()
        {
            var mockXItem = new XSQLServerTableStorageEntity()
            {
                PartitionKey = Guid.NewGuid().ToString(),
                RowKey = Guid.NewGuid().ToString(),
                Timestamp = new DateTimeOffset(DateTime.Now),
                XName1 = "xname1"
            };

            var mockItem = new SQLServerTableStorageEntity()
            {
                PartitionKey = mockXItem.PartitionKey,
                RowKey = mockXItem.RowKey,
                Timestamp = mockXItem.Timestamp
            };
            mockItem.Content = JsonSerializerService.Current.Serialize(mockXItem);

            var mockRepository = new Mock<ISQLServerTableStorageRepository>();
            mockRepository
                .Setup(m => m.ReadAsync(It.Is<string>(p => p == SAMPLE_TABLE_NAME1), It.Is<string>(p => p == mockItem.PartitionKey), It.Is<string>(p => p == mockItem.RowKey)))
                .Returns(Task.FromResult<SQLServerTableStorageEntity>(mockItem));

            var tableStorage = new SQLServerTableStorage<XSQLServerTableStorageEntity>(mockRepository.Object, new CustomRetryPolicyConfiguration());
            var response = await tableStorage.ReadAsync(SAMPLE_TABLE_NAME1, mockItem.PartitionKey, mockItem.RowKey);
            mockRepository
                .Verify(m => m.ReadAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once());

            var comparedResult = response.PartitionKey == mockXItem.PartitionKey && response.RowKey == mockXItem.RowKey && response.XName1 == mockXItem.XName1;

            Assert.IsTrue(comparedResult);
        }

        [Test]
        public async void SearchAsyncTest_ByMaxResults()
        {
            int maxResults = new Random().Next(1, _sampleItemList.Count());
            var mockRepository = new Mock<ISQLServerTableStorageRepository>();
            mockRepository
                .Setup(m => m.SearchAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<long>(), maxResults))
                .Returns(Task.FromResult<SQLServerTableStorageEntity[]>(_sampleItemList.Take(maxResults).ToArray()));

            var tableStorage = new SQLServerTableStorage<XSQLServerTableStorageEntity>(mockRepository.Object, new CustomRetryPolicyConfiguration());
            var response = await tableStorage.SearchAsync(new TableSearchOptions()
            {
                MaxResults = maxResults,
                TableName = SAMPLE_TABLE_NAME1
            });
            var comparedResult = response != null && response.Results != null && response.Results.Count() == maxResults;

            Assert.IsTrue(comparedResult);
        }

        [Test]
        public async void SearchAsync_Paging()
        {
            int maxResults = new Random().Next(1, _sampleItemList.Count() - 1);
            var mockRepository = new Mock<ISQLServerTableStorageRepository>();
            mockRepository
                .Setup(m => m.SearchAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<long>(), It.IsAny<int>()))
                .Returns(Task.FromResult<SQLServerTableStorageEntity[]>(_sampleItemList.Take(maxResults).ToArray()));

            var tableStorage = new SQLServerTableStorage<XSQLServerTableStorageEntity>(mockRepository.Object, new CustomRetryPolicyConfiguration());
            var response = await tableStorage.SearchAsync(new TableSearchOptions()
            {
                MaxResults = maxResults,
                TableName = SAMPLE_TABLE_NAME1
            });
            var comparedResult = response != null && response.Results != null && response.Results.Count() == maxResults;

            var result = comparedResult;

            //---

            maxResults = 1;
            mockRepository
                .Setup(m => m.SearchAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<long>(), It.IsAny<int>()))
                .Returns(Task.FromResult<SQLServerTableStorageEntity[]>(_sampleItemList.Take(maxResults).ToArray()));

            tableStorage = new SQLServerTableStorage<XSQLServerTableStorageEntity>(mockRepository.Object, new CustomRetryPolicyConfiguration());
            response = await tableStorage.SearchAsync(new TableSearchOptions()
            {
                MaxResults = maxResults,
                TableName = SAMPLE_TABLE_NAME1,
                ContinuationToken = response.ContinuationToken
            });

            comparedResult = response != null && response.Results != null && response.Results.Count() == maxResults;
            result = result && comparedResult;

            Assert.IsTrue(comparedResult);
        }

        [Test]
        public async void SearchAsync_ByFilter()
        {
            var mockRepository = new Mock<ISQLServerTableStorageRepository>();
            var sampleFilteredItems = _sampleItemList.Where(p => p.ID >= 2 && p.ID <= 4).ToArray();
            mockRepository
                .Setup(m => m.SearchAsync(It.IsAny<string>(), It.Is<string>(p => p == "ID>=2 and ID<=4"), It.IsAny<long>(), It.IsAny<int>()))
                .Returns(Task.FromResult<SQLServerTableStorageEntity[]>(sampleFilteredItems));

            var tableStorage = new SQLServerTableStorage<XSQLServerTableStorageEntity>(mockRepository.Object, new CustomRetryPolicyConfiguration());
            var response = await tableStorage.SearchAsync(new TableSearchOptions()
            {
                Filter = "ID>=2L and ID<=4L",
                TableName = SAMPLE_TABLE_NAME1
            });
            var comparedResult = response != null && response.Results != null && response.Results.Count() == sampleFilteredItems.Count();

            Assert.IsTrue(comparedResult);
        }

        [Test]
        public async void RetryPolicy_Settings()
        {
            int maxResults = new Random().Next(1, _sampleItemList.Count());
            var mockRepository = new Mock<ISQLServerTableStorageRepository>();
            mockRepository
                .Setup(m => m.SearchAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<long>(), maxResults))
                .Returns(Task.FromResult<SQLServerTableStorageEntity[]>(_sampleItemList.Take(maxResults).ToArray()));

            var retryPolicy = new CustomRetryPolicyConfiguration();
            retryPolicy.DeltaBackoff = TimeSpan.FromMilliseconds(3000);
            retryPolicy.MaxAttempts = 6;
            retryPolicy.RetryMethod = RetryMethod.Linear;
            retryPolicy.RetrySpans = new List<TimeSpan>() { TimeSpan.FromMilliseconds(20), TimeSpan.FromMilliseconds(120), TimeSpan.FromMilliseconds(220), TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(1500) };

            var tableStorage = new SQLServerTableStorage<XSQLServerTableStorageEntity>(mockRepository.Object, retryPolicy);
            var response = await tableStorage.SearchAsync(new TableSearchOptions()
            {
                MaxResults = maxResults,
                TableName = SAMPLE_TABLE_NAME1
            });
            var comparedResult = response != null && response.Results != null && response.Results.Count() == maxResults;

            var result = response != null
                && response.Results != null
                && response.Results.Count() == maxResults
                && SQLServerStorageDbConfiguration.DeltaBackoff == retryPolicy.DeltaBackoff
                && SQLServerStorageDbConfiguration.MaxAttempts == retryPolicy.MaxAttempts
                && SQLServerStorageDbConfiguration.RetryMethod == retryPolicy.RetryMethod
                && SQLServerStorageDbConfiguration.RetrySpans == retryPolicy.RetrySpans;

            Assert.IsTrue(result);
        }

        private IQueryable<SQLServerTableStorageEntity> InitItemList()
        {
            var i = 0;

            var list = new List<SQLServerTableStorageEntity>
            { 
                new SQLServerTableStorageEntity { ID=(++i), PartitionKey = "P" + i.ToString() ,  RowKey="key" + i.ToString(), Timestamp= new DateTimeOffset(DateTime.Now) }
                ,new SQLServerTableStorageEntity { ID=(++i), PartitionKey = "P" + i.ToString() ,  RowKey="key" + i.ToString(), Timestamp= new DateTimeOffset(DateTime.Now) }
                ,new SQLServerTableStorageEntity { ID=(++i), PartitionKey = "P" + i.ToString() ,  RowKey="key" + i.ToString(), Timestamp= new DateTimeOffset(DateTime.Now) }
                ,new SQLServerTableStorageEntity { ID=(++i), PartitionKey = "P" + i.ToString() ,  RowKey="key" + i.ToString(), Timestamp= new DateTimeOffset(DateTime.Now) }
                ,new SQLServerTableStorageEntity { ID=(++i), PartitionKey = "P" + i.ToString() ,  RowKey="key" + i.ToString(), Timestamp= new DateTimeOffset(DateTime.Now) }
            }.AsQueryable();

            return list;
        }

    }
}
