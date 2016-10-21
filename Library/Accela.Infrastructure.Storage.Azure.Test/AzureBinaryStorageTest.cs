
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
using System.Reflection;

namespace Accela.Infrastructure.Azure.Test
{
    [TestFixture]
    public class AzureBinaryStorageTest : BaseAzureTest
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
        public void TestAzureBinaryStorage_Construct()
        {
            //// Case 1. container name is requied
            //Assert.Throws(typeof(ArgumentNullException), delegate { new AzureBinaryStorage(null, null, null); });

            // Case 2. connection string is required
            Assert.Throws(typeof(ArgumentNullException), delegate { new AzureBinaryStorage(null, null); });

            //// Case 3. Container name is invalid
            //Assert.Throws(typeof(ArgumentException), delegate { new AzureBinaryStorage(StorageConnectionString, null); });

            // Case 4. valid parameters
            var storage = new AzureBinaryStorage(new StorageConnectionStringSetting(), null);

            // case 5. init thru diffrent Retry policy.
            storage = new AzureBinaryStorage(new StorageConnectionStringSetting(), new NoRetryPolicyConfiguration() { });

            storage = new AzureBinaryStorage(new StorageConnectionStringSetting(), new CustomRetryPolicyConfiguration() { RetryMethod = RetryMethod.Exponential, DeltaBackoff = TimeSpan.FromMilliseconds(200), MaxAttempts = 3 });

            storage = new AzureBinaryStorage(new StorageConnectionStringSetting(), new CustomRetryPolicyConfiguration() { RetryMethod = RetryMethod.Linear, DeltaBackoff = TimeSpan.FromMilliseconds(500), MaxAttempts = 3 });
        }

        [Test]
        public async void TestAzureBinaryStorage_CreateNewAsync()
        {
            var azureStorage = new AzureBinaryStorage(new StorageConnectionStringSetting(), null);
            string blobName = UT_TEST_BlobNamePrefix + Guid.NewGuid().ToString();

            // Case 1. Create a new blob file
            string content = "This is test for CreateNewAsync() - Create Blob.";
            Stream streamContent = new MemoryStream(Encoding.UTF8.GetBytes(content));
            await azureStorage.CreateNewAsync(UT_TEST_Container, blobName, streamContent);

            bool exist = await azureStorage.ExistsAsync(UT_TEST_Container, blobName);

            Assert.IsTrue(exist);

            // Case 2. create a existing blob file will throw exception
            Assert.Throws(typeof(ArgumentException), async delegate
            {
                content = "This is test for CreateNewAsync() - Throw exception if the blob exists.";
                streamContent = new MemoryStream(Encoding.UTF8.GetBytes(content));
                await azureStorage.CreateNewAsync(UT_TEST_Container, blobName, streamContent);
            });

            // clear data
            await azureStorage.DeleteIfExistsAsync(UT_TEST_Container, blobName);
        }

        [Test]
        public async void TestAzureBinaryStorage_CreateNewOrUpdateAsync()
        {
            var azureStorage = new AzureBinaryStorage(new StorageConnectionStringSetting(), null);
            string blobName = UT_TEST_BlobNamePrefix + Guid.NewGuid().ToString();

            // 1. Create a new blob file
            string content = "This is test for CreateNewOrUpdateAsync() - Create Blob.";
            Stream streamContent = new MemoryStream(Encoding.UTF8.GetBytes(content));
            await azureStorage.CreateNewOrUpdateAsync(UT_TEST_Container, blobName, streamContent);

            // 2. Update a existing blob file 
            content = "This is test for CreateNewOrUpdateAsync() - Update Blob.";
            streamContent = new MemoryStream(Encoding.UTF8.GetBytes(content));
            await azureStorage.CreateNewOrUpdateAsync(UT_TEST_Container, blobName, streamContent);

            // 3. read data to compare whether the data is same as created
            var result = await azureStorage.ReadAsStringAsync(UT_TEST_Container, blobName);

            Assert.AreEqual(content, result);

            // 4. Create a new blob file that size is greater than 4M - for block test
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Accela.Infrastructure.Azure.Test.TestData.4.4M-File.exe.test";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                await azureStorage.CreateNewOrUpdateAsync(UT_TEST_Container, blobName, stream);
            }

