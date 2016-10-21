using System;
using Accela.Apps.Apis.Models.DomainModels.GlobalEntityModels;
using Accela.Apps.Apis.Models.DTOs.Responses.GlobalEntityResponse;
using Accela.Apps.Apis.Models.DTOs.Requests.GlobalEntityRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;
using Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests;

namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    /// <summary>
    /// Global entity business entity interface.
    /// </summary>
    public interface IGlobalEntityBusinessEntity : IBusinessEntity
    {

        /// <summary>
        /// Count record num according to record type.
        /// </summary>
        /// <param name="countRecordNumRequest">Count Record Num Request</param>
        /// <returns>Record type and num count list.</returns>
        GetRecordCountByRecordTypeResponse CountRecordNumByRecordType(GetRecordCountByRecordTypeRequest countRecordNumRequest);

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
        /// <returns>GlobalEntityModel.</returns>
        GlobalEntityModel GetGlobalEntity(string entityID, string entityType, string agencyName, string enviroment);

        /// <summary>
        /// Get global entity according to specified entity id, agency name and environment name.
        /// </summary>
        /// <param name="entityID">Entity ID.</param>   
        /// <param name="agencyName">Agency name.</param>
        /// <param name="environment">Environment.</param>
        /// <returns>GlobalEntityModel.</returns>
        GlobalEntityModel GetGlobalEntity(string entityID, string agencyName, string enviroment);

        GetGlobalEntityResponse GlobalEntity(GetGlobalEntityRequest request);

        /// <summary>
        /// Update Global Entity Model
        /// </summary>
        /// <param name="globalEntityModel">Global entity model</param>
        /// <returns>Global entity model</returns>
        GlobalEntityModel Update(GlobalEntityModel globalEntityModel);

        /// <summary>
        /// Add a new global entity model.
        /// </summary>
        /// <param name="globalEntityModel">Global entity model.</param>
        /// <returns>Global entity model.</returns>
        GlobalEntityModel AddIfNotExist(GlobalEntityModel globalEntityModel);

        /// <summary>
        /// Get Record Count(including total count,posted count and closed count)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetGlobalEntitiesCountResponse GetGlobalEntitiesCount(GetGlobalEntitiesCountRequest request);

        /// <summary>
        /// Search global entities.
        /// </summary>
        /// <param name="request">Search entities request.</param>
        /// <returns>Search results.</returns>
        GetGlobalEntitiesResponse SearchGlobalEntities(GetGlobalEntitiesRequest request);

        /// <summary>
        /// Nearby records
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        RecordsGeoResponse GetRecordsViaGeo(RecordsGeoRequest o);
    }
}
