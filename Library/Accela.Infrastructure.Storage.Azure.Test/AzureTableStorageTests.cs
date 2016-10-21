
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accela.Infrastructure.Azure;
using Microsoft.WindowsAzure.Storage;
using System.IO;
using Accela.Infrastructure.Exceptions;
using Accela.Infrastructure.Storage;
using System.Threading;
using Accela.Infrastructure.Azure.Tables;
using Accela.Infrastructure.Tables;
using Microsoft.WindowsAzure.Storage.Table;
namespace Accela.Infrastructure.Azure.Test
{
    [TestFixture]
    public class AzureTableStorageTests : BaseAzureTest
    {
        AzureTableStorage<TestObject> _tableStorage;

        private const string TABLE_NAME = "UTTableName";
        private const string PATITION_KEY = "UTPartitionKey";
        TestObject oneObject = null;
        List<TestObject> manyObjects = new List<TestObject>();
        
        [SetUp]
        public void Init()
        {
            _tableStorage = new AzureTableStorage<TestObject>(new StorageConnectionStringSetting(), null);
            oneObject = new TestObject
            {
                Id = Guid.Empty.ToString(),
                Name = "UTTest",
                Expired= DateTime.Now,
                RowKey = Guid.NewGuid().ToString(),
                PartitionKey = PATITION_KEY
            };
        }

        [TearDown]
        public void Dispose()
        {
            var c = base.StorageAccount.CreateCloudTableClient();
            CloudTable table = c.GetTableReference(TABLE_NAME);

            if(table.Exists())
                table.Delete();
        }

        [Test]
        public void AzureTableStorage_Construct()
        {
            Assert.Throws(typeof(ArgumentNullException), delegate { new AzureTableStorage<TestObject>(null, null); });

            var storage = new AzureTableStorage<TestObject>(new StorageConnectionStringSetting(), null);

            // case 5. init thru diffrent Retry policy.
            storage = new AzureTableStorage<TestObject>(new StorageConnectionStringSetting(), new NoRetryPolicyConfiguration() { });

            storage = new AzureTableStorage<TestObject>(new StorageConnectionStringSetting(), new CustomRetryPolicyConfiguration() { RetryMethod = RetryMethod.Exponential, DeltaBackoff = TimeSpan.FromMilliseconds(200), MaxAttempts = 3 });

            storage = new AzureTableStorage<TestObject>(new StorageConnectionStringSetting(), new CustomRetryPolicyConfiguration() { RetryMethod = RetryMethod.Linear, DeltaBackoff = TimeSpan.FromMilliseconds(500), MaxAttempts = 3 });

            Assert.Throws(typeof(NotSupportedException), delegate
            {
                new AzureTableStorage<TestObject>(new StorageConnectionStringSetting(), new CustomRetryPolicyConfiguration()
                    {
                        RetryMethod = RetryMethod.Discrete,
                        RetrySpans = new List<TimeSpan>{ 
                                    TimeSpan.FromMilliseconds(100), 
                                    TimeSpan.FromMilliseconds(200),
                                    TimeSpan.FromMilliseconds(500),
                                    TimeSpan.FromMilliseconds(500)
                        }
                    });
            });
        }

        [Test]
        public void CreateNewOrReplaceAsync_ShouldThrowException()
        {
            Assert.Throws(typeof(ArgumentNullException), async delegate { await _tableStorage.CreateNewOrReplaceAsync(null as TestObject, TABLE_NAME); });
            Assert.Throws(typeof(ArgumentNullException), async delegate { await _tableStorage.CreateNewOrReplaceAsync(oneObject, null); });
            Assert.Throws(typeof(ArgumentNullException), async delegate { await _tableStorage.CreateNewOrReplaceAsync(null as TestObject, string.Empty); });
        }

        [Test]
        public void CreateNewOrReplaceAsync_ShouldThrowException_2()
        {
            Assert.Throws(typeof(ArgumentNullException), async delegate { await _tableStorage.CreateNewOrReplaceAsync(null as TestObject[], TABLE_NAME); });
            Assert.Throws(typeof(ArgumentNullException), async delegate { await _tableStorage.CreateNewOrReplaceAsync(oneObject, null); });
            Assert.Throws(typeof(ArgumentNullException), async delegate { await _tableStorage.CreateNewOrReplaceAsync(null as TestObject[], string.Empty); });
        }