            // clear data
            await azureStorage.DeleteIfExistsAsync(UT_TEST_Container, blobName);
        }

        [Test]
        public async void TestAzureBinaryStorage_ReadAsync()
        {
            var azureStorage = new AzureBinaryStorage(new StorageConnectionStringSetting(), null);
            string blobName = UT_TEST_BlobNamePrefix + Guid.NewGuid().ToString();

            // 1. Create a new blob file
            string content = "This is test for TestAzureBinaryStorage_ReadAsync().";
            Stream streamContent = new MemoryStream(Encoding.UTF8.GetBytes(content));
            await azureStorage.CreateNewOrUpdateAsync(UT_TEST_Container, blobName, streamContent);

            // 2. read Stream data to compare whether the data is same as created
            var result = await azureStorage.ReadAsStreamAsync(UT_TEST_Container, blobName);

            string result2 = null;
            using (StreamReader reader = new StreamReader(result))
            {
                result2 = reader.ReadToEnd();
            }
            Assert.AreEqual(content, result2);

            // 4. use read text async
            result2 = await azureStorage.ReadAsStringAsync(UT_TEST_Container, blobName);
            Assert.AreEqual(content, result2);

            result2 = await azureStorage.ReadAsStringAsync(UT_TEST_Container, blobName);
            Assert.AreEqual(content, result2);
            // clear data
            await azureStorage.DeleteIfExistsAsync(UT_TEST_Container, blobName);
        }

        [Test]
        public void TestAzureBinaryStorage_ReadAsyncInSyncMethod()
        {
            var azureStorage = new AzureBinaryStorage(new StorageConnectionStringSetting(), null);
            string blobName = UT_TEST_BlobNamePrefix + Guid.NewGuid().ToString();

            // 1. Create a new blob file
            string content = "This is test for TestAzureBinaryStorage_ReadAsync().";
            Stream streamContent = new MemoryStream(Encoding.UTF8.GetBytes(content));

            var t = Task.Run(async() => await azureStorage.CreateNewOrUpdateAsync(UT_TEST_Container, blobName, streamContent));
            t.Wait();

            Assert.AreEqual(TaskStatus.RanToCompletion, t.Status);

            // 2. read Stream data to compare whether the data is same as created
            //var result = azureStorage.ReadAsStreamAsync(UT_TEST_Container, blobName);

            string result2 = null;

            t = Task.Run(async () =>
            {
                var result = await azureStorage.ReadAsStreamAsync(UT_TEST_Container, blobName); ;
                using (StreamReader reader = new StreamReader(result))
                {
                    result2 = reader.ReadToEnd();
                }
            });
            t.Wait();



            Assert.AreEqual(content, result2);

            // 4. use read text async
            result2 = azureStorage.ReadAsStringAsync(UT_TEST_Container, blobName).Result;
            Assert.AreEqual(content, result2);
            // clear data
            //azureStorage.DeleteIfExistsAsync(UT_TEST_Container, blobName);
        }

        [Test]
        public void TestAzureBinaryStorage_ReadSync()
        {
            var azureStorage = new AzureBinaryStorage(new StorageConnectionStringSetting(), null);
            string blobName = UT_TEST_BlobNamePrefix + Guid.NewGuid().ToString();

            // 1. Create a new blob file
            string content = "This is test for TestAzureBinaryStorage_ReadAsync().";
            Stream streamContent = new MemoryStream(Encoding.UTF8.GetBytes(content));
            azureStorage.CreateNewOrUpdateAsync(UT_TEST_Container, blobName, streamContent).Wait();

            // 2. read Stream data to compare whether the data is same as created
            var result = azureStorage.ReadAsStreamAsync(UT_TEST_Container, blobName).Result;

            string result2 = null;
            using (StreamReader reader = new StreamReader(result))
            {
                result2 = reader.ReadToEnd();
            }
            Assert.AreEqual(content, result2);

            // 4. use read text async
            result2 = azureStorage.ReadAsStringAsync(UT_TEST_Container, blobName).Result;

            Assert.AreEqual(content, result2);
            // clear data
            azureStorage.DeleteIfExistsAsync(UT_TEST_Container, blobName).Wait();
        }


        [Test]
        public void TestAzureBinaryStorage_ReadSyncInNewThread()
        {
            //var task = Task.Factory.StartNew( () =>
            // {
                 try
                 {
                     var azureStorage = new AzureBinaryStorage(new StorageConnectionStringSetting(), null);
                     string blobName = UT_TEST_BlobNamePrefix + Guid.NewGuid().ToString();

                     // 1. Create a new blob file
                     string content = "This is test for TestAzureBinaryStorage_ReadAsync().";

                     using (var streamContent = new MemoryStream(Encoding.UTF8.GetBytes(content)))
                     {
                         azureStorage.CreateNewOrUpdateAsync(UT_TEST_Container, blobName, streamContent).ContinueWith((t) =>
                         {
                             // 2. read Stream data to compare whether the data is same as created
                             azureStorage.ReadAsStreamAsync(UT_TEST_Container, blobName).ContinueWith((tResult) =>
                             {
                                 //Task.WhenAll(t1, result).ContinueWith(  );
                                 string result2 = null;
                                 using (StreamReader reader = new StreamReader(tResult.Result))
                                 {
                                     result2 = reader.ReadToEnd();
                                 }
                                 Assert.AreEqual(content, result2);
                             }).Wait();
                         });
                     }

                     //// 4. use read text async
                     //result2 = await azureStorage.ReadTextAsync(UT_TEST_Container, blobName);

                     //Assert.AreEqual(content, result2);
                     //// clear data
                     //await azureStorage.DeleteIfExistsAsync(UT_TEST_Container, blobName);
                 }
                 catch (Exception ex)
                 {
                     throw ex;
                 }
            // });

            //Task.WaitAll();
            //while(!task.IsCompleted)
            //{
            //    var c = "t";
            //    Thread.Sleep(1000);
            //}

            //Task.Factory.StartNew( async () =>
            //{
            //    try
            //    {
            //        var azureStorage = new AzureBinaryStorage(StorageConnectionString, null);
            //        string blobName = UT_TEST_BlobNamePrefix + Guid.NewGuid().ToString();

            //        // 1. Create a new blob file
            //        string content = "This is test for TestAzureBinaryStorage_ReadAsync().";

            //        using (var streamContent = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            //        {
            //            var t1 = azureStorage.CreateNewOrUpdateAsync(UT_TEST_Container, blobName, streamContent);
            //            await t1.ContinueWith((t) =>
            //            {
            //                // 2. read Stream data to compare whether the data is same as created
            //                var result = azureStorage.ReadAsync(UT_TEST_Container, blobName);
            //                //Task.WhenAll(t1, result).ContinueWith(  );
            //                string result2 = null;
            //                using (StreamReader reader = new StreamReader(result.Result))
            //                {
            //                    result2 = reader.ReadToEnd();
            //                }
            //                Assert.AreEqual(content, result2);
            //                Assert.AreNotSame(1, 1, "");
            //            });
            //        }

            //        //// 4. use read text async
            //        //result2 = await azureStorage.ReadTextAsync(UT_TEST_Container, blobName);

            //        //Assert.AreEqual(content, result2);
            //        //// clear data
            //        //await azureStorage.DeleteIfExistsAsync(UT_TEST_Container, blobName);
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //});

        }

        [Test]
        public async void TestAzureBinaryStorage_ExistsAsync()
        {
            var azureStorage = new AzureBinaryStorage(new StorageConnectionStringSetting(), null);

            // case 1: the blob doesn't exist, SHOULD return false
            string blobName = UT_TEST_BlobNamePrefix + Guid.NewGuid().ToString();
            bool exist = await azureStorage.ExistsAsync(UT_TEST_Container, blobName);
            Assert.IsFalse(exist);

            //  Create a new blob file for Exists check
            string content = "ExistsAsync";
            Stream streamContent = new MemoryStream(Encoding.UTF8.GetBytes(content));
            await azureStorage.CreateNewOrUpdateAsync(UT_TEST_Container, blobName, streamContent);

            // case 2: the blob exists, SHOULD return true
            exist = await azureStorage.ExistsAsync(UT_TEST_Container, blobName);
            Assert.IsTrue(exist);

            // clear data
            await azureStorage.DeleteIfExistsAsync(UT_TEST_Container, blobName);
        }

        [Test]
        public async void TestAzureBinaryStorage_DeleteAsync()
        {
            var azureStorage = new AzureBinaryStorage(new StorageConnectionStringSetting(), null);
            string blobName = UT_TEST_BlobNamePrefix + Guid.NewGuid().ToString();

            // case 1 : delete a non-existing blob, should return false
            bool deleted = await azureStorage.DeleteIfExistsAsync(UT_TEST_Container, blobName);
            Assert.IsFalse(deleted);

            // prepare data for delete
            //  Create a new blob file for Exists check
            string content = "DeleteIfExistsAsync()";
            Stream streamContent = new MemoryStream(Encoding.UTF8.GetBytes(content));
            await azureStorage.CreateNewOrUpdateAsync(UT_TEST_Container, blobName, streamContent);

            // case 2: if the blob exists, SHOULD return true
            deleted = await azureStorage.DeleteIfExistsAsync(UT_TEST_Container, blobName);
            Assert.IsTrue(deleted);
        }

        [Test]
        public async void TestAzureBinaryStorage_DeleteContainerAsync()
        {
            var azureStorage = new AzureBinaryStorage(new StorageConnectionStringSetting(), null);

            // case 1 : delete a non-existing container, should return false
            bool deleted = await azureStorage.DeleteContainerIfExistsAsync("ut1233notexist");
            Assert.IsFalse(deleted);

            // prepare data for delete
            //  Create a new container
            var blobClient = base.StorageAccount.CreateCloudBlobClient();
            string containerToBeCreted = "utdeletecontainertest123";
            var container = blobClient.GetContainerReference(containerToBeCreted);
            container.CreateIfNotExists();
            // case 2: if the blob exists, SHOULD return true
            deleted = await azureStorage.DeleteContainerIfExistsAsync(containerToBeCreted);
            Assert.IsTrue(deleted);
        }

        [Test]
        public async void TestAzureBinaryStorage_FetchBlobProperties()
        {
            var azureStorage = new AzureBinaryStorage(new StorageConnectionStringSetting(), null);
            string blobName = UT_TEST_BlobNamePrefix + Guid.NewGuid().ToString();

            // case 1 : Fetch a non-existing blob properties
            Assert.Throws(typeof(ArgumentException), async delegate
            {
                var blobInfo = await azureStorage.ReadAttributesAsync(UT_TEST_Container, blobName);
            });

            // prepare data for delete
            //  Create a new blob file for FetchBlob properties
            string content = "FetchAttributesAsync()";
            Stream streamContent = new MemoryStream(Encoding.UTF8.GetBytes(content));
            await azureStorage.CreateNewOrUpdateAsync(UT_TEST_Container, blobName, streamContent);

            // case 2: Fetch a existing blob properties
            var b = await azureStorage.ReadAttributesAsync(UT_TEST_Container, blobName);

            Assert.AreEqual(content.Length,b.Length);
            Assert.AreEqual(blobName,b.BlobName );
            Assert.AreEqual(DateTime.UtcNow.Date,b.LastModified.Value.Date);
            Assert.AreEqual(UT_TEST_Container,b.ContainerName );
            Assert.AreEqual( "application/octet-stream",b.ContentType);
            // clear data
            await azureStorage.DeleteIfExistsAsync(UT_TEST_Container, blobName);
        }

        [Test]
        public async void TestAzureBinaryStorage_SearchAsync()
        {
            var azureStorage = new AzureBinaryStorage(new StorageConnectionStringSetting(), new CustomRetryPolicyConfiguration() { RetryMethod = RetryMethod.Linear, DeltaBackoff = TimeSpan.FromMilliseconds(500), MaxAttempts = 3 });

            // Case 1: Exception
            Assert.Throws(typeof(ArgumentNullException), async delegate
            {
                var blobInfo = await azureStorage.SearchAsync(UT_TEST_Container, null);
            });


            string blobPrefix = UT_TEST_BlobNamePrefix + "SearchAsync_";
            // perpare data for search
            int blobCount = 25;
            for (int i = 0; i < blobCount; i++)
            {
                string blobName = blobPrefix + i.ToString() + "-" + Guid.NewGuid().ToString();
                var content = "This is test for SearchAsync() - test data " + i.ToString();
                var streamContent = new MemoryStream(Encoding.UTF8.GetBytes(content));
                await azureStorage.CreateNewOrUpdateAsync(UT_TEST_Container, blobName, streamContent);
            }

            // Get the first page data
            BlobSearchOptions searchOption = new BlobSearchOptions
            {
                ContinuationToken = null,
                NamePrefix = blobPrefix,
                MaxResults = 10
            };

            // Case 2: Get the first page data

            var theFirstPageResult = await azureStorage.SearchAsync(UT_TEST_Container, searchOption);
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
            var theSecondtPageResult = await azureStorage.SearchAsync(UT_TEST_Container, searchOption);
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
            var theThirdPageResult = await azureStorage.SearchAsync(UT_TEST_Container, searchOption);
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
            var noMatchedData = await azureStorage.SearchAsync(UT_TEST_Container, searchOption);
            int countZero = noMatchedData.Results.ToList().Count;
            Assert.AreEqual(countZero, 0);
        }


        [Test]
        public async void TestAzureBinaryStorage_RetryPolicy()
        {
            // Case1: DefaultCustomRetryPolicy
            var azureStorage = new AzureBinaryStorage(new StorageConnectionStringSetting(), new CustomRetryPolicyConfiguration());
            string blobName = UT_TEST_BlobNamePrefix + Guid.NewGuid().ToString();

            // Create a new blob file
            string content = "This is test for TestAzureBinaryStorage_RetryPolicy().";
            Stream streamContent = new MemoryStream(Encoding.UTF8.GetBytes(content));
            await azureStorage.CreateNewOrUpdateAsync(UT_TEST_Container, blobName, streamContent);
            // clear data
            await azureStorage.DeleteIfExistsAsync(UT_TEST_Container, blobName);

            // case 2: Linear Retry
            azureStorage = new AzureBinaryStorage(new StorageConnectionStringSetting(), new CustomRetryPolicyConfiguration { RetryMethod = RetryMethod.Linear, MaxAttempts = 3, DeltaBackoff = TimeSpan.FromMilliseconds(100) });
            blobName = UT_TEST_BlobNamePrefix + Guid.NewGuid().ToString();

            // Create a new blob file
            content = "This is test for TestAzureBinaryStorage_RetryPolicy() for Linear.";
            streamContent = new MemoryStream(Encoding.UTF8.GetBytes(content));
            await azureStorage.CreateNewOrUpdateAsync(UT_TEST_Container, blobName, streamContent);
            // clear data
            await azureStorage.DeleteIfExistsAsync(UT_TEST_Container, blobName);

            // case 3: Linear Retry
            azureStorage = new AzureBinaryStorage(new StorageConnectionStringSetting(), new CustomRetryPolicyConfiguration { RetryMethod = RetryMethod.Exponential, MaxAttempts = 3, DeltaBackoff = TimeSpan.FromMilliseconds(100) });
            blobName = UT_TEST_BlobNamePrefix + Guid.NewGuid().ToString();

            // Create a new blob file
            content = "This is test for TestAzureBinaryStorage_RetryPolicy() for Exponential.";
            streamContent = new MemoryStream(Encoding.UTF8.GetBytes(content));
            await azureStorage.CreateNewOrUpdateAsync(UT_TEST_Container, blobName, streamContent);
            // clear data
            await azureStorage.DeleteIfExistsAsync(UT_TEST_Container, blobName);
        }

        [Test]
        public async void TestAzureBinaryStorage_BlobNameExceedsMaxLength()
        {
            var azureStorage = new AzureBinaryStorage(new StorageConnectionStringSetting(), null);

            string randMaxFileName = string.Empty;
            for (int i = 0; i < 255; i++)
            {
                randMaxFileName += i.ToString();
            }

            var content = "TestAzureBinaryStorage_BlobNameExceedsMaxLength().";
            var streamContent = new MemoryStream(Encoding.UTF8.GetBytes(content));

            string blobName = (UT_TEST_BlobNamePrefix + randMaxFileName).Substring(0, 255);

            await azureStorage.CreateNewOrUpdateAsync(UT_TEST_Container, blobName, streamContent);

            Assert.Throws(typeof(ArgumentOutOfRangeException), async delegate { await azureStorage.CreateNewOrUpdateAsync(UT_TEST_Container, blobName + "a", streamContent); });

            await azureStorage.DeleteIfExistsAsync(UT_TEST_Container, blobName);
        }
    }
}
