using System;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Dev.WSModels.V2;

namespace Accela.Apps.Apis.Repositories.Interfaces.Admin
{
    /// <summary>
    /// App repository
    /// </summary>
    public interface IAppRepository : IRepository
    {
        ///// <summary>
        ///// Get App by App Id
        ///// </summary>
        ///// <param name="id">App Id(primary Key)</param>
        ///// <returns>return App that according Id</returns>
        //AppModel GetAppByID(Guid id);

        /// <summary>
        /// Get settings by App id.
        /// </summary>
        /// <param name="appId">App Id</param>
        /// <returns></returns>
        AppModel GetAppByAppId(string appId);    
 
        /// <summary>
        /// Search Apps according to search condition. 
        /// </summary>
        /// <param name="searchConditions">search condition, if null means get all apps.</param>
        /// <returns>WSApp list.</returns>
        List<WSApp> SearchApps(Dictionary<string, string> searchConditions);
    }
}
