using System;
using Accela.Apps.Apis.Models.DomainModels;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Contexts;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    public static class QueryHelpler
    {
        /// <summary>
        /// Gets the entity scope.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="agency">agency name.</param>
        /// <returns>the entity scope.</returns>
        public static IEntityScope GetEntityScope(EntityTypes entityType, IAgencyAppContext agencyContext)
        {
            var scope = new EntityScope();
            scope.Agency = agencyContext.Agency;
            scope.ProductName = agencyContext.App;
            scope.EntityType = entityType.ToString();
            var cloudUserId = agencyContext.ContextUser == null ? Guid.Empty : agencyContext.ContextUser.Id;
            var agencyId = agencyContext.ContextUser == null ? Guid.Empty : agencyContext.ContextUser.AgencyID;
            var isReferenceType = IsReferenceType(entityType);
            scope.UserId = isReferenceType ? agencyId : cloudUserId;

            string language = String.IsNullOrEmpty(agencyContext.Language) ? String.Empty : agencyContext.Language.ToLower().Replace("_", "-");

            if(!String.IsNullOrWhiteSpace(language))
            {
                scope.Namespace = scope.UserId + "-" + agencyContext.EnvName.ToLowerInvariant() + "-" + language;
            }
            else
            {
                scope.Namespace = scope.UserId + "-" + agencyContext.EnvName.ToLowerInvariant();
            }
            
            return scope;
        }

        /// <summary>
        /// Determines whether [is reference type] [the specified entity type].
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <returns>
        /// <c>true</c> if [is reference type] [the specified entity type]; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsReferenceType(EntityTypes entityType)
        {
            bool result = false;

            switch (entityType)
            {
                case EntityTypes.StandardCommentGroup:
                case EntityTypes.StandardComment:
                case EntityTypes.DepartmentWithInspector:
                case EntityTypes.AssetASIAndASIT:
                case EntityTypes.AssetType:
                case EntityTypes.SystemInspector:
                case EntityTypes.SystemDepartment:
                    result = true;
                    break;
            }

            return result;
        }
    }
}
