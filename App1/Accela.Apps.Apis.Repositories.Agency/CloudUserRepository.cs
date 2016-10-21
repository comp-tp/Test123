using System;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.Repositories.Interfaces;

namespace Accela.Apps.Apis.Repositories.Agency
{
    public class CloudUserRepository : RepositoryBase, ICloudUserRepository
    {
        public CloudUserRepository(string appId, string agencyName, string serviceProvCode, string agencyUserId, string agencyUsername, string token, string environmentName, string language)
            : base(appId, agencyName, serviceProvCode, agencyUserId, agencyUsername, token, environmentName, language)
        {
        }

        public CloudUserModel GetCloudUserByLoginName(string loginName)
        {
            // TODO:
            throw new NotImplementedException("Implement this later");
        }

        public CloudUserModel CreateCivicId(CloudUserModel cloudUser)
        {
            // TODO:
            throw new Exception("Implement this later");
        }
    }
}
