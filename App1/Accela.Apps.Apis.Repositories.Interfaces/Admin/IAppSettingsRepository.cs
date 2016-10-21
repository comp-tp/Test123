using System.Collections.Generic;

using Accela.Apps.Apis.Models.DomainModels.Portals;

namespace Accela.Apps.Apis.Repositories.Interfaces.Admin
{
    public interface IAppSettingsRepository : IRepository
    {
        IList<AppSettings> GetAppSettings(string appId, string agency, string host);
    }
}
