using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Accela.Apps.Apis.Models.DomainModels;
using System.Threading.Tasks;

namespace Accela.Apps.Apis.Repositories.Interfaces
{
    public interface IMobileEntityRepository<T>
    {
        /// <summary>
        /// Insert an IMobileEntity object.
        /// </summary>
        /// <param name="entity">IMobileEntity object.</param>
        void InsertEntity(IMobileEntity entity);

        /// <summary>
        /// Batch insert IMobileEntity object.
        /// </summary>
        /// <param name="entities">an IMobileEntity collection.</param>
        void InsertEntities(IList<IMobileEntity> entities);
        
        /// <summary>
        /// Updates an IMobileEntity object.
        /// </summary>
        /// <param name="entity">IMobileEntity object.</param>
        void UpdateEntity(IMobileEntity entity);

        /// <summary>
        /// Delete an IMobileEntity object.
        /// </summary>
        /// <param name="entity">IMobileEntity object.</param>
        void DeleteEntity(IMobileEntity entity);

        /// <summary>
        /// Delete user's cached data.
        /// </summary>
        /// <param name="scope">IEntityScope.</param>
        void DeleteEntitiesByUser(IEntityScope scope);

        /// <summary>
        /// Get an instance of T by entity id.
        /// </summary>
        /// <param name="scope">entity scope.</param>
        /// <param name="entityId">entity id.</param>
        /// <param name="isInvariantCulture">is invariant culture for cache, 
        /// ture: cache are different against different culture, 
        /// false: cache are same against different culture</param>
        /// <returns>an instance of T.</returns>
        K GetObjectById<K>(IEntityScope scope, string entityId, bool isInvariantCulture = false);

        /// <summary>
        /// Get All entities.
        /// </summary>
        /// <param name="scope">entity scope.</param>
        /// <returns>a T list.</returns>
        //IList<T> GetEntities(IEntityScope scope);

        /// <summary>
        /// Query T with an expression.
        /// </summary>
        /// <param name="scope">entity scope.</param>
        /// <param name="expression">filter expression.</param>
        /// <returns>a T list.</returns>
        IList<T> Query(IEntityScope scope, Expression<Func<T, bool>> expression);

        /// <summary>
        /// Removes the expired entities.
        /// </summary>
        void RemoveExpiredItems();

        /// <summary>
        /// Generates the blob name. 
        /// </summary>
        /// <param name="scope">Entity Scope.</param>
        /// <param name="blobKey">blob key.</param>
        /// <returns>blob name.</returns>
        string BuildBlobName(IEntityScope scope, string blobKey);
    }
}
