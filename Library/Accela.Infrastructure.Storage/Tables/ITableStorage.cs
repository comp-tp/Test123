using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Tables
{
    /// <summary>
    /// All operations are based on Table. There will exist TableStorageProvider to create TableStorage adapter.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITableStorage<T> where T : class, ITableEntity,new()
    {
        /// <summary>
        /// Create a new entity item or update an entity if exists.
        /// </summary>
        /// <param name="entity"></param>
        Task CreateNewOrReplaceAsync(T entity, string tableName);

        /// <summary>
        /// Batches create or update.
        /// </summary>
        /// <param name="entities">The entities.</param>
        Task CreateNewOrReplaceAsync(T[] entities, string tableName);

        /// <summary>
        /// Delete a entity item.
        /// </summary>
        /// <param name="entity"></param>
        Task DeleteIfExistsAsync(T entity, string tableName);

        ///// <summary>
        ///// Delete a entity item by key.
        ///// </summary>
        ///// <param name="entity"></param>
        //void DeleteIfExistsAsync(string partitionKey, string rowKey);

        /// <summary>
        /// Read (select) the specified row in the specified partition from the client table.
        /// </summary>
        /// <param name="partitionKey">The partition key.</param>
        /// <param name="rowKey">The row key.</param>
        /// <returns></returns>
        Task<T> ReadAsync(string tableName, string partitionKey, string rowKey);

        /// <summary>
        /// Search the specified rows in the specified partitions and rows.
        /// </summary>
        /// <param name="partitionKeys">The partition keys.</param>
        Task<PagedResults<T>> SearchAsync(TableSearchOptions searchOptions);
    }
}
