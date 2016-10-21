using System;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Shared.Contants;

namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    /// <summary>
    /// App logic interface.
    /// </summary>
    public interface IAppBusinessEntity : IBusinessEntity
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
        /// Check if App is enable
        /// </summary>
        /// <param name="app">app model.</param>
        /// <returns>true/false</returns>
        bool IsAppEnable(AppModel app);

        /// <summary>
        /// validate whether the app is enabled by agency.
        /// Exception if app is not allowed by agency:
        /// ForbiddenException
        /// </summary>
        /// <param name="appGuid">app guid.</param>
        /// <param name="agencyName">agency name.</param>
        /// <param name="currentAPI">current api includes httpmethod and api, like 'get /v4/paments'</param>
        void ValidateAppPermissionByAgency(Guid appGuid, string agencyName, string currentAPI = null);
    }
}
