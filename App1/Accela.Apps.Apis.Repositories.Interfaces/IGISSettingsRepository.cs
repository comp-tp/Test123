using Accela.Apps.Apis.Models.DomainModels.GISModels;

namespace Accela.Apps.Apis.Repositories.Interfaces
{
    public interface IGISSettingsRepository : IRepository
    {
       GeocodeSettingsModel GetGeocodeServiceSettings(string agency);
    }
}
