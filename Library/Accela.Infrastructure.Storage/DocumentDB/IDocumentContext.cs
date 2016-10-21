using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.DocumentDB
{
    /// <summary>
    /// All operations are based on No-SQL Document DB. There will exist DocumentDBProvider to create DocumentDB adapter.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDocumentContext<T> where T : class
    {
        void Init(string connectionString, IRetryPolicyConfiguration retryPolicyConfiguration);

        /// <summary>
        /// check whether a collection exists or not
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        bool CollectionExists(string collection);

        /// <summary>
        /// create a collection for documents
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        Task<bool> CreateCollectionAsync(string collection);

        /// <summary>
        /// Create a new entity item as document
        /// </summary>
        /// <param name="entity"></param>
        Task<string> CreateAsync(T entity, string collection);

        /// <summary>
        /// Create a new entity item as document
        /// </summary>
        /// <param name="content"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        Task<string> CreateAsync(Stream content, string collection);

        /// <summary>
        /// Batches create.
        /// </summary>
        /// <param name="entities">The entities.</param>
        Task<string[]> CreateAsync(T[] entities, string collection);

        /// <summary>
        /// Delete a entity item.
        /// </summary>
        /// <param name="entity"></param>
        Task<T> UpdateAsync(string docId, string collection, T entity);

        /// <summary>
        /// Delete a entity item.
        /// </summary>
        /// <param name="entity"></param>
        Task<bool> DeleteAsync(string docId, string collection);

        /// <summary>
        /// Delete enties satisfying the criteria
        /// </summary>
        /// <param name="entity"></param>
        Task<bool> DeleteAsync(DocumentSearchOptions filter);

        /// <summary>
        /// Read (select) the specified row in the specified partition from the client table.
        /// </summary>
        /// <param name="partitionKey">The partition key.</param>
        /// <param name="rowKey">The row key.</param>
        /// <returns></returns>
        Task<T> ReadAsync(string docId, string collection);

        /// <summary>
        /// Search the specified rows in the specified partitions and rows.
        /// </summary>
        /// <param name="partitionKeys">The partition keys.</param>
        Task<PagedResults<T>> SearchAsync(DocumentSearchOptions searchOptions);
    }
}
