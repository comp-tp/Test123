using Accela.Apps.Core;
using Accela.Core.Serialization;
using Accela.Infrastructure.Storage.SQLServer;
using Accela.Infrastructure.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.SQLServer.Tables
{
    public class SQLServerTableStorage<T> : ITableStorage<T> where T : class, ITableEntity, new()
    {
        ISQLServerTableStorageRepository _sqlServerTableStorageRepository;
        private IRetryPolicyConfiguration _retryPolicyConfiguration = null;

        public SQLServerTableStorage(ISQLServerTableStorageRepository sqlServerTableStorageRepository, IRetryPolicyConfiguration retryPolicyConfiguration = null)
        {
            if (sqlServerTableStorageRepository == null)
            {
                throw new ArgumentNullException("sqlServerTableStorageRepository");
            }

            _sqlServerTableStorageRepository = sqlServerTableStorageRepository;

            this._retryPolicyConfiguration = retryPolicyConfiguration;

            if (this._retryPolicyConfiguration != null)
            {
                SQLServerStorageDbConfiguration.DeltaBackoff = this._retryPolicyConfiguration.DeltaBackoff;
                SQLServerStorageDbConfiguration.MaxAttempts = this._retryPolicyConfiguration.MaxAttempts;
                SQLServerStorageDbConfiguration.RetryMethod = this._retryPolicyConfiguration.RetryMethod;
                SQLServerStorageDbConfiguration.RetrySpans = this._retryPolicyConfiguration.RetrySpans;
            }
        }

        public async Task CreateNewOrReplaceAsync(T entity, string tableName)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            if (String.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentNullException("tableName");
            }

            var tableEntity = ConvertToSqlEntity(entity);
            await _sqlServerTableStorageRepository.CreateNewOrReplaceAsync(tableEntity, tableName);
        }

        public async Task CreateNewOrReplaceAsync(T[] entities, string tableName)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }

            if (String.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentNullException("tableName");
            }

            var tableEntities = new List<SQLServerTableStorageEntity>();

            foreach (var entity in entities)
            {
                var tableEntity = ConvertToSqlEntity(entity);
                tableEntities.Add(tableEntity);
            }

            await _sqlServerTableStorageRepository.CreateNewOrReplaceAsync(tableEntities.ToArray(), tableName);
        }

        public async Task DeleteIfExistsAsync(T entity, string tableName)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            if (String.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentNullException("tableName");
            }

            var tableEntity = ConvertToSqlEntity(entity);
            await _sqlServerTableStorageRepository.DeleteIfExistsAsync(tableEntity, tableName);
        }

        public async Task<T> ReadAsync(string tableName, string partitionKey, string rowKey)
        {
            if (String.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentNullException("tableName");
            }

            if (String.IsNullOrWhiteSpace(partitionKey))
            {
                throw new ArgumentNullException("partitionKey");
            }

            if (String.IsNullOrWhiteSpace(rowKey))
            {
                throw new ArgumentNullException("rowKey");
            }

            var tempResult = await _sqlServerTableStorageRepository.ReadAsync(tableName, partitionKey, rowKey);
            var result = default(T);

            if (tempResult != null && tempResult.Content != null)
            {
                result = JsonSerializerService.Current.Deserialize<T>(tempResult.Content);
            }

            return result;
        }

        public async Task<PagedResults<T>> SearchAsync(TableSearchOptions searchOptions)
        {
            if (searchOptions == null)
            {
                throw new ArgumentNullException("searchOptions");
            }

            if (String.IsNullOrWhiteSpace(searchOptions.TableName))
            {
                throw new ArgumentNullException("searchOptions.TableName");
            }

            PagedResults<T> result = null;

            var dbPaginationModel = DbPaginationModel.ConvertFrom(searchOptions.ContinuationToken);
            var lastCount = dbPaginationModel != null ? dbPaginationModel.LastCount : -1;

            var sqlFilter = ConvertToSqlFilter(searchOptions.Filter);

            var tempItemsResult = await _sqlServerTableStorageRepository.SearchAsync(searchOptions.TableName, sqlFilter, lastCount, searchOptions.MaxResults);

            if (tempItemsResult != null)
            {
                var newRowNumber = tempItemsResult.Select(p => p.ID).OrderByDescending(p => p).FirstOrDefault();
                var tempResult = tempItemsResult.Select(p =>
                    JsonSerializerService.Current.Deserialize<T>(p.Content)).ToArray();

                var newDbPaginationModel = new DbPaginationModel()
                {
                    LastCount = newRowNumber
                };

                result = new PagedResults<T>()
                {
                    ContinuationToken = DbPaginationModel.ConvertToToken(newDbPaginationModel),
                    Results = tempResult
                };
            }

            return result;
        }

        private SQLServerTableStorageEntity ConvertToSqlEntity(T entity)
        {
            SQLServerTableStorageEntity result = null;
            var baseEntity = entity as ITableEntity;

            if (baseEntity != null)
            {
                result = new SQLServerTableStorageEntity()
                {
                    Content = JsonSerializerService.Current.Serialize(entity),
                    PartitionKey = baseEntity.PartitionKey,
                    RowKey = baseEntity.RowKey,
                    Timestamp = baseEntity.Timestamp
                };
            }

            return result;
        }

        private string ConvertToSqlFilter(string oDataFilter)
        {
            string result = null;

            var tempFilter = oDataFilter ?? String.Empty;
            tempFilter = tempFilter.Replace(" " + QueryComparisons.Equal + " ", " = ");
            tempFilter = tempFilter.Replace(" " + QueryComparisons.GreaterThan + " ", " > ");
            tempFilter = tempFilter.Replace(" " + QueryComparisons.GreaterThanOrEqual + " ", " >= ");
            tempFilter = tempFilter.Replace(" " + QueryComparisons.LessThan + " ", " < ");
            tempFilter = tempFilter.Replace(" " + QueryComparisons.LessThanOrEqual + " ", " <= ");
            tempFilter = tempFilter.Replace(" " + QueryComparisons.NotEqual + " ", " <> ");
            tempFilter = tempFilter.Replace("datetime'", " ");
            tempFilter = tempFilter.Replace("guid'", " ");
            tempFilter = tempFilter.Replace("X'", " ");
            tempFilter = tempFilter.Replace("L ", " ");

            if (tempFilter.EndsWith("L", StringComparison.Ordinal))
            {
                tempFilter = (tempFilter + " ").Replace("L ", "");
            }

            result = tempFilter;

            return result;
        }
    }
}
