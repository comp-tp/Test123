using System;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.GlobalEntityModels;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.Models.DTOs.Responses.GlobalEntityResponse;
using Accela.Apps.Apis.Models.DTOs.Requests.GlobalEntityRequests;

namespace Accela.Apps.Apis.Repositories.Interfaces
{
    /// <summary>
    /// Global entity repository interface.
    /// </summary>
    public interface IGlobalEntityRepository : IRepository
    {
        /// <summary>
        /// Get global entity by id.
        /// </summary>
        /// <param name="id">ID.</param>
        /// <returns>GlobalEntityModel.</returns>
        GlobalEntityModel GetGlobalEntity(Guid id);

        /// <summary>
        /// Get global entity according to specified entity id,entity type, agency name and environment name.
        /// </summary>
        /// <param name="entityID">Entity ID.</param>
        /// <param name="entityType">Entity type.</param>
        /// <param name="agencyName">Agency name.</param>
        /// <param name="environment">Environment.</param>
        /// <returns>GlobalEntityModel</returns>
        GlobalEntityModel GetGlobalEntity(string entityID, string entityType, string agencyName, string environment);

        /// <summary>
        /// Get global entity according to specified entity id, agency name and environment name.
        /// </summary>
        /// <param name="entityID">Entity ID.</param>
        /// <param name="agencyName">Agency name.</param>
        /// <param name="enviroment">Environment.</param>
        /// <returns>GlobalEntityModel.</returns>
        GlobalEntityModel GetGlobalEntity(string entityID, string agencyName, string enviroment);

        /// <summary>
        /// Get global entities by civic id.
        /// </summary>
        /// <param name="civicId">CivicId.</param>  
        /// <param name="type">Type.</param>
        /// <param name="enviroment">Environment.</param>
        /// <returns>Record count.</returns>
        int GetGlobalEntitiesCountByCivicId(Guid civicId, string type, string enviroment);

        /// <summary>
        /// Get global entities by civic id.
        /// </summary>
        /// <param name="civicId">CivicId.</param> 
        /// <param name="type">Type.</param>
        /// <param name="enviroment">Environment.</param>
        /// <param name="offSet">Offset.</param>
        /// <param name="limit">Limit.</param>
        /// <returns>GlobalEntityModel list.</returns>
        List<RecordGeoModel> GetGlobalEntitiesByCivicId(Guid civicId, string type, string enviroment, int offSet, int limit);

        /// <summary>
        /// Add a new global entity model
        /// </summary>
        /// <param name="globalEntityModel">Global entity model.</param>
        /// <returns>Global entity model.</returns>
        GlobalEntityModel AddIfNotExist(GlobalEntityModel globalEntityModel);

        /// <summary>
        /// Search global entities.
        /// </summary>
        /// <param name="agencyName">Agency Name.</param>
        /// <param name="environment">Environment.</param>
        /// <param name="entityType">Entity Type.</param>
        /// <param name="searchConditions">Search Conditions.</param>
        /// <param name="sortExpression">Sort Expression.</param>
        /// <param name="pageIndex">Page Index.</param>
        /// <param name="pageSize">Page Size.</param>
        /// <param name="count">Record Count.</param>
        /// <returns>Global entities.</returns>
        List<GlobalEntityModel> SearchGlobalEntities(string agencyName,
                                                     string environment,
                                                     string entityType,
                                                     IDictionary<string, string> searchConditions,
                                                     string sortExpression,
                                                     int pageIndex,
                                                     int pageSize,
                                                     out int count);

        /// <summary>
        /// Count record num according to record type.
        /// </summary>
        /// <param name="angecyName">Agency name.</param>
        /// <param name="entityType">Entity type.</param>
        /// <param name="environment">Environment.</param>
        /// <returns>Record type and num count list.</returns>
        Dictionary<string, int> CountRecordNumByRecordType(string angecyName, string entityType, string environment);

        /// <summary>
        /// Get globalentities count(including total count,posted count and closed count).
        /// </summary>
        /// <param name="request">GetGlobalEntitiesCount Request</param>
        /// <returns>GetGlobalEntitiesCount Response</returns>
        GetGlobalEntitiesCountResponse GetGlobalEntitiesCount(GetGlobalEntitiesCountRequest request);

        /// <summary>
        /// Add a new global entity model
        /// </summary>
        /// <param name="globalEntityModel">Global entity model.</param>
        /// <returns>Global entity model.</returns>
        GlobalEntityModel Update(GlobalEntityModel globalEntityModel);

    }
}
