
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.Models.DTOs.Requests.UserRequest;
using Accela.Apps.Apis.Models.DTOs.Responses.UserReponses;
using System;

namespace Accela.Apps.Apis.Repositories.Interfaces.Admin
{
    public interface IUserRepository : IRepository
    {
        CloudUserModel GetCloudUser(Guid cloudUserId);

        UserProfileResponse GetUserProfile(UserProfileRequest request);
    }
}
