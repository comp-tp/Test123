using Accela.Apps.Apis.Models.DomainModels.ServerPropertyModels;

namespace Accela.Apps.Apis.Repositories.Interfaces
{
    public interface IServerPropertyRepository : IRepository
    {
        ServerPropertyV4Model GetServerProperties(string agencyName, string environment);
    }
}
