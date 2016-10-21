
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accela.Infrastructure.Azure;
using Accela.Infrastructure.Azure.Storage;
using Microsoft.WindowsAzure.Storage;
using System.IO;
using Accela.Infrastructure.Exceptions;
using Accela.Infrastructure.Storage;
using System.Threading;

namespace Accela.Infrastructure.Azure.Test
{
    [TestFixture]
    public class BinaryStorageExtensionTest : BaseAzureTest
    {
        private const string UT_TEST_Container = "utcontainer";
        private const string UT_TEST_BlobNamePrefix = "uttests/blob_";
        [SetUp]
        public void Init()
        {


        }

        [TearDown]
        public void Dispose()
        {
            var c = base.StorageAccount.CreateCloudBlobClient();
            var container = c.GetContainerReference(UT_TEST_Container);
            container.DeleteIfExists();
        }

        [Test]
        public void TestBinaryStorageExtension_CreateNew()
        {
            var azureStorage = new AzureBinaryStorage(new StorageConnectionStringSetting(), null);
            string blobName = UT_TEST_BlobNamePrefix + Guid.NewGuid().ToString();

            // Case 1. Create a new blob file
            string content = "This is test for CreateNewAsync() - Create Blob.";
            Stream streamContent = new MemoryStream(Encoding.UTF8.GetBytes(content));
            azureStorage.CreateNew(UT_TEST_Container, blobName, streamContent);

            bool exist = azureStorage.Exists(UT_TEST_Container, blobName);

            Assert.IsTrue(exist);

            // Case 2. create a existing blob file will throw exception
            Assert.Throws(typeof(ArgumentException), delegate
            {
                content = "This is test for CreateNewAsync() - Throw exception if the blob exists.";
                streamContent = new MemoryStream(Encoding.UTF8.GetBytes(content));
                azureStorage.CreateNew(UT_TEST_Container, blobName, streamContent);
            });

            // clear data
            azureStorage.DeleteIfExists(UT_TEST_Container, blobName);
        }

        [Test]
        public void TestBinaryStorageExtension_CreateNewOrUpdate()
        {
            var azureStorage = new AzureBinaryStorage(new StorageConnectionStringSetting(), null);
            string blobName = UT_TEST_BlobNamePrefix + Guid.NewGuid().ToString();

            // 1. Create a new blob file
            string content = "This is test for CreateNewOrUpdateAsync() - Create Blob.";
            Stream streamContent = new MemoryStream(Encoding.UTF8.GetBytes(content));
            azureStorage.CreateNewOrUpdate(UT_TEST_Container, blobName, streamContent);

            // 2. Update a existing blob file 
            content = "This is test for CreateNewOrUpdateAsync() - Update Blob.";
            streamContent = new MemoryStream(Encoding.UTF8.GetBytes(content));
            azureStorage.CreateNewOrUpdate(UT_TEST_Container, blobName, streamContent);


            // 3. read data to compare whether the data is same as created
            var result = azureStorage.ReadAsString(UT_TEST_Container, blobName);

            Assert.AreEqual(content, result);
            // clear data
            azureStorage.DeleteIfExists(UT_TEST_Container, blobName);
        }

        [Test]
        public void TestBinaryStorageExtension_Read()
        {
            var azureStorage = new AzureBinaryStorage(new StorageConnectionStringSetting(), null);
            string blobName = UT_TEST_BlobNamePrefix + Guid.NewGuid().ToString();

            // 1. Create a new blob file
            string content = "This is test for TestAzureBinaryStorage_ReadAsync().";
            Stream streamContent = new MemoryStream(Encoding.UTF8.GetBytes(content));
            azureStorage.CreateNewOrUpdate(UT_TEST_Container, blobName, streamContent);

            // 2. read Stream data to compare whether the data is same as created
            var result = azureStorage.ReadAsStream(UT_TEST_Container, blobName);

            string result2 = null;
            using (StreamReader reader = new StreamReader(result))
            {
                result2 = reader.ReadToEnd();
            }
            Assert.AreEqual(content, result2);

            // 4. use read text async
            result2 = azureStorage.ReadAsString(UT_TEST_Container, blobName);
            Assert.AreEqual(content, result2);

            // clear data
            azureStorage.DeleteIfExists(UT_TEST_Container, blobName);
        }

        [Test]
        public void TestBinaryStorageExtension_Exists()
        {
            var azureStorage = new AzureBinaryStorage(new StorageConnectionStringSetting(), null);

            // case 1: the blob doesn't exist, SHOULD return false
            string blobName = UT_TEST_BlobNamePrefix + Guid.NewGuid().ToString();
            bool exist = azureStorage.Exists(UT_TEST_Container, blobName);
            Assert.IsFalse(exist);

            //  Create a new blob file for Exists check
            string content = "ExistsAsync";
            Stream streamContent = new MemoryStream(Encoding.UTF8.GetBytes(content));
            azureStorage.CreateNewOrUpdate(UT_TEST_Container, blobName, streamContent);

            // case 2: the blob exists, SHOULD return true
            exist = azureStorage.Exists(UT_TEST_Container, blobName);
            Assert.IsTrue(exist);

            // clear data
            azureStorage.DeleteIfExists(UT_TEST_Container, blobName);
        }