        [Test]
        public async void CreateNewOrReplaceAsync_ShouldCreateEntitySuccess()
        {
            // create new
            var newObject = new TestObject
            {
                Id = Guid.NewGuid().ToString(),
                Name = "UTTest",
                Expired = DateTime.Now,
                RowKey = Guid.NewGuid().ToString(),
                PartitionKey = PATITION_KEY
            };

            await _tableStorage.CreateNewOrReplaceAsync(newObject, TABLE_NAME);

            // check the data if exists in storage
            var returnObj = await _tableStorage.ReadAsync(TABLE_NAME, newObject.PartitionKey,newObject.RowKey);

            Assert.IsNotNull(returnObj);
            Assert.AreEqual(newObject.RowKey, returnObj.RowKey);
            Assert.AreEqual(newObject.PartitionKey, returnObj.PartitionKey);
            Assert.AreEqual(newObject.Name, returnObj.Name);
            Assert.AreEqual(newObject.Id, returnObj.Id);
        }

        [Test]
        public async void CreateNewOrReplaceAsync_ShouldReplaceEntitySuccess()
        {
            // create new
            var newObject = new TestObject
            {
                Id = Guid.NewGuid().ToString(),
                Name = "UTTest",
                Expired = DateTime.Now,
                RowKey = Guid.NewGuid().ToString(),
                PartitionKey = PATITION_KEY
            };

            await _tableStorage.CreateNewOrReplaceAsync(newObject, TABLE_NAME);

            // replace
            newObject.Name = "UTTest-Replace";

            await _tableStorage.CreateNewOrReplaceAsync(newObject, TABLE_NAME);

            // get data from storage
            var returnObj = await _tableStorage.ReadAsync(TABLE_NAME, newObject.PartitionKey, newObject.RowKey);

            Assert.IsNotNull(returnObj);
            Assert.AreEqual("UTTest-Replace", returnObj.Name);
        }

        [Test]
        public async void CreateNewOrReplaceAsync_ShouldReplaceEntitiesSuccess()
        {
            // create new
            var newObject = new TestObject
            {
                Id = Guid.NewGuid().ToString(),
                Name = "UTTest",
                Expired = DateTime.Now,
                RowKey = Guid.NewGuid().ToString(),
                PartitionKey = PATITION_KEY
            };

            var newObject2 = new TestObject
            {
                Id = Guid.NewGuid().ToString(),
                Name = "UTTest",
                Expired = DateTime.Now,
                RowKey = Guid.NewGuid().ToString(),
                PartitionKey = PATITION_KEY
            };

            List<TestObject> objList = new List<TestObject>() { newObject, newObject2};

            await _tableStorage.CreateNewOrReplaceAsync(objList.ToArray(), TABLE_NAME);

            // replace
            foreach (var replace in objList)
            {
                replace.Name = "UTTest-Replace-many";
            }

            await _tableStorage.CreateNewOrReplaceAsync(objList.ToArray(), TABLE_NAME);

            // get data from storage
            var returnObj = await _tableStorage.ReadAsync(TABLE_NAME, newObject.PartitionKey, newObject.RowKey);

            Assert.IsNotNull(returnObj);
            Assert.AreEqual("UTTest-Replace-many", returnObj.Name);

            returnObj = await _tableStorage.ReadAsync(TABLE_NAME, newObject2.PartitionKey, newObject2.RowKey);

            Assert.IsNotNull(returnObj);
            Assert.AreEqual("UTTest-Replace-many", returnObj.Name);
        }

        [Test]
        public void ReadAsync_ShouldThrowException()
        {
            Assert.Throws(typeof(ArgumentNullException), async delegate { await _tableStorage.ReadAsync(null,"partitionKey", "rowKey"); });
            Assert.Throws(typeof(ArgumentNullException), async delegate { await _tableStorage.ReadAsync("tabeName", null, "rowKey"); });
            Assert.Throws(typeof(ArgumentNullException), async delegate { await _tableStorage.ReadAsync("tabeName", "partitionKey", null); });
        }

        [Test]
        public void DeleteIfExistsAsync_ShouldThrowException()
        {
            Assert.Throws(typeof(ArgumentNullException), async delegate { await _tableStorage.DeleteIfExistsAsync(null as TestObject, TABLE_NAME); });
            Assert.Throws(typeof(ArgumentNullException), async delegate { await _tableStorage.DeleteIfExistsAsync(oneObject, null); });
        }

