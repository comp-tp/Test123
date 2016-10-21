
using Accela.Infrastructure.Azure;
using Accela.Infrastructure.Azure.DocumentDB;
using Accela.Infrastructure.DocumentDB;
using Accela.Infrastructure.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Accela.Infrastructure.Azure.Test
{
    [TestFixture]
    public class AzureDocumentDBTests : BaseAzureTest
    {
        private static string TEST_CONNECTION_STRING = "AccountEndpoint=https://admdocumentdb.documents.azure.com:443/;AccountKey=uMKEXr4kMAt8PLUFTFp7vlvSTciDjFX5S2TSl94Irv49ECHXDqBRvuL/etwq6zBdpG9HZIWs/S1CsSRk77Vmkw==;Database=UT";
        private static string INVALID_CONNECTION_STRING = "Account=https://admdocumentdb.documents.azure.com:443/;AccountKey=uMKEXr4kMAt8PLUFTFp7vlvSTciDjFX5S2TSl94Irv49ECHXDqBRvuL/etwq6zBdpG9HZIWs/S1CsSRk77Vmkw==;Database=UT";
        private static string INVALID_ACCOUNT_CONNECTION_STRING = "AccountEndpoint=https://aaaaa.documents.azure.com:443/;AccountKey=uMKEXr4kMAt8PLUFTFp7vlvSTciDjFX5S2TSl94Irv49ECHXDqBRvuL/etwq6zBdpG9HZIWs/S1CsSRk77Vmkw==;Database=UT";
        private static string INVALID_DB_CONNECTION_STRING = "AccountEndpoint=https://admdocumentdb.documents.azure.com:443/;AccountKey=uMKEXr4kMAt8PLUFTFp7vlvSTciDjFX5S2TSl94Irv49ECHXDqBRvuL/etwq6zBdpG9HZIWs/S1CsSRk77Vmkw==;Database=UT999";

        AzureDocumentDB<TestDocument> _DocumentDB;

        private const string NONEXIST_COLLECTION_NAME = "UT999";
        private const string TEST_COLLECTION_NAME = "UTCollection";
        TestDocument oneObject = null;
        List<TestDocument> manyObjects = new List<TestDocument>();

        [SetUp]
        public void Init()
        {
            _DocumentDB = new AzureDocumentDB<TestDocument>();
            _DocumentDB.Init(TEST_CONNECTION_STRING, null);

            if (!_DocumentDB.CollectionExists(TEST_COLLECTION_NAME))
            {
                var result = _DocumentDB.CreateCollectionAsync(TEST_COLLECTION_NAME).Result;
                Assert.AreEqual(true, result);
            }

            oneObject = new TestDocument
            {
                Key = Guid.NewGuid(),
                Name = "UTTest",
                Date = DateTime.Now
            };
        }

        [TearDown]
        public void Dispose()
        {
        }

        [Test]
        public void AzureDocumentDB_Construct()
        {
            AzureDocumentDB<TestDocument> db = new AzureDocumentDB<TestDocument>();

            Assert.Throws(typeof(ArgumentNullException), delegate { db.Init(null, null); });

            Assert.Throws(typeof(ArgumentException), delegate
            {
                db.Init(
                    INVALID_CONNECTION_STRING, null);
            });

            Assert.Throws(typeof(ArgumentException), delegate
            {
                db.Init(
                    INVALID_ACCOUNT_CONNECTION_STRING, null);
            });

            Assert.Throws(typeof(ArgumentException), delegate
            {
                db.Init(INVALID_DB_CONNECTION_STRING, null);
            });

            // case 5. init thru diffrent Retry policy.
            db.Init(TEST_CONNECTION_STRING, new NoRetryPolicyConfiguration() { });
            // should come here after init success

            db.Init(TEST_CONNECTION_STRING, 
                new CustomRetryPolicyConfiguration() { RetryMethod = RetryMethod.Exponential, DeltaBackoff = TimeSpan.FromMilliseconds(200), MaxAttempts = 3 });

            // TODO: test retry policy
            /*
            db = new AzureDocumentDB<TestDocument>(), new CustomRetryPolicyConfiguration() { RetryMethod = RetryMethod.Linear, DeltaBackoff = TimeSpan.FromMilliseconds(500), MaxAttempts = 3 });
            Assert.Throws(typeof(NotSupportedException), delegate
            {
                new AzureDocumentDB<TestDocument>(), new CustomRetryPolicyConfiguration()
                    {
                        RetryMethod = RetryMethod.Discrete,
                        RetrySpans = new List<TimeSpan>{ 
                                    TimeSpan.FromMilliseconds(100), 
                                    TimeSpan.FromMilliseconds(200),
                                    TimeSpan.FromMilliseconds(500),
                                    TimeSpan.FromMilliseconds(500)
                        }
                    });
            });*/
        }

        [Test]
        public void Create_ShouldThrowException()
        {
            Assert.Throws(typeof(ArgumentNullException), async delegate { await _DocumentDB.CreateAsync(null as TestDocument, string.Empty); });
            Assert.Throws(typeof(ArgumentNullException), async delegate { await _DocumentDB.CreateAsync(null as TestDocument, TEST_COLLECTION_NAME); });
            Assert.Throws(typeof(ArgumentNullException), async delegate { await _DocumentDB.CreateAsync(oneObject, null); });
            Assert.Throws(typeof(ArgumentNullException), async delegate { await _DocumentDB.CreateAsync(oneObject, NONEXIST_COLLECTION_NAME); });
        }

        [Test]
        public async void Create_ShouldCreateEntitySuccess()
        {
            // create new
            var newObject = new TestDocument
            {
                Key = Guid.NewGuid(),
                Name = "UTTest",
                Date = DateTime.Now
            };

            var docId = await _DocumentDB.CreateAsync(newObject, TEST_COLLECTION_NAME);

            // check the data if exists in db
            var returnObj = await _DocumentDB.ReadAsync(docId, TEST_COLLECTION_NAME);

            Assert.IsNotNull(returnObj);
            Assert.AreEqual(newObject.Name, returnObj.Name);
            Assert.AreEqual(newObject.Key, returnObj.Key);
        }

        [Test]
        public async void Create_ShouldCreateEntitiesSuccess()
        {
            // create new
            var newObject = new TestDocument
            {
                Key = Guid.NewGuid(),
                Name = "UTTest",
                Date = DateTime.Now
            };

            var newObject2 = new TestDocument
            {
                Key = Guid.NewGuid(),
                Name = "UTTest",
                Date = DateTime.Now
            };

            List<TestDocument> objList = new List<TestDocument>() { newObject, newObject2 };

            var docIds = await _DocumentDB.CreateAsync(objList.ToArray(), TEST_COLLECTION_NAME);
            // TODO: validate result

            Assert.IsNotNull(docIds);
            Assert.IsNotNull(docIds.Length == 2);
        }

        [Test]
        public async void Update_ShouldReplaceEntitySuccess()
        {
            // create new
            var newObject = new TestDocument
            {
                Key = Guid.NewGuid(),
                Name = "UTTest",
                Date = DateTime.Now
            };

            var docId = await _DocumentDB.CreateAsync(newObject, TEST_COLLECTION_NAME);

            // replace
            newObject.Name = "UTTest-Replace";
            newObject.id = docId;

            await _DocumentDB.UpdateAsync(docId, TEST_COLLECTION_NAME, newObject);

            // get data from db
            var returnObj = await _DocumentDB.ReadAsync(docId, TEST_COLLECTION_NAME);

            Assert.IsNotNull(returnObj);
            Assert.AreEqual("UTTest-Replace", returnObj.Name);
        }

        [Test]
        public async void Delete_ShouldDeleteEntitySuccess()
        {
            // create new
            var newObject = new TestDocument
            {
                Key = Guid.NewGuid(),
                Name = "UTTest",
                Date = DateTime.Now
            };

            var docId = await _DocumentDB.CreateAsync(newObject, TEST_COLLECTION_NAME);

            var result = await _DocumentDB.DeleteAsync(docId, TEST_COLLECTION_NAME);
            Assert.IsTrue(result);

            // get data from db
            var returnObj = await _DocumentDB.ReadAsync(docId, TEST_COLLECTION_NAME);

            Assert.IsNull(returnObj);
        }

        [Test]
        public void Read_ShouldThrowException()
        {
            Assert.Throws(typeof(ArgumentNullException), async delegate { await _DocumentDB.ReadAsync(null, null); });
            //Assert.Throws(typeof(ArgumentNullException), async delegate { await _DocumentDB.Read("non-exist-id"); });
        }

        [Test]
        public void Delete_ShouldThrowException()
        {
            Assert.Throws(typeof(ArgumentNullException), async delegate { await _DocumentDB.DeleteAsync(null, null); });
            //Assert.Throws(typeof(ArgumentNullException), async delegate { await _DocumentDB.Delete("non-exist-id"); });
        }

        [Test]
        public void Search_ShouldThrowException()
        {
            Assert.Throws(typeof(ArgumentNullException), async delegate { await _DocumentDB.SearchAsync(null); });
            Assert.Throws(typeof(ArgumentNullException), async delegate { await _DocumentDB.SearchAsync(new DocumentSearchOptions { Collection = null }); });
        }

        [Test]
        public async void Search_ShouldReturnResults()
        {
            List<TestDocument> objList = new List<TestDocument>();
            for (int i = 1; i <= 10; i++)
            {
                var newObject = new TestDocument
                {
                    Key = Guid.NewGuid(),
                    Name = "UTTest",
                    Index = i,
                    Date = DateTime.Now
                };
                objList.Add(newObject);
            }

            await _DocumentDB.CreateAsync(objList.ToArray(), TEST_COLLECTION_NAME);

            // DocumentDB needs range index in order to perform query WHERE STARTSWITH(c.Name, 'UTTest - ')
            DocumentSearchOptions searchOptions = new DocumentSearchOptions
            {
                Collection = TEST_COLLECTION_NAME,
                Filter = "SELECT * FROM c WHERE c.Name='UTTest' AND c.Index>0",
                MaxResults = 5
            };

            PagedResults<TestDocument> pageResults = await _DocumentDB.SearchAsync(searchOptions);

            Assert.IsNotNull(pageResults);
            Assert.IsNotNull(pageResults.Results);
            Assert.AreEqual(searchOptions.MaxResults, pageResults.Results.Count());

            // get the 2nd page data
            if (!String.IsNullOrEmpty(pageResults.ContinuationToken))
            {
                searchOptions.ContinuationToken = pageResults.ContinuationToken;
                pageResults = await _DocumentDB.SearchAsync(searchOptions);

                Assert.IsNotNull(pageResults);
                Assert.IsNotNull(pageResults.Results);
                Assert.AreEqual(searchOptions.MaxResults, pageResults.Results.Count());

            }

        }

    }

    public class TestDocument
    {
        public string id { get; set; }    // TODO: NOTE: Azure DocumentDB has "id" (lower case and have confliction seems)
        public Guid Key { get; set; }
        public string Name { get; set; }
        public int Index { get; set; }
        public DateTime Date { get; set; }
    }

    public class DocumentDBConnectionStringSetting : IConnectionStringSetting
    {
        private string connectionString = null;

        public DocumentDBConnectionStringSetting(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string Get()
        {
            return connectionString;
        }


        public string Get(string key)
        {
            throw new NotImplementedException();
        }
    }
}