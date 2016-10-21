using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Storage
{
    public interface IBinaryStorage
    {
        Task<bool> ExistsAsync(string containerName, string blobName);

        Task<BlobProperties> ReadAttributesAsync(string containerName, string blobName);

        Task<Stream> ReadAsStreamAsync(string containerName, string blobName);

        Task<string> ReadAsStringAsync(string containerName, string blobName);

        Task CreateNewAsync(string containerName, string blobName, Stream content);

        Task CreateNewAsync(string containerName, string blobName, string content);

        Task CreateNewOrUpdateAsync(string containerName, string blobName, Stream content);

        Task CreateNewOrUpdateAsync(string containerName, string blobName, string content);

        Task<bool> DeleteIfExistsAsync(string containerName, string blobName);

        /// <summary>
        /// deletes the container if it already exists.
        /// </summary>
        /// <param name="containerName">container name.</param>
        /// <returns>true if the container did not already exist and was created; otherwise false.</returns>
        Task<bool> DeleteContainerIfExistsAsync(string containerName);

        Task<BlobSearchResult> SearchAsync(string containerName, BlobSearchOptions filter);
    }
}