        [Test]
        public void SearchAsync_ShouldThrowException()
        {
            Assert.Throws(typeof(ArgumentNullException), async delegate { await _tableStorage.SearchAsync(null); });
            Assert.Throws(typeof(ArgumentNullException), async delegate { await _tableStorage.SearchAsync(new TableSearchOptions { TableName = null}); });
        }

        [Test]
        public async void SearchAsync_ShouldReturnResults()
        {
            List<TestObject> objList = new List<TestObject>();
            for (int i = 0; i < 30; i++)
            {
                var newObject = new TestObject
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "UTTest-" + i,
                    Expired = DateTime.Now,
                    RowKey = "UT-RowKey-" + Guid.NewGuid().ToString(),
                    PartitionKey = PATITION_KEY
                };
                objList.Add(newObject);
            }
  
            await _tableStorage.CreateNewOrReplaceAsync(objList.ToArray(), TABLE_NAME);

            TableSearchOptions searchOptions = new TableSearchOptions{
                TableName = TABLE_NAME,
                Filter = TableQueryCondition.CombineFilters(TableQueryCondition.GenerateFilterCondition(TableQueryCondition.ROW_KEY, Accela.Infrastructure.Tables.QueryComparisons.GreaterThanOrEqual,"UT-RowKey-"),
                Accela.Infrastructure.Tables.TableOperators.And,
                TableQueryCondition.GenerateFilterCondition(TableQueryCondition.PARTITION_KEY, Accela.Infrastructure.Tables.QueryComparisons.Equal, "UTPartitionKey")),
                MaxResults = 5
            };

            PagedResults<TestObject> pageResults = await _tableStorage.SearchAsync(searchOptions);

            Assert.IsNotNull(pageResults);
            Assert.IsNotNull(pageResults.Results);
            Assert.AreEqual(searchOptions.MaxResults, pageResults.Results.Count());

            foreach(var obj in pageResults.Results)
            {
                Assert.IsTrue(obj.RowKey.StartsWith("UT-RowKey-"));
            }

            // get the 2nd page data
            if (!String.IsNullOrEmpty(pageResults.ContinuationToken))
            {
                searchOptions.ContinuationToken = pageResults.ContinuationToken;
                pageResults = await _tableStorage.SearchAsync(searchOptions);

                Assert.IsNotNull(pageResults);
                Assert.IsNotNull(pageResults.Results);
                Assert.AreEqual(searchOptions.MaxResults, pageResults.Results.Count());

                foreach (var obj in pageResults.Results)
                {
                    Assert.IsTrue(obj.RowKey.StartsWith("UT-RowKey-"));
                }
            }

        }


        [Test]
        public void CreateNewOrReplaceAsync_ShouldCreateEntitySuccess_InSyncCall()
        {
            // create new
            var newObject = new TestObject
            {
                Id = Guid.NewGuid().ToString(),
                Name = "UTTest",
                Expired = DateTime.Now,
                RowKey = Guid.NewGuid().ToString(),
                PartitionKey = PATITION_KEY
            };

            _tableStorage.CreateNewOrReplace(newObject, TABLE_NAME);

            // check the data if exists in storage
            var returnObj = _tableStorage.Read(TABLE_NAME, newObject.PartitionKey, newObject.RowKey);

            Assert.IsNotNull(returnObj);
            Assert.AreEqual(newObject.RowKey, returnObj.RowKey);
            Assert.AreEqual(newObject.PartitionKey, returnObj.PartitionKey);
            Assert.AreEqual(newObject.Name, returnObj.Name);
            Assert.AreEqual(newObject.Id, returnObj.Id);
        }

        [Test]
        public void CreateNewOrReplaceAsync_ShouldReplaceEntitySuccess_InSyncCall()
        {
            // create new
            var newObject = new TestObject
            {
                Id = Guid.NewGuid().ToString(),
                Name = "UTTest",
                Expired = DateTime.Now,
                RowKey = Guid.NewGuid().ToString(),
                PartitionKey = PATITION_KEY
            };

            _tableStorage.CreateNewOrReplace(newObject, TABLE_NAME);

            // replace
            newObject.Name = "UTTest-Replace";

            _tableStorage.CreateNewOrReplace(newObject, TABLE_NAME);

            // get data from storage
            var returnObj = _tableStorage.Read(TABLE_NAME, newObject.PartitionKey, newObject.RowKey);

            Assert.IsNotNull(returnObj);
            Assert.AreEqual("UTTest-Replace", returnObj.Name);
        }

