using Accela.Apps.Apis.Models.DomainModels.Portals;

namespace Accela.Apps.Apis.Repositories.Interfaces
{
    public interface ICloudUserRepository
    {
        CloudUserModel GetCloudUserByLoginName(string loginName);

        CloudUserModel CreateCivicId(CloudUserModel cloudUser);
    }
}
