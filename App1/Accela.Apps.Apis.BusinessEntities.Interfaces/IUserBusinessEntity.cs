using Accela.Apps.Apis.Models.DTOs.Requests.UserRequest;
using Accela.Apps.Apis.Models.DTOs.Responses.UserReponses;

namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    public interface IUserBusinessEntity : IBusinessEntity
    {
        UserProfileResponse GetUserProfile(UserProfileRequest request);
    }
}
