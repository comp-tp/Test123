using Accela.Infrastructure.SQLServer.Table;
using Accela.Infrastructure.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.SQLServer.Tables
{
    public class SQLServerTableStorageRepository : ISQLServerTableStorageRepository
    {
        string _connectionString;

        public SQLServerTableStorageRepository(string connectionString)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException("connectionString");
            }

            _connectionString = connectionString;
        }

        public async Task CreateNewOrReplaceAsync(SQLServerTableStorageEntity entity, string tableName)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            if (String.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentNullException("tableName");
            }

            using (var dbContext = GetDbContext())
            {
                await dbContext.Database.ExecuteSqlCommandAsync(
                        @"[dbo].[createOrReplaceTableEntity] @tableName, @partitionKey, @rowKey, @timestamp, @content"
                        , new SqlParameter("@tableName", tableName)
                        , new SqlParameter("@partitionKey", entity.PartitionKey)
                        , new SqlParameter("@rowKey", entity.RowKey)
                        , new SqlParameter("@timestamp", entity.Timestamp)
                        , new SqlParameter("@content", entity.Content)
                        );
            }
        }

        public async Task CreateNewOrReplaceAsync(SQLServerTableStorageEntity[] entities, string tableName)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }

            if (String.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentNullException("tableName");
            }

            using (var dbContext = GetDbContext())
            {
                foreach (var entity in entities)
                {
                    await dbContext.Database.ExecuteSqlCommandAsync(
                        @"[dbo].[createOrReplaceTableEntity] @tableName, @partitionKey, @rowKey, @timestamp, @content"
                        , new SqlParameter("@tableName", tableName)
                        , new SqlParameter("@partitionKey", entity.PartitionKey)
                        , new SqlParameter("@rowKey", entity.RowKey)
                        , new SqlParameter("@timestamp", entity.Timestamp)
                        , new SqlParameter("@content", entity.Content)
                        );
                }
            }
        }

        public async Task DeleteIfExistsAsync(SQLServerTableStorageEntity entity, string tableName)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            if (String.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentNullException("tableName");
            }

            var result = false;

            using (var dbContext = GetDbContext())
            {
                var tempResult = new SqlParameter() { ParameterName = "@result", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
                await dbContext.Database.ExecuteSqlCommandAsync(
                        @"[dbo].[deleteTableEntityIfExists] @tableName, @partitionKey, @rowKey, @result output"
                        , new SqlParameter("@tableName", tableName)
                        , new SqlParameter("@partitionKey", entity.PartitionKey)
                        , new SqlParameter("@rowKey", entity.RowKey)
                        , tempResult
                        );
                result = Convert.ToBoolean(tempResult.Value);
            }
        }

        public async Task<SQLServerTableStorageEntity> ReadAsync(string tableName, string partitionKey, string rowKey)
        {
            if (String.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentNullException("tableName");
            }

            if (partitionKey == null)
            {
                throw new ArgumentNullException("partitionKey");
            }

            if (rowKey == null)
            {
                throw new ArgumentNullException("rowKey");
            }

            SQLServerTableStorageEntity result = null;

            using (var dbContext = GetDbContext())
            {
                var tempResult = dbContext.Database.SqlQuery<SQLServerTableStorageEntity>(
                        @"[dbo].[getTableEntity] @tableName, @partitionKey, @rowKey"
                        , new SqlParameter("@tableName", tableName)
                        , new SqlParameter("@partitionKey", partitionKey)
                        , new SqlParameter("@rowKey", rowKey)
                        );

                result = await tempResult.FirstOrDefaultAsync();
            }

            return result;
        }

        public async Task<SQLServerTableStorageEntity[]> SearchAsync(string tableName, string filter, long lastCount, int maxResults)
        {
            if (String.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentNullException("tableName");
            }

            SQLServerTableStorageEntity[] result = null;

            using (var dbContext = GetDbContext())
            {
                var tempResult = dbContext.Database.SqlQuery<SQLServerTableStorageEntity>(
                        @"[dbo].[searchTableEntities] @tableName, @filter, @lastRowId, @maxResults"
                        , new SqlParameter("@tableName", tableName)
                        , new SqlParameter("@filter", filter)
                        , new SqlParameter("@lastRowId", lastCount)
                        , new SqlParameter("@maxResults", maxResults)
                        );

                result = await tempResult.ToArrayAsync();
            }

            return result;
        }

        public async Task<bool> ExistsAsync(string tableName)
        {
            var result = false;

            using (var dbContext = GetDbContext())
            {
                var tempResult = new SqlParameter() { ParameterName = "@result", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
                await dbContext.Database.ExecuteSqlCommandAsync(
                        @"[dbo].[existsTable] @tableName, @result output"
                        , new SqlParameter("@tableName", tableName)
                        , tempResult
                        );

                result = Convert.ToBoolean(tempResult.Value);
            }

            return result;
        }

        public async Task CreateTableIfNotExist(string tableName)
        {
            using (var dbContext = GetDbContext())
            {
                await dbContext.Database.ExecuteSqlCommandAsync(
                        @"[dbo].[createTableIfNotExist] @tableName"
                        , new SqlParameter("@tableName", tableName)
                        );
            }
        }

        private TableDBContext GetDbContext()
        {
            return new TableDBContext(_connectionString);
        }
    }
}