        [Test]
        public void TestBinaryStorageExtension_Delete()
        {
            var azureStorage = new AzureBinaryStorage(new StorageConnectionStringSetting(), null);
            string blobName = UT_TEST_BlobNamePrefix + Guid.NewGuid().ToString();

            // case 1 : delete a non-existing blob, should return false
            bool deleted = azureStorage.DeleteIfExists(UT_TEST_Container, blobName);
            Assert.IsFalse(deleted);

            // prepare data for delete
            //  Create a new blob file for Exists check
            string content = "DeleteIfExistsAsync()";
            Stream streamContent = new MemoryStream(Encoding.UTF8.GetBytes(content));
            azureStorage.CreateNewOrUpdate(UT_TEST_Container, blobName, streamContent);

            // case 2: if the blob exists, SHOULD return true
            deleted = azureStorage.DeleteIfExists(UT_TEST_Container, blobName);
            Assert.IsTrue(deleted);
        }

        [Test]
        public void TestBinaryStorageExtension_FetchBlobProperties()
        {
            var azureStorage = new AzureBinaryStorage(new StorageConnectionStringSetting(), null);
            string blobName = UT_TEST_BlobNamePrefix + Guid.NewGuid().ToString();

            // case 1 : Fetch a non-existing blob properties
            Assert.Throws(typeof(ArgumentException), async delegate
            {
                var blobInfo = azureStorage.ReadAttributes(UT_TEST_Container, blobName);
            });

            // prepare data for delete
            //  Create a new blob file for FetchBlob properties
            string content = "FetchAttributesAsync()";
            Stream streamContent = new MemoryStream(Encoding.UTF8.GetBytes(content));
            azureStorage.CreateNewOrUpdate(UT_TEST_Container, blobName, streamContent);

            // case 2: Fetch a existing blob properties
            var b = azureStorage.ReadAttributes(UT_TEST_Container, blobName);

            Assert.AreEqual(content.Length, b.Length);
            Assert.AreEqual(blobName, b.BlobName);
            Assert.AreEqual(DateTime.UtcNow.Date, b.LastModified.Value.Date);
            Assert.AreEqual(UT_TEST_Container, b.ContainerName);
            Assert.AreEqual("application/octet-stream", b.ContentType);
            // clear data
            azureStorage.DeleteIfExists(UT_TEST_Container, blobName);
        }

        [Test]
        public void TestBinaryStorageExtension_Search()
        {
            var azureStorage = new AzureBinaryStorage(new StorageConnectionStringSetting(), new CustomRetryPolicyConfiguration() { RetryMethod = RetryMethod.Linear, DeltaBackoff = TimeSpan.FromMilliseconds(500), MaxAttempts = 3 });

            // Case 1: Exception
            Assert.Throws(typeof(ArgumentNullException), async delegate
            {
                var blobInfo = azureStorage.Search(UT_TEST_Container, null);
            });


            string blobPrefix = UT_TEST_BlobNamePrefix + "SearchAsync_";
            // perpare data for search
            int blobCount = 25;
            for (int i = 0; i < blobCount; i++)
            {
                string blobName = blobPrefix + i.ToString() + "-" + Guid.NewGuid().ToString();
                var content = "This is test for SearchAsync() - test data " + i.ToString();
                var streamContent = new MemoryStream(Encoding.UTF8.GetBytes(content));
                azureStorage.CreateNewOrUpdate(UT_TEST_Container, blobName, streamContent);
            }

            // Get the first page data
            BlobSearchOptions searchOption = new BlobSearchOptions
            {
                ContinuationToken = null,
                NamePrefix = blobPrefix,
                MaxResults = 10
            };

            // Case 2: Get the first page data

            var theFirstPageResult = azureStorage.Search(UT_TEST_Container, searchOption);
            var returnResults = theFirstPageResult.Results.ToList();

            // assert return count
            Assert.AreEqual(10, returnResults.Count);

            // assert name
            foreach (var item in returnResults)
            {
                Assert.IsTrue(item.BlobName.StartsWith(blobPrefix));
                Assert.AreEqual(item.ContainerName, UT_TEST_Container);
                Assert.AreEqual(item.ContentType, "application/octet-stream");
            }

            // case 3: get second page data

            searchOption.ContinuationToken = theFirstPageResult.ContinuationToken;
            var theSecondtPageResult = azureStorage.Search(UT_TEST_Container, searchOption);
            returnResults = theSecondtPageResult.Results.ToList();

            // assert return count
            Assert.AreEqual(10, returnResults.Count);

            // assert name
            foreach (var item in returnResults)
            {
                Assert.IsTrue(item.BlobName.StartsWith(blobPrefix));
            }

            // case 4 : get last page data
            searchOption.ContinuationToken = theSecondtPageResult.ContinuationToken;
            var theThirdPageResult = azureStorage.Search(UT_TEST_Container, searchOption);
            returnResults = theThirdPageResult.Results.ToList();

            // assert return count
            Assert.AreEqual(5, returnResults.Count);
            Assert.IsNull(theThirdPageResult.ContinuationToken);
            // assert name
            foreach (var item in returnResults)
            {
                Assert.IsTrue(item.BlobName.StartsWith(blobPrefix));
            }

            // case 5 : No matched data 
            searchOption = new BlobSearchOptions { NamePrefix = "NoMatchedData" };
            var noMatchedData = azureStorage.Search(UT_TEST_Container, searchOption);
            int countZero = noMatchedData.Results.ToList().Count;
            Assert.AreEqual(countZero, 0);
        }
    }
}
