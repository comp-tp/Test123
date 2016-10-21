using Accela.Apps.Apis.Models.DomainModels;
using Accela.Apps.Apis.Repositories.GovXmlHelpers;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Contexts;
using System;

namespace Accela.Apps.Apis.Repositories.Agency
{
    public class CacheBase : RepositoryBase
    {
        public CacheBase()
        { 
        
        }

        /// <summary>
        /// Builds the mobile entity.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="cacheKey">The cache id.</param>
        /// <param name="cacheData">The cache data.</param>
        /// <returns>the mobile entity.</returns>
        protected IMobileEntity BuildMobileEntity(IEntityScope scope, string cacheKey, string cacheData)
        {
            IMobileEntity result = new MobileEntity(scope);
            result.ObjectId = cacheKey;
            result.ObjectData = cacheData;
            DateTime timestamp = DateTime.UtcNow;
            result.Timestamp = timestamp;
            var entityType = (EntityTypes)Enum.Parse(typeof(EntityTypes), scope.EntityType);
            var cacheInterval = this.GetCacheInterval(entityType);
            result.ExpiresAfter = timestamp.AddMinutes(cacheInterval);
            result.EntityType = scope.EntityType;
            return result;
        }

        /// <summary>
        /// Gets the cache interval.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <returns>the cache interval.</returns>
        protected int GetCacheInterval(EntityTypes entityType)
        {
            int result = Constants.CACHE_EXPIRED_PERIOD;

            switch (entityType)
            {
                case EntityTypes.DepartmentWithInspector:
                case EntityTypes.InspectionRefType:
                case EntityTypes.StandardComment:
                case EntityTypes.StandardCommentGroup:
                case EntityTypes.AssetASIAndASIT:
                case EntityTypes.AssetType:
                case EntityTypes.RecordType:
                case EntityTypes.ASIAndASIT:
                case EntityTypes.InspectionGroup:
                    result = 1440; // 24h, need to allow modify the value in config file later
                    break;
                case EntityTypes.AttachmentFileInfo:
                case EntityTypes.AttachmentFileThumbnailInfo:
                    result = 2880;
                    break;
            }

            return result;
        }

        protected void DoCache<T>(IMobileEntityRepository<T> entityRepository, EntityTypes entityType, DataModel dataModel, string cacheKey, IAgencyAppContext agencyContext) where T : DataModel
        {
            var scope = QueryHelpler.GetEntityScope(entityType, agencyContext);
            var cacheData = JsonConverter.ToJson(dataModel);
            var entity = this.BuildMobileEntity(scope, cacheKey, cacheData);
            entityRepository.DeleteEntity(entity);
            entityRepository.InsertEntity(entity);
        }
    }
}
