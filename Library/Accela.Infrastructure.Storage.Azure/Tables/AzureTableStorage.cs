using Accela.Infrastructure.Tables;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Accela.Infrastructure.Azure.Tables
{
    public class AzureTableStorage<T> : ITableStorage<T> where T : class, Accela.Infrastructure.Tables.ITableEntity,new()
    {
        private CloudTableClient _tableClient = null;
        private TableRequestOptions _requestOptions = null;

        public AzureTableStorage(IConnectionStringSetting connectionStringSetting, IRetryPolicyConfiguration retryPolicyConfiguration)
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
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);

            // Creates the Table service client.
            _tableClient = storageAccount.CreateCloudTableClient();

            TableRequestOptions requestOptions = null;
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
                else if(retryPolicyConfiguration.RetryMethod == RetryMethod.Discrete)
                {
                    throw new NotSupportedException("Doesn't support Discrete retry method in Azure implementation.");
                }

                if (azureRetryPolicy != null)
                {
                    requestOptions = new TableRequestOptions()
                    {
                        RetryPolicy = azureRetryPolicy,
                    };
                    _requestOptions = requestOptions;
                }
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

            // Create the CloudTable object that represents the Entity table.
            CloudTable table = _tableClient.GetTableReference(tableName);

            await table.CreateIfNotExistsAsync();
    
            var azureTableEntity = DynamicTableEntityConverter<T>.ToAzureTableEntity(entity);
            // Create the TableOperation that inserts the customer entity.
            TableOperation insertOperation = TableOperation.InsertOrReplace(azureTableEntity);
            
            var result = await table.ExecuteAsync(insertOperation, _requestOptions, null);
        }

        public async Task CreateNewOrReplaceAsync(T[] entities, string tableName)
        {
            if (entities == null || entities.Length == 0)
            {
                throw new ArgumentNullException("entities");
            }

            if (String.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentNullException("tableName");
            }

            // Create the CloudTable object that represents the Entity table.
            CloudTable table = _tableClient.GetTableReference(tableName);

            await table.CreateIfNotExistsAsync();

            var azureEntities = new List<Microsoft.WindowsAzure.Storage.Table.ITableEntity>();

            foreach(var entity in entities)
            {
                azureEntities.Add(DynamicTableEntityConverter<T>.ToAzureTableEntity(entity));
            }
            
            // Create the TableOperation that batch inserts the customer entities.
            TableBatchOperation batchOperation = new TableBatchOperation();
            foreach (var entity in azureEntities)
            {
                batchOperation.InsertOrReplace(entity);
            }

            var result = await table.ExecuteBatchAsync(batchOperation, _requestOptions, null);
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

            // Create the CloudTable object that represents the Entity table.
            CloudTable table = _tableClient.GetTableReference(tableName);

            TableOperation retrieveOperation = TableOperation.Retrieve<Microsoft.WindowsAzure.Storage.Table.ITableEntity>(entity.PartitionKey, entity.RowKey);

            // Execute the operation.
            TableResult retrievedResult = await table.ExecuteAsync(retrieveOperation);

            // Create the Delete TableOperation.
            if (retrievedResult.Result != null)
            {
                TableOperation deleteOperation = TableOperation.Delete((Microsoft.WindowsAzure.Storage.Table.ITableEntity)retrievedResult.Result);

                // Execute the operation.
                await table.ExecuteAsync(deleteOperation, _requestOptions, null);
            }
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

            // Create the CloudTable object that represents the Entity table.
            CloudTable table = _tableClient.GetTableReference(tableName);

            // Create a retrieve operation that takes a customer entity.
            TableOperation retrieveOperation = TableOperation.Retrieve(partitionKey, rowKey);

            // Execute the operation.
            TableResult retrievedResult = await table.ExecuteAsync(retrieveOperation, _requestOptions, null);

            var result = default(T);

            if (retrievedResult.Result != null)
            {
                result = DynamicTableEntityConverter<T>.ToITableEntity(retrievedResult.Result as DynamicTableEntity);
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

            // Create the CloudTable object that represents the Entity table.
            CloudTable table = _tableClient.GetTableReference(searchOptions.TableName);

            // Create the table query.
            TableQuery<Microsoft.WindowsAzure.Storage.Table.DynamicTableEntity> rangeQuery = null;

            if(String.IsNullOrWhiteSpace(searchOptions.Filter))
            {
                rangeQuery = new TableQuery<Microsoft.WindowsAzure.Storage.Table.DynamicTableEntity>();
            }
            else
            {
                rangeQuery = new TableQuery<Microsoft.WindowsAzure.Storage.Table.DynamicTableEntity>().Where(searchOptions.Filter);
            }

            // restore continuationToken string to object
            TableContinuationToken continuationToken = ConvertTokenStringToContinationTokenObject(searchOptions.ContinuationToken);

            var retriveAzureEntities = new List<Microsoft.WindowsAzure.Storage.Table.DynamicTableEntity>();
            do
            {
                var tableQueryResult =
                    await table.ExecuteQuerySegmentedAsync(rangeQuery.Take(searchOptions.MaxResults), continuationToken, _requestOptions, null);

                retriveAzureEntities.AddRange(tableQueryResult.Results);

                continuationToken = tableQueryResult.ContinuationToken;
            }
            while (continuationToken != null && retriveAzureEntities.Count < searchOptions.MaxResults);

            List<T> retriveEntities = new List<T>();
            retriveAzureEntities.ForEach(t => retriveEntities.Add(DynamicTableEntityConverter<T>.ToITableEntity(t)));

            PagedResults<T> pagedResults = new PagedResults<T>();
            pagedResults.Results = retriveEntities;
            pagedResults.ContinuationToken = ConvertContinationTokenObjectToString(continuationToken);

            return pagedResults;
        }

        private static string ConvertContinationTokenObjectToString(TableContinuationToken tokenObj)
        {
            if (tokenObj == null) return null;

            string restult = null;

            using (var sw = new StringWriter())
            {
                using (var xw = XmlWriter.Create(sw))
                {
                    tokenObj.WriteXml(xw);
                }
                restult = Convert.ToBase64String(Encoding.UTF8.GetBytes(sw.ToString()));
            }
            return restult;
        }

        private static TableContinuationToken ConvertTokenStringToContinationTokenObject(string tokenString)
        {
            if (String.IsNullOrWhiteSpace(tokenString)) return null;

            TableContinuationToken restult = null;
            var base64Decode = Encoding.UTF8.GetString(Convert.FromBase64String(tokenString));
            using (var sr = new StringReader(base64Decode))
            {
                using (var xmlReader = XmlReader.Create(sr))
                {
                    restult = new TableContinuationToken();
                    restult.ReadXml(xmlReader);
                }
            }

            return restult;
        }
    }
}