        [Test]
        public void CreateNewOrReplaceAsync_ShouldReplaceEntitiesSuccess_InSyncCall()
        {
            // create new
            var newObject = new TestObject
            {
                Id = Guid.NewGuid().ToString(),
                Name = "UTTest",
                Expired = DateTime.Now,
                RowKey = Guid.NewGuid().ToString(),
                PartitionKey = PATITION_KEY
            };

            var newObject2 = new TestObject
            {
                Id = Guid.NewGuid().ToString(),
                Name = "UTTest",
                Expired = DateTime.Now,
                RowKey = Guid.NewGuid().ToString(),
                PartitionKey = PATITION_KEY
            };

            List<TestObject> objList = new List<TestObject>() { newObject, newObject2 };

            _tableStorage.CreateNewOrReplace(objList.ToArray(), TABLE_NAME);

            // replace
            foreach (var replace in objList)
            {
                replace.Name = "UTTest-Replace-many";
            }

            _tableStorage.CreateNewOrReplace(objList.ToArray(), TABLE_NAME);

            // get data from storage
            var returnObj = _tableStorage.Read(TABLE_NAME, newObject.PartitionKey, newObject.RowKey);

            Assert.IsNotNull(returnObj);
            Assert.AreEqual("UTTest-Replace-many", returnObj.Name);

            returnObj = _tableStorage.Read(TABLE_NAME, newObject2.PartitionKey, newObject2.RowKey);

            Assert.IsNotNull(returnObj);
            Assert.AreEqual("UTTest-Replace-many", returnObj.Name);
        }

        [Test]
        public void SearchAsync_ShouldReturnResults_InSyncCall()
        {
            List<TestObject> objList = new List<TestObject>();
            for (int i = 0; i < 30; i++)
            {
                var newObject = new TestObject
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "UTTest-" + i,
                    Expired = DateTime.Now,
                    RowKey = "UT-RowKey-" + Guid.NewGuid().ToString(),
                    PartitionKey = PATITION_KEY
                };
                objList.Add(newObject);
            }

            _tableStorage.CreateNewOrReplaceAsync(objList.ToArray(), TABLE_NAME).Wait();

            TableSearchOptions searchOptions = new TableSearchOptions
            {
                TableName = TABLE_NAME,
                Filter = TableQueryCondition.CombineFilters(TableQueryCondition.GenerateFilterCondition(TableQueryCondition.ROW_KEY, Accela.Infrastructure.Tables.QueryComparisons.GreaterThanOrEqual, "UT-RowKey-"),
                Accela.Infrastructure.Tables.TableOperators.And,
                TableQueryCondition.GenerateFilterCondition(TableQueryCondition.PARTITION_KEY, Accela.Infrastructure.Tables.QueryComparisons.Equal, "UTPartitionKey")),
                MaxResults = 5
            };

            PagedResults<TestObject> pageResults = _tableStorage.Search(searchOptions);

            Assert.IsNotNull(pageResults);
            Assert.IsNotNull(pageResults.Results);
            Assert.AreEqual(searchOptions.MaxResults, pageResults.Results.Count());

            foreach (var obj in pageResults.Results)
            {
                Assert.IsTrue(obj.RowKey.StartsWith("UT-RowKey-"));
            }

            // get the 2nd page data
            if (!String.IsNullOrEmpty(pageResults.ContinuationToken))
            {
                searchOptions.ContinuationToken = pageResults.ContinuationToken;
                pageResults =  _tableStorage.SearchAsync(searchOptions).Result;

                Assert.IsNotNull(pageResults);
                Assert.IsNotNull(pageResults.Results);
                Assert.AreEqual(searchOptions.MaxResults, pageResults.Results.Count());

                foreach (var obj in pageResults.Results)
                {
                    Assert.IsTrue(obj.RowKey.StartsWith("UT-RowKey-"));
                }
            }

        }

    }

    public class TestObject : Accela.Infrastructure.Tables.ITableEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Expired { get; set; }

        public string RowKey { get; set; }
        public string PartitionKey { get; set; }

        public DateTimeOffset Timestamp { get; set; }
    }

    public class StorageConnectionStringSetting : IConnectionStringSetting
    {

        public string Get()
        {
            return  "UseDevelopmentStorage=true;";
        }


        public string Get(string key)
        {
            throw new NotImplementedException();
        }
    }
}
