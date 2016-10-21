using Accela.Infrastructure.Exceptions;
using Accela.Infrastructure.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Storage.SQLServer.Binary
{
    public class SQLServerBinaryStorage : IBinaryStorage
    {
        private const string DEFAULT_CONTENT_TYPE = "application/octet-stream";
        private const string CREATOR = "System";

        ISQLServerBinaryStorageRepository _sqlServerBinaryStorageRepository;
        private IRetryPolicyConfiguration _retryPolicyConfiguration = null;

        public SQLServerBinaryStorage(ISQLServerBinaryStorageRepository sqlServerBinaryStorageRepository, IRetryPolicyConfiguration retryPolicyConfiguration = null)
        {
            if (sqlServerBinaryStorageRepository == null)
            {
                throw new ArgumentNullException("sqlServerBinaryStorageRepository");
            }

            _sqlServerBinaryStorageRepository = sqlServerBinaryStorageRepository;

            this._retryPolicyConfiguration = retryPolicyConfiguration;

            if (this._retryPolicyConfiguration != null)
            {
                SQLServerStorageDbConfiguration.DeltaBackoff = this._retryPolicyConfiguration.DeltaBackoff;
                SQLServerStorageDbConfiguration.MaxAttempts = this._retryPolicyConfiguration.MaxAttempts;
                SQLServerStorageDbConfiguration.RetryMethod = this._retryPolicyConfiguration.RetryMethod;
                SQLServerStorageDbConfiguration.RetrySpans = this._retryPolicyConfiguration.RetrySpans;
            }
        }

        public async Task<bool> ExistsAsync(string containerName, string blobName)
        {
            var result = false;
            containerName = ValidateAndRefineContainer(containerName);
            blobName = ValidateAndRefineBlobName(blobName);
            result = await _sqlServerBinaryStorageRepository.ExistsAsync(containerName, blobName);

            return result;
        }

        public async Task<BlobProperties> ReadAttributesAsync(string containerName, string blobName)
        {
            BlobProperties result = null;
            containerName = ValidateAndRefineContainer(containerName);
            blobName = ValidateAndRefineBlobName(blobName);

            var tempResult = await _sqlServerBinaryStorageRepository.ReadAttributesAsync(containerName, blobName);

            if (tempResult != null)
            {
                result = new BlobProperties()
                {
                    BlobName = tempResult.Name,
                    ContainerName = containerName,
                    ContentEncoding = tempResult.ContentEncoding,
                    ContentType = tempResult.ContentType,
                    LastModified = tempResult.LastUpdatedDate.HasValue ? tempResult.LastUpdatedDate.Value : tempResult.CreatedDate,
                    Length = tempResult.ContentLength
                };
            }

            return result;
        }

        public async Task<Stream> ReadAsStreamAsync(string containerName, string blobName)
        {
            MemoryStream result = null;
            containerName = ValidateAndRefineContainer(containerName);
            blobName = ValidateAndRefineBlobName(blobName);

            var tempResult = await _sqlServerBinaryStorageRepository.ReadContentAsync(containerName, blobName);

            if (tempResult != null)
            {
                result = tempResult != null ? new MemoryStream(tempResult) : null;
            }

            return result;
        }

        public async Task<string> ReadAsStringAsync(string containerName, string blobName)
        {
            string result = null;
            containerName = ValidateAndRefineContainer(containerName);
            blobName = ValidateAndRefineBlobName(blobName);

            var tempResult = await _sqlServerBinaryStorageRepository.ReadContentAsync(containerName, blobName);

            if (tempResult != null)
            {
                result = tempResult != null ? Encoding.UTF8.GetString(tempResult) : null;
            }

            return result;
        }

        public async Task CreateNewAsync(string containerName, string blobName, Stream content)
        {
            containerName = ValidateAndRefineContainer(containerName);
            blobName = ValidateAndRefineBlobName(blobName);

            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            content.Position = 0;

            var isExisting = await ExistsAsync(containerName, blobName);

            if (isExisting)
            {
                throw new ArgumentException(string.Format("Blob {0} exists in container {1}.", blobName, containerName), blobName);
            }

            var contentBuffer = content != null ? new byte[content.Length] : null;
            var contentLength = content != null ? content.Length : 0;

            if (content != null)
            {
                await content.ReadAsync(contentBuffer, 0, (int)content.Length);
            }

            await CreateNewAsync(containerName, blobName, contentBuffer, contentLength);
        }

        public async Task CreateNewAsync(string containerName, string blobName, String content)
        {
            containerName = ValidateAndRefineContainer(containerName);
            blobName = ValidateAndRefineBlobName(blobName);

            var contentBuffer = content != null ? Encoding.UTF8.GetBytes(content) : null;
            var contentLength = content != null ? content.Length : 0;

            await CreateNewAsync(containerName, blobName, contentBuffer, contentLength);
        }

        public async Task CreateNewOrUpdateAsync(string containerName, string blobName, Stream content)
        {
            containerName = ValidateAndRefineContainer(containerName);
            blobName = ValidateAndRefineBlobName(blobName);

            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            content.Position = 0;

            var contentBuffer = content != null ? new byte[content.Length] : null;
            var contentLength = content != null ? content.Length : 0;

            if (content != null)
            {
                await content.ReadAsync(contentBuffer, 0, (int)content.Length);
            }

            await CreateNewOrUpdateAsync(containerName, blobName, contentBuffer, contentLength);
        }

        public async Task CreateNewOrUpdateAsync(string containerName, string blobName, String content)
        {
            containerName = ValidateAndRefineContainer(containerName);
            blobName = ValidateAndRefineBlobName(blobName);

            var contentBuffer = content != null ? Encoding.UTF8.GetBytes(content) : null;
            var contentLength = content != null ? content.Length : 0;

            await CreateNewOrUpdateAsync(containerName, blobName, contentBuffer, contentLength);
        }

        public async Task<bool> DeleteIfExistsAsync(string containerName, string blobName)
        {
            var result = false;
            containerName = ValidateAndRefineContainer(containerName);
            blobName = ValidateAndRefineBlobName(blobName);

            result = await _sqlServerBinaryStorageRepository.DeleteIfExistsAsync(containerName, blobName);

            return result;
        }

        /// <summary>
        /// deletes the container if it already exists.
        /// </summary>
        /// <param name="containerName">container name.</param>
        /// <returns>true if the container did not already exist and was created; otherwise false.</returns>
        public async Task<bool> DeleteContainerIfExistsAsync(string containerName)
        {
            // TODO..
            throw new NotSupportedException();
        }


        public async Task<BlobSearchResult> SearchAsync(string containerName, BlobSearchOptions filter)
        {
            BlobSearchResult result = null;
            containerName = ValidateAndRefineContainer(containerName);

            if (filter == null)
            {
                filter = new BlobSearchOptions();
            }

            var dbPaginationModel = DbPaginationModel.ConvertFrom(filter.ContinuationToken);
            var lastCount = dbPaginationModel != null ? dbPaginationModel.LastCount : -1;

            var tempBlobItemsResult = await _sqlServerBinaryStorageRepository.SearchAsync(containerName, filter.NamePrefix, lastCount, filter.MaxResults);

            if (tempBlobItemsResult != null)
            {
                var newRowNumber = tempBlobItemsResult.Select(p => p.RowNumber).OrderByDescending(p => p).FirstOrDefault();
                var tempResult = tempBlobItemsResult.Select(p =>
                    new BlobProperties()
                    {
                        BlobName = p.Name,
                        ContainerName = containerName,
                        ContentEncoding = p.ContentEncoding,
                        ContentType = p.ContentType,
                        LastModified = p.LastUpdatedDate.HasValue ? p.LastUpdatedDate.Value : p.CreatedDate,
                        Length = p.ContentLength
                    }).ToArray();

                var newDbPaginationModel = new DbPaginationModel()
                {
                    LastCount = newRowNumber
                };

                result = new BlobSearchResult()
                {
                    ContinuationToken = DbPaginationModel.ConvertToToken(newDbPaginationModel),
                    Results = tempResult
                };
            }

            return result;
        }

        private async Task CreateNewAsync(string containerName, string blobName, byte[] content, long contentLength)
        {
            var containerModel = await GetOrCreateContainerAsync(containerName);
            var blobItem = new BlobItem()
                {
                    Content = content,
                    ContentEncoding = null,
                    ContentLength = contentLength,
                    ContentType = DEFAULT_CONTENT_TYPE,
                    Name = blobName,
                    ContainerId = containerModel.Id,
                    CreatedBy = CREATOR,
                    CreatedDate = DateTime.UtcNow,
                    Id = Guid.NewGuid()
                };
            await _sqlServerBinaryStorageRepository.CreateAsync(blobItem);
        }

        private async Task CreateNewOrUpdateAsync(string containerName, string blobName, byte[] content, long contentLength)
        {
            var blobItem = await _sqlServerBinaryStorageRepository.ReadAttributesAsync(containerName, blobName);

            if (blobItem != null)
            {
                blobItem.Content = content;
                blobItem.ContentEncoding = null;
                blobItem.ContentLength = contentLength;
                blobItem.ContentType = DEFAULT_CONTENT_TYPE;
                blobItem.LastUpdatedBy = CREATOR;
                blobItem.LastUpdatedDate = DateTime.UtcNow;

                await _sqlServerBinaryStorageRepository.UpdateAsync(blobItem);
            }
            else
            {
                await CreateNewAsync(containerName, blobName, content, contentLength);
            }
        }

        private async Task<BlobContainer> GetOrCreateContainerAsync(string containerName)
        {
            BlobContainer result = null;

            result = await _sqlServerBinaryStorageRepository.GetContainerAsync(containerName);

            if (result == null)
            {
                var newContainer = new BlobContainer()
                {
                    Name = containerName,
                    CreatedBy = CREATOR,
                    CreatedDate = DateTime.UtcNow,
                    Id = Guid.NewGuid()
                };

                await _sqlServerBinaryStorageRepository.CreateContainerAsync(newContainer);
                result = await _sqlServerBinaryStorageRepository.GetContainerAsync(containerName);
            }

            return result;
        }

        private string ValidateAndRefineBlobName(string blobName)
        {
            if (string.IsNullOrWhiteSpace(blobName))
            {
                throw new ArgumentNullException("blobName");
            }

            var blobNameLower = blobName.ToLower();

            blobNameLower = blobNameLower.Replace("\\", "/");

            return blobNameLower;
        }

        private static bool IsBlobContainerNameValid(string name)
        {
            string validBlobContainerNameRegex = @"^(([a-z\d]((-(?=[a-z\d]))|([a-z\d])){2,62})|(\$root))$";
            Regex reg = new Regex(validBlobContainerNameRegex);

            if (reg.IsMatch(name))
            {
                return true;
            }

            return false;
        }

        private static string ValidateAndRefineContainer(string containerName)
        {
            if (string.IsNullOrWhiteSpace(containerName))
            {
                throw new ArgumentNullException("containerName");
            }
            var containerLower = containerName.ToLower();

            if (!IsBlobContainerNameValid(containerLower))
            {
                throw new ArgumentException("Invalid container name.", "containerName");
            }

            return containerLower;
        }
    }
}
