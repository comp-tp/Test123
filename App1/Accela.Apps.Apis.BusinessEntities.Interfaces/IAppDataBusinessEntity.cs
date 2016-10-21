using Accela.Apps.Apis.Models.DTOs.Requests.AppDataRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AppDataResponses;

namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    /// <summary>
    /// App data business entity.
    /// </summary>
    public interface IAppDataBusinessEntity : IBusinessEntity
    {
        /// <summary>
        /// Get app data.
        /// </summary>
        /// <param name="appDataRequest">AppDataRequest.</param>
        /// <returns>Get app data response.</returns>
        GetAppDataResponse GetAppData(GetAppDataRequest appDataRequest);

        /// <summary>
        /// Save app data.
        /// </summary>
        /// <param name="createAppDataRequest">SaveAppDataRequest.</param>
        /// <returns>Save app data response.</returns>
        SaveAppDataResponse SaveAppData(SaveAppDataRequest createAppDataRequest);

        /// <summary>
        /// Delete app data.
        /// </summary>
        /// <param name="deleteAppDataRequest">Delete app data request.</param>
        /// <returns>Delete app data response.</returns>
        DeleteAppDataResponse DeleteAppData(DeleteAppDataRequest deleteAppDataRequest);
    }
}
