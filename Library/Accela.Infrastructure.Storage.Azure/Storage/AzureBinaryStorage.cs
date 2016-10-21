using Accela.Infrastructure.Exceptions;
using Accela.Infrastructure.Storage;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Accela.Infrastructure.Azure.Storage
{
    public class AzureBinaryStorage : IBinaryStorage
    {
        private const int MAX_SIZE_CHUNK = 4 * 1024 * 1024;    //   4 MB
        CloudBlobClient _cloudBlobClient = null;
        BlobRequestOptions _requestOptions = null;

        public AzureBinaryStorage(IConnectionStringSetting connectionStringSetting, IRetryPolicyConfiguration retryPolicyConfiguration)
        {
            if (connectionStringSetting == null)
            {
                throw new ArgumentNullException("connectionStringSetting");
            }

            var connectionString = connectionStringSetting.Get();
            if (String.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException("Invalid connection string.");
            }

            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(connectionString);
            _cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();

            BlobRequestOptions requestOptions = null;
            // Retry Policy
            if (retryPolicyConfiguration != null && retryPolicyConfiguration.RetryMethod != RetryMethod.None)
            {
                Microsoft.WindowsAzure.Storage.RetryPolicies.IRetryPolicy azureRetryPolicy = null;
                // convert to azure IRetryPolicy
                if (retryPolicyConfiguration.RetryMethod == RetryMethod.Linear)
                {
                    azureRetryPolicy = new Microsoft.WindowsAzure.Storage.RetryPolicies.LinearRetry(retryPolicyConfiguration.DeltaBackoff, retryPolicyConfiguration.MaxAttempts);
                }
                else if (retryPolicyConfiguration.RetryMethod == RetryMethod.Exponential)
                {
                    azureRetryPolicy = new Microsoft.WindowsAzure.Storage.RetryPolicies.ExponentialRetry(retryPolicyConfiguration.DeltaBackoff, retryPolicyConfiguration.MaxAttempts);
                }

                if (azureRetryPolicy != null)
                {
                    requestOptions = new BlobRequestOptions()
                    {
                        RetryPolicy = azureRetryPolicy,
                    };
                    _requestOptions = requestOptions;
                }
            }
        }

        public string StorageUri
        {
            get
            {
                return _cloudBlobClient.StorageUri.PrimaryUri.ToString();
            }
        }

        public async Task<bool> ExistsAsync(string containerName, string blobName)
        {
            var blobReference = GetBlockBlobReference(containerName, blobName);
            return await blobReference.ExistsAsync(_requestOptions, null);
        }

        public async Task<Stream> ReadAsStreamAsync(string containerName, string blobName)
        {
            var blobReference = GetBlockBlobReference(containerName, blobName);

            if (blobReference.Exists())
            {
                return await blobReference.OpenReadAsync(null, _requestOptions, null);
            }
            else
            {
                throw new ArgumentException(string.Format("Blob {0} not found in container {1}.", blobName, containerName), blobName);
            }
        }

        public async Task<string> ReadAsStringAsync(string containerName, string blobName)
        {
            var blobReference = GetBlockBlobReference(containerName, blobName);

            string result = null;
            if (blobReference.Exists())
            {
                using (var streamResult = await blobReference.OpenReadAsync(null, _requestOptions, null))
                {
                    using (StreamReader reader = new StreamReader(streamResult))
                    {
                        result = reader.ReadToEnd();
                    }

                }
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task CreateNewAsync(string containerName, string blobName, Stream content)
        {
            await CreateNewOrReplaceAsync(containerName, blobName, content, false);
        }

        public async Task CreateNewAsync(string containerName, string blobName, string content)
        {
            var blobReference = GetBlockBlobReference(containerName, blobName);

            if (!blobReference.Exists())
            {
                await blobReference.UploadTextAsync(content, null, null, _requestOptions, null);
            }
            else
            {
                throw new ArgumentException(string.Format("Blob {0} exists in container {1}.", blobName, containerName), blobName);
            }
        }

        public async Task CreateNewOrUpdateAsync(string containerName, string blobName, Stream content)
        {
            await CreateNewOrReplaceAsync(containerName, blobName, content, true);
        }

        public async Task CreateNewOrUpdateAsync(string containerName, string blobName, string content)
        {
            var blobReference = GetBlockBlobReference(containerName, blobName);
            await blobReference.UploadTextAsync(content, null, null, _requestOptions, null);
        }

        private async Task CreateNewOrReplaceAsync(string containerName, string blobName, Stream content, bool replaceIfExists)
        {
            if(content == null)
            {
                throw new ArgumentNullException("content");
            }

            var blobReference = GetBlockBlobReference(containerName, blobName);

            if(!replaceIfExists && blobReference.Exists())
            {
                throw new ArgumentException(string.Format("Blob {0} exists in container {1}.", blobName, containerName), blobName);
            }

            content.Position = 0;

            if (content.Length > MAX_SIZE_CHUNK)
            {
                byte[] data = new byte[content.Length];
                content.Read(data, 0, Convert.ToInt32(content.Length));
                int id = 0;
                int byteslength = data.Length;
                int bytesread = 0;
                int index = 0;
                List<string> blocklist = new List<string>();
                int numBytesPerChunk = 250 * 1024; //250KB per block

                do
                {
                    byte[] buffer = new byte[numBytesPerChunk];
                    int limit = index + numBytesPerChunk;
                    for (int loops = 0; index < limit; index++)
                    {
                        buffer[loops] = data[index];
                        loops++;
                    }
                    bytesread = index;
                    string blockIdBase64 = Convert.ToBase64String(System.BitConverter.GetBytes(id));

                    await blobReference.PutBlockAsync(blockIdBase64, new MemoryStream(buffer, true), null, null, _requestOptions, null);
                    blocklist.Add(blockIdBase64);
                    id++;
                } while (byteslength - bytesread > numBytesPerChunk);

                int final = byteslength - bytesread;
                byte[] finalbuffer = new byte[final];

                for (int loops = 0; index < byteslength; index++)
                {
                    finalbuffer[loops] = data[index];
                    loops++;
                }

                string blockId = Convert.ToBase64String(System.BitConverter.GetBytes(id));
                await blobReference.PutBlockAsync(blockId, new MemoryStream(finalbuffer, true), null, null, _requestOptions, null);
                blocklist.Add(blockId);

                await blobReference.PutBlockListAsync(blocklist, null, _requestOptions, null);
            }
            else
            {
                await blobReference.UploadFromStreamAsync(content, null, _requestOptions, null);
            }
        }

        public async Task<bool> DeleteIfExistsAsync(string containerName, string blobName)
        {
            var blobReference = GetBlockBlobReference(containerName, blobName);

            return await blobReference.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots, null, _requestOptions, null);
        }

        /// <summary>
        /// deletes the container if it already exists.
        /// </summary>
        /// <param name="containerName">container name.</param>
        /// <returns>true if the container did not already exist and was created; otherwise false.</returns>
        public async Task<bool> DeleteContainerIfExistsAsync(string containerName)
        {
            ValidateContainerName(containerName);

            var cloudBlobContainer = _cloudBlobClient.GetContainerReference(containerName);
            return await cloudBlobContainer.DeleteIfExistsAsync();
        }

        public async Task<Accela.Infrastructure.Storage.BlobProperties> ReadAttributesAsync(string containerName, string blobName)
        {
            try
            {
                var blobReference = GetBlockBlobReference(containerName, blobName);

                await blobReference.FetchAttributesAsync(null, _requestOptions, null);

                return new Accela.Infrastructure.Storage.BlobProperties
                {
                    ContainerName = containerName,
                    ContentEncoding = blobReference.Properties.ContentEncoding,
                    ContentType = blobReference.Properties.ContentType,
                    LastModified = blobReference.Properties.LastModified.Value.DateTime,
                    BlobName = blobName,
                    Length = blobReference.Properties.Length,
                };
            }
            catch (StorageException ex)
            {
                if (ex.Message.Contains("(404) Not Found."))
                {
                    throw new ArgumentException(string.Format("Blob {0} not found in container {1}.", blobName, containerName), blobName);
                }
                else
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BlobSearchResult> SearchAsync(string containerName, BlobSearchOptions filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException("filter");
            }

            ValidateContainerName(containerName);

            CloudBlobContainer cloudBlobContainer = _cloudBlobClient.GetContainerReference(containerName);
            cloudBlobContainer.CreateIfNotExists(_requestOptions);

            BlobContinuationToken continueToken = null;

            if(!String.IsNullOrWhiteSpace(filter.ContinuationToken))
            {
                var base64Decode = Encoding.UTF8.GetString(Convert.FromBase64String(filter.ContinuationToken));
                using (var sr = new StringReader(base64Decode))
                {
                    using (var xmlReader = XmlReader.Create(sr))
                    {
                        continueToken = new BlobContinuationToken();
                        continueToken.ReadXml(xmlReader);
                    }
                }
            }

            var listSegements = await cloudBlobContainer.ListBlobsSegmentedAsync(filter.NamePrefix, true, BlobListingDetails.None,
                filter.MaxResults, continueToken, _requestOptions, null);

            BlobSearchResult result = new BlobSearchResult();
     
            if(listSegements.ContinuationToken != null)
            {
                using (var sw = new StringWriter())
                {
                    using (var xw = XmlWriter.Create(sw))
                    {
                        listSegements.ContinuationToken.WriteXml(xw);
                    }
                    result.ContinuationToken = Convert.ToBase64String(Encoding.UTF8.GetBytes( sw.ToString()));
                }
            }

            var blobList = new List<Accela.Infrastructure.Storage.BlobProperties>();

            foreach (var item in listSegements.Results)
            {
                var blob = item as CloudBlockBlob;
                if (blob != null)
                {
                    var bi = new Accela.Infrastructure.Storage.BlobProperties();
                    bi.ContainerName = item.Container.Name;
                    bi.BlobName = blob.Name;
                    bi.LastModified = blob.Properties.LastModified.HasValue ? blob.Properties.LastModified.Value.DateTime : (DateTime?)null;
                    bi.ContentEncoding = blob.Properties.ContentEncoding;
                    bi.ContentType = blob.Properties.ContentType;
                    bi.Length = blob.Properties.Length;
                    blobList.Add(bi);
                }
            }

            result.Results = blobList.AsEnumerable<Accela.Infrastructure.Storage.BlobProperties>();

            return result;
        }

        private CloudBlockBlob GetBlockBlobReference(string containerName, string blobName)
        {
            ValidateContainerName(containerName);
            ValidateBlobName(blobName);

            var cloudBlobContainer = _cloudBlobClient.GetContainerReference(containerName);
            cloudBlobContainer.CreateIfNotExists(_requestOptions);
            return cloudBlobContainer.GetBlockBlobReference(blobName);
        }

        private void ValidateBlobName(string blobName)
        {
            if (string.IsNullOrWhiteSpace(blobName))
            {
                throw new ArgumentNullException("blobName");
            }

            if (blobName.Length > Constants.BLOB_NAME_MAX_LENGTH)
            {
                throw new ArgumentOutOfRangeException(String.Format("blobName length exceeds the maximum limitation(250 characters)."));
            }
        }

        private static void ValidateContainerName(string containerName)
        {
            if (string.IsNullOrWhiteSpace(containerName))
            {
                throw new ArgumentNullException("containerName");
            }

            if (!IsContainerNameValid(containerName))
            {
                throw new ArgumentException("Invalid container name.", "containerName");
            }
        }

        private static bool IsContainerNameValid(string containerName)
        {
            string validBlobContainerNameRegex = @"^(([a-z\d]((-(?=[a-z\d]))|([a-z\d])){2,62})|(\$root))$";
            Regex reg = new Regex(validBlobContainerNameRegex);

            if (reg.IsMatch(containerName))
            {
                return true;
            }

            return false;
        }
    }
}
