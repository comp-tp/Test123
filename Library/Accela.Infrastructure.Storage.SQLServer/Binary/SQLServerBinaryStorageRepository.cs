using Accela.Infrastructure.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Storage.SQLServer.Binary
{
    public class SQLServerBinaryStorageRepository : ISQLServerBinaryStorageRepository
    {
        string _connectionString;

        public SQLServerBinaryStorageRepository(string connectionString)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException("connectionString");
            }

            _connectionString = connectionString;
        }

        public async Task<bool> ExistsAsync(string containerName, string blobName)
        {
            var result = false;

            using (var dbContext = GetDbContext())
            {
                var tempResult = new SqlParameter() { ParameterName = "@result", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
                await dbContext.Database.ExecuteSqlCommandAsync(
                        @"[dbo].[existsBlob] @containerName, @blobName, @result output"
                        , new SqlParameter("@containerName", containerName)
                        , new SqlParameter("@blobName", blobName)
                        , tempResult
                        );

                result = Convert.ToBoolean(tempResult.Value);
            }

            return result;
        }

        public async Task<BlobItem> ReadAttributesAsync(string containerName, string blobName)
        {
            BlobItem result = null;

            using (var dbContext = GetDbContext())
            {
                var tempResult = dbContext.Database.SqlQuery<BlobItem>(
                        @"[dbo].[getBlobAttributes] @containerName, @blobName"
                        , new SqlParameter("@containerName", containerName)
                        , new SqlParameter("@blobName", blobName)
                        );

                result = await tempResult.FirstOrDefaultAsync();
            }

            return result;
        }

        public async Task<byte[]> ReadContentAsync(string containerName, string blobName)
        {
            byte[] result = null;

            using (var dbContext = GetDbContext())
            {
                var tempResult = dbContext.Database.SqlQuery<byte[]>(
                        @"[dbo].[getBlobContent] @containerName, @blobName"
                        , new SqlParameter("@containerName", containerName)
                        , new SqlParameter("@blobName", blobName)
                        );

                result = await tempResult.FirstOrDefaultAsync();
            }

            return result;
        }

        public async Task<bool> DeleteIfExistsAsync(string containerName, string blobName)
        {
            bool result = false;

            using (var dbContext = GetDbContext())
            {
                var tempResult = new SqlParameter() { ParameterName = "@result", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
                await dbContext.Database.ExecuteSqlCommandAsync(
                        @"[dbo].[deleteBlobIfExists] @containerName, @blobName, @result output"
                        , new SqlParameter("@containerName", containerName)
                        , new SqlParameter("@blobName", blobName)
                        , tempResult
                        );

                result = Convert.ToBoolean(tempResult.Value);
            }

            return result;
        }

        public async Task<BlobItem[]> SearchAsync(string containerName, string namePrefix, long lastCount, int maxResults)
        {
            BlobItem[] result = null;

            using (var dbContext = GetDbContext())
            {
                var tempResult = dbContext.Database.SqlQuery<BlobItem>(
                        @"[dbo].[searchBlobs] @containerName, @namePrefix, @lastCount, @maxResults"
                        , new SqlParameter() { ParameterName = "@containerName", Value = containerName, IsNullable = true }
                        , new SqlParameter() { ParameterName = "@namePrefix", Value = String.IsNullOrWhiteSpace(namePrefix) ? (object)DBNull.Value : namePrefix, IsNullable = true }
                        , new SqlParameter("@lastCount", lastCount)
                        , new SqlParameter("@maxResults", maxResults)
                        );

                result = await tempResult.ToArrayAsync();
            }

            return result;
        }

        public async Task<int> CreateAsync(BlobItem blobItem)
        {
            int result = 0;

            using (var dbContext = GetDbContext())
            {
                result = await dbContext.Database.ExecuteSqlCommandAsync(
                        @"[dbo].[createBlobItem] @Id, @ContainerId, @Name, @Content, @ContentEncoding, @ContentType, @ContentLength, @CreatedBy, @CreatedDate"
                        , new SqlParameter("@Id", blobItem.Id)
                        , new SqlParameter("@ContainerId", blobItem.ContainerId)
                        , new SqlParameter("@Name", blobItem.Name)
                        , new SqlParameter("@Content", blobItem.Content)
                        , new SqlParameter() { ParameterName = "@ContentEncoding", Value = String.IsNullOrWhiteSpace(blobItem.ContentEncoding) ? (object)DBNull.Value : blobItem.ContentEncoding, IsNullable = true }
                        , new SqlParameter() { ParameterName = "@ContentType", Value = String.IsNullOrWhiteSpace(blobItem.ContentType) ? (object)DBNull.Value : blobItem.ContentType, IsNullable = true }
                        , new SqlParameter("@ContentLength", blobItem.ContentLength)
                        , new SqlParameter("@CreatedBy", blobItem.CreatedBy)
                        , new SqlParameter("@CreatedDate", blobItem.CreatedDate)
                        );
            }

            return result;
        }

        public async Task<int> UpdateAsync(BlobItem blobItem)
        {
            int result = 0;

            using (var dbContext = GetDbContext())
            {
                result = await dbContext.Database.ExecuteSqlCommandAsync(
                        @"[dbo].[updateBlobItem] @Id, @ContainerId, @Name, @Content, @ContentEncoding, @ContentType, @ContentLength, @LastUpdatedBy,  @LastUpdatedDate"
                        , new SqlParameter("@Id", blobItem.Id)
                        , new SqlParameter("@ContainerId", blobItem.ContainerId)
                        , new SqlParameter("@Name", blobItem.Name)
                        , new SqlParameter("@Content", blobItem.Content)
                        , new SqlParameter() { ParameterName = "@ContentEncoding", Value = String.IsNullOrWhiteSpace(blobItem.ContentEncoding) ? (object)DBNull.Value : blobItem.ContentEncoding, IsNullable = true }
                        , new SqlParameter() { ParameterName = "@ContentType", Value = String.IsNullOrWhiteSpace(blobItem.ContentType) ? (object)DBNull.Value : blobItem.ContentType, IsNullable = true }
                        , new SqlParameter("@ContentLength", blobItem.ContentLength)
                        , new SqlParameter("@LastUpdatedBy", blobItem.LastUpdatedBy)
                        , new SqlParameter("@LastUpdatedDate", blobItem.LastUpdatedDate)
                        );
            }

            return result;
        }

        public async Task<BlobContainer> GetContainerAsync(string containerName)
        {
            BlobContainer result = null;

            using (var dbContext = GetDbContext())
            {
                var tempResult = dbContext.Database.SqlQuery<BlobContainer>(
                        @"[dbo].[getBlobContainer] @containerName"
                        , new SqlParameter("@containerName", containerName)
                        );

                result = await tempResult.FirstOrDefaultAsync();
            }

            return result;
        }

        public async Task<int> CreateContainerAsync(BlobContainer blobContainer)
        {
            int result = 0;

            using (var dbContext = GetDbContext())
            {
                result = await dbContext.Database.ExecuteSqlCommandAsync(
                         @"[dbo].[createBlobContainer] @Id, @Name, @CreatedBy, @CreatedDate"
                         , new SqlParameter("@Id", blobContainer.Id)
                         , new SqlParameter("@Name", blobContainer.Name)
                         , new SqlParameter("@CreatedBy", blobContainer.CreatedBy)
                         , new SqlParameter("@CreatedDate", blobContainer.CreatedDate)
                         );
            }

            return result;
        }

        private SQLServerBinaryStorageEntities GetDbContext()
        {
            var result = new SQLServerBinaryStorageEntities(_connectionString);
            return result;
        }
    }
}
