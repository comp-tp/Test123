using Accela.Infrastructure.Storage;
using Accela.Infrastructure.Storage.SQLServer;
using Accela.Infrastructure.Storage.SQLServer.Binary;
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
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.SQLServer.Test
{
    [TestFixture]
    public class SQLServerBinaryStorageTest
    {
        private const string SAMPLE_CONTAINER_NAME1 = "C1C";
        private const string SAMPLE_CONTAINER_NAME2 = "C2C";
        private const string SAMPLE_BLOBITEM_NAME1 = "I1I";
        private const string SAMPLE_BLOBITEM_NAME1_PARTIAL = "I1";
        private const string SAMPLE_CONTENT = "BLOB sample content";
        private const string SAMPLE_CONNECTION_STRING = "SampleConnectionString4SqlServer";
        private IQueryable<BlobContainer> _sampleBlobContainerList = null;
        private IQueryable<BlobItem> _sampleBlobItemList = null;

        public SQLServerBinaryStorageTest()
        {

        }

        [SetUp]
        public void Setup()
        {
            _sampleBlobContainerList = InitBlobContainerList();
            _sampleBlobItemList = InitBlobItemList(_sampleBlobContainerList);
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public async void ExistsAsync()
        {
            var mockISQLServerBinaryStorageBlobRepository = new Mock<ISQLServerBinaryStorageRepository>();
            mockISQLServerBinaryStorageBlobRepository.Setup(m => m.ExistsAsync(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<bool>(true));

            IBinaryStorage sqlServerBinaryStorage = new SQLServerBinaryStorage(mockISQLServerBinaryStorageBlobRepository.Object, new CustomRetryPolicyConfiguration());
            var response = await sqlServerBinaryStorage.ExistsAsync(SAMPLE_CONTAINER_NAME1, SAMPLE_BLOBITEM_NAME1);

            Assert.IsTrue(response);
        }

        [Test]
        public async void NotExistsAsync()
        {
            var mockISQLServerBinaryStorageBlobRepository = new Mock<ISQLServerBinaryStorageRepository>();
            mockISQLServerBinaryStorageBlobRepository.Setup(m => m.ExistsAsync(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<bool>(false));

            IBinaryStorage sqlServerBinaryStorage = new SQLServerBinaryStorage(mockISQLServerBinaryStorageBlobRepository.Object, new CustomRetryPolicyConfiguration());
            var response = await sqlServerBinaryStorage.ExistsAsync(SAMPLE_CONTAINER_NAME1, SAMPLE_BLOBITEM_NAME1);

            Assert.IsFalse(response);
        }

        [Test]
        public async void ReadAttributesAsync()
        {
            var mockISQLServerBinaryStorageBlobRepository = new Mock<ISQLServerBinaryStorageRepository>();
            var mockBlobItem = new BlobItem()
                {
                    ContainerId = Guid.NewGuid(),
                    Content = Encoding.UTF8.GetBytes(SAMPLE_CONTENT),
                    ContentEncoding = "sampleEncoding",
                    ContentLength = SAMPLE_CONTENT.Length,
                    ContentType = "sampleType",
                    CreatedBy = "testCase",
                    CreatedDate = DateTime.Now,
                    Id = Guid.NewGuid(),
                    LastUpdatedBy = "testCase",
                    LastUpdatedDate = DateTime.Now,
                    Name = SAMPLE_BLOBITEM_NAME1
                };
            mockISQLServerBinaryStorageBlobRepository
                .Setup(m => m.ReadAttributesAsync(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult<BlobItem>(mockBlobItem));

            IBinaryStorage sqlServerBinaryStorage = new SQLServerBinaryStorage(mockISQLServerBinaryStorageBlobRepository.Object, new CustomRetryPolicyConfiguration());
            var response = await sqlServerBinaryStorage.ReadAttributesAsync(SAMPLE_CONTAINER_NAME1, SAMPLE_BLOBITEM_NAME1);
            var comparedResult = response.BlobName == mockBlobItem.Name;

            Assert.IsTrue(comparedResult);
        }

        [Test]
        public async void ReadAsStreamAsync()
        {
            var mockISQLServerBinaryStorageBlobRepository = new Mock<ISQLServerBinaryStorageRepository>();
            var mockContent = Encoding.UTF8.GetBytes(SAMPLE_CONTENT);
            mockISQLServerBinaryStorageBlobRepository
                .Setup(m => m.ReadContentAsync(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult<byte[]>(mockContent));

            IBinaryStorage sqlServerBinaryStorage = new SQLServerBinaryStorage(mockISQLServerBinaryStorageBlobRepository.Object, new CustomRetryPolicyConfiguration());
            var response = await sqlServerBinaryStorage.ReadAsStreamAsync(SAMPLE_CONTAINER_NAME1, SAMPLE_BLOBITEM_NAME1);
            var comparedResult = new StreamReader(response).ReadToEnd().Equals(Encoding.UTF8.GetString(mockContent));

            Assert.IsTrue(comparedResult);
        }

        [Test]
        public async void ReadAsStringAsync()
        {
            var mockISQLServerBinaryStorageBlobRepository = new Mock<ISQLServerBinaryStorageRepository>();
            var mockContent = Encoding.UTF8.GetBytes(SAMPLE_CONTENT);
            mockISQLServerBinaryStorageBlobRepository
                .Setup(m => m.ReadContentAsync(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult<byte[]>(mockContent));

            IBinaryStorage sqlServerBinaryStorage = new SQLServerBinaryStorage(mockISQLServerBinaryStorageBlobRepository.Object, new CustomRetryPolicyConfiguration());
            var response = await sqlServerBinaryStorage.ReadAsStringAsync(SAMPLE_CONTAINER_NAME1, SAMPLE_BLOBITEM_NAME1);
            var comparedResult = response.Equals(Encoding.UTF8.GetString(mockContent));

            Assert.IsTrue(comparedResult);
        }

        [Test]
        public async void CreateNewAsync()
        {
            var mockISQLServerBinaryStorageBlobRepository = new Mock<ISQLServerBinaryStorageRepository>();
            var mockBlobItem = new BlobItem()
            {
                ContainerId = Guid.NewGuid(),
                Content = Encoding.UTF8.GetBytes(SAMPLE_CONTENT),
                ContentEncoding = "sampleEncoding",
                ContentLength = SAMPLE_CONTENT.Length,
                ContentType = "sampleType",
                CreatedBy = "testCase",
                CreatedDate = DateTime.Now,
                Id = Guid.NewGuid(),
                LastUpdatedBy = "testCase",
                LastUpdatedDate = DateTime.Now,
                Name = SAMPLE_BLOBITEM_NAME1
            };
            var mockBlobContainer = new BlobContainer()
            {
                Id = mockBlobItem.ContainerId,
                Name = "sampleContainer"
            };

            mockISQLServerBinaryStorageBlobRepository
                .Setup(m => m.ExistsAsync(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult<bool>(false));
            mockISQLServerBinaryStorageBlobRepository
                .Setup(m => m.GetContainerAsync(It.IsAny<string>()))
                .Returns(Task.FromResult<BlobContainer>(mockBlobContainer));
            mockISQLServerBinaryStorageBlobRepository
                .Setup(m => m.CreateAsync(It.IsAny<BlobItem>()))
                .Returns(Task.FromResult<int>(0));

            IBinaryStorage sqlServerBinaryStorage = new SQLServerBinaryStorage(mockISQLServerBinaryStorageBlobRepository.Object, new CustomRetryPolicyConfiguration());
            await sqlServerBinaryStorage.CreateNewAsync(SAMPLE_CONTAINER_NAME1, SAMPLE_BLOBITEM_NAME1, new MemoryStream(mockBlobItem.Content));

            mockISQLServerBinaryStorageBlobRepository
                .Verify(m => m.CreateAsync(It.IsAny<BlobItem>()), Times.Once());
        }

        [Test]
        public async void CreateNewOrUpdateAsync()
        {
            var mockISQLServerBinaryStorageBlobRepository = new Mock<ISQLServerBinaryStorageRepository>();
            var mockBlobItem = new BlobItem()
            {
                ContainerId = Guid.NewGuid(),
                Content = Encoding.UTF8.GetBytes(SAMPLE_CONTENT),
                ContentEncoding = "sampleEncoding",
                ContentLength = SAMPLE_CONTENT.Length,
                ContentType = "sampleType",
                CreatedBy = "testCase",
                CreatedDate = DateTime.Now,
                Id = Guid.NewGuid(),
                LastUpdatedBy = "testCase",
                LastUpdatedDate = DateTime.Now,
                Name = SAMPLE_BLOBITEM_NAME1
            };
            mockISQLServerBinaryStorageBlobRepository
                .Setup(m => m.ReadAttributesAsync(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult<BlobItem>(mockBlobItem));
            mockISQLServerBinaryStorageBlobRepository
                .Setup(m => m.UpdateAsync(It.IsAny<BlobItem>()))
                .Returns(Task.FromResult<int>(0));

            IBinaryStorage sqlServerBinaryStorage = new SQLServerBinaryStorage(mockISQLServerBinaryStorageBlobRepository.Object, new CustomRetryPolicyConfiguration());
            await sqlServerBinaryStorage.CreateNewOrUpdateAsync(SAMPLE_CONTAINER_NAME1, SAMPLE_BLOBITEM_NAME1, new MemoryStream(mockBlobItem.Content));

            mockISQLServerBinaryStorageBlobRepository
                .Verify(m => m.UpdateAsync(It.IsAny<BlobItem>()), Times.Once());
        }

        [Test]
        public async void DeleteIfExistsAsync()
        {
            var mockISQLServerBinaryStorageBlobRepository = new Mock<ISQLServerBinaryStorageRepository>();
            mockISQLServerBinaryStorageBlobRepository
                .Setup(m => m.DeleteIfExistsAsync(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult<bool>(true));

            IBinaryStorage sqlServerBinaryStorage = new SQLServerBinaryStorage(mockISQLServerBinaryStorageBlobRepository.Object, new CustomRetryPolicyConfiguration());
            var response = await sqlServerBinaryStorage.DeleteIfExistsAsync(SAMPLE_CONTAINER_NAME1, SAMPLE_BLOBITEM_NAME1);

            Assert.IsTrue(response);
        }

        [Test]
        public async void SearchAsync_ByMaxResults()
        {
            var mockISQLServerBinaryStorageBlobRepository = new Mock<ISQLServerBinaryStorageRepository>();
            mockISQLServerBinaryStorageBlobRepository
                .Setup(m => m.SearchAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<long>(), 10))
                .Returns(Task.FromResult<BlobItem[]>(_sampleBlobItemList.ToArray()));

            IBinaryStorage sqlServerBinaryStorage = new SQLServerBinaryStorage(mockISQLServerBinaryStorageBlobRepository.Object, new CustomRetryPolicyConfiguration());
            var response = await sqlServerBinaryStorage.SearchAsync(SAMPLE_CONTAINER_NAME1, new BlobSearchOptions()
            {
                MaxResults = 10,
                NamePrefix = "sampleNamePrefix"
            });
            var comparedResult = response != null && response.Results != null && response.Results.Count() == _sampleBlobItemList.Count();

            Assert.IsTrue(comparedResult);
        }

        [Test]
        public async void SearchAsync_Paging()
        {
            var mockISQLServerBinaryStorageBlobRepository = new Mock<ISQLServerBinaryStorageRepository>();
            int maxResults = 2;
            mockISQLServerBinaryStorageBlobRepository
                .Setup(m => m.SearchAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<long>(), It.IsAny<int>()))
                .Returns(Task.FromResult<BlobItem[]>(_sampleBlobItemList.Take(maxResults).ToArray()));

            IBinaryStorage sqlServerBinaryStorage = new SQLServerBinaryStorage(mockISQLServerBinaryStorageBlobRepository.Object, new CustomRetryPolicyConfiguration());
            var response = await sqlServerBinaryStorage.SearchAsync(SAMPLE_CONTAINER_NAME1, new BlobSearchOptions()
            {
                MaxResults = maxResults,
                NamePrefix = "sampleNamePrefix"
            });
            var comparedResult = response != null && response.Results != null && response.Results.Count() == maxResults;

            var result = comparedResult;

            //---

            maxResults = 1;
            mockISQLServerBinaryStorageBlobRepository
                .Setup(m => m.SearchAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<long>(), It.IsAny<int>()))
                .Returns(Task.FromResult<BlobItem[]>(_sampleBlobItemList.Take(maxResults).ToArray()));

            sqlServerBinaryStorage = new SQLServerBinaryStorage(mockISQLServerBinaryStorageBlobRepository.Object, new CustomRetryPolicyConfiguration());
            response = await sqlServerBinaryStorage.SearchAsync(SAMPLE_CONTAINER_NAME1, new BlobSearchOptions()
            {
                MaxResults = maxResults,
                NamePrefix = "sampleNamePrefix",
                ContinuationToken = response.ContinuationToken
            });
            comparedResult = response != null && response.Results != null && response.Results.Count() == maxResults;
            result = result && comparedResult;

            Assert.IsTrue(comparedResult);
        }

        [Test]
        public async void SearchAsync_ByPartialName()
        {
            var mockISQLServerBinaryStorageBlobRepository = new Mock<ISQLServerBinaryStorageRepository>();
            var sampleBlobItems = _sampleBlobItemList.Where(p => p.Name.StartsWith(SAMPLE_BLOBITEM_NAME1_PARTIAL)).ToArray();
            mockISQLServerBinaryStorageBlobRepository
                .Setup(m => m.SearchAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<long>(), 10))
                .Returns(Task.FromResult<BlobItem[]>(sampleBlobItems));

            IBinaryStorage sqlServerBinaryStorage = new SQLServerBinaryStorage(mockISQLServerBinaryStorageBlobRepository.Object, new CustomRetryPolicyConfiguration());
            var response = await sqlServerBinaryStorage.SearchAsync(SAMPLE_CONTAINER_NAME1, new BlobSearchOptions()
            {
                MaxResults = 10,
                NamePrefix = SAMPLE_BLOBITEM_NAME1_PARTIAL
            });
            var comparedResult = response != null && response.Results != null && response.Results.Where(p => p.BlobName.StartsWith(SAMPLE_BLOBITEM_NAME1_PARTIAL)).Count() == sampleBlobItems.Count();

            Assert.IsTrue(comparedResult);
        }

        [Test]
        public async void SearchAsync_ByAllConditions()
        {
            var mockISQLServerBinaryStorageBlobRepository = new Mock<ISQLServerBinaryStorageRepository>();
            var sampleBlobItems = _sampleBlobItemList.Where(p => p.Name.StartsWith(SAMPLE_BLOBITEM_NAME1)).ToArray();
            mockISQLServerBinaryStorageBlobRepository
                .Setup(m => m.SearchAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<long>(), 10))
                .Returns(Task.FromResult<BlobItem[]>(sampleBlobItems));

            IBinaryStorage sqlServerBinaryStorage = new SQLServerBinaryStorage(mockISQLServerBinaryStorageBlobRepository.Object, new CustomRetryPolicyConfiguration());
            var response = await sqlServerBinaryStorage.SearchAsync(SAMPLE_CONTAINER_NAME1, new BlobSearchOptions()
            {
                MaxResults = 10,
                NamePrefix = SAMPLE_BLOBITEM_NAME1_PARTIAL
            });
            var comparedResult = response != null && response.Results != null && response.Results.Where(p => p.BlobName.StartsWith(SAMPLE_BLOBITEM_NAME1)).Count() == sampleBlobItems.Count();

            Assert.IsTrue(comparedResult);
        }

        [Test]
        public async void RetryPolicy_Settings()
        {
            var mockISQLServerBinaryStorageBlobRepository = new Mock<ISQLServerBinaryStorageRepository>();
            var sampleBlobItems = _sampleBlobItemList.Where(p => p.Name.StartsWith(SAMPLE_BLOBITEM_NAME1)).ToArray();
            mockISQLServerBinaryStorageBlobRepository
                .Setup(m => m.SearchAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<long>(), 10))
                .Returns(Task.FromResult<BlobItem[]>(sampleBlobItems));

            var retryPolicy = new CustomRetryPolicyConfiguration();
            retryPolicy.DeltaBackoff = TimeSpan.FromMilliseconds(3000);
            retryPolicy.MaxAttempts = 6;
            retryPolicy.RetryMethod = RetryMethod.Linear;
            retryPolicy.RetrySpans = new List<TimeSpan>() { TimeSpan.FromMilliseconds(20), TimeSpan.FromMilliseconds(120), TimeSpan.FromMilliseconds(220), TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(1500) };

            IBinaryStorage sqlServerBinaryStorage = new SQLServerBinaryStorage(mockISQLServerBinaryStorageBlobRepository.Object, retryPolicy);
            var response = await sqlServerBinaryStorage.SearchAsync(SAMPLE_CONTAINER_NAME1, new BlobSearchOptions()
            {
                MaxResults = 10,
                NamePrefix = SAMPLE_BLOBITEM_NAME1_PARTIAL
            });
            var comparedResult = response != null && response.Results != null && response.Results.Where(p => p.BlobName.StartsWith(SAMPLE_BLOBITEM_NAME1)).Count() == sampleBlobItems.Count();

            var result = response != null
                && response.Results != null
                && response.Results.Count() == 1
                && SQLServerStorageDbConfiguration.DeltaBackoff == retryPolicy.DeltaBackoff
                && SQLServerStorageDbConfiguration.MaxAttempts == retryPolicy.MaxAttempts
                && SQLServerStorageDbConfiguration.RetryMethod == retryPolicy.RetryMethod
                && SQLServerStorageDbConfiguration.RetrySpans == retryPolicy.RetrySpans;

            Assert.IsTrue(result);
        }

        private IQueryable<BlobContainer> InitBlobContainerList()
        {
            var blobContainerList = new List<BlobContainer> 
            { 
                new BlobContainer { Id=Guid.Parse("EDA6C545-A462-4B3D-9961-BA67E0B2601B"), Name = SAMPLE_CONTAINER_NAME1, CreatedDate =DateTime.Parse("2015-04-19 17:04"), CreatedBy="System" }, 
                new BlobContainer { Id=Guid.Parse("645C5447-4F84-4C02-B230-0F387B01ED37"), Name = SAMPLE_CONTAINER_NAME2, CreatedDate =DateTime.Parse("2015-04-19 17:04"), CreatedBy="System" }, 
                new BlobContainer { Id=Guid.Parse("067C7B17-E528-46EA-A2EF-78A35F189542"), Name = "C3C", CreatedDate =DateTime.Parse("2015-04-19 17:04"), CreatedBy="System" }, 
            }.AsQueryable();

            return blobContainerList;
        }

        private IQueryable<BlobItem> InitBlobItemList(IQueryable<BlobContainer> blobContainerList)
        {
            var containers = blobContainerList.ToArray();
            var Id2 = containers[1].Id;
            var blobItemList = new List<BlobItem>
            { 
                new BlobItem { Id=Guid.NewGuid(), Name = SAMPLE_BLOBITEM_NAME1 , Content = Encoding.UTF8.GetBytes(SAMPLE_CONTENT), ContainerId = containers[0].Id, ContentLength = 101, CreatedDate =DateTime.Parse("2015-03-19 17:03") }
                ,new BlobItem { Id=Guid.NewGuid(), Name = "I2I" , Content = Encoding.UTF8.GetBytes("BLOB sample 2 content"), ContainerId = Id2, ContentLength = 900, CreatedDate =DateTime.Parse("2015-03-25 17:03"), LastUpdatedDate =DateTime.Parse("2015-04-19 17:06") }
                ,new BlobItem { Id=Guid.NewGuid(), Name = "I3I" , Content = Encoding.UTF8.GetBytes("BLOB sample 3 content"), ContainerId = Id2, ContentLength = 600, CreatedDate =DateTime.Parse("2015-04-19 17:04") }
                ,new BlobItem { Id=Guid.NewGuid(), Name = "I4I" , Content = Encoding.UTF8.GetBytes("BLOB sample 4 content"), ContainerId = Id2, ContentLength = 1000, CreatedDate =DateTime.Parse("2015-05-19 17:04") }
                ,new BlobItem { Id=Guid.NewGuid(), Name = "I5I" , Content = Encoding.UTF8.GetBytes("BLOB sample 5 content"), ContainerId = containers[2].Id, ContentLength = 1200, CreatedDate =DateTime.Parse("2015-05-19 17:04") }
            }.AsQueryable();

            return blobItemList;
        }
    }
}
