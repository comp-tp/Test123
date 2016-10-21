using System;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.Models.DTOs.Requests.EnvironmentRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.EnvironmentResponses;

namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    public interface IEnvironmentBusinessEntity
    {
        /// <summary>
        /// Gets the agency default environment.
        /// </summary>
        /// <param name="agencyName">Name of the agency.</param>
        /// <returns>
        /// HostEnvModel
        /// </returns>
        HostEnvModel GetAgencyDefaultEnvironment(string agencyName);

        /// <summary>
        /// Get environment by id.
        /// </summary>
        /// <param name="getEnvironmentRequest">getEnvironmentRequest.</param>
        /// <returns>GetEnvironmentResponse.</returns>
        GetEnvironmentResponse GetEnvironment(GetEnvironmentRequest getEnvironmentRequest);

        /// <summary>
        /// Update server.
        /// </summary>
        /// <param name="updateEnvironmentRequest">updateEnvironmentRequest.</param>
        /// <returns>UpdateEnvironmentResponse.</returns>
        UpdateEnvironmentResponse UpdateServer(UpdateEnvironmentServerRequest updateEnvironmentServerRequest);

        /// <summary>
        /// Add server.
        /// </summary>
        /// <param name="updateEnvironmentRequest">newEnvironmentServerRequest.</param>
        /// <returns>UpdateEnvironmentResponse.</returns>
        UpdateEnvironmentResponse AddServer(UpdateEnvironmentServerRequest newEnvironmentServerRequest);

        /// <summary>
        /// Delet server.
        /// </summary>
        /// <param name="sDetailId">sDetailId.</param>
        /// <returns>UpdateEnvironmentResponse.</returns>
        UpdateEnvironmentResponse DelServer(Guid detailId);
    }
}
