using Accela.Infrastructure.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.SQLServer.Tables
{
    public interface ISQLServerTableStorageRepository
    {
        Task CreateNewOrReplaceAsync(SQLServerTableStorageEntity entity, string tableName);

        Task CreateNewOrReplaceAsync(SQLServerTableStorageEntity[] entities, string tableName);

        Task DeleteIfExistsAsync(SQLServerTableStorageEntity entity, string tableName);

        Task<SQLServerTableStorageEntity> ReadAsync(string tableName, string partitionKey, string rowKey);

        Task<SQLServerTableStorageEntity[]> SearchAsync(string tableName, string filter, long lastCount, int maxResults);

        Task<bool> ExistsAsync(string tableName);

        Task CreateTableIfNotExist(string tableName);
    }
}
