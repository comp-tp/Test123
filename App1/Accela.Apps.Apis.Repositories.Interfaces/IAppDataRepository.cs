using Accela.Apps.Apis.Models.DTOs.Requests.AppDataRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AppDataResponses;

namespace Accela.Apps.Apis.Repositories.Interfaces
{
    /// <summary>
    /// App data repository interface.
    /// </summary>
    public interface IAppDataRepository : IRepository
    {
        /// <summary>
        /// Get app data.
        /// </summary>
        /// <param name="appDataRequest">Get app data request.</param>
        /// <returns>Get app data response.</returns>
        GetAppDataResponse GetAppData(GetAppDataRequest appDataRequest);

        /// <summary>
        /// Save app data.
        /// </summary>
        /// <param name="saveAppDataRequest">Save app data request.</param>
        /// <returns>SaveAppDataResponse.</returns>
        SaveAppDataResponse SaveAppData(SaveAppDataRequest saveAppDataRequest);

        /// <summary>
        /// Delete app data.
        /// </summary>
        /// <param name="deleteAppDataRequest">Delete app data request.</param>
        /// <returns>Delete app data response.</returns>
        DeleteAppDataResponse DeleteAppData(DeleteAppDataRequest deleteAppDataRequest);
    }
}
