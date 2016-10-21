using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Storage.SQLServer.Binary
{
    public interface ISQLServerBinaryStorageRepository
    {
        Task<bool> ExistsAsync(string containerName, string blobName);
        Task<BlobItem> ReadAttributesAsync(string containerName, string blobName);
        Task<byte[]> ReadContentAsync(string containerName, string blobName);
        Task<bool> DeleteIfExistsAsync(string containerName, string blobName);
        Task<BlobItem[]> SearchAsync(string containerName, string namePrefix, long lastCount, int maxResults);
        Task<int> CreateAsync(BlobItem blobItem);
        Task<int> UpdateAsync(BlobItem blobItem);


        Task<BlobContainer> GetContainerAsync(string containerName);
        Task<int> CreateContainerAsync(BlobContainer blobContainer);
    }
}
